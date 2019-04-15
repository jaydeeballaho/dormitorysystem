<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.panelMain = New System.Windows.Forms.Panel()
        Me.panelSubMain = New System.Windows.Forms.Panel()
        Me.panelDash = New System.Windows.Forms.Panel()
        Me.tblPanelAlert = New System.Windows.Forms.TableLayoutPanel()
        Me.PanelRight = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.gvView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnPaid = New System.Windows.Forms.Button()
        Me.btnOn = New System.Windows.Forms.Button()
        Me.btnNewBills = New System.Windows.Forms.Button()
        Me.btnOutToday = New System.Windows.Forms.Button()
        Me.btnDue = New System.Windows.Forms.Button()
        Me.btnUnpaidBills = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnViewNotif = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PanelLeft = New System.Windows.Forms.Panel()
        Me.lblRoom = New System.Windows.Forms.Label()
        Me.flRoom = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.panelTopAlertStock = New System.Windows.Forms.Panel()
        Me.btnViewRoom = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.panelTop = New System.Windows.Forms.Panel()
        Me.tblPanelTop = New System.Windows.Forms.TableLayoutPanel()
        Me.flowPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnRent = New System.Windows.Forms.Button()
        Me.btnBorder = New System.Windows.Forms.Button()
        Me.btnBillings = New System.Windows.Forms.Button()
        Me.btnCollection = New System.Windows.Forms.Button()
        Me.btnSettings = New System.Windows.Forms.Button()
        Me.btnAccounts = New System.Windows.Forms.Button()
        Me.btnRoom = New System.Windows.Forms.Button()
        Me.btnReports = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnMyProfile = New System.Windows.Forms.Button()
        Me.btnLogout = New System.Windows.Forms.Button()
        Me.panelBtm = New System.Windows.Forms.Panel()
        Me.ssMain = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel6 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsUser = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsType = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel12 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel8 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsDate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel11 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsTime = New System.Windows.Forms.ToolStripStatusLabel()
        Me.panelHeader = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.timerMain = New System.Windows.Forms.Timer(Me.components)
        Me.cmMain = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TimerBilling = New System.Windows.Forms.Timer(Me.components)
        Me.TimerRoom = New System.Windows.Forms.Timer(Me.components)
        Me.panelMain.SuspendLayout()
        Me.panelSubMain.SuspendLayout()
        Me.panelDash.SuspendLayout()
        Me.tblPanelAlert.SuspendLayout()
        Me.PanelRight.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.gvView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.PanelLeft.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.panelTopAlertStock.SuspendLayout()
        Me.panelTop.SuspendLayout()
        Me.tblPanelTop.SuspendLayout()
        Me.flowPanel.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.panelBtm.SuspendLayout()
        Me.ssMain.SuspendLayout()
        Me.panelHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelMain
        '
        Me.panelMain.Controls.Add(Me.panelSubMain)
        Me.panelMain.Controls.Add(Me.panelTop)
        Me.panelMain.Controls.Add(Me.panelBtm)
        Me.panelMain.Controls.Add(Me.panelHeader)
        Me.panelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelMain.Location = New System.Drawing.Point(0, 0)
        Me.panelMain.Name = "panelMain"
        Me.panelMain.Size = New System.Drawing.Size(1284, 682)
        Me.panelMain.TabIndex = 0
        '
        'panelSubMain
        '
        Me.panelSubMain.BackColor = System.Drawing.Color.Transparent
        Me.panelSubMain.Controls.Add(Me.panelDash)
        Me.panelSubMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelSubMain.Location = New System.Drawing.Point(0, 210)
        Me.panelSubMain.Name = "panelSubMain"
        Me.panelSubMain.Size = New System.Drawing.Size(1284, 432)
        Me.panelSubMain.TabIndex = 1
        '
        'panelDash
        '
        Me.panelDash.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelDash.BackColor = System.Drawing.Color.Transparent
        Me.panelDash.Controls.Add(Me.tblPanelAlert)
        Me.panelDash.Location = New System.Drawing.Point(6, 2)
        Me.panelDash.Name = "panelDash"
        Me.panelDash.Size = New System.Drawing.Size(1273, 429)
        Me.panelDash.TabIndex = 2
        '
        'tblPanelAlert
        '
        Me.tblPanelAlert.ColumnCount = 2
        Me.tblPanelAlert.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.95!))
        Me.tblPanelAlert.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.05!))
        Me.tblPanelAlert.Controls.Add(Me.PanelRight, 1, 0)
        Me.tblPanelAlert.Controls.Add(Me.PanelLeft, 0, 0)
        Me.tblPanelAlert.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblPanelAlert.Location = New System.Drawing.Point(0, 0)
        Me.tblPanelAlert.Name = "tblPanelAlert"
        Me.tblPanelAlert.RowCount = 1
        Me.tblPanelAlert.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblPanelAlert.Size = New System.Drawing.Size(1273, 429)
        Me.tblPanelAlert.TabIndex = 0
        '
        'PanelRight
        '
        Me.PanelRight.Controls.Add(Me.Panel7)
        Me.PanelRight.Controls.Add(Me.Panel2)
        Me.PanelRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelRight.Location = New System.Drawing.Point(638, 3)
        Me.PanelRight.Name = "PanelRight"
        Me.PanelRight.Size = New System.Drawing.Size(632, 423)
        Me.PanelRight.TabIndex = 1
        '
        'Panel7
        '
        Me.Panel7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel7.Controls.Add(Me.gvView)
        Me.Panel7.Controls.Add(Me.btnPaid)
        Me.Panel7.Controls.Add(Me.btnOn)
        Me.Panel7.Controls.Add(Me.btnNewBills)
        Me.Panel7.Controls.Add(Me.btnOutToday)
        Me.Panel7.Controls.Add(Me.btnDue)
        Me.Panel7.Controls.Add(Me.btnUnpaidBills)
        Me.Panel7.Location = New System.Drawing.Point(3, 52)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(625, 368)
        Me.Panel7.TabIndex = 281
        '
        'gvView
        '
        Me.gvView.AllowUserToAddRows = False
        Me.gvView.AllowUserToDeleteRows = False
        Me.gvView.AllowUserToResizeColumns = False
        Me.gvView.AllowUserToResizeRows = False
        Me.gvView.BackgroundColor = System.Drawing.Color.White
        Me.gvView.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.gvView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(60, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gvView.ColumnHeadersHeight = 35
        Me.gvView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.gvView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn6, Me.Column1})
        Me.gvView.EnableHeadersVisualStyles = False
        Me.gvView.GridColor = System.Drawing.Color.White
        Me.gvView.Location = New System.Drawing.Point(3, 4)
        Me.gvView.Name = "gvView"
        Me.gvView.ReadOnly = True
        Me.gvView.RowHeadersVisible = False
        Me.gvView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gvView.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.gvView.RowTemplate.Height = 30
        Me.gvView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvView.Size = New System.Drawing.Size(321, 82)
        Me.gvView.TabIndex = 276
        Me.gvView.Visible = False
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "rentid"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn6
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn6.HeaderText = "Amount"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column1
        '
        Me.Column1.HeaderText = "charge"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'btnPaid
        '
        Me.btnPaid.BackColor = System.Drawing.Color.White
        Me.btnPaid.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnPaid.FlatAppearance.BorderSize = 0
        Me.btnPaid.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnPaid.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btnPaid.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPaid.Font = New System.Drawing.Font("Segoe UI Semibold", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPaid.ForeColor = System.Drawing.Color.DarkKhaki
        Me.btnPaid.Location = New System.Drawing.Point(239, 52)
        Me.btnPaid.Name = "btnPaid"
        Me.btnPaid.Size = New System.Drawing.Size(150, 110)
        Me.btnPaid.TabIndex = 281
        Me.btnPaid.TabStop = False
        Me.btnPaid.Text = "0" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Paid Bills Today"
        Me.btnPaid.UseVisualStyleBackColor = False
        '
        'btnOn
        '
        Me.btnOn.BackColor = System.Drawing.Color.White
        Me.btnOn.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnOn.FlatAppearance.BorderSize = 0
        Me.btnOn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnOn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btnOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOn.Font = New System.Drawing.Font("Segoe UI Semibold", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOn.ForeColor = System.Drawing.Color.SeaGreen
        Me.btnOn.Location = New System.Drawing.Point(239, 206)
        Me.btnOn.Name = "btnOn"
        Me.btnOn.Size = New System.Drawing.Size(150, 110)
        Me.btnOn.TabIndex = 282
        Me.btnOn.TabStop = False
        Me.btnOn.Text = "0" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "On-going Rent"
        Me.btnOn.UseVisualStyleBackColor = False
        '
        'btnNewBills
        '
        Me.btnNewBills.BackColor = System.Drawing.Color.White
        Me.btnNewBills.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnNewBills.FlatAppearance.BorderSize = 0
        Me.btnNewBills.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnNewBills.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btnNewBills.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNewBills.Font = New System.Drawing.Font("Segoe UI Semibold", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNewBills.ForeColor = System.Drawing.Color.SteelBlue
        Me.btnNewBills.Location = New System.Drawing.Point(42, 52)
        Me.btnNewBills.Name = "btnNewBills"
        Me.btnNewBills.Size = New System.Drawing.Size(150, 110)
        Me.btnNewBills.TabIndex = 277
        Me.btnNewBills.TabStop = False
        Me.btnNewBills.Tag = ""
        Me.btnNewBills.Text = "0" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "New Bills Today"
        Me.btnNewBills.UseVisualStyleBackColor = False
        '
        'btnOutToday
        '
        Me.btnOutToday.BackColor = System.Drawing.Color.White
        Me.btnOutToday.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnOutToday.FlatAppearance.BorderSize = 0
        Me.btnOutToday.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnOutToday.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btnOutToday.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOutToday.Font = New System.Drawing.Font("Segoe UI Semibold", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOutToday.ForeColor = System.Drawing.Color.DarkOrange
        Me.btnOutToday.Location = New System.Drawing.Point(42, 206)
        Me.btnOutToday.Name = "btnOutToday"
        Me.btnOutToday.Size = New System.Drawing.Size(150, 110)
        Me.btnOutToday.TabIndex = 279
        Me.btnOutToday.TabStop = False
        Me.btnOutToday.Text = "0" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Border Out Today"
        Me.btnOutToday.UseVisualStyleBackColor = False
        '
        'btnDue
        '
        Me.btnDue.BackColor = System.Drawing.Color.White
        Me.btnDue.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnDue.FlatAppearance.BorderSize = 0
        Me.btnDue.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnDue.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btnDue.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDue.Font = New System.Drawing.Font("Segoe UI Semibold", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDue.ForeColor = System.Drawing.Color.Crimson
        Me.btnDue.Location = New System.Drawing.Point(433, 206)
        Me.btnDue.Name = "btnDue"
        Me.btnDue.Size = New System.Drawing.Size(150, 110)
        Me.btnDue.TabIndex = 280
        Me.btnDue.TabStop = False
        Me.btnDue.Text = "0" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Over Due Rent"
        Me.btnDue.UseVisualStyleBackColor = False
        '
        'btnUnpaidBills
        '
        Me.btnUnpaidBills.BackColor = System.Drawing.Color.White
        Me.btnUnpaidBills.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnUnpaidBills.FlatAppearance.BorderSize = 0
        Me.btnUnpaidBills.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnUnpaidBills.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btnUnpaidBills.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUnpaidBills.Font = New System.Drawing.Font("Segoe UI Semibold", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUnpaidBills.ForeColor = System.Drawing.Color.DimGray
        Me.btnUnpaidBills.Location = New System.Drawing.Point(433, 52)
        Me.btnUnpaidBills.Name = "btnUnpaidBills"
        Me.btnUnpaidBills.Size = New System.Drawing.Size(150, 110)
        Me.btnUnpaidBills.TabIndex = 278
        Me.btnUnpaidBills.TabStop = False
        Me.btnUnpaidBills.Text = "0" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Unpaid Bills"
        Me.btnUnpaidBills.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Panel2.Controls.Add(Me.btnViewNotif)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(632, 50)
        Me.Panel2.TabIndex = 0
        '
        'btnViewNotif
        '
        Me.btnViewNotif.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnViewNotif.BackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btnViewNotif.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnViewNotif.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewNotif.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewNotif.ForeColor = System.Drawing.Color.White
        Me.btnViewNotif.Location = New System.Drawing.Point(476, 13)
        Me.btnViewNotif.Name = "btnViewNotif"
        Me.btnViewNotif.Size = New System.Drawing.Size(141, 25)
        Me.btnViewNotif.TabIndex = 8
        Me.btnViewNotif.TabStop = False
        Me.btnViewNotif.Text = "Refresh Notifications"
        Me.btnViewNotif.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(10, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(123, 25)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Notifications"
        '
        'PanelLeft
        '
        Me.PanelLeft.BackColor = System.Drawing.Color.Transparent
        Me.PanelLeft.Controls.Add(Me.lblRoom)
        Me.PanelLeft.Controls.Add(Me.flRoom)
        Me.PanelLeft.Controls.Add(Me.Panel1)
        Me.PanelLeft.Controls.Add(Me.panelTopAlertStock)
        Me.PanelLeft.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelLeft.Location = New System.Drawing.Point(3, 3)
        Me.PanelLeft.Name = "PanelLeft"
        Me.PanelLeft.Size = New System.Drawing.Size(629, 423)
        Me.PanelLeft.TabIndex = 0
        '
        'lblRoom
        '
        Me.lblRoom.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRoom.ForeColor = System.Drawing.Color.Black
        Me.lblRoom.Location = New System.Drawing.Point(3, 211)
        Me.lblRoom.Name = "lblRoom"
        Me.lblRoom.Size = New System.Drawing.Size(624, 32)
        Me.lblRoom.TabIndex = 3
        Me.lblRoom.Text = "NO ROOMS YET"
        Me.lblRoom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'flRoom
        '
        Me.flRoom.AutoScroll = True
        Me.flRoom.Location = New System.Drawing.Point(21, 74)
        Me.flRoom.Name = "flRoom"
        Me.flRoom.Size = New System.Drawing.Size(586, 295)
        Me.flRoom.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Panel6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 366)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(629, 57)
        Me.Panel1.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkGray
        Me.Label7.Location = New System.Drawing.Point(481, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(129, 25)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Not Available"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Crimson
        Me.Label6.Location = New System.Drawing.Point(345, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(99, 25)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Room Full"
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Silver
        Me.Panel6.Location = New System.Drawing.Point(450, 16)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(25, 25)
        Me.Panel6.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkOrange
        Me.Label5.Location = New System.Drawing.Point(163, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(145, 25)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Some Occupied"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Crimson
        Me.Panel5.Location = New System.Drawing.Point(314, 16)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(25, 25)
        Me.Panel5.TabIndex = 4
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.DarkOrange
        Me.Panel4.Location = New System.Drawing.Point(132, 16)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(25, 25)
        Me.Panel4.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.SeaGreen
        Me.Label3.Location = New System.Drawing.Point(46, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 25)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Vacant"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.SeaGreen
        Me.Panel3.Location = New System.Drawing.Point(24, 16)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(25, 25)
        Me.Panel3.TabIndex = 2
        '
        'panelTopAlertStock
        '
        Me.panelTopAlertStock.BackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.panelTopAlertStock.Controls.Add(Me.btnViewRoom)
        Me.panelTopAlertStock.Controls.Add(Me.Label1)
        Me.panelTopAlertStock.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelTopAlertStock.Location = New System.Drawing.Point(0, 0)
        Me.panelTopAlertStock.Name = "panelTopAlertStock"
        Me.panelTopAlertStock.Size = New System.Drawing.Size(629, 50)
        Me.panelTopAlertStock.TabIndex = 0
        '
        'btnViewRoom
        '
        Me.btnViewRoom.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnViewRoom.BackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btnViewRoom.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnViewRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewRoom.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewRoom.ForeColor = System.Drawing.Color.White
        Me.btnViewRoom.Location = New System.Drawing.Point(476, 13)
        Me.btnViewRoom.Name = "btnViewRoom"
        Me.btnViewRoom.Size = New System.Drawing.Size(141, 25)
        Me.btnViewRoom.TabIndex = 7
        Me.btnViewRoom.TabStop = False
        Me.btnViewRoom.Text = "Refresh Room Status"
        Me.btnViewRoom.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(10, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Room Status"
        '
        'panelTop
        '
        Me.panelTop.Controls.Add(Me.tblPanelTop)
        Me.panelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelTop.Location = New System.Drawing.Point(0, 100)
        Me.panelTop.Name = "panelTop"
        Me.panelTop.Size = New System.Drawing.Size(1284, 110)
        Me.panelTop.TabIndex = 0
        '
        'tblPanelTop
        '
        Me.tblPanelTop.BackColor = System.Drawing.Color.Transparent
        Me.tblPanelTop.ColumnCount = 2
        Me.tblPanelTop.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblPanelTop.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220.0!))
        Me.tblPanelTop.Controls.Add(Me.flowPanel, 0, 0)
        Me.tblPanelTop.Controls.Add(Me.FlowLayoutPanel1, 1, 0)
        Me.tblPanelTop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblPanelTop.Location = New System.Drawing.Point(0, 0)
        Me.tblPanelTop.Name = "tblPanelTop"
        Me.tblPanelTop.RowCount = 1
        Me.tblPanelTop.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblPanelTop.Size = New System.Drawing.Size(1284, 110)
        Me.tblPanelTop.TabIndex = 0
        '
        'flowPanel
        '
        Me.flowPanel.Controls.Add(Me.btnSearch)
        Me.flowPanel.Controls.Add(Me.btnRent)
        Me.flowPanel.Controls.Add(Me.btnBorder)
        Me.flowPanel.Controls.Add(Me.btnBillings)
        Me.flowPanel.Controls.Add(Me.btnCollection)
        Me.flowPanel.Controls.Add(Me.btnSettings)
        Me.flowPanel.Controls.Add(Me.btnAccounts)
        Me.flowPanel.Controls.Add(Me.btnRoom)
        Me.flowPanel.Controls.Add(Me.btnReports)
        Me.flowPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flowPanel.Location = New System.Drawing.Point(3, 3)
        Me.flowPanel.Name = "flowPanel"
        Me.flowPanel.Padding = New System.Windows.Forms.Padding(1, 0, 0, 0)
        Me.flowPanel.Size = New System.Drawing.Size(1058, 104)
        Me.flowPanel.TabIndex = 0
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btnSearch.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window
        Me.btnSearch.FlatAppearance.BorderSize = 0
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.Color.White
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.Location = New System.Drawing.Point(4, 3)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.btnSearch.Size = New System.Drawing.Size(100, 100)
        Me.btnSearch.TabIndex = 1
        Me.btnSearch.Text = "Quick Search"
        Me.btnSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSearch.UseVisualStyleBackColor = False
        Me.btnSearch.Visible = False
        '
        'btnRent
        '
        Me.btnRent.BackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btnRent.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window
        Me.btnRent.FlatAppearance.BorderSize = 0
        Me.btnRent.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRent.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRent.ForeColor = System.Drawing.Color.White
        Me.btnRent.Image = CType(resources.GetObject("btnRent.Image"), System.Drawing.Image)
        Me.btnRent.Location = New System.Drawing.Point(110, 3)
        Me.btnRent.Name = "btnRent"
        Me.btnRent.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.btnRent.Size = New System.Drawing.Size(100, 100)
        Me.btnRent.TabIndex = 2
        Me.btnRent.Text = "Rent"
        Me.btnRent.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnRent.UseVisualStyleBackColor = False
        '
        'btnBorder
        '
        Me.btnBorder.BackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btnBorder.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window
        Me.btnBorder.FlatAppearance.BorderSize = 0
        Me.btnBorder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBorder.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBorder.ForeColor = System.Drawing.Color.White
        Me.btnBorder.Image = CType(resources.GetObject("btnBorder.Image"), System.Drawing.Image)
        Me.btnBorder.Location = New System.Drawing.Point(216, 3)
        Me.btnBorder.Name = "btnBorder"
        Me.btnBorder.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.btnBorder.Size = New System.Drawing.Size(100, 100)
        Me.btnBorder.TabIndex = 3
        Me.btnBorder.Text = "Border"
        Me.btnBorder.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBorder.UseVisualStyleBackColor = False
        '
        'btnBillings
        '
        Me.btnBillings.BackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btnBillings.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window
        Me.btnBillings.FlatAppearance.BorderSize = 0
        Me.btnBillings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBillings.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBillings.ForeColor = System.Drawing.Color.White
        Me.btnBillings.Image = CType(resources.GetObject("btnBillings.Image"), System.Drawing.Image)
        Me.btnBillings.Location = New System.Drawing.Point(322, 3)
        Me.btnBillings.Name = "btnBillings"
        Me.btnBillings.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.btnBillings.Size = New System.Drawing.Size(100, 100)
        Me.btnBillings.TabIndex = 4
        Me.btnBillings.Text = "Billings"
        Me.btnBillings.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBillings.UseVisualStyleBackColor = False
        '
        'btnCollection
        '
        Me.btnCollection.BackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btnCollection.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window
        Me.btnCollection.FlatAppearance.BorderSize = 0
        Me.btnCollection.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCollection.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCollection.ForeColor = System.Drawing.Color.White
        Me.btnCollection.Image = CType(resources.GetObject("btnCollection.Image"), System.Drawing.Image)
        Me.btnCollection.Location = New System.Drawing.Point(428, 3)
        Me.btnCollection.Name = "btnCollection"
        Me.btnCollection.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.btnCollection.Size = New System.Drawing.Size(100, 100)
        Me.btnCollection.TabIndex = 5
        Me.btnCollection.Text = "Collection"
        Me.btnCollection.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCollection.UseVisualStyleBackColor = False
        '
        'btnSettings
        '
        Me.btnSettings.BackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btnSettings.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window
        Me.btnSettings.FlatAppearance.BorderSize = 0
        Me.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSettings.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSettings.ForeColor = System.Drawing.Color.White
        Me.btnSettings.Image = CType(resources.GetObject("btnSettings.Image"), System.Drawing.Image)
        Me.btnSettings.Location = New System.Drawing.Point(534, 3)
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.btnSettings.Size = New System.Drawing.Size(100, 100)
        Me.btnSettings.TabIndex = 6
        Me.btnSettings.Text = "Settings"
        Me.btnSettings.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSettings.UseVisualStyleBackColor = False
        '
        'btnAccounts
        '
        Me.btnAccounts.BackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btnAccounts.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window
        Me.btnAccounts.FlatAppearance.BorderSize = 0
        Me.btnAccounts.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAccounts.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAccounts.ForeColor = System.Drawing.Color.White
        Me.btnAccounts.Image = CType(resources.GetObject("btnAccounts.Image"), System.Drawing.Image)
        Me.btnAccounts.Location = New System.Drawing.Point(640, 3)
        Me.btnAccounts.Name = "btnAccounts"
        Me.btnAccounts.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.btnAccounts.Size = New System.Drawing.Size(100, 100)
        Me.btnAccounts.TabIndex = 7
        Me.btnAccounts.Text = "Accounts"
        Me.btnAccounts.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAccounts.UseVisualStyleBackColor = False
        '
        'btnRoom
        '
        Me.btnRoom.BackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btnRoom.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window
        Me.btnRoom.FlatAppearance.BorderSize = 0
        Me.btnRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRoom.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRoom.ForeColor = System.Drawing.Color.White
        Me.btnRoom.Image = CType(resources.GetObject("btnRoom.Image"), System.Drawing.Image)
        Me.btnRoom.Location = New System.Drawing.Point(746, 3)
        Me.btnRoom.Name = "btnRoom"
        Me.btnRoom.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.btnRoom.Size = New System.Drawing.Size(100, 100)
        Me.btnRoom.TabIndex = 8
        Me.btnRoom.Text = "Rooms"
        Me.btnRoom.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnRoom.UseVisualStyleBackColor = False
        '
        'btnReports
        '
        Me.btnReports.BackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btnReports.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window
        Me.btnReports.FlatAppearance.BorderSize = 0
        Me.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReports.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReports.ForeColor = System.Drawing.Color.White
        Me.btnReports.Image = CType(resources.GetObject("btnReports.Image"), System.Drawing.Image)
        Me.btnReports.Location = New System.Drawing.Point(852, 3)
        Me.btnReports.Name = "btnReports"
        Me.btnReports.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.btnReports.Size = New System.Drawing.Size(100, 100)
        Me.btnReports.TabIndex = 9
        Me.btnReports.Text = "Reports"
        Me.btnReports.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnReports.UseVisualStyleBackColor = False
        Me.btnReports.Visible = False
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.btnMyProfile)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnLogout)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(1067, 3)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(214, 104)
        Me.FlowLayoutPanel1.TabIndex = 1
        '
        'btnMyProfile
        '
        Me.btnMyProfile.BackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btnMyProfile.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window
        Me.btnMyProfile.FlatAppearance.BorderSize = 0
        Me.btnMyProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMyProfile.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMyProfile.ForeColor = System.Drawing.Color.White
        Me.btnMyProfile.Image = CType(resources.GetObject("btnMyProfile.Image"), System.Drawing.Image)
        Me.btnMyProfile.Location = New System.Drawing.Point(3, 3)
        Me.btnMyProfile.Name = "btnMyProfile"
        Me.btnMyProfile.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.btnMyProfile.Size = New System.Drawing.Size(100, 100)
        Me.btnMyProfile.TabIndex = 10
        Me.btnMyProfile.Text = "Profile"
        Me.btnMyProfile.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnMyProfile.UseVisualStyleBackColor = False
        '
        'btnLogout
        '
        Me.btnLogout.BackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btnLogout.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window
        Me.btnLogout.FlatAppearance.BorderSize = 0
        Me.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogout.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogout.ForeColor = System.Drawing.Color.White
        Me.btnLogout.Image = CType(resources.GetObject("btnLogout.Image"), System.Drawing.Image)
        Me.btnLogout.Location = New System.Drawing.Point(109, 3)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.btnLogout.Size = New System.Drawing.Size(100, 100)
        Me.btnLogout.TabIndex = 11
        Me.btnLogout.Text = "Log-out"
        Me.btnLogout.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLogout.UseVisualStyleBackColor = False
        '
        'panelBtm
        '
        Me.panelBtm.Controls.Add(Me.ssMain)
        Me.panelBtm.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panelBtm.Location = New System.Drawing.Point(0, 642)
        Me.panelBtm.Name = "panelBtm"
        Me.panelBtm.Size = New System.Drawing.Size(1284, 40)
        Me.panelBtm.TabIndex = 0
        '
        'ssMain
        '
        Me.ssMain.BackColor = System.Drawing.Color.Transparent
        Me.ssMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ssMain.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ssMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel6, Me.ToolStripStatusLabel1, Me.tsUser, Me.ToolStripStatusLabel3, Me.tsType, Me.ToolStripStatusLabel12, Me.ToolStripStatusLabel8, Me.tsDate, Me.ToolStripStatusLabel11, Me.tsTime})
        Me.ssMain.Location = New System.Drawing.Point(0, 0)
        Me.ssMain.Name = "ssMain"
        Me.ssMain.Size = New System.Drawing.Size(1284, 40)
        Me.ssMain.SizingGrip = False
        Me.ssMain.TabIndex = 2
        '
        'ToolStripStatusLabel6
        '
        Me.ToolStripStatusLabel6.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel6.Name = "ToolStripStatusLabel6"
        Me.ToolStripStatusLabel6.Size = New System.Drawing.Size(0, 35)
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(114, 35)
        Me.ToolStripStatusLabel1.Text = "   Current User:"
        '
        'tsUser
        '
        Me.tsUser.BackColor = System.Drawing.Color.White
        Me.tsUser.ForeColor = System.Drawing.Color.Black
        Me.tsUser.Name = "tsUser"
        Me.tsUser.Size = New System.Drawing.Size(92, 35)
        Me.tsUser.Text = "User Admin"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(79, 35)
        Me.ToolStripStatusLabel3.Text = "User Type"
        '
        'tsType
        '
        Me.tsType.ForeColor = System.Drawing.Color.Black
        Me.tsType.Name = "tsType"
        Me.tsType.Size = New System.Drawing.Size(106, 35)
        Me.tsType.Text = "Administrator"
        '
        'ToolStripStatusLabel12
        '
        Me.ToolStripStatusLabel12.Name = "ToolStripStatusLabel12"
        Me.ToolStripStatusLabel12.Size = New System.Drawing.Size(595, 35)
        Me.ToolStripStatusLabel12.Spring = True
        '
        'ToolStripStatusLabel8
        '
        Me.ToolStripStatusLabel8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ToolStripStatusLabel8.Name = "ToolStripStatusLabel8"
        Me.ToolStripStatusLabel8.Size = New System.Drawing.Size(45, 35)
        Me.ToolStripStatusLabel8.Text = "Date:"
        '
        'tsDate
        '
        Me.tsDate.ForeColor = System.Drawing.Color.Black
        Me.tsDate.Name = "tsDate"
        Me.tsDate.Size = New System.Drawing.Size(94, 35)
        Me.tsDate.Text = "06/07/2017"
        '
        'ToolStripStatusLabel11
        '
        Me.ToolStripStatusLabel11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ToolStripStatusLabel11.Name = "ToolStripStatusLabel11"
        Me.ToolStripStatusLabel11.Size = New System.Drawing.Size(47, 35)
        Me.ToolStripStatusLabel11.Text = "Time:"
        '
        'tsTime
        '
        Me.tsTime.ForeColor = System.Drawing.Color.Black
        Me.tsTime.Name = "tsTime"
        Me.tsTime.Size = New System.Drawing.Size(97, 35)
        Me.tsTime.Text = "12:15:07 PM"
        '
        'panelHeader
        '
        Me.panelHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.panelHeader.Controls.Add(Me.Label4)
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.Location = New System.Drawing.Point(0, 0)
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.Size = New System.Drawing.Size(1284, 100)
        Me.panelHeader.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 35.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Snow
        Me.Label4.Location = New System.Drawing.Point(192, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(901, 62)
        Me.Label4.TabIndex = 107
        Me.Label4.Text = "BA DORMITORY MANAGEMENT SYSTEM"
        '
        'timerMain
        '
        '
        'cmMain
        '
        Me.cmMain.Name = "cmMain"
        Me.cmMain.Size = New System.Drawing.Size(61, 4)
        '
        'TimerBilling
        '
        Me.TimerBilling.Enabled = True
        Me.TimerBilling.Interval = 3000
        '
        'TimerRoom
        '
        Me.TimerRoom.Enabled = True
        Me.TimerRoom.Interval = 5000
        '
        'frmMain
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1284, 682)
        Me.Controls.Add(Me.panelMain)
        Me.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMain"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BA DORMITORY MANAGEMENT SYSTEM"
        Me.panelMain.ResumeLayout(False)
        Me.panelSubMain.ResumeLayout(False)
        Me.panelDash.ResumeLayout(False)
        Me.tblPanelAlert.ResumeLayout(False)
        Me.PanelRight.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        CType(Me.gvView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.PanelLeft.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.panelTopAlertStock.ResumeLayout(False)
        Me.panelTopAlertStock.PerformLayout()
        Me.panelTop.ResumeLayout(False)
        Me.tblPanelTop.ResumeLayout(False)
        Me.flowPanel.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.panelBtm.ResumeLayout(False)
        Me.panelBtm.PerformLayout()
        Me.ssMain.ResumeLayout(False)
        Me.ssMain.PerformLayout()
        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents panelMain As System.Windows.Forms.Panel
    Friend WithEvents panelTop As System.Windows.Forms.Panel
    Friend WithEvents flowPanel As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnReports As System.Windows.Forms.Button
    Friend WithEvents panelSubMain As System.Windows.Forms.Panel
    Friend WithEvents timerMain As System.Windows.Forms.Timer
    Friend WithEvents tblPanelTop As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents panelDash As System.Windows.Forms.Panel
    Friend WithEvents panelBtm As System.Windows.Forms.Panel
    Friend WithEvents ssMain As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel6 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsType As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsUser As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel12 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel8 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsDate As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel11 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsTime As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tblPanelAlert As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents PanelLeft As System.Windows.Forms.Panel
    Friend WithEvents panelTopAlertStock As System.Windows.Forms.Panel
    Friend WithEvents PanelRight As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents panelHeader As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnMyProfile As System.Windows.Forms.Button
    Friend WithEvents btnLogout As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnRoom As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents flRoom As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnViewNotif As System.Windows.Forms.Button
    Friend WithEvents btnViewRoom As System.Windows.Forms.Button
    Friend WithEvents cmMain As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents lblRoom As System.Windows.Forms.Label
    Friend WithEvents btnRent As System.Windows.Forms.Button
    Friend WithEvents btnBorder As System.Windows.Forms.Button
    Friend WithEvents btnBillings As System.Windows.Forms.Button
    Friend WithEvents btnCollection As System.Windows.Forms.Button
    Friend WithEvents btnSettings As System.Windows.Forms.Button
    Friend WithEvents btnAccounts As System.Windows.Forms.Button
    Friend WithEvents gvView As System.Windows.Forms.DataGridView
    Friend WithEvents btnDue As System.Windows.Forms.Button
    Friend WithEvents btnOutToday As System.Windows.Forms.Button
    Friend WithEvents btnUnpaidBills As System.Windows.Forms.Button
    Friend WithEvents btnNewBills As System.Windows.Forms.Button
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents btnPaid As System.Windows.Forms.Button
    Friend WithEvents btnOn As System.Windows.Forms.Button
    Friend WithEvents TimerBilling As System.Windows.Forms.Timer
    Friend WithEvents TimerRoom As System.Windows.Forms.Timer
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
