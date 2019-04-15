Public Class frmAddRoom

    Private room As New RoomController
    Dim cat As String = "Mix"

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
        ElseIf room.IsRoomExist(txtName.Text) Then
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
                If .AddRoom() = True Then
                    MessageBox.Show("New Room successfully saved.", "Message", _
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()
                Else
                    MessageBox.Show("New Room failed to save.", "Message", _
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End With
        End If
    End Sub

    Private Sub frmAddRoom_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboCategory.SelectedIndex = 0
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

    Private Sub nudroom_ValueChanged(sender As Object, e As EventArgs) Handles nudroom.ValueChanged

    End Sub
End Class