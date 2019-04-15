Imports System.Windows.Forms

Public Class frmSearchRoom

    Public rent As RentController
    Public room As RoomController
    Public gender As String = "Male"

    Private Sub txtSearch_GotFocus(sender As Object, e As EventArgs) Handles txtSearch.GotFocus
        txtSearch.Text = ""
        txtSearch.ForeColor = Color.Black
    End Sub

    Private Sub txtSearch_LostFocus(sender As Object, e As EventArgs) Handles txtSearch.LostFocus
        txtSearch.ForeColor = Color.DarkGray
        txtSearch.Text = "Search Room"
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        AllowedOnly(AlphaChar, txtSearch)
        ToUpperOnly(CodeOnly, txtSearch)
        If txtSearch.Text.ToLower() <> "search room" Then
            room.FilterRoom(txtSearch.Text, gvView, lblResult)
        End If
    End Sub

    Private Sub frmRoom_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        room.ViewFilterRoom(gvView, lblResult, gender)
    End Sub

    Private Sub gvView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gvView.CellContentClick
        If e.ColumnIndex = 9 Then
            rent.Rate = room.PerBed
            rent.Whole = 1
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        ElseIf e.ColumnIndex = 10 Then
            rent.Rate = room.PerRoom
            rent.Whole = room.RoomOccupants
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub gvView_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles gvView.CellFormatting
        For Each r As DataGridViewRow In gvView.Rows
            If r.Cells(3).Value = "Male" Then
                r.Cells(3).Style.ForeColor = Color.Blue
            ElseIf r.Cells(3).Value = "Female" Then
                r.Cells(3).Style.ForeColor = Color.DeepPink
            Else
                r.Cells(3).Style.ForeColor = Color.Crimson
            End If
            If r.Cells(8).Value = "Vacant" Then
                r.Cells(8).Style.ForeColor = Color.SeaGreen
            ElseIf r.Cells(8).Value = "Not Available" Then
                r.Cells(8).Style.ForeColor = Color.DarkGray
            ElseIf r.Cells(8).Value = "Full" Then
                r.Cells(8).Style.ForeColor = Color.Crimson
            Else
                r.Cells(8).Style.ForeColor = Color.DarkOrange
            End If
        Next
    End Sub

    Private Sub gvView_MouseDown(sender As Object, e As MouseEventArgs) Handles gvView.MouseDown
        Dim _ht As DataGridView.HitTestInfo = Me.gvView.HitTest(e.X, e.Y)
        If _ht.Type = DataGridViewHitTestType.Cell Then
            room.SetRoomDetails(Me.gvView.Rows(_ht.RowIndex).Cells(0).Value)
        End If
    End Sub

    Private Sub gvView_SelectionChanged(sender As Object, e As EventArgs) Handles gvView.SelectionChanged
        gvView.ClearSelection()
    End Sub

End Class
