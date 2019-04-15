Imports System.Windows.Forms

Public Class frmAddOns

    Public setting As SettingsController
    Public addons As AddOnsController
    Dim type As String = "Free"
    Public edit As Boolean = False

    Private Sub rbFree_CheckedChanged(sender As Object, e As EventArgs) Handles rbFree.CheckedChanged
        If rbFree.Checked = True Then
            type = "Free"
            nudCharge.Enabled = False
            nudCharge.Value = 0
        End If
    End Sub

    Private Sub rbWithCharge_CheckedChanged(sender As Object, e As EventArgs) Handles rbWithCharge.CheckedChanged
        If rbWithCharge.Checked = True Then
            type = "With Charge"
            nudCharge.Enabled = True
            nudCharge.Value = setting.Charge
        End If
    End Sub

    Private Sub bntCancel_Click(sender As Object, e As EventArgs) Handles bntCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If cboName.Text = "" Then
            MessageBox.Show("Appliance Name is required.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            With addons
                .Name = cboName.Text
                .Qty = nudQty.Value
                .Type = type
                .Charge = nudCharge.Value
            End With
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub frmAddOns_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        addons.LoanAddOnstoCBO(cboName)
        If edit Then
            With addons
                cboName.Text = .Name
                nudQty.Value = .Qty
                If .Type = "Free" Then
                    rbFree.Checked = True
                Else
                    rbWithCharge.Checked = True
                End If
                nudCharge.Value = .Charge
            End With
        End If
    End Sub

    Private Sub cboName_TextChanged(sender As Object, e As EventArgs) Handles cboName.TextChanged
        AllowedOnlyCBO(AlphaChar, cboName)
        ToUpperOnlyCBO(CodeOnly, cboName)
    End Sub
End Class
