Imports System.Windows.Forms

Public Class frmSearchRent

    Public rent As RentController
    Public def As Decimal = 0

    Private Sub txtSearch_GotFocus(sender As Object, e As EventArgs) Handles txtSearch.GotFocus
        txtSearch.Text = ""
        txtSearch.ForeColor = Color.Black
    End Sub

    Private Sub txtSearch_LostFocus(sender As Object, e As EventArgs) Handles txtSearch.LostFocus
        txtSearch.ForeColor = Color.DarkGray
        txtSearch.Text = "Search Rental"
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        AllowedOnly(AlphaChar, txtSearch)
        ToUpperOnly(CodeOnly, txtSearch)
        If txtSearch.Text.ToLower() <> "search rental" Then
            rent.SearchRental(txtSearch.Text, gvView, lblResult)
        End If
    End Sub

    Private Sub gvView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gvView.CellContentClick
        If e.ColumnIndex = 8 Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub gvView_MouseDown(sender As Object, e As MouseEventArgs) Handles gvView.MouseDown
        Dim _ht As DataGridView.HitTestInfo = Me.gvView.HitTest(e.X, e.Y)
        If _ht.Type = DataGridViewHitTestType.Cell Then
            rent.SetRentDetails(Me.gvView.Rows(_ht.RowIndex).Cells(0).Value)
            rent.Rate = Me.gvView.Rows(_ht.RowIndex).Cells(9).Value
            def = Me.gvView.Rows(_ht.RowIndex).Cells(10).Value
        End If
    End Sub

    Private Sub gvView_SelectionChanged(sender As Object, e As EventArgs) Handles gvView.SelectionChanged
        gvView.ClearSelection()
    End Sub

    Private Sub frmSearchRent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rent.SearchRental("", gvView, lblResult)
    End Sub

    Private Sub gvView_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles gvView.CellFormatting
        For Each r As DataGridViewRow In gvView.Rows
            If r.Cells(7).Value = "On-going" Then
                r.Cells(7).Style.ForeColor = Color.SeaGreen
            ElseIf r.Cells(7).Value = "Out Today" Then
                r.Cells(7).Style.ForeColor = Color.DarkOrange
            ElseIf r.Cells(7).Value = "Over Due" Then
                r.Cells(7).Style.ForeColor = Color.Crimson
            ElseIf r.Cells(7).Value = "Pending" Then
                r.Cells(7).Style.ForeColor = Color.SteelBlue
            Else
                r.Cells(7).Style.ForeColor = Color.DarkGray
            End If
        Next
    End Sub
End Class
