Imports System.Windows.Forms

Public Class frmViewGuardian

    Private border As New BorderController
    Private guardian As New GuardianController

    Private Sub txtSearch_GotFocus(sender As Object, e As EventArgs) Handles txtSearch.GotFocus
        txtSearch.Text = ""
        txtSearch.ForeColor = Color.Black
    End Sub

    Private Sub txtSearch_LostFocus(sender As Object, e As EventArgs) Handles txtSearch.LostFocus
        txtSearch.ForeColor = Color.DarkGray
        txtSearch.Text = "Search Guardian"
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        AllowedOnly(AlphaChar, txtSearch)
        ToUpperOnly(CodeOnly, txtSearch)
        If txtSearch.Text.ToLower() <> "search guardian" Then
            guardian.SearchGuardian(gvView, lblResult, txtSearch.Text)
        End If
    End Sub

    Private Sub frmborder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        guardian.ViewGuardian(gvView, lblResult)
    End Sub

    Private Sub gvView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gvView.CellContentClick
        If e.ColumnIndex = 6 Then
            Dim obj As New frmEditBorder
            obj.border = Me.border
            obj.guardian = Me.guardian
            obj.PanelBorder.Enabled = False
            If obj.ShowDialog() = Windows.Forms.DialogResult.OK Then
                guardian.ViewGuardian(gvView, lblResult)
            End If
        End If
    End Sub

    Private Sub gvView_MouseDown(sender As Object, e As MouseEventArgs) Handles gvView.MouseDown
        Dim _ht As DataGridView.HitTestInfo = Me.gvView.HitTest(e.X, e.Y)
        If _ht.Type = DataGridViewHitTestType.Cell Then
            border.SetBorderDetails(Me.gvView.Rows(_ht.RowIndex).Cells(0).Value)
            guardian.SetGuardianDetails(Me.gvView.Rows(_ht.RowIndex).Cells(0).Value)
        End If
    End Sub

    Private Sub gvView_SelectionChanged(sender As Object, e As EventArgs) Handles gvView.SelectionChanged
        gvView.ClearSelection()
    End Sub
End Class
