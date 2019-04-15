Imports System.Windows.Forms

Public Class frmEditAccount

    Public account As AccountController
    Dim role As String = "Clerk"

    Private Sub txtFirstname_TextChanged(sender As Object, e As EventArgs) Handles txtFirstname.TextChanged
        AllowedOnly(LetterOnly, txtFirstname)
        ToUpperOnly(CodeOnly, txtFirstname)
    End Sub

    Private Sub txtLastname_TextChanged(sender As Object, e As EventArgs) Handles txtLastname.TextChanged
        AllowedOnly(LetterOnly, txtLastname)
        ToUpperOnly(CodeOnly, txtLastname)
    End Sub

    Private Sub txtUsername_TextChanged(sender As Object, e As EventArgs) Handles txtUsername.TextChanged
        AllowedOnly(CodeOnly, txtUsername)
    End Sub

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged
        AllowedOnly(CodeOnly, txtPassword)
    End Sub

    Private Sub frmAddAccount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With account
            txtFirstname.Text = .AccountFirstName
            txtLastname.Text = .AccountLastName
            If .AccountRole = "Administrator" Then
                cboRole.Enabled = False
            Else
                cboRole.SelectedIndex = cboRole.FindString(.AccountRole)
            End If
            txtUsername.Text = .AccountUserName
            txtPassword.Text = .AccountPassword
        End With
    End Sub

    Private Sub cboRole_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboRole.SelectedIndexChanged
        Me.role = cboRole.Text
    End Sub

    Private Sub bntCancel_Click(sender As Object, e As EventArgs) Handles bntCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If IsTextBoxEmpty(txtFirstname, txtLastname) = True Then
            MessageBox.Show("First Name, Last Name, username and password are required.", "Message", _
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            With account
                .AccountFirstName = txtFirstname.Text
                .AccountLastName = txtLastname.Text
                .AccountRole = role
                
                If .EditAccount() = True Then
                    MessageBox.Show("Account successfully updated.", "Message", _
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()
                Else
                    MessageBox.Show("Account failed to update.", "Message", _
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End With
        End If
    End Sub

    Private Sub cbShow_CheckedChanged(sender As Object, e As EventArgs) Handles cbShow.CheckedChanged
        If cbShow.Checked = True Then
            txtPassword.UseSystemPasswordChar = False
        Else
            txtPassword.UseSystemPasswordChar = True
        End If
    End Sub
End Class
