Imports System.Windows.Forms

Public Class frmUpdateBorderInRent

    Public border As BorderController
    Private guardian As New GuardianController

    Dim sex As String = "Male"

    Private Sub txtFirstname_TextChanged(sender As Object, e As EventArgs) Handles txtFirstname.TextChanged
        AllowedOnly(LetterOnly, txtFirstname)
        ToUpperOnly(CodeOnly, txtFirstname)
    End Sub

    Private Sub txtLastName_TextChanged(sender As Object, e As EventArgs) Handles txtLastName.TextChanged
        AllowedOnly(LetterOnly, txtLastName)
        ToUpperOnly(CodeOnly, txtLastName)
    End Sub

    Private Sub rbMale_CheckedChanged(sender As Object, e As EventArgs) Handles rbMale.CheckedChanged
        If rbMale.Checked = True Then
            sex = "Male"
        End If
    End Sub

    Private Sub rbFemale_CheckedChanged(sender As Object, e As EventArgs) Handles rbFemale.CheckedChanged
        If rbFemale.Checked = True Then
            sex = "Female"
        End If
    End Sub

    Private Sub txtContact_TextChanged(sender As Object, e As EventArgs) Handles txtContact.TextChanged
        AllowedOnly(NumberWDashOnly, txtContact)
        PhoneFormat(txtContact)
    End Sub

    Private Sub txtGuardianFN_TextChanged(sender As Object, e As EventArgs) Handles txtGuardianFN.TextChanged
        AllowedOnly(LetterOnly, txtGuardianFN)
        ToUpperOnly(CodeOnly, txtGuardianFN)
    End Sub

    Private Sub txtGuardianLN_TextChanged(sender As Object, e As EventArgs) Handles txtGuardianLN.TextChanged
        AllowedOnly(LetterOnly, txtGuardianLN)
        ToUpperOnly(CodeOnly, txtGuardianLN)
    End Sub

    Private Sub txtGuardianCN_TextChanged(sender As Object, e As EventArgs) Handles txtGuardianCN.TextChanged
        AllowedOnly(NumberWDashOnly, txtGuardianCN)
        PhoneFormat(txtGuardianCN)
    End Sub

    Private Sub txtGuardianAddress_TextChanged(sender As Object, e As EventArgs) Handles txtGuardianAddress.TextChanged
        AllowedOnly(AlphaChar, txtGuardianAddress)
        ToUpperOnly(CodeOnly, txtGuardianAddress)
    End Sub

    Private Sub bntCancel_Click(sender As Object, e As EventArgs) Handles bntCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If IsTextBoxEmpty(txtFirstname, txtLastName, txtContact) Then
            MessageBox.Show("Border first name, last name and contact information are required.", "Message",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            With border
                .BorderFN = txtFirstname.Text
                .BorderLN = txtLastName.Text
                .BorderSex = sex
                .BorderCN = txtContact.Text
                .EditBorder()
            End With
            With guardian
                .BorderID = border.BorderID
                .GuardianFN = txtGuardianFN.Text
                .GuardianLN = txtGuardianLN.Text
                .GuardianCN = txtGuardianCN.Text
                .GuardianAddress = txtGuardianAddress.Text
                .EditGuardian()
            End With
            MessageBox.Show("Border successfully saved.", "Message",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub frmAddBorder_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        guardian.SetGuardianDetails(border.BorderID)

        With border
            txtFirstname.Text = .BorderFN
            txtLastName.Text = .BorderLN
            txtContact.Text = .BorderCN
            If .BorderSex = "Male" Then
                rbMale.Checked = True
            Else
                rbFemale.Checked = True
            End If
        End With
        With guardian
            txtGuardianFN.Text = .GuardianFN
            txtGuardianLN.Text = .GuardianLN
            txtGuardianCN.Text = .GuardianCN
            txtGuardianAddress.Text = .GuardianAddress
        End With
    End Sub

End Class
