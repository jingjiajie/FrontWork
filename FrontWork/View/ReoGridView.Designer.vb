﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReoGridView
    Inherits UserControl

    'UserControl 重写释放以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ReoGridControl = New unvell.ReoGrid.ReoGridControl()
        Me.SuspendLayout()
        '
        'ReoGridControl
        '
        Me.ReoGridControl.BackColor = System.Drawing.Color.White
        Me.ReoGridControl.ColumnHeaderContextMenuStrip = Nothing
        Me.ReoGridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReoGridControl.LeadHeaderContextMenuStrip = Nothing
        Me.ReoGridControl.Location = New System.Drawing.Point(0, 0)
        Me.ReoGridControl.Name = "ReoGridControl"
        Me.ReoGridControl.RowHeaderContextMenuStrip = Nothing
        Me.ReoGridControl.Script = Nothing
        Me.ReoGridControl.SheetTabContextMenuStrip = Nothing
        Me.ReoGridControl.SheetTabNewButtonVisible = True
        Me.ReoGridControl.SheetTabVisible = True
        Me.ReoGridControl.SheetTabWidth = 60
        Me.ReoGridControl.ShowScrollEndSpacing = True
        Me.ReoGridControl.Size = New System.Drawing.Size(911, 523)
        Me.ReoGridControl.TabIndex = 0
        Me.ReoGridControl.Text = "ReoGridControl1"
        '
        'ReoGridView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ReoGridControl)
        Me.Name = "ReoGridView"
        Me.Size = New System.Drawing.Size(911, 523)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReoGridControl As unvell.ReoGrid.ReoGridControl
End Class
