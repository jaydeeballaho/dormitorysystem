Imports System.Windows.Forms

Public Class frmEditRoom

    Public room As RoomController
    Dim status As String = "Available"
    Dim cat As String = "Mix"

    Private Sub frmEditRoom_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With room
            txtName.Text = .RoomCode
            cboCategory.SelectedIndex = cboCategory.FindString(.RoomCategory)
            nudOccupants.Value = .RoomOccupants
            nudbed.Value = .PerBed
            nudroom.Value = .PerRoom
            txtDescription.Text = .RoomDescription
            If .RoomStatus = "Available" Then
                cbNotAvailable.Checked = False
            Else
                cbNotAvailable.Checked = True
            End If
        End With
    End Sub

    Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged
        AllowedOnly(CodeWSpec, txtName)
        ToUpperOnly(CodeOnly, txtName)
    End Sub

    Private Sub txtDescription_TextChanged(sender As Object, e As EventArgs) Handles txtDescription.TextChanged
        AllowedOnly(AlphaChar, txtDescription)
        ToUpperOnly(CodeOnly, txtDescription)
    End Sub

    Private Sub bntCancel_Click(sender As Object, e As EventArgs) Handles bntCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If IsTextBoxEmpty(txtName) = True Then
            MessageBox.Show("Room Name/Code/No is required.", "Message", _
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf room.IsRoomExist(txtName.Text) And txtName.Text.ToLower() <> room.RoomCode.ToLower() Then
            MessageBox.Show("Room Name/Code/No already exist.", "Message", _
                           MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            With room
                .RoomCode = txtName.Text
                .RoomCategory = cat
                .RoomOccupants = nudOccupants.Value
                .PerBed = nudbed.Value
                .PerRoom = nudroom.Value
                .RoomDescription = txtDescription.Text
                .RoomStatus = status
                If .EditRoom() = True Then
                    MessageBox.Show("Room successfully updated.", "Message", _
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()
                Else
                    MessageBox.Show("Room failed to update.", "Message", _
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End With
        End If
    End Sub

    Private Sub cbNotAvailable_CheckedChanged(sender As Object, e As EventArgs) Handles cbNotAvailable.CheckedChanged
        If cbNotAvailable.Checked = True Then
            status = "Not Available"
        Else
            status = "Available"
        End If
    End Sub

    Private Sub cboCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCategory.SelectedIndexChanged
        cat = cboCategory.Text
    End Sub

    Private Sub nudOccupants_ValueChanged_1(sender As Object, e As EventArgs) Handles nudOccupants.ValueChanged
        nudroom.Value = nudbed.Value * nudOccupants.Value
    End Sub

    Private Sub nudbed_ValueChanged_1(sender As Object, e As EventArgs) Handles nudbed.ValueChanged
        nudroom.Value = nudbed.Value * nudOccupants.Value
    End Sub
End Class
