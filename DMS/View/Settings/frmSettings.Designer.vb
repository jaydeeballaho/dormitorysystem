<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettings
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSettings))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.nudBilling = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.nudPercent = New System.Windows.Forms.NumericUpDown()
        Me.nudAmount = New System.Windows.Forms.NumericUpDown()
        Me.rbAmount = New System.Windows.Forms.RadioButton()
        Me.rbPercent = New System.Windows.Forms.RadioButton()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.nudAddons = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.nudDeposit = New System.Windows.Forms.NumericUpDown()
        Me.nudAdvance = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.bntCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.nudBilling, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudPercent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudAddons, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudDeposit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudAdvance, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(308, 449)
        Me.Panel1.TabIndex = 8
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Location = New System.Drawing.Point(8, 7)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(293, 40)
        Me.Panel3.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(71, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(151, 21)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "UPDATE SETTINGS"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Controls.Add(Me.nudBilling)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.Label5)
        Me.Panel4.Controls.Add(Me.nudPercent)
        Me.Panel4.Controls.Add(Me.nudAmount)
        Me.Panel4.Controls.Add(Me.rbAmount)
        Me.Panel4.Controls.Add(Me.rbPercent)
        Me.Panel4.Controls.Add(Me.Label8)
        Me.Panel4.Controls.Add(Me.nudAddons)
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.Label7)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.nudDeposit)
        Me.Panel4.Controls.Add(Me.nudAdvance)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.bntCancel)
        Me.Panel4.Controls.Add(Me.btnSave)
        Me.Panel4.Controls.Add(Me.Label23)
        Me.Panel4.Location = New System.Drawing.Point(8, 51)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(293, 391)
        Me.Panel4.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(147, 290)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(105, 17)
        Me.Label9.TabIndex = 291
        Me.Label9.Text = "days after billing"
        '
        'nudBilling
        '
        Me.nudBilling.Location = New System.Drawing.Point(21, 288)
        Me.nudBilling.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudBilling.Name = "nudBilling"
        Me.nudBilling.Size = New System.Drawing.Size(120, 25)
        Me.nudBilling.TabIndex = 8
        Me.nudBilling.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(18, 268)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(131, 17)
        Me.Label4.TabIndex = 289
        Me.Label4.Text = "Set Billing / Due Date"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(18, 249)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 17)
        Me.Label5.TabIndex = 288
        Me.Label5.Text = "Billings"
        '
        'nudPercent
        '
        Me.nudPercent.DecimalPlaces = 2
        Me.nudPercent.Enabled = False
        Me.nudPercent.Location = New System.Drawing.Point(151, 183)
        Me.nudPercent.Name = "nudPercent"
        Me.nudPercent.Size = New System.Drawing.Size(120, 25)
        Me.nudPercent.TabIndex = 5
        '
        'nudAmount
        '
        Me.nudAmount.DecimalPlaces = 2
        Me.nudAmount.Increment = New Decimal(New Integer() {100, 0, 0, 0})
        Me.nudAmount.Location = New System.Drawing.Point(151, 214)
        Me.nudAmount.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.nudAmount.Name = "nudAmount"
        Me.nudAmount.Size = New System.Drawing.Size(120, 25)
        Me.nudAmount.TabIndex = 7
        Me.nudAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudAmount.ThousandsSeparator = True
        Me.nudAmount.Value = New Decimal(New Integer() {200, 0, 0, 0})
        '
        'rbAmount
        '
        Me.rbAmount.AutoSize = True
        Me.rbAmount.Checked = True
        Me.rbAmount.Location = New System.Drawing.Point(20, 214)
        Me.rbAmount.Name = "rbAmount"
        Me.rbAmount.Size = New System.Drawing.Size(119, 21)
        Me.rbAmount.TabIndex = 6
        Me.rbAmount.TabStop = True
        Me.rbAmount.Text = "In Amount (Php)"
        Me.rbAmount.UseVisualStyleBackColor = True
        '
        'rbPercent
        '
        Me.rbPercent.AutoSize = True
        Me.rbPercent.Location = New System.Drawing.Point(20, 183)
        Me.rbPercent.Name = "rbPercent"
        Me.rbPercent.Size = New System.Drawing.Size(119, 21)
        Me.rbPercent.TabIndex = 4
        Me.rbPercent.Text = "In Percentile (%)"
        Me.rbPercent.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(147, 128)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(133, 17)
        Me.Label8.TabIndex = 281
        Me.Label8.Text = "/ Appliance or Device"
        '
        'nudAddons
        '
        Me.nudAddons.DecimalPlaces = 2
        Me.nudAddons.Increment = New Decimal(New Integer() {100, 0, 0, 0})
        Me.nudAddons.Location = New System.Drawing.Point(21, 126)
        Me.nudAddons.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.nudAddons.Name = "nudAddons"
        Me.nudAddons.Size = New System.Drawing.Size(120, 25)
        Me.nudAddons.TabIndex = 3
        Me.nudAddons.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudAddons.ThousandsSeparator = True
        Me.nudAddons.Value = New Decimal(New Integer() {500, 0, 0, 0})
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(18, 106)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(109, 17)
        Me.Label6.TabIndex = 279
        Me.Label6.Text = "Add-Ons Charge"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(147, 73)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(109, 17)
        Me.Label7.TabIndex = 278
        Me.Label7.Text = "Month(s) Deposit"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(147, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 17)
        Me.Label3.TabIndex = 277
        Me.Label3.Text = "Month(s) Advance"
        '
        'nudDeposit
        '
        Me.nudDeposit.Location = New System.Drawing.Point(21, 71)
        Me.nudDeposit.Name = "nudDeposit"
        Me.nudDeposit.Size = New System.Drawing.Size(120, 25)
        Me.nudDeposit.TabIndex = 2
        '
        'nudAdvance
        '
        Me.nudAdvance.Location = New System.Drawing.Point(21, 40)
        Me.nudAdvance.Name = "nudAdvance"
        Me.nudAdvance.Size = New System.Drawing.Size(120, 25)
        Me.nudAdvance.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(18, 161)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 17)
        Me.Label2.TabIndex = 260
        Me.Label2.Text = "Penalties"
        '
        'bntCancel
        '
        Me.bntCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bntCancel.BackColor = System.Drawing.Color.White
        Me.bntCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.bntCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bntCancel.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bntCancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.bntCancel.Location = New System.Drawing.Point(149, 331)
        Me.bntCancel.Name = "bntCancel"
        Me.bntCancel.Size = New System.Drawing.Size(122, 40)
        Me.bntCancel.TabIndex = 10
        Me.bntCancel.Text = "Cancel"
        Me.bntCancel.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(21, 331)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(122, 40)
        Me.btnSave.TabIndex = 9
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label23.Location = New System.Drawing.Point(18, 18)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(92, 17)
        Me.Label23.TabIndex = 254
        Me.Label23.Text = "Miscellaneous"
        '
        'frmSettings
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(308, 449)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.nudBilling, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudPercent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudAddons, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudDeposit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudAdvance, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents bntCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents nudBilling As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents nudPercent As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudAmount As System.Windows.Forms.NumericUpDown
    Friend WithEvents rbAmount As System.Windows.Forms.RadioButton
    Friend WithEvents rbPercent As System.Windows.Forms.RadioButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents nudAddons As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents nudDeposit As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudAdvance As System.Windows.Forms.NumericUpDown

End Class
