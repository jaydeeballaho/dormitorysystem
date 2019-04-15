Imports System.Windows.Forms

Public Class frmShowLogin

    Private account As New AccountController

    Private Sub frmaccount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        account.ViewLoginAccount(gvView, lblResult)
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        If cbAll.Checked = True Then
            For Each r As DataGridViewRow In gvView.Rows
                account.SetAccountDetails(r.Cells(0).Value)
                account.AccountStatus = 0
                account.EditAccount()
            Next
        End If
        account.ViewLoginAccount(gvView, lblResult)
    End Sub

    Private Sub gvView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gvView.CellContentClick
        If e.ColumnIndex = 5 Then
            account.AccountStatus = 0
            account.EditAccount()
            account.ViewLoginAccount(gvView, lblResult)
        End If
    End Sub

    Private Sub gvView_MouseDown(sender As Object, e As MouseEventArgs) Handles gvView.MouseDown
        Dim _ht As DataGridView.HitTestInfo = Me.gvView.HitTest(e.X, e.Y)
        If _ht.Type = DataGridViewHitTestType.Cell Then
            account.SetAccountDetails(Me.gvView.Rows(_ht.RowIndex).Cells(0).Value)
        End If
    End Sub

    Private Sub gvView_SelectionChanged(sender As Object, e As EventArgs) Handles gvView.SelectionChanged
        gvView.ClearSelection()
    End Sub


End Class
