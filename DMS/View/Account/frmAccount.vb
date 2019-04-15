Imports System.Windows.Forms

Public Class frmAccount

    Private account As New accountController

    Private Sub txtSearch_GotFocus(sender As Object, e As EventArgs) Handles txtSearch.GotFocus
        txtSearch.Text = ""
        txtSearch.ForeColor = Color.Black
    End Sub

    Private Sub txtSearch_LostFocus(sender As Object, e As EventArgs) Handles txtSearch.LostFocus
        txtSearch.ForeColor = Color.DarkGray
        txtSearch.Text = "Search Account"
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        AllowedOnly(AlphaChar, txtSearch)
        ToUpperOnly(CodeOnly, txtSearch)
        If txtSearch.Text.ToLower() <> "search account" Then
            account.SearchAccount(txtSearch.Text, gvView, lblResult)
        End If
    End Sub

    Private Sub frmaccount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        account.ViewAccount(gvView, lblResult)
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Dim obj As New frmAddaccount
        If obj.ShowDialog() = Windows.Forms.DialogResult.OK Then
            account.ViewAccount(gvView, lblResult)
        End If
    End Sub

    Private Sub gvView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gvView.CellContentClick
        If e.ColumnIndex = 5 Then
            Dim obj As New frmEditAccount
            obj.account = Me.account
            If obj.ShowDialog() = Windows.Forms.DialogResult.OK Then
                account.ViewAccount(gvView, lblResult)
            End If
        ElseIf e.ColumnIndex = 6 Then
            If account.AccountRole = "Administrator" Then
                MessageBox.Show("Sorry you cannot delete this Administrator Account.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                If MessageBox.Show("Are you sure want to delete " + account.AccountFirstName + " " + account.AccountLastName + _
                              " account?.", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) _
               = Windows.Forms.DialogResult.Yes Then
                    account.DeleteAccount()
                    account.ViewAccount(gvView, lblResult)
                End If
            End If
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
