﻿Imports System.ComponentModel
Imports System.Drawing.Design
Imports System.Globalization
Imports System.Linq
Imports System.Reflection
Imports Jint.Native

''' <summary>
''' 配置中心，集中存储一组组件的配置信息
''' </summary>
Public Class Configuration
    Inherits UserControl

    ''' <summary>
    ''' 配置改变事件
    ''' </summary>
    Public Event ConfigurationChanged As EventHandler(Of ConfigurationChangedEventArgs)

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label

    Private _configurationString As String
    Private _methodListeners As ModeMethodListenerNamesPair() = {}
    Private jsEngine As New Jint.Engine

    Public Sub New()
        jsEngine.SetValue("log", New Action(Of Object)(AddressOf Console.WriteLine))
    End Sub

    ''' <summary>
    ''' 配置模式
    ''' </summary>
    ''' <returns></returns>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property ModeConfigurations As New List(Of ModeConfiguration) From {New ModeConfiguration() With {.Mode = "default"}}

    ''' <summary>
    ''' 配置字符串，Json格式。读取后自动分析转换为Configuration对象
    ''' </summary>
    ''' <returns></returns>
    <Description("配置字符串"), Category("FrontWork")>
    <Editor(GetType(ConfigurationEditor), GetType(UITypeEditor))>
    Public Property ConfigurationString As String
        Get
            Return Me._configurationString
        End Get
        Set(value As String)
            Me._configurationString = value
            Me.Configurate(Me._configurationString)
            If Me.MethodListeners.Length > 0 Then
                For Each modeMethodListeners In Me._methodListeners
                    Call Me.SetMethodListener(modeMethodListeners.MethodListenerNames, modeMethodListeners.Mode)
                Next
            End If
            RaiseEvent ConfigurationChanged(Me, New ConfigurationChangedEventArgs)
        End Set
    End Property

    <Description("方法监听器"), Category("FrontWork")>
    <Editor(GetType(Design.ArrayEditor), GetType(UITypeEditor))>
    Public Property MethodListeners As ModeMethodListenerNamesPair()
        Get
            Return Me._methodListeners
        End Get
        Set(value As ModeMethodListenerNamesPair())
            Me._methodListeners = value
            If Me.modeConfigurations.Count > 0 Then
                For Each modeMethodListeners In Me._methodListeners
                    Call Me.SetMethodListener(modeMethodListeners.MethodListenerNames, modeMethodListeners.Mode)
                Next
            End If
        End Set
    End Property

    ''' <summary>
    ''' 当前的配置信息是否包含某种模式
    ''' </summary>
    ''' <param name="mode">模式名称</param>
    ''' <returns>是否包含模式</returns>
    Public Function ContainsMode(mode As String) As Boolean
        Dim foundConfiguration = (From m In Me.modeConfigurations Where m.Mode = mode Select m).FirstOrDefault
        If foundConfiguration IsNot Nothing Then
            Return True
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' 设置方法监听器，用来执行配置信息中所指定的字段对应的的本地函数名
    ''' </summary>
    ''' <param name="methodListenerNames">方法监听器类名</param>
    ''' <param name="mode">设置到的模式</param>
    Public Sub SetMethodListener(methodListenerNames As String(), mode As String)
        If Me.DesignMode Then Return '设计器设计的时候就不用绑方法监听器了
        Dim foundModeConfiguration = (From m In Me.modeConfigurations Where m.Mode.Equals(mode, StringComparison.OrdinalIgnoreCase) Select m).FirstOrDefault
        If foundModeConfiguration Is Nothing Then
            Throw New Exception($"mode ""{mode}"" not found!")
            Return
        End If

        foundModeConfiguration.MethodListenerNames = methodListenerNames
    End Sub

    ''' <summary>
    ''' 获取当前模式的字段配置
    ''' </summary>
    ''' <returns>字段的配置信息</returns>
    Public Function GetFieldConfigurations(mode As String) As FieldConfiguration()
        Dim foundModeConfiguration = (From m In modeConfigurations Where m.Mode = mode Select m).FirstOrDefault
        If foundModeConfiguration Is Nothing Then
            Throw New Exception($"Mode ""{mode}"" not found!")
        Else
            Return foundModeConfiguration.Fields
        End If
    End Function

    ''' <summary>
    ''' 获取当前模式的HTTPAPIs的配置信息
    ''' </summary>
    ''' <returns>HTTPAPIs配置信息</returns>
    Public Function GetHTTPAPIConfigurations(mode As String) As HTTPAPIConfiguration()
        Dim foundModeConfiguration = (From m In modeConfigurations Where m.Mode = mode Select m).FirstOrDefault
        If foundModeConfiguration Is Nothing Then
            Return {}
        Else
            Return foundModeConfiguration.HTTPAPIs
        End If
    End Function

    ''' <summary>
    ''' 配置，输入json字符串进行分析并配置为json所描述的配置
    ''' </summary>
    ''' <param name="jsonStr">json配置字符串</param>
    Public Sub Configurate(jsonStr As String)
        Dim jsValue As JsValue = Nothing
        Try
            jsValue = jsEngine.Execute("$_FWJsonResult = " + jsonStr).GetValue("$_FWJsonResult")
        Catch ex As Exception
            Throw New Exception("ConfigurationString error: " + ex.Message)
        End Try
        Dim newModeConfigurations = ModeConfiguration.FromJsValue(Me.MethodListeners, jsValue)
        If newModeConfigurations Is Nothing Then Return
        Me.modeConfigurations.Clear()
        Me.modeConfigurations.AddRange(newModeConfigurations)
    End Sub

    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Configuration))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.PictureBox1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(180, 180)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(180, 140)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.5!)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(0, 140)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(180, 40)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Config"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Configuration
        '
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.DoubleBuffered = True
        Me.Name = "Configuration"
        Me.Size = New System.Drawing.Size(180, 180)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private Sub Configuration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Me.DesignMode Then Me.Visible = False
        Call InitializeComponent()
    End Sub
End Class

<TypeConverter(GetType(ModeMethodListenerNamesPair.ModeMethodListenerPairTypeConverter))>
Public Class ModeMethodListenerNamesPair

    <Description("方法监听器")>
    Public Property MethodListenerNames As String() = {}

    <Description("要应用该方法监听器的模式")>
    Public Property Mode As String

    Friend Class ModeMethodListenerPairTypeConverter
        Inherits TypeConverter

        Public Overrides Function ConvertTo(context As ITypeDescriptorContext, culture As CultureInfo, value As Object, destinationType As Type) As Object
            Dim pair = CType(value, ModeMethodListenerNamesPair)
            If destinationType = GetType(String) Then
                Return $"{pair.Mode} => {pair.MethodListenerNames.ToString}"
            End If
            Return MyBase.ConvertTo(context, culture, value, destinationType)
        End Function
    End Class
End Class