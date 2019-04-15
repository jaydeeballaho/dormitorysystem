Imports System.Windows.Forms

Public Class frmPrint
    'Try
    'Dim frm As New frmPrintReport
    'Dim rpt As New prtDTR
    'Dim dt As New DataTable

    '        With dt.Columns
    '            .Add("day")
    '            .Add("amin")
    '            .Add("amout")
    '            .Add("pmin")
    '            .Add("pmout")
    '            .Add("remarks")
    '        End With

    '        For Each r As DataGridViewRow In gvTeacher.Rows
    '            dt.Rows.Add(r.Cells(0).Value, r.Cells(1).Value, r.Cells(2).Value, r.Cells(3).Value, r.Cells(4).Value, r.Cells(5).Value)
    '        Next


    '        rpt.SetDataSource(dt)

    '        rpt.SetParameterValue("Name", txtName.Text)
    '        rpt.SetParameterValue("Name2", txtName.Text)


    '        rpt.SetParameterValue("Month", cboMonth.Text + ", " + cboYear.Text)
    '        rpt.SetParameterValue("Month2", cboMonth.Text + ", " + cboYear.Text)

    'Dim sched As New ScheduleSettings
    '        sched.SetSchedSettingDetails()
    '        dtpMStart.MinDate = Date.Parse("06:00 AM")
    '        dtpMStart.MaxDate = Date.Parse("12:00 PM")
    '        dtpMEnd.MinDate = Date.Parse("06:00 AM")
    '        dtpMEnd.MaxDate = Date.Parse("12:00 PM")

    '        dtpAStart.MinDate = Date.Parse("12:30 PM")
    '        dtpAStart.MaxDate = Date.Parse("05:00 PM")
    '        dtpAEnd.MinDate = Date.Parse("12:30 PM")
    '        dtpAEnd.MaxDate = Date.Parse("05:00 PM")

    '        dtpMStart.Value = Date.Parse(sched.MorningST)
    '        dtpMEnd.Value = Date.Parse(sched.MorningET)
    '        dtpAStart.Value = Date.Parse(sched.NoonST)
    '        dtpAEnd.Value = Date.Parse(sched.NoonET)


    '        rpt.SetParameterValue("AM", dtpMStart.Value.ToString("hh:mm tt") + "-" + dtpMEnd.Value.ToString("hh:mm tt"))
    '        rpt.SetParameterValue("PM", dtpAStart.Value.ToString("hh:mm tt") + "-" + dtpAEnd.Value.ToString("hh:mm tt"))
    '        rpt.SetParameterValue("AM2", dtpMStart.Value.ToString("hh:mm tt") + "-" + dtpMEnd.Value.ToString("hh:mm tt"))
    '        rpt.SetParameterValue("PM2", dtpAStart.Value.ToString("hh:mm tt") + "-" + dtpAEnd.Value.ToString("hh:mm tt"))

    ''
    'Dim schl As New SchoolSettings
    '        schl.SetSchoolSettingDetails()
    '        rpt.SetParameterValue("PrincipalName", schl.Name)
    '        rpt.SetParameterValue("PrincipalName2", schl.Name)

    '        rpt.SetParameterValue("dateprinted", frmHome.dtServer.ToShortDateString)

    '        With frm
    '            .crv.ReportSource = rpt
    '            .crv.Refresh()
    '            .ShowDialog()
    '        End With
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try

    'Baliwasan, Along PSA rd, Zamboanga City.

    Private Sub frmPrint_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
