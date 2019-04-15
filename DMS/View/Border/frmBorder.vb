Imports System.Windows.Forms

Public Class frmBorder

    Private rent As New RentController
    Private border As New BorderController
    Private guardian As New GuardianController

    Dim g As String = "All"

    Private Sub txtSearch_GotFocus(sender As Object, e As EventArgs) Handles txtSearch.GotFocus
        txtSearch.Text = ""
        txtSearch.ForeColor = Color.Black
    End Sub

    Private Sub txtSearch_LostFocus(sender As Object, e As EventArgs) Handles txtSearch.LostFocus
        txtSearch.ForeColor = Color.DarkGray
        txtSearch.Text = "Search Border"
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        AllowedOnly(AlphaChar, txtSearch)
        ToUpperOnly(CodeOnly, txtSearch)
        If txtSearch.Text.ToLower() <> "search border" Then
            border.Searchborder(txtSearch.Text, gvView, lblResult)
        End If
    End Sub

    Private Sub frmborder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboGender.SelectedIndex = 2
        border.ViewBorder(gvView, lblResult, cboGender.Text)
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Dim obj As New frmAddBorder
        obj.rent = Me.rent
        obj.border = Me.border
        obj.guardian = Me.guardian
        If obj.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim addrent As New frmAddRent
            addrent.rent = Me.rent
            addrent.border = Me.border
            addrent.guardian = Me.guardian
            With border
                addrent.txtFirstname.Text = .BorderFN
                addrent.txtLastName.Text = .BorderLN
                addrent.txtContact.Text = .BorderCN
                If .BorderSex = "Male" Then
                    addrent.rbMale.Checked = True
                Else
                    addrent.rbFemale.Checked = True
                End If
            End With
            addrent.btnNew.Text = "Edit Border"
            If addrent.ShowDialog() = Windows.Forms.DialogResult.OK Then
                border.ViewBorder(gvView, lblResult, cboGender.Text)
            End If
        End If
    End Sub

    Private Sub gvView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gvView.CellContentClick
        If e.ColumnIndex = 6 Then
            Dim obj As New frmEditBorder
            obj.border = Me.border
            obj.guardian = Me.guardian
            If obj.ShowDialog() = Windows.Forms.DialogResult.OK Then
                border.ViewBorder(gvView, lblResult, cboGender.SelectedText)
            End If
        End If
    End Sub

    Private Sub gvView_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles gvView.CellFormatting
        For Each r As DataGridViewRow In gvView.Rows
            If r.Cells(3).Value = "Male" Then
                r.Cells(3).Style.ForeColor = Color.Blue
            ElseIf r.Cells(3).Value = "Female" Then
                r.Cells(3).Style.ForeColor = Color.DeepPink
            End If
            If r.Cells(5).Value = "With Rent" Then
                r.Cells(5).Style.ForeColor = Color.DarkGray
            Else
                r.Cells(5).Style.ForeColor = Color.SeaGreen
            End If
        Next
    End Sub

    Private Sub gvView_MouseDown(sender As Object, e As MouseEventArgs) Handles gvView.MouseDown
        Dim _ht As DataGridView.HitTestInfo = Me.gvView.HitTest(e.X, e.Y)
        If _ht.Type = DataGridViewHitTestType.Cell Then
            border.SetBorderDetails(Me.gvView.Rows(_ht.RowIndex).Cells(0).Value)
            guardian.SetGuardianDetails(Me.gvView.Rows(_ht.RowIndex).Cells(0).Value)
        End If
    End Sub

    Private Sub gvView_SelectionChanged(sender As Object, e As EventArgs) Handles gvView.SelectionChanged
        gvView.ClearSelection()
    End Sub

    Private Sub btnViewGuardian_Click(sender As Object, e As EventArgs) Handles btnViewGuardian.Click
        Dim obj As New frmViewGuardian
        obj.ShowDialog()
    End Sub

    Private Sub linkPrint_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkPrint.LinkClicked
        print()
    End Sub

    Sub print()
        Try
            Dim frm As New frmPrint
            Dim rpt As New crptBorder
            Dim dt As New DataTable

            With dt.Columns
                .Add("No")
                .Add("Name")
                .Add("Sex")
                .Add("ContactNo")
            End With

            For Each r As DataGridViewRow In gvView.Rows
                dt.Rows.Add(r.Cells(1).Value, r.Cells(2).Value, r.Cells(3).Value, r.Cells(4).Value)
            Next


            rpt.SetDataSource(dt)
            rpt.SetParameterValue("gender", cboGender.Text)
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

    Private Sub cboStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboGender.SelectedIndexChanged
        g = cboGender.Text
        border.ViewBorder(gvView, lblResult, cboGender.Text)
    End Sub
End Class
