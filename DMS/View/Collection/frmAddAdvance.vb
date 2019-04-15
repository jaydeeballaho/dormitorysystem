Imports System.Windows.Forms

Public Class frmAddAdvance

    Public rent As RentController
    Dim bill As New BillingController
    Public lastBill As Date
   
    Private Sub bntCancel_Click(sender As Object, e As EventArgs) Handles bntCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If nudMonth.Value = 0 Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        Else
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub frmAddAdvance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpDateIn.Value = rent.DateIn
        lastBill = dtpDateIn.Value
        dtpDateOut.Value = rent.DateOut
        'Load Last Bill
        txtDate.Text = bill.GetLastBill(rent.RentID)
        lastBill = bill.GetLastBill(rent.RentID, dtpDateIn.Value)
        nudMonth.Maximum = DateDiff(DateInterval.Month, dtpDateIn.Value, dtpDateOut.Value)
        If txtDate.Text <> "No Billings Yet" Then
            nudMonth.Maximum = DateDiff(DateInterval.Month, lastBill, dtpDateOut.Value)
        End If
    End Sub
End Class
