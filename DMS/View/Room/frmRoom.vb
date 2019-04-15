Public Class frmRoom

    Private room As New RoomController

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
            room.SearchRoom(txtSearch.Text, gvView, lblResult)
            RoomForDeletion()
        End If
    End Sub

    Private Sub frmRoom_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        room.ViewRoom(gvView, lblResult)
        RoomForDeletion()
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Dim obj As New frmAddRoom
        If obj.ShowDialog() = Windows.Forms.DialogResult.OK Then
            room.ViewRoom(gvView, lblResult)
            RoomForDeletion()
        End If
    End Sub

    Private Sub gvView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gvView.CellContentClick
        If e.ColumnIndex = 9 Then
            Dim obj As New frmEditRoom
            obj.room = Me.room
            If obj.ShowDialog() = Windows.Forms.DialogResult.OK Then
                room.ViewRoom(gvView, lblResult)
                RoomForDeletion()
            End If
        ElseIf e.ColumnIndex = 10 Then
            If MessageBox.Show("Are you sure you want to delete room " & room.RoomCode & " ?", "", MessageBoxButtons.YesNo, _
                               MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If room.DeleteRoom() = True Then
                    room.ViewRoom(gvView, lblResult)
                    RoomForDeletion()
                End If
            End If
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
            If r.Cells(8).Value = "Available" Then
                r.Cells(8).Style.ForeColor = Color.SeaGreen
            Else
                r.Cells(8).Style.ForeColor = Color.DarkGray
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

    Sub RoomForDeletion()
        If frmMain.userType = "Administrator" Then
            For Each r As DataGridViewRow In gvView.Rows
                r.Cells(10).Value = room.IsRoomForDelete(r.Cells(0).Value)
            Next
        End If
    End Sub
End Class