Imports System.Windows.Forms

Public Class frmViewOccupantsInRoom

    Private rent As New RentController
    Private border As New BorderController
    Private guardian As New GuardianController
    Dim link As String
    Dim status = "All"
    Dim filter = "datein"
    Dim temp = ""

    Public rm As String = ""


    Private Sub frmborder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rent.ViewOccupantsInRoom(rm, gvView, lblResult)
    End Sub

    Private Sub gvView_SelectionChanged(sender As Object, e As EventArgs) Handles gvView.SelectionChanged
        gvView.ClearSelection()
    End Sub

    Private Sub gvView_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles gvView.CellFormatting
        For Each r As DataGridViewRow In gvView.Rows
            If r.Cells(9).Value = "On-going" Then
                r.Cells(9).Style.ForeColor = Color.SeaGreen
            ElseIf r.Cells(9).Value = "Out Today" Then
                r.Cells(9).Style.ForeColor = Color.DarkOrange
            ElseIf r.Cells(9).Value = "Over Due" Then
                r.Cells(9).Style.ForeColor = Color.Crimson
            ElseIf r.Cells(9).Value = "Pending" Then
                r.Cells(9).Style.ForeColor = Color.SteelBlue
            Else
                r.Cells(9).Style.ForeColor = Color.DarkGray
            End If
        Next
    End Sub
End Class
