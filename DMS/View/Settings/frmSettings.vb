Imports System.Windows.Forms

Public Class frmSettings

    Private settings As New SettingsController
    Dim type As String = "Amount"

    Private Sub rbPercent_CheckedChanged(sender As Object, e As EventArgs) Handles rbPercent.CheckedChanged
        If rbPercent.Checked = True Then
            nudAmount.Enabled = False
            nudPercent.Enabled = True
            type = "Percent"
        End If
    End Sub

    Private Sub rbAmount_CheckedChanged(sender As Object, e As EventArgs) Handles rbAmount.CheckedChanged
        If rbAmount.Checked = True Then
            nudPercent.Enabled = False
            nudAmount.Enabled = True
            type = "Amount"
        End If
    End Sub

    Private Sub frmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With settings
            .SetsettingsDetails(100)
            nudAdvance.Value = .Advance
            nudDeposit.Value = .Deposit
            nudAddons.Value = .Charge
            If .Pentype = "Amount" Then
                rbAmount.Checked = True
            Else
                rbPercent.Checked = True
            End If
            nudPercent.Value = .PenByPercent
            nudAmount.Value = .PenByAmount
            nudBilling.Value = .NotifBilling
        End With
    End Sub

    Private Sub bntCancel_Click(sender As Object, e As EventArgs) Handles bntCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        With settings
            If .HasSettings(100) Then
                .DeleteSettings()
            End If
            .SettingsID = 100
            .Advance = nudAdvance.Value
            .Deposit = nudDeposit.Value
            .Charge = nudAddons.Value
            .Pentype = type
            .PenByPercent = nudPercent.Value
            .PenByAmount = nudAmount.Value
            .NotifBilling = nudBilling.Value
            If .Addsettings() Then
                MessageBox.Show("New Settings successfully saved.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("New Settings failed to update.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End With
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
End Class
