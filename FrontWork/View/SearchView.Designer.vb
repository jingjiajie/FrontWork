﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SearchView

    'UserControl 重写释放以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelSearchCondition = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboBoxSearchKey = New System.Windows.Forms.ComboBox()
        Me.ComboBoxSearchRelation = New System.Windows.Forms.ComboBox()
        Me.ComboBoxOrderKey = New System.Windows.Forms.ComboBox()
        Me.ComboBoxOrder = New System.Windows.Forms.ComboBox()
        Me.TextBoxSearchCondition = New System.Windows.Forms.TextBox()
        Me.ButtonSearch = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 10
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.LabelSearchCondition, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 5, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ComboBoxSearchKey, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ComboBoxSearchRelation, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ComboBoxOrderKey, 6, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ComboBoxOrder, 7, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBoxSearchCondition, 4, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonSearch, 8, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1280, 84)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'LabelSearchCondition
        '
        Me.LabelSearchCondition.AutoSize = True
        Me.LabelSearchCondition.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelSearchCondition.Font = New System.Drawing.Font("黑体", 10.0!)
        Me.LabelSearchCondition.Location = New System.Drawing.Point(60, 24)
        Me.LabelSearchCondition.Margin = New System.Windows.Forms.Padding(5, 5, 5, 0)
        Me.LabelSearchCondition.Name = "LabelSearchCondition"
        Me.LabelSearchCondition.Size = New System.Drawing.Size(140, 40)
        Me.LabelSearchCondition.TabIndex = 0
        Me.LabelSearchCondition.Text = "查询条件"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("黑体", 10.0!)
        Me.Label2.Location = New System.Drawing.Point(660, 24)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 5, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(140, 40)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "排序条件"
        '
        'ComboBoxSearchKey
        '
        Me.ComboBoxSearchKey.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxSearchKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxSearchKey.Font = New System.Drawing.Font("黑体", 10.0!)
        Me.ComboBoxSearchKey.FormattingEnabled = True
        Me.ComboBoxSearchKey.Location = New System.Drawing.Point(210, 19)
        Me.ComboBoxSearchKey.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.ComboBoxSearchKey.Name = "ComboBoxSearchKey"
        Me.ComboBoxSearchKey.Size = New System.Drawing.Size(140, 35)
        Me.ComboBoxSearchKey.TabIndex = 2
        '
        'ComboBoxSearchRelation
        '
        Me.ComboBoxSearchRelation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxSearchRelation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxSearchRelation.Font = New System.Drawing.Font("黑体", 10.0!)
        Me.ComboBoxSearchRelation.FormattingEnabled = True
        Me.ComboBoxSearchRelation.Items.AddRange(New Object() {"等于", "大于等于", "小于等于"})
        Me.ComboBoxSearchRelation.Location = New System.Drawing.Point(360, 19)
        Me.ComboBoxSearchRelation.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.ComboBoxSearchRelation.Name = "ComboBoxSearchRelation"
        Me.ComboBoxSearchRelation.Size = New System.Drawing.Size(140, 35)
        Me.ComboBoxSearchRelation.TabIndex = 3
        '
        'ComboBoxOrderKey
        '
        Me.ComboBoxOrderKey.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxOrderKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxOrderKey.Font = New System.Drawing.Font("黑体", 10.0!)
        Me.ComboBoxOrderKey.FormattingEnabled = True
        Me.ComboBoxOrderKey.Items.AddRange(New Object() {"无"})
        Me.ComboBoxOrderKey.Location = New System.Drawing.Point(810, 19)
        Me.ComboBoxOrderKey.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.ComboBoxOrderKey.Name = "ComboBoxOrderKey"
        Me.ComboBoxOrderKey.Size = New System.Drawing.Size(140, 35)
        Me.ComboBoxOrderKey.TabIndex = 4
        '
        'ComboBoxOrder
        '
        Me.ComboBoxOrder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxOrder.Font = New System.Drawing.Font("黑体", 10.0!)
        Me.ComboBoxOrder.FormattingEnabled = True
        Me.ComboBoxOrder.Items.AddRange(New Object() {"正序", "倒序"})
        Me.ComboBoxOrder.Location = New System.Drawing.Point(960, 19)
        Me.ComboBoxOrder.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.ComboBoxOrder.Name = "ComboBoxOrder"
        Me.ComboBoxOrder.Size = New System.Drawing.Size(140, 35)
        Me.ComboBoxOrder.TabIndex = 5
        '
        'TextBoxSearchCondition
        '
        Me.TextBoxSearchCondition.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxSearchCondition.Font = New System.Drawing.Font("黑体", 9.0!)
        Me.TextBoxSearchCondition.Location = New System.Drawing.Point(510, 19)
        Me.TextBoxSearchCondition.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.TextBoxSearchCondition.Name = "TextBoxSearchCondition"
        Me.TextBoxSearchCondition.Size = New System.Drawing.Size(140, 35)
        Me.TextBoxSearchCondition.TabIndex = 6
        '
        'ButtonSearch
        '
        Me.ButtonSearch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonSearch.Font = New System.Drawing.Font("黑体", 10.0!)
        Me.ButtonSearch.Location = New System.Drawing.Point(1110, 14)
        Me.ButtonSearch.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.ButtonSearch.Name = "ButtonSearch"
        Me.TableLayoutPanel1.SetRowSpan(Me.ButtonSearch, 3)
        Me.ButtonSearch.Size = New System.Drawing.Size(110, 55)
        Me.ButtonSearch.TabIndex = 7
        Me.ButtonSearch.Text = "查询"
        Me.ButtonSearch.UseVisualStyleBackColor = True
        '
        'SearchView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "SearchView"
        Me.Size = New System.Drawing.Size(1280, 84)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents LabelSearchCondition As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ComboBoxSearchKey As ComboBox
    Friend WithEvents ComboBoxSearchRelation As ComboBox
    Friend WithEvents ComboBoxOrderKey As ComboBox
    Friend WithEvents ComboBoxOrder As ComboBox
    Friend WithEvents TextBoxSearchCondition As TextBox
    Friend WithEvents ButtonSearch As Button
End Class
