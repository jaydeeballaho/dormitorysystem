Imports System.Text

Module Methods

    Public LetterOnly As String = " ñabcdefghijklmnopqrstuvwxyzÑABCDEFGHIJKLMNOPQRSTUVWXYZ-"
    Public LetterWSpecial As String = " ÑñabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ-,./"

    Public NumberOnly As String = "1234567890"
    Public NumberWCommaDot As String = "1234567890,."
    Public NumberWSlashDash As String = "1234567890/-"
    Public NumberWDotOnly As String = "1234567890."
    Public NumberWDashOnly As String = "1234567890-"

    Public CodeOnly As String = "1234567890ñabcdefghijklmnopqrstuvwxyzÑABCDEFGHIJKLMNOPQRSTUVWXYZ"

    Public AlphaChar As String = " ñabcdefghijklmnopqrstuvwxyzÑ1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ-,./_"

    Public CodeWSpec As String = "1234567890ñabcdefghijklmnopqrstuvwxyzÑABCDEFGHIJKLMNOPQRSTUVWXYZ-_"

    Public Function IsTextBoxEmpty(ParamArray obj() As TextBox)
        Dim bool As Boolean = False
        Dim i As Integer
        For i = 0 To obj.Length - 1
            If obj(i).Text.Length = 0 Then
                bool = True
                Exit For
            End If
        Next
        Return bool
    End Function
    Public Sub EnableTextBox(ParamArray obj() As TextBox)
        Dim i As Integer
        For i = 0 To obj.Length - 1
            obj(i).Enabled = True
        Next
    End Sub
    Public Sub DisableTextBox(ParamArray obj() As TextBox)
        Dim i As Integer
        For i = 0 To obj.Length - 1
            obj(i).Enabled = False
        Next
    End Sub
    Public Sub ContactNo(tb As TextBox)
        Try
            If tb.Text.Length >= 5 Then
                Dim s As String = tb.Text.Replace("-", "")
                For x As Integer = 4 To s.Length Step 4
                    s = s.Insert(x + ((x \ 4) - 1), "-")
                Next
                s = s.TrimEnd("-"c)
                tb.Text = s
                tb.SelectionStart = s.Length
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub NumberFormat(ByVal Text As TextBox)
        Try
            If Len(Text.Text) > 0 Then
                If Text.Text.Substring(0, 1) = "," Then
                    Text.Text = Text.Text.Remove(0, 1)
                    Exit Sub
                End If
                Text.Text = FormatNumber(CDbl(Text.Text), 0)
                Dim x As Integer = Text.SelectionStart.ToString
                If x = 0 Then
                    Text.SelectionStart = Len(Text.Text)
                    Text.SelectionLength = 0
                Else
                    Text.SelectionStart = x
                    Text.SelectionLength = 0
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub ToUpperOnly(s As String, ByVal tb As TextBox)
        Try
            If tb.TextLength = 1 Then
                Dim theText As String = tb.Text
                Dim Letter As String
                Dim SelectionIndex As Integer = tb.SelectionStart
                Dim Change As Integer = 0
                Letter = tb.Text.Substring(0, 1)
                If s.Contains(Letter) = False Then
                    theText = theText.Replace(Letter, String.Empty)
                    Change = 1
                End If
                theText = theText.ToUpper()
                tb.Text = theText
                tb.Select(SelectionIndex - Change, 0)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub ToUpperOnlyCBO(s As String, ByVal tb As ComboBox)
        Try
            If tb.Text.Count = 1 Then
                Dim theText As String = tb.Text
                Dim Letter As String
                Dim SelectionIndex As Integer = tb.SelectionStart
                Dim Change As Integer = 0
                Letter = tb.Text.Substring(0, 1)
                If s.Contains(Letter) = False Then
                    theText = theText.Replace(Letter, String.Empty)
                    Change = 1
                End If
                theText = theText.ToUpper()
                tb.Text = theText
                tb.Select(SelectionIndex - Change, 0)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub SentenceCase(ByVal Text As TextBox)
        Dim startPos As Integer
        Dim selectionLength As Integer
        ' store the cursor position and selection length prior to changing the text
        startPos = Text.SelectionStart
        selectionLength = Text.SelectionLength
        Text.Text = Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Text.Text)
        Text.SelectionStart = startPos
        Text.SelectionLength = selectionLength
    End Sub
    Public Sub AllowedOnlyCBO(s As String, cbo As ComboBox)
        Try
            Dim theText As String = cbo.Text
            Dim Letter As String
            Dim SelectionIndex As Integer = cbo.SelectionStart
            Dim Change As Integer
            For x As Integer = 0 To cbo.Text.Length - 1
                Letter = cbo.Text.Substring(x, 1)
                If s.Contains(Letter) = False Then
                    theText = theText.Replace(Letter, String.Empty)
                    Change = 1
                End If
            Next
            cbo.Text = theText
            cbo.Select(SelectionIndex - Change, 0)
        Catch ex As Exception
        End Try
    End Sub
    Public Sub AllowedOnly(s As String, tb As TextBox)
        Try
            Dim theText As String = tb.Text
            Dim Letter As String
            Dim SelectionIndex As Integer = tb.SelectionStart
            Dim Change As Integer = 0
            For x As Integer = 0 To tb.Text.Length - 1
                Letter = tb.Text.Substring(x, 1)
                If s.Contains(Letter) = False Then
                    theText = theText.Replace(Letter, String.Empty)
                    Change = 1
                End If
            Next
            tb.Text = theText
            tb.Select(SelectionIndex - Change, 0)
        Catch ex As Exception
        End Try
    End Sub

    Public Sub CheckforDoubleDot(tb As TextBox)
        Try
            Dim cntr As Integer = 0
            Dim theText As String = tb.Text
            Dim Letter As String
            Dim SelectionIndex As Integer = tb.SelectionStart
            Dim Change As Integer
            For x As Integer = 0 To tb.Text.Length - 1
                Letter = tb.Text.Substring(x, 1)
                If Letter = "." Then
                    cntr = cntr + 1
                End If
                If cntr > 1 Then
                    theText = ChangeSecondDot(tb.Text, x)
                    Change = 1
                End If
            Next
            tb.Text = theText
            tb.Select(SelectionIndex - Change, 0)
            If tb.Text.Length = 1 Then
                If cntr = 1 Then
                    tb.Text = "0."
                    tb.Select(2, 0)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Function ChangeSecondDot(s As String, idx As Integer) As String
        Dim sb As New StringBuilder(s)
        sb(idx) = ""
        Return sb.ToString()
    End Function
    Public Sub PhoneFormat(tb As TextBox)
        Try
            If tb.Text.Length >= 5 Then
                Dim s As String = tb.Text.Replace("-", "")
                For x As Integer = 4 To s.Length Step 4
                    s = s.Insert(x + ((x \ 4) - 1), "-")
                Next
                s = s.TrimEnd("-"c)
                tb.Text = s
                tb.SelectionStart = s.Length
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub EnableInput(root As Control)
        For Each ctrl As Control In root.Controls
            EnableInput(ctrl)
            If TypeOf ctrl Is TextBox Then
                CType(ctrl, TextBox).Enabled = True
            End If
            If TypeOf ctrl Is RadioButton Then
                CType(ctrl, RadioButton).Enabled = True
            End If
            If TypeOf ctrl Is ComboBox Then
                CType(ctrl, ComboBox).Enabled = True
            End If
            If TypeOf ctrl Is DateTimePicker Then
                CType(ctrl, DateTimePicker).Enabled = True
            End If
            If TypeOf ctrl Is Button Then
                CType(ctrl, Button).Enabled = True
            End If
        Next ctrl
    End Sub
    Public Sub DisableInput(root As Control)
        For Each ctrl As Control In root.Controls
            DisableInput(ctrl)
            If TypeOf ctrl Is TextBox Then
                CType(ctrl, TextBox).Enabled = False
            End If
            If TypeOf ctrl Is RadioButton Then
                CType(ctrl, RadioButton).Enabled = False
            End If
            If TypeOf ctrl Is DateTimePicker Then
                CType(ctrl, DateTimePicker).Enabled = False
            End If
            If TypeOf ctrl Is ComboBox Then
                CType(ctrl, ComboBox).Enabled = False
            End If
            If TypeOf ctrl Is Button Then
                CType(ctrl, Button).Enabled = False
            End If
        Next ctrl
    End Sub
    Public Sub ClearInput(root As Control)
        For Each ctrl As Control In root.Controls
            ClearInput(ctrl)
            If TypeOf ctrl Is TextBox Then
                CType(ctrl, TextBox).Text = String.Empty
            End If
        Next ctrl
    End Sub
End Module
