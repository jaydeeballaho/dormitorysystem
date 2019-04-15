Imports System.Windows.Forms

Public Class frmRent

    Private rent As New RentController
    Private border As New BorderController
    Private guardian As New GuardianController
    Dim link As String
    Dim status = "On"
    Dim filter = "datein"
    Dim temp = ""

    Private Sub txtSearch_GotFocus(sender As Object, e As EventArgs) Handles txtSearch.GotFocus
        txtSearch.Text = ""
        txtSearch.ForeColor = Color.Black
    End Sub

    Private Sub txtSearch_LostFocus(sender As Object, e As EventArgs) Handles txtSearch.LostFocus
        txtSearch.ForeColor = Color.DarkGray
        txtSearch.Text = "Search Rental"
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        AllowedOnly(AlphaChar, txtSearch)
        ToUpperOnly(CodeOnly, txtSearch)
        If txtSearch.Text.ToLower() <> "search rental" Then
            rent.FilterRental(txtSearch.Text, gvView, lblResult, status, dtpStart.Value, dtpEnd.Value, filter)
        End If
    End Sub

    Private Sub frmborder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboStatus.SelectedIndex = 4
        cboDate.SelectedIndex = 0
        rent.ViewFilterRental(gvView, lblResult, status, dtpStart.Value, dtpEnd.Value, filter)
        'dtpStart.Value = Date.Parse("01/01/" & frmMain.dtServer.Year.ToString)
        'dtpEnd.Value = Date.Parse("12/31/" & frmMain.dtServer.Year.ToString)
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Dim obj As New frmAddRent
        obj.border = Me.border
        obj.rent = Me.rent
        obj.guardian = Me.guardian
        If obj.ShowDialog() = Windows.Forms.DialogResult.OK Then
            status = cboStatus.Text
            rent.ViewFilterRental(gvView, lblResult, status, dtpStart.Value, dtpEnd.Value, filter)
        End If
    End Sub

    Private Sub gvView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gvView.CellContentClick
        If e.ColumnIndex = 10 Then
            If link = "Edit" Then
                Dim obj As New frmEditRent
                obj.border = Me.border
                obj.rent = Me.rent
                obj.temp = temp
                If obj.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    rent.ViewFilterRental(gvView, lblResult, status, dtpStart.Value, dtpEnd.Value, filter)
                End If
            Else

            End If
        End If
    End Sub

    Private Sub gvView_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles gvView.CellFormatting
        For Each r As DataGridViewRow In gvView.Rows
            If r.Cells(9).Value = "On-going" Then
                r.Cells(9).Style.ForeColor = Color.SeaGreen
            ElseIf r.Cells(9).Value = "Out Today" Then
                r.Cells(9).Style.ForeColor = Color.DarkOrange
            ElseIf r.Cells(9).Value = "Over Due" Then
                r.Cells(9).Style.ForeColor = Color.Crimson
            ElseIf r.Cells(9).Value = "Pending" Then
                r.Cells(9).Style.ForeColor = Color.SteelBlue
            Else
                r.Cells(9).Style.ForeColor = Color.DarkGray
            End If
        Next
    End Sub

    Private Sub gvView_MouseDown(sender As Object, e As MouseEventArgs) Handles gvView.MouseDown
        Dim _ht As DataGridView.HitTestInfo = Me.gvView.HitTest(e.X, e.Y)
        If _ht.Type = DataGridViewHitTestType.Cell Then
            border.SetBorderDetails(Me.gvView.Rows(_ht.RowIndex).Cells(0).Value)
            rent.SetRentDetails(Me.gvView.Rows(_ht.RowIndex).Cells(1).Value)
            link = Me.gvView.Rows(_ht.RowIndex).Cells(10).Value
            temp = Me.gvView.Rows(_ht.RowIndex).Cells(9).Value
        End If
    End Sub

    Private Sub gvView_SelectionChanged(sender As Object, e As EventArgs) Handles gvView.SelectionChanged
        gvView.ClearSelection()
    End Sub

    Private Sub cboStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStatus.SelectedIndexChanged
        status = cboStatus.Text
        rent.ViewFilterRental(gvView, lblResult, status, dtpStart.Value, dtpEnd.Value, filter)
    End Sub

    Private Sub cboDate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDate.SelectedIndexChanged
        If cboDate.Text = "Date-In" Then
            filter = "datein"
        Else
            filter = "dateout"
        End If
        dtpStart.Value = rent.GetStartDate(filter)
        dtpEnd.Value = rent.GetEndDate(filter)
        rent.ViewFilterRental(gvView, lblResult, status, dtpStart.Value, dtpEnd.Value, filter)
    End Sub

    Private Sub dtpStart_ValueChanged(sender As Object, e As EventArgs) Handles dtpStart.ValueChanged
        rent.ViewFilterRental(gvView, lblResult, status, dtpStart.Value, dtpEnd.Value, filter)
    End Sub

    Private Sub dtpEnd_ValueChanged(sender As Object, e As EventArgs) Handles dtpEnd.ValueChanged
        rent.ViewFilterRental(gvView, lblResult, status, dtpStart.Value, dtpEnd.Value, filter)
    End Sub

    Private Sub linkPrint_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkPrint.LinkClicked
        print()
    End Sub

    Sub print()
        Try
            Dim frm As New frmPrint
            Dim rpt As New crptRent
            Dim dt As New DataTable

            With dt.Columns
                .Add("No")
                .Add("Name")
                .Add("Room")
                .Add("Space")
                .Add("Monthly")
                .Add("DateIn")
                .Add("DateOut")
                .Add("Status")
            End With

            For Each r As DataGridViewRow In gvView.Rows
                dt.Rows.Add(r.Cells(2).Value, r.Cells(3).Value, r.Cells(4).Value, r.Cells(5).Value, _
                            r.Cells(6).Value, r.Cells(7).Value, r.Cells(8).Value, r.Cells(9).Value)
            Next


            rpt.SetDataSource(dt)
            rpt.SetParameterValue("status", cboStatus.Text)
            rpt.SetParameterValue("date", dtpStart.Value.ToString("yyyy-MM-dd"))
            rpt.SetParameterValue("date2", dtpEnd.Value.ToString("yyyy-MM-dd"))
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
