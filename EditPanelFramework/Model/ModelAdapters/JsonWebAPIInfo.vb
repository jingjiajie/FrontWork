﻿Imports Jint.Native
Imports System.Text
Imports System.Text.RegularExpressions

Public Class JsonWebAPIInfo
    Public Property URLTemplate As String
    Public Property HTTPMethod As HTTPMethod
    Public Property RequestBodyTemplate As String
    Public Property ResponseBodyTemplate As String

    Private jsEngine As New Jint.Engine

    Public Sub New()
        jsEngine.SetValue("log", New Action(Of String)(AddressOf Console.WriteLine))
        jsEngine.Execute(<string>
                             function mapProperty(objs,propName){
                                var result = []
                                for(var i=0;i&lt;objs.length;i++){
        log('mapProperty: '+JSON.stringify(objs[i]))
                                    result.push(objs[i][propName])
                                }
                                return result
                             }
                         </string>)
    End Sub

    Public Sub SetRequestParameter(paramName As String, value As Object)
        Me.jsEngine.SetValue(paramName, value)
    End Sub

    Public Sub SetJsonRequestParameter(paramName As String, jsonString As String)
        Try
            Me.jsEngine.Execute($"{paramName} = JSON.parse('{jsonString}');")
        Catch
            Throw New Exception($"Invalid jsonString: ""{jsonString}""")
        End Try
    End Sub

    Public Function GetURL() As String
        Logger.SetMode(LogMode.MODEL_ADAPTER)
        Dim resultURL As New StringBuilder(Me.URLTemplate)
        Dim curMatch = Regex.Match(Me.URLTemplate, "{([^}]*)}")
        Do While curMatch.Success '遍历匹配到的各个"{表达式}"
            Dim expr As String = curMatch.Groups(1).Value
            Dim value As String
            If String.IsNullOrWhiteSpace(expr) Then
                value = "{}"
            Else
                Try
                    value = Me.jsEngine.Execute($"JSON.stringify({expr})").GetCompletionValue.ToString
                Catch
                    Logger.PutMessage($"Invalid expression: ""{expr}""")
                    Return Nothing
                End Try
            End If
            resultURL = resultURL.Remove(curMatch.Index, curMatch.Length)
            resultURL.Insert(curMatch.Index, value)
            curMatch = curMatch.NextMatch
        Loop
        Return resultURL.ToString
    End Function

    Public Function GetRequestBody() As String
        If String.IsNullOrWhiteSpace(Me.RequestBodyTemplate) Then Return String.Empty
        Return Me.jsEngine.Execute($"JSON.stringify({RequestBodyTemplate})").GetCompletionValue.ToString
    End Function

    Public Function GetParamValuesFromResponse(responseBody As String, paramNames As String()) As Object()
        Logger.SetMode(LogMode.MODEL_ADAPTER)
        Dim paramPaths = Me.GetResponseBodyTemplateParamPaths(responseBody, paramNames)
        Dim result(paramNames.Length - 1) As Object

        For i = 0 To paramNames.Length - 1
            Dim paramName = paramNames(i)
            '如果此参数没有找到路径，报错并Continue
            If Not paramPaths.ContainsKey(paramName) Then
                Logger.PutMessage($"Parameter ""{paramName}"" not found in ResponseBodyTemplate!")
                Continue For
            End If

            Dim responseJsValue = Me.jsEngine.Execute("$_EPFResponse=" & responseBody).GetValue("$_EPFResponse")
            Dim paramPath = paramPaths(paramName)
            Dim curJsValue As JsValue = responseJsValue
            '根据参数的路径去寻找参数
            For Each prop In paramPath
                curJsValue = curJsValue.AsObject.GetOwnProperty(prop).Value
            Next
            result(i) = curJsValue.ToObject
        Next
        Return result
    End Function

    Private Function GetResponseBodyTemplateParamPaths(responseBody As String, paramNames As String()) As Dictionary(Of String, String())
        Dim result As New Dictionary(Of String, String())
        Dim jsEngine = New Jint.Engine
        jsEngine.Execute("objsToFind = {};")

        For Each paramName In paramNames
            jsEngine.Execute($"{paramName} = new Object();")
            jsEngine.Execute($"objsToFind['{paramName}'] = {paramName};")
        Next
        jsEngine.SetValue("log", New Action(Of String)(AddressOf Console.WriteLine))
        Dim strFindData = '从给定jsonTemplate中寻找$data变量
            <string>
                var objPaths = {}

                //填充objPaths，将从curObj中找到的对象的路径填充到objPaths里
                function fillObjPath(curObj){
                  if(!fillObjPath.stackInited){
                    fillObjPath.stack = []
                    fillObjPath.stackInited = true
                  }
                  var foundName = findKeyInObject(curObj,objsToFind)
                  if(foundName){
                    objPaths[foundName] = copyArray(fillObjPath.stack)
                    return
                  }
                  if(typeof(curObj) == 'object'){
                      for(var key in curObj){
                        fillObjPath.stack.push(key)
                        fillObjPath(curObj[key])
                        fillObjPath.stack.pop()
                      }
                  }
                }

                //在对象中根据值搜索key，找到返回key，找不到返回null
                function findKeyInObject(value,obj){
                  for(var key in obj){
                    if(obj[key] == value){
                      return key
                    }
                  }
                  return null
                }

                //数组拷贝
                function copyArray(arr) {
                    let res = []
                    for (let i = 0; i &lt; arr.length; i++) {
                     res.push(arr[i])
                    }
                    return res
                }
            </string>.Value
        jsEngine.Execute(strFindData)
        Try
            jsEngine.Execute(String.Format("var $_EPFTargetObject = {0}", Me._ResponseBodyTemplate))
        Catch
            Throw New Exception("Invalid ResponseBodyTemplate")
        End Try
        jsEngine.Execute("fillObjPath($_EPFTargetObject)")
        For Each paramName In paramNames
            Dim dataPath = jsEngine.Execute($"objPaths['{paramName}']").GetCompletionValue
            If dataPath.IsUndefined OrElse dataPath.IsNull Then
                Logger.PutMessage($"{paramName} not found!")
                Continue For
            End If
            '把Object()转为String()
            Dim dataPathArray = Util.ToArray(Of String)(dataPath.ToObject)
            result.Add(paramName, dataPathArray)
        Next
        Return result
    End Function
End Class