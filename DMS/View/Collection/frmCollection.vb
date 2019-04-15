Imports System.Windows.Forms

Public Class frmCollection

    Private rent As New RentController
    Private border As New BorderController
    Private pay As New CollectionController
    Dim filter = "paymentdate"

    Private Sub txtSearch_GotFocus(sender As Object, e As EventArgs) Handles txtSearch.GotFocus
        txtSearch.Text = ""
        txtSearch.ForeColor = Color.Black
    End Sub

    Private Sub txtSearch_LostFocus(sender As Object, e As EventArgs) Handles txtSearch.LostFocus
        txtSearch.ForeColor = Color.DarkGray
        txtSearch.Text = "Search Payment"
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        AllowedOnly(AlphaChar, txtSearch)
        ToUpperOnly(CodeOnly, txtSearch)
        If txtSearch.Text.ToLower() <> "search payment" Then
            pay.FilterCollection(txtSearch.Text, gvView, lblResult, dtpStart.Value, dtpEnd.Value, filter)
        End If
    End Sub

    Private Sub frmborder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpStart.Value = pay.GetStartDate(filter)
        dtpEnd.Value = pay.GetEndDate(filter)
        pay.ViewCollection(gvView, lblResult, dtpStart.Value, dtpEnd.Value, filter)
    End Sub

    Private Sub gvView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gvView.CellContentClick
        If e.ColumnIndex = 6 Then
            'Edit
            Dim obj As New frmEditPayment
            obj.rent = Me.rent
            obj.pay = Me.pay
            obj.border = Me.border
            If obj.ShowDialog() = Windows.Forms.DialogResult.OK Then
                pay.ViewCollection(gvView, lblResult, dtpStart.Value, dtpEnd.Value, filter)
            End If
        End If
    End Sub

    Private Sub gvView_MouseDown(sender As Object, e As MouseEventArgs) Handles gvView.MouseDown
        Dim _ht As DataGridView.HitTestInfo = Me.gvView.HitTest(e.X, e.Y)
        If _ht.Type = DataGridViewHitTestType.Cell Then
            pay.SetCollectionDetails(Me.gvView.Rows(_ht.RowIndex).Cells(0).Value)
            rent.SetRentDetails(pay.RentID)
            border.SetBorderDetails(rent.BorderID)
        End If
    End Sub

    Private Sub gvView_SelectionChanged(sender As Object, e As EventArgs) Handles gvView.SelectionChanged
        gvView.ClearSelection()
    End Sub

    Private Sub dtpStart_ValueChanged(sender As Object, e As EventArgs) Handles dtpStart.ValueChanged
        pay.ViewCollection(gvView, lblResult, dtpStart.Value, dtpEnd.Value, filter)
    End Sub

    Private Sub dtpEnd_ValueChanged(sender As Object, e As EventArgs) Handles dtpEnd.ValueChanged
        pay.ViewCollection(gvView, lblResult, dtpStart.Value, dtpEnd.Value, filter)
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Dim obj As New frmAddPayment
        If obj.ShowDialog() = Windows.Forms.DialogResult.OK Then

        End If
        pay.ViewCollection(gvView, lblResult, dtpStart.Value, dtpEnd.Value, filter)
    End Sub

    Private Sub linkPrint_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkPrint.LinkClicked
        print()
    End Sub

    Sub print()
        Try
            Dim frm As New frmPrint
            Dim rpt As New crptCollection
            Dim dt As New DataTable

            With dt.Columns
                .Add("No")
                .Add("Account")
                .Add("Collector")
                .Add("PaymentDate")
                .Add("AmountPaid")
            End With

            For Each r As DataGridViewRow In gvView.Rows
                dt.Rows.Add(r.Cells(1).Value, r.Cells(2).Value, r.Cells(3).Value, r.Cells(4).Value, r.Cells(5).Value)
            Next


            rpt.SetDataSource(dt)

            rpt.SetParameterValue("datefrom", dtpStart.Value.ToString("yyyy-MM-dd"))
            rpt.SetParameterValue("dateto", dtpEnd.Value.ToString("yyyy-MM-dd"))
            rpt.SetParameterValue("printedby", frmMain.fullname)
            rpt.SetParameterValue("dateprinted", frmMain.dtServer.Date.ToString("yyyy-MM-dd"))
            With frm
                .crv.ReportSource = rpt
                .crv.Refresh()
                .ShowDialog()
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
