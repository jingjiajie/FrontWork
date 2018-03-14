﻿Public Class Range
    Private _row As Long
    Private _column As Long
    Private _rows As Long
    Private _columns As Long

    Public Property Row As Long
        Get
            Return Me._row
        End Get
        Set(value As Long)
            Me._row = value
            RaiseEvent RangeChanged(New RangeChangedEventArgs(Me))
        End Set
    End Property

    Public Property Column As Long
        Get
            Return Me._column
        End Get
        Set(value As Long)
            Me._column = value
            RaiseEvent RangeChanged(New RangeChangedEventArgs(Me))
        End Set
    End Property

    Public Property Rows As Long
        Get
            Return Me._rows
        End Get
        Set(value As Long)
            Me._rows = value
            RaiseEvent RangeChanged(New RangeChangedEventArgs(Me))
        End Set
    End Property
    Public Property Columns As Long
        Get
            Return Me._columns
        End Get
        Set(value As Long)
            Me._columns = value
            RaiseEvent RangeChanged(New RangeChangedEventArgs(Me))
        End Set
    End Property

    Public Sub New(row As Long, column As Long, rows As Long, columns As Long)
        Me._row = row
        Me._column = column
        Me._rows = rows
        Me._columns = columns
    End Sub

    Public Event RangeChanged(e As RangeChangedEventArgs)
End Class
