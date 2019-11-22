Namespace TiT.PTS
  Partial Public Class MainForm
    ''' <summary>
    ''' Требуется переменная конструктора.
    ''' </summary>
    Private components As System.ComponentModel.IContainer = Nothing

    ''' <summary>
    ''' Освободить все используемые ресурсы.
    ''' </summary>
    ''' <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso (components IsNot Nothing) Then
        components.Dispose()
      End If
      MyBase.Dispose(disposing)
    End Sub

#Region "Код, автоматически созданный конструктором форм Windows"

    ''' <summary>
    ''' Обязательный метод для поддержки конструктора - не изменяйте
    ''' содержимое данного метода при помощи редактора кода.
    ''' </summary>
    Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
      Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Me.tableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
      Me._fuelPointControl16 = New TiT.PTS.FuelPointControl()
      Me._fuelPointControl15 = New TiT.PTS.FuelPointControl()
      Me._fuelPointControl14 = New TiT.PTS.FuelPointControl()
      Me._fuelPointControl13 = New TiT.PTS.FuelPointControl()
      Me._fuelPointControl12 = New TiT.PTS.FuelPointControl()
      Me._fuelPointControl11 = New TiT.PTS.FuelPointControl()
      Me._fuelPointControl10 = New TiT.PTS.FuelPointControl()
      Me._fuelPointControl9 = New TiT.PTS.FuelPointControl()
      Me._fuelPointControl8 = New TiT.PTS.FuelPointControl()
      Me._fuelPointControl7 = New TiT.PTS.FuelPointControl()
      Me._fuelPointControl6 = New TiT.PTS.FuelPointControl()
      Me._fuelPointControl5 = New TiT.PTS.FuelPointControl()
      Me._fuelPointControl4 = New TiT.PTS.FuelPointControl()
      Me._fuelPointControl3 = New TiT.PTS.FuelPointControl()
      Me._fuelPointControl2 = New TiT.PTS.FuelPointControl()
      Me._fuelPointControl1 = New TiT.PTS.FuelPointControl()
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.toolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
      Me.portListComboBox = New System.Windows.Forms.ToolStripComboBox()
      Me.toolStrip = New System.Windows.Forms.ToolStrip()
      Me.portConnectionButton = New System.Windows.Forms.ToolStripButton()
      Me.Label13 = New System.Windows.Forms.Label()
      Me.txtuser = New System.Windows.Forms.Label()
      Me.Label14 = New System.Windows.Forms.Label()
      Me.txtusername = New System.Windows.Forms.Label()
      Me.DataGridView1 = New System.Windows.Forms.DataGridView()
      Me.DataGridView2 = New System.Windows.Forms.DataGridView()
      Me.ItemLookUp = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.UnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Discount = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.pointw = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.pointx = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IDZ = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Panel2 = New System.Windows.Forms.Panel()
      Me.btdot = New System.Windows.Forms.Button()
      Me.bt00 = New System.Windows.Forms.Button()
      Me.bt0 = New System.Windows.Forms.Button()
      Me.bt1 = New System.Windows.Forms.Button()
      Me.bt2 = New System.Windows.Forms.Button()
      Me.bt3 = New System.Windows.Forms.Button()
      Me.bt6 = New System.Windows.Forms.Button()
      Me.bt5 = New System.Windows.Forms.Button()
      Me.bt4 = New System.Windows.Forms.Button()
      Me.bt9 = New System.Windows.Forms.Button()
      Me.bt8 = New System.Windows.Forms.Button()
      Me.bt7 = New System.Windows.Forms.Button()
      Me.bt1000 = New System.Windows.Forms.Button()
      Me.bt500 = New System.Windows.Forms.Button()
      Me.bt400 = New System.Windows.Forms.Button()
      Me.bt300 = New System.Windows.Forms.Button()
      Me.bt200 = New System.Windows.Forms.Button()
      Me.bt100 = New System.Windows.Forms.Button()
      Me.Panel3 = New System.Windows.Forms.Panel()
      Me.txtcash = New System.Windows.Forms.TextBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.txtPlateNo = New System.Windows.Forms.TextBox()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.txtDN = New System.Windows.Forms.TextBox()
      Me.Label10 = New System.Windows.Forms.Label()
      Me.txtact = New System.Windows.Forms.TextBox()
      Me.Label9 = New System.Windows.Forms.Label()
      Me.txtname = New System.Windows.Forms.Label()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.Panel12 = New System.Windows.Forms.Panel()
      Me.txtplussd = New System.Windows.Forms.Label()
      Me.txttax = New System.Windows.Forms.Label()
      Me.txtdis = New System.Windows.Forms.Label()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.TXTVAT = New System.Windows.Forms.Label()
      Me.txtvT = New System.Windows.Forms.Label()
      Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
      Me.Label16 = New System.Windows.Forms.Label()
      Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
      Me.Label15 = New System.Windows.Forms.Label()
      Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
      Me.TabPage3 = New System.Windows.Forms.TabPage()
      Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
      Me.btlastdrop = New System.Windows.Forms.Button()
      Me.btCashdrop = New System.Windows.Forms.Button()
      Me.btvoid = New System.Windows.Forms.Button()
      Me.bddiscount = New System.Windows.Forms.Button()
      Me.Button11 = New System.Windows.Forms.Button()
      Me.Button12 = New System.Windows.Forms.Button()
      Me.Button13 = New System.Windows.Forms.Button()
      Me.btsplit = New System.Windows.Forms.Button()
      Me.btcalibration = New System.Windows.Forms.Button()
      Me.btpayout = New System.Windows.Forms.Button()
      Me.TabPage2 = New System.Windows.Forms.TabPage()
      Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
      Me.btcredittocredit = New System.Windows.Forms.Button()
      Me.btLoyaltyReport = New System.Windows.Forms.Button()
      Me.btpump = New System.Windows.Forms.Button()
      Me.btxreport = New System.Windows.Forms.Button()
      Me.buttom123 = New System.Windows.Forms.Button()
      Me.btzreport = New System.Windows.Forms.Button()
      Me.Btdub = New System.Windows.Forms.Button()
      Me.btcr = New System.Windows.Forms.Button()
      Me.btpumpreading = New System.Windows.Forms.Button()
      Me.Button7 = New System.Windows.Forms.Button()
      Me.TabPage1 = New System.Windows.Forms.TabPage()
      Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
      Me.btclear = New System.Windows.Forms.Button()
      Me.bttotalizer = New System.Windows.Forms.Button()
      Me.btreedem = New System.Windows.Forms.Button()
      Me.btchangep = New System.Windows.Forms.Button()
      Me.btchangeuser = New System.Windows.Forms.Button()
      Me.btnonfuel = New System.Windows.Forms.Button()
      Me.MenuBar = New System.Windows.Forms.TabControl()
      Me.Panel4 = New System.Windows.Forms.Panel()
      Me.BTCASHpoint = New System.Windows.Forms.Button()
      Me.btDRAWER = New System.Windows.Forms.Button()
      Me.Button1 = New System.Windows.Forms.Button()
      Me.BTpoPoint = New System.Windows.Forms.Button()
      Me.btcash = New System.Windows.Forms.Button()
      Me.btpo = New System.Windows.Forms.Button()
      Me.Panel7 = New System.Windows.Forms.Panel()
      Me.txttotaldue = New System.Windows.Forms.Label()
      Me.txtchangename = New System.Windows.Forms.Label()
      Me.txttotalTender = New System.Windows.Forms.Label()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.txtchange = New System.Windows.Forms.Label()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.btaddall = New System.Windows.Forms.Button()
      Me.tableLayoutPanel.SuspendLayout()
      Me.Panel1.SuspendLayout()
      Me.toolStrip.SuspendLayout()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.Panel2.SuspendLayout()
      Me.Panel3.SuspendLayout()
      Me.Panel12.SuspendLayout()
      Me.TabPage3.SuspendLayout()
      Me.TableLayoutPanel5.SuspendLayout()
      Me.TabPage2.SuspendLayout()
      Me.TableLayoutPanel4.SuspendLayout()
      Me.TabPage1.SuspendLayout()
      Me.TableLayoutPanel1.SuspendLayout()
      Me.MenuBar.SuspendLayout()
      Me.Panel7.SuspendLayout()
      Me.SuspendLayout()
      '
      'tableLayoutPanel
      '
      Me.tableLayoutPanel.BackColor = System.Drawing.Color.White
      Me.tableLayoutPanel.ColumnCount = 4
      Me.tableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
      Me.tableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
      Me.tableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
      Me.tableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
      Me.tableLayoutPanel.Controls.Add(Me._fuelPointControl16, 3, 3)
      Me.tableLayoutPanel.Controls.Add(Me._fuelPointControl15, 2, 3)
      Me.tableLayoutPanel.Controls.Add(Me._fuelPointControl14, 1, 3)
      Me.tableLayoutPanel.Controls.Add(Me._fuelPointControl13, 0, 3)
      Me.tableLayoutPanel.Controls.Add(Me._fuelPointControl12, 3, 2)
      Me.tableLayoutPanel.Controls.Add(Me._fuelPointControl11, 2, 2)
      Me.tableLayoutPanel.Controls.Add(Me._fuelPointControl10, 1, 2)
      Me.tableLayoutPanel.Controls.Add(Me._fuelPointControl9, 0, 2)
      Me.tableLayoutPanel.Controls.Add(Me._fuelPointControl8, 3, 1)
      Me.tableLayoutPanel.Controls.Add(Me._fuelPointControl7, 2, 1)
      Me.tableLayoutPanel.Controls.Add(Me._fuelPointControl6, 1, 1)
      Me.tableLayoutPanel.Controls.Add(Me._fuelPointControl5, 0, 1)
      Me.tableLayoutPanel.Controls.Add(Me._fuelPointControl4, 3, 0)
      Me.tableLayoutPanel.Controls.Add(Me._fuelPointControl3, 2, 0)
      Me.tableLayoutPanel.Controls.Add(Me._fuelPointControl2, 1, 0)
      Me.tableLayoutPanel.Controls.Add(Me._fuelPointControl1, 0, 0)
      Me.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
      Me.tableLayoutPanel.Location = New System.Drawing.Point(0, 0)
      Me.tableLayoutPanel.Margin = New System.Windows.Forms.Padding(0)
      Me.tableLayoutPanel.Name = "tableLayoutPanel"
      Me.tableLayoutPanel.RowCount = 4
      Me.tableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
      Me.tableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
      Me.tableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
      Me.tableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
      Me.tableLayoutPanel.Size = New System.Drawing.Size(395, 492)
      Me.tableLayoutPanel.TabIndex = 3
      '
      '_fuelPointControl16
      '
      Me._fuelPointControl16.BackColor = System.Drawing.Color.LightYellow
      Me._fuelPointControl16.FuelPointID = Nothing
      Me._fuelPointControl16.IsDispensing = False
      Me._fuelPointControl16.IsLocked = False
      Me._fuelPointControl16.Location = New System.Drawing.Point(297, 372)
      Me._fuelPointControl16.Name = "_fuelPointControl16"
      Me._fuelPointControl16.PTS = Nothing
      Me._fuelPointControl16.Size = New System.Drawing.Size(95, 117)
      Me._fuelPointControl16.TabIndex = 15
      '
      '_fuelPointControl15
      '
      Me._fuelPointControl15.BackColor = System.Drawing.Color.LightYellow
      Me._fuelPointControl15.FuelPointID = Nothing
      Me._fuelPointControl15.IsDispensing = False
      Me._fuelPointControl15.IsLocked = False
      Me._fuelPointControl15.Location = New System.Drawing.Point(199, 372)
      Me._fuelPointControl15.Name = "_fuelPointControl15"
      Me._fuelPointControl15.PTS = Nothing
      Me._fuelPointControl15.Size = New System.Drawing.Size(92, 117)
      Me._fuelPointControl15.TabIndex = 14
      '
      '_fuelPointControl14
      '
      Me._fuelPointControl14.BackColor = System.Drawing.Color.LightYellow
      Me._fuelPointControl14.FuelPointID = Nothing
      Me._fuelPointControl14.IsDispensing = False
      Me._fuelPointControl14.IsLocked = False
      Me._fuelPointControl14.Location = New System.Drawing.Point(101, 372)
      Me._fuelPointControl14.Name = "_fuelPointControl14"
      Me._fuelPointControl14.PTS = Nothing
      Me._fuelPointControl14.Size = New System.Drawing.Size(92, 117)
      Me._fuelPointControl14.TabIndex = 13
      '
      '_fuelPointControl13
      '
      Me._fuelPointControl13.BackColor = System.Drawing.Color.LightYellow
      Me._fuelPointControl13.FuelPointID = Nothing
      Me._fuelPointControl13.IsDispensing = False
      Me._fuelPointControl13.IsLocked = False
      Me._fuelPointControl13.Location = New System.Drawing.Point(3, 372)
      Me._fuelPointControl13.Name = "_fuelPointControl13"
      Me._fuelPointControl13.PTS = Nothing
      Me._fuelPointControl13.Size = New System.Drawing.Size(92, 117)
      Me._fuelPointControl13.TabIndex = 12
      '
      '_fuelPointControl12
      '
      Me._fuelPointControl12.BackColor = System.Drawing.Color.LightYellow
      Me._fuelPointControl12.FuelPointID = Nothing
      Me._fuelPointControl12.IsDispensing = False
      Me._fuelPointControl12.IsLocked = False
      Me._fuelPointControl12.Location = New System.Drawing.Point(297, 249)
      Me._fuelPointControl12.Name = "_fuelPointControl12"
      Me._fuelPointControl12.PTS = Nothing
      Me._fuelPointControl12.Size = New System.Drawing.Size(95, 117)
      Me._fuelPointControl12.TabIndex = 11
      '
      '_fuelPointControl11
      '
      Me._fuelPointControl11.BackColor = System.Drawing.Color.LightYellow
      Me._fuelPointControl11.FuelPointID = Nothing
      Me._fuelPointControl11.IsDispensing = False
      Me._fuelPointControl11.IsLocked = False
      Me._fuelPointControl11.Location = New System.Drawing.Point(199, 249)
      Me._fuelPointControl11.Name = "_fuelPointControl11"
      Me._fuelPointControl11.PTS = Nothing
      Me._fuelPointControl11.Size = New System.Drawing.Size(92, 117)
      Me._fuelPointControl11.TabIndex = 10
      '
      '_fuelPointControl10
      '
      Me._fuelPointControl10.BackColor = System.Drawing.Color.LightYellow
      Me._fuelPointControl10.FuelPointID = Nothing
      Me._fuelPointControl10.IsDispensing = False
      Me._fuelPointControl10.IsLocked = False
      Me._fuelPointControl10.Location = New System.Drawing.Point(101, 249)
      Me._fuelPointControl10.Name = "_fuelPointControl10"
      Me._fuelPointControl10.PTS = Nothing
      Me._fuelPointControl10.Size = New System.Drawing.Size(92, 117)
      Me._fuelPointControl10.TabIndex = 9
      '
      '_fuelPointControl9
      '
      Me._fuelPointControl9.BackColor = System.Drawing.Color.LightYellow
      Me._fuelPointControl9.FuelPointID = Nothing
      Me._fuelPointControl9.IsDispensing = False
      Me._fuelPointControl9.IsLocked = False
      Me._fuelPointControl9.Location = New System.Drawing.Point(3, 249)
      Me._fuelPointControl9.Name = "_fuelPointControl9"
      Me._fuelPointControl9.PTS = Nothing
      Me._fuelPointControl9.Size = New System.Drawing.Size(92, 117)
      Me._fuelPointControl9.TabIndex = 8
      '
      '_fuelPointControl8
      '
      Me._fuelPointControl8.BackColor = System.Drawing.Color.LightYellow
      Me._fuelPointControl8.FuelPointID = Nothing
      Me._fuelPointControl8.IsDispensing = False
      Me._fuelPointControl8.IsLocked = False
      Me._fuelPointControl8.Location = New System.Drawing.Point(297, 126)
      Me._fuelPointControl8.Name = "_fuelPointControl8"
      Me._fuelPointControl8.PTS = Nothing
      Me._fuelPointControl8.Size = New System.Drawing.Size(95, 117)
      Me._fuelPointControl8.TabIndex = 7
      '
      '_fuelPointControl7
      '
      Me._fuelPointControl7.BackColor = System.Drawing.Color.LightYellow
      Me._fuelPointControl7.FuelPointID = Nothing
      Me._fuelPointControl7.IsDispensing = False
      Me._fuelPointControl7.IsLocked = False
      Me._fuelPointControl7.Location = New System.Drawing.Point(199, 126)
      Me._fuelPointControl7.Name = "_fuelPointControl7"
      Me._fuelPointControl7.PTS = Nothing
      Me._fuelPointControl7.Size = New System.Drawing.Size(92, 117)
      Me._fuelPointControl7.TabIndex = 6
      '
      '_fuelPointControl6
      '
      Me._fuelPointControl6.BackColor = System.Drawing.Color.LightYellow
      Me._fuelPointControl6.FuelPointID = Nothing
      Me._fuelPointControl6.IsDispensing = False
      Me._fuelPointControl6.IsLocked = False
      Me._fuelPointControl6.Location = New System.Drawing.Point(101, 126)
      Me._fuelPointControl6.Name = "_fuelPointControl6"
      Me._fuelPointControl6.PTS = Nothing
      Me._fuelPointControl6.Size = New System.Drawing.Size(92, 117)
      Me._fuelPointControl6.TabIndex = 5
      '
      '_fuelPointControl5
      '
      Me._fuelPointControl5.BackColor = System.Drawing.Color.LightYellow
      Me._fuelPointControl5.FuelPointID = Nothing
      Me._fuelPointControl5.IsDispensing = False
      Me._fuelPointControl5.IsLocked = False
      Me._fuelPointControl5.Location = New System.Drawing.Point(3, 126)
      Me._fuelPointControl5.Name = "_fuelPointControl5"
      Me._fuelPointControl5.PTS = Nothing
      Me._fuelPointControl5.Size = New System.Drawing.Size(92, 117)
      Me._fuelPointControl5.TabIndex = 4
      '
      '_fuelPointControl4
      '
      Me._fuelPointControl4.BackColor = System.Drawing.Color.LightYellow
      Me._fuelPointControl4.FuelPointID = Nothing
      Me._fuelPointControl4.IsDispensing = False
      Me._fuelPointControl4.IsLocked = False
      Me._fuelPointControl4.Location = New System.Drawing.Point(297, 3)
      Me._fuelPointControl4.Name = "_fuelPointControl4"
      Me._fuelPointControl4.PTS = Nothing
      Me._fuelPointControl4.Size = New System.Drawing.Size(95, 117)
      Me._fuelPointControl4.TabIndex = 3
      '
      '_fuelPointControl3
      '
      Me._fuelPointControl3.BackColor = System.Drawing.Color.LightYellow
      Me._fuelPointControl3.FuelPointID = Nothing
      Me._fuelPointControl3.IsDispensing = False
      Me._fuelPointControl3.IsLocked = False
      Me._fuelPointControl3.Location = New System.Drawing.Point(199, 3)
      Me._fuelPointControl3.Name = "_fuelPointControl3"
      Me._fuelPointControl3.PTS = Nothing
      Me._fuelPointControl3.Size = New System.Drawing.Size(92, 117)
      Me._fuelPointControl3.TabIndex = 2
      '
      '_fuelPointControl2
      '
      Me._fuelPointControl2.BackColor = System.Drawing.Color.LightYellow
      Me._fuelPointControl2.FuelPointID = Nothing
      Me._fuelPointControl2.IsDispensing = False
      Me._fuelPointControl2.IsLocked = False
      Me._fuelPointControl2.Location = New System.Drawing.Point(101, 3)
      Me._fuelPointControl2.Name = "_fuelPointControl2"
      Me._fuelPointControl2.PTS = Nothing
      Me._fuelPointControl2.Size = New System.Drawing.Size(92, 117)
      Me._fuelPointControl2.TabIndex = 1
      '
      '_fuelPointControl1
      '
      Me._fuelPointControl1.BackColor = System.Drawing.Color.LightYellow
      Me._fuelPointControl1.FuelPointID = Nothing
      Me._fuelPointControl1.IsDispensing = False
      Me._fuelPointControl1.IsLocked = False
      Me._fuelPointControl1.Location = New System.Drawing.Point(3, 3)
      Me._fuelPointControl1.Name = "_fuelPointControl1"
      Me._fuelPointControl1.PTS = Nothing
      Me._fuelPointControl1.Size = New System.Drawing.Size(92, 117)
      Me._fuelPointControl1.TabIndex = 0
      '
      'Panel1
      '
      Me.Panel1.Controls.Add(Me.tableLayoutPanel)
      Me.Panel1.Location = New System.Drawing.Point(12, 28)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(395, 492)
      Me.Panel1.TabIndex = 4
      '
      'toolStripLabel1
      '
      Me.toolStripLabel1.Name = "toolStripLabel1"
      Me.toolStripLabel1.Size = New System.Drawing.Size(63, 22)
      Me.toolStripLabel1.Text = "COM port:"
      '
      'portListComboBox
      '
      Me.portListComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.portListComboBox.Name = "portListComboBox"
      Me.portListComboBox.Size = New System.Drawing.Size(75, 25)
      '
      'toolStrip
      '
      Me.toolStrip.BackColor = System.Drawing.Color.RoyalBlue
      Me.toolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripLabel1, Me.portListComboBox, Me.portConnectionButton})
      Me.toolStrip.Location = New System.Drawing.Point(0, 0)
      Me.toolStrip.Name = "toolStrip"
      Me.toolStrip.Size = New System.Drawing.Size(1350, 25)
      Me.toolStrip.TabIndex = 2
      '
      'portConnectionButton
      '
      Me.portConnectionButton.CheckOnClick = True
      Me.portConnectionButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.portConnectionButton.Image = CType(resources.GetObject("portConnectionButton.Image"), System.Drawing.Image)
      Me.portConnectionButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.portConnectionButton.Name = "portConnectionButton"
      Me.portConnectionButton.Size = New System.Drawing.Size(23, 22)
      '
      'Label13
      '
      Me.Label13.AutoSize = True
      Me.Label13.BackColor = System.Drawing.Color.RoyalBlue
      Me.Label13.Font = New System.Drawing.Font("Verdana", 9.75!)
      Me.Label13.ForeColor = System.Drawing.Color.White
      Me.Label13.Location = New System.Drawing.Point(174, 4)
      Me.Label13.Name = "Label13"
      Me.Label13.Size = New System.Drawing.Size(57, 16)
      Me.Label13.TabIndex = 260
      Me.Label13.Text = "UserID:"
      '
      'txtuser
      '
      Me.txtuser.AutoSize = True
      Me.txtuser.BackColor = System.Drawing.Color.RoyalBlue
      Me.txtuser.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtuser.ForeColor = System.Drawing.Color.White
      Me.txtuser.Location = New System.Drawing.Point(228, 0)
      Me.txtuser.Name = "txtuser"
      Me.txtuser.Size = New System.Drawing.Size(66, 23)
      Me.txtuser.TabIndex = 262
      Me.txtuser.Text = "None"
      '
      'Label14
      '
      Me.Label14.AutoSize = True
      Me.Label14.BackColor = System.Drawing.Color.RoyalBlue
      Me.Label14.Font = New System.Drawing.Font("Verdana", 9.75!)
      Me.Label14.ForeColor = System.Drawing.Color.White
      Me.Label14.Location = New System.Drawing.Point(291, 4)
      Me.Label14.Name = "Label14"
      Me.Label14.Size = New System.Drawing.Size(50, 16)
      Me.Label14.TabIndex = 261
      Me.Label14.Text = "Name:"
      '
      'txtusername
      '
      Me.txtusername.AutoSize = True
      Me.txtusername.BackColor = System.Drawing.Color.RoyalBlue
      Me.txtusername.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtusername.ForeColor = System.Drawing.Color.White
      Me.txtusername.Location = New System.Drawing.Point(338, 0)
      Me.txtusername.Name = "txtusername"
      Me.txtusername.Size = New System.Drawing.Size(66, 23)
      Me.txtusername.TabIndex = 263
      Me.txtusername.Text = "None"
      '
      'DataGridView1
      '
      Me.DataGridView1.AllowUserToAddRows = False
      Me.DataGridView1.AllowUserToDeleteRows = False
      DataGridViewCellStyle8.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle8
      Me.DataGridView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
      Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
      Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
      DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle9.BackColor = System.Drawing.Color.RoyalBlue
      DataGridViewCellStyle9.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle9.ForeColor = System.Drawing.Color.White
      DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
      Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.DataGridView1.Cursor = System.Windows.Forms.Cursors.Hand
      Me.DataGridView1.EnableHeadersVisualStyles = False
      Me.DataGridView1.GridColor = System.Drawing.Color.LightSkyBlue
      Me.DataGridView1.Location = New System.Drawing.Point(655, 48)
      Me.DataGridView1.Name = "DataGridView1"
      Me.DataGridView1.ReadOnly = True
      Me.DataGridView1.RowHeadersVisible = False
      Me.DataGridView1.RowHeadersWidth = 25
      DataGridViewCellStyle10.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold)
      Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle10
      Me.DataGridView1.Size = New System.Drawing.Size(695, 231)
      Me.DataGridView1.TabIndex = 268
      '
      'DataGridView2
      '
      Me.DataGridView2.AllowUserToAddRows = False
      Me.DataGridView2.AllowUserToDeleteRows = False
      DataGridViewCellStyle11.Font = New System.Drawing.Font("Verdana", 10.0!)
      Me.DataGridView2.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle11
      Me.DataGridView2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.DataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
      Me.DataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
      Me.DataGridView2.BackgroundColor = System.Drawing.Color.White
      DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle12.BackColor = System.Drawing.Color.DimGray
      DataGridViewCellStyle12.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
      DataGridViewCellStyle12.ForeColor = System.Drawing.Color.White
      DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.DataGridView2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle12
      Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ItemLookUp, Me.Description, Me.Quantity, Me.UnitPrice, Me.Amount, Me.Discount, Me.pointw, Me.pointx, Me.IDZ, Me.Column1})
      Me.DataGridView2.Cursor = System.Windows.Forms.Cursors.Hand
      Me.DataGridView2.EnableHeadersVisualStyles = False
      Me.DataGridView2.GridColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
      Me.DataGridView2.Location = New System.Drawing.Point(655, 285)
      Me.DataGridView2.Name = "DataGridView2"
      Me.DataGridView2.ReadOnly = True
      DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle13.BackColor = System.Drawing.Color.White
      DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.DataGridView2.RowHeadersDefaultCellStyle = DataGridViewCellStyle13
      Me.DataGridView2.RowHeadersVisible = False
      Me.DataGridView2.RowHeadersWidth = 30
      DataGridViewCellStyle14.Font = New System.Drawing.Font("Verdana", 10.25!)
      DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
      Me.DataGridView2.RowsDefaultCellStyle = DataGridViewCellStyle14
      Me.DataGridView2.Size = New System.Drawing.Size(695, 235)
      Me.DataGridView2.TabIndex = 271
      '
      'ItemLookUp
      '
      Me.ItemLookUp.HeaderText = "Item Look Up Code"
      Me.ItemLookUp.Name = "ItemLookUp"
      Me.ItemLookUp.ReadOnly = True
      Me.ItemLookUp.Width = 132
      '
      'Description
      '
      Me.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
      Me.Description.FillWeight = 75.0!
      Me.Description.HeaderText = "Description"
      Me.Description.Name = "Description"
      Me.Description.ReadOnly = True
      '
      'Quantity
      '
      Me.Quantity.HeaderText = "Qty"
      Me.Quantity.Name = "Quantity"
      Me.Quantity.ReadOnly = True
      Me.Quantity.Width = 60
      '
      'UnitPrice
      '
      Me.UnitPrice.HeaderText = "Unit Price"
      Me.UnitPrice.Name = "UnitPrice"
      Me.UnitPrice.ReadOnly = True
      Me.UnitPrice.ToolTipText = "0"
      Me.UnitPrice.Width = 98
      '
      'Amount
      '
      Me.Amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
      Me.Amount.FillWeight = 50.0!
      Me.Amount.HeaderText = "Amount"
      Me.Amount.Name = "Amount"
      Me.Amount.ReadOnly = True
      '
      'Discount
      '
      Me.Discount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
      Me.Discount.FillWeight = 40.0!
      Me.Discount.HeaderText = "Discount"
      Me.Discount.Name = "Discount"
      Me.Discount.ReadOnly = True
      Me.Discount.ToolTipText = "0"
      '
      'pointw
      '
      Me.pointw.HeaderText = "pointw"
      Me.pointw.MinimumWidth = 2
      Me.pointw.Name = "pointw"
      Me.pointw.ReadOnly = True
      Me.pointw.Visible = False
      Me.pointw.Width = 87
      '
      'pointx
      '
      Me.pointx.HeaderText = "pointx"
      Me.pointx.MinimumWidth = 2
      Me.pointx.Name = "pointx"
      Me.pointx.ReadOnly = True
      Me.pointx.Visible = False
      Me.pointx.Width = 82
      '
      'IDZ
      '
      Me.IDZ.HeaderText = "IDZ"
      Me.IDZ.Name = "IDZ"
      Me.IDZ.ReadOnly = True
      Me.IDZ.Visible = False
      Me.IDZ.Width = 62
      '
      'Column1
      '
      Me.Column1.HeaderText = "Column1"
      Me.Column1.Name = "Column1"
      Me.Column1.ReadOnly = True
      Me.Column1.Visible = False
      Me.Column1.Width = 102
      '
      'Panel2
      '
      Me.Panel2.Controls.Add(Me.btdot)
      Me.Panel2.Controls.Add(Me.bt00)
      Me.Panel2.Controls.Add(Me.bt0)
      Me.Panel2.Controls.Add(Me.bt1)
      Me.Panel2.Controls.Add(Me.bt2)
      Me.Panel2.Controls.Add(Me.bt3)
      Me.Panel2.Controls.Add(Me.bt6)
      Me.Panel2.Controls.Add(Me.bt5)
      Me.Panel2.Controls.Add(Me.bt4)
      Me.Panel2.Controls.Add(Me.bt9)
      Me.Panel2.Controls.Add(Me.bt8)
      Me.Panel2.Controls.Add(Me.bt7)
      Me.Panel2.Controls.Add(Me.bt1000)
      Me.Panel2.Controls.Add(Me.bt500)
      Me.Panel2.Controls.Add(Me.bt400)
      Me.Panel2.Controls.Add(Me.bt300)
      Me.Panel2.Controls.Add(Me.bt200)
      Me.Panel2.Controls.Add(Me.bt100)
      Me.Panel2.Location = New System.Drawing.Point(413, 31)
      Me.Panel2.Name = "Panel2"
      Me.Panel2.Size = New System.Drawing.Size(236, 281)
      Me.Panel2.TabIndex = 279
      '
      'btdot
      '
      Me.btdot.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btdot.BackColor = System.Drawing.Color.White
      Me.btdot.BackgroundImage = CType(resources.GetObject("btdot.BackgroundImage"), System.Drawing.Image)
      Me.btdot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
      Me.btdot.Cursor = System.Windows.Forms.Cursors.Hand
      Me.btdot.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.btdot.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btdot.ForeColor = System.Drawing.Color.White
      Me.btdot.Location = New System.Drawing.Point(178, 111)
      Me.btdot.Name = "btdot"
      Me.btdot.Size = New System.Drawing.Size(56, 52)
      Me.btdot.TabIndex = 104
      Me.btdot.Text = "."
      Me.btdot.UseVisualStyleBackColor = False
      '
      'bt00
      '
      Me.bt00.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.bt00.BackColor = System.Drawing.Color.White
      Me.bt00.BackgroundImage = CType(resources.GetObject("bt00.BackgroundImage"), System.Drawing.Image)
      Me.bt00.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
      Me.bt00.Cursor = System.Windows.Forms.Cursors.Hand
      Me.bt00.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.bt00.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bt00.ForeColor = System.Drawing.Color.White
      Me.bt00.Location = New System.Drawing.Point(120, 111)
      Me.bt00.Name = "bt00"
      Me.bt00.Size = New System.Drawing.Size(56, 52)
      Me.bt00.TabIndex = 103
      Me.bt00.Text = "00"
      Me.bt00.UseVisualStyleBackColor = False
      '
      'bt0
      '
      Me.bt0.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.bt0.BackColor = System.Drawing.Color.White
      Me.bt0.BackgroundImage = CType(resources.GetObject("bt0.BackgroundImage"), System.Drawing.Image)
      Me.bt0.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
      Me.bt0.Cursor = System.Windows.Forms.Cursors.Hand
      Me.bt0.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.bt0.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bt0.ForeColor = System.Drawing.Color.White
      Me.bt0.Location = New System.Drawing.Point(62, 111)
      Me.bt0.Name = "bt0"
      Me.bt0.Size = New System.Drawing.Size(56, 52)
      Me.bt0.TabIndex = 102
      Me.bt0.Text = "0"
      Me.bt0.UseVisualStyleBackColor = False
      '
      'bt1
      '
      Me.bt1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.bt1.BackColor = System.Drawing.Color.White
      Me.bt1.BackgroundImage = CType(resources.GetObject("bt1.BackgroundImage"), System.Drawing.Image)
      Me.bt1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
      Me.bt1.Cursor = System.Windows.Forms.Cursors.Hand
      Me.bt1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.bt1.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bt1.ForeColor = System.Drawing.Color.White
      Me.bt1.Location = New System.Drawing.Point(4, 3)
      Me.bt1.Name = "bt1"
      Me.bt1.Size = New System.Drawing.Size(56, 52)
      Me.bt1.TabIndex = 101
      Me.bt1.Text = "1"
      Me.bt1.UseVisualStyleBackColor = False
      '
      'bt2
      '
      Me.bt2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.bt2.BackColor = System.Drawing.Color.White
      Me.bt2.BackgroundImage = CType(resources.GetObject("bt2.BackgroundImage"), System.Drawing.Image)
      Me.bt2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
      Me.bt2.Cursor = System.Windows.Forms.Cursors.Hand
      Me.bt2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.bt2.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bt2.ForeColor = System.Drawing.Color.White
      Me.bt2.Location = New System.Drawing.Point(62, 3)
      Me.bt2.Name = "bt2"
      Me.bt2.Size = New System.Drawing.Size(56, 52)
      Me.bt2.TabIndex = 100
      Me.bt2.Text = "2"
      Me.bt2.UseVisualStyleBackColor = False
      '
      'bt3
      '
      Me.bt3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.bt3.BackColor = System.Drawing.Color.White
      Me.bt3.BackgroundImage = CType(resources.GetObject("bt3.BackgroundImage"), System.Drawing.Image)
      Me.bt3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
      Me.bt3.Cursor = System.Windows.Forms.Cursors.Hand
      Me.bt3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.bt3.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bt3.ForeColor = System.Drawing.Color.White
      Me.bt3.Location = New System.Drawing.Point(120, 3)
      Me.bt3.Name = "bt3"
      Me.bt3.Size = New System.Drawing.Size(56, 52)
      Me.bt3.TabIndex = 99
      Me.bt3.Text = "3"
      Me.bt3.UseVisualStyleBackColor = False
      '
      'bt6
      '
      Me.bt6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.bt6.BackColor = System.Drawing.Color.White
      Me.bt6.BackgroundImage = CType(resources.GetObject("bt6.BackgroundImage"), System.Drawing.Image)
      Me.bt6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
      Me.bt6.Cursor = System.Windows.Forms.Cursors.Hand
      Me.bt6.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.bt6.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bt6.ForeColor = System.Drawing.Color.White
      Me.bt6.Location = New System.Drawing.Point(62, 57)
      Me.bt6.Name = "bt6"
      Me.bt6.Size = New System.Drawing.Size(56, 52)
      Me.bt6.TabIndex = 98
      Me.bt6.Text = "6"
      Me.bt6.UseVisualStyleBackColor = False
      '
      'bt5
      '
      Me.bt5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.bt5.BackColor = System.Drawing.Color.White
      Me.bt5.BackgroundImage = CType(resources.GetObject("bt5.BackgroundImage"), System.Drawing.Image)
      Me.bt5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
      Me.bt5.Cursor = System.Windows.Forms.Cursors.Hand
      Me.bt5.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.bt5.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bt5.ForeColor = System.Drawing.Color.White
      Me.bt5.Location = New System.Drawing.Point(4, 57)
      Me.bt5.Name = "bt5"
      Me.bt5.Size = New System.Drawing.Size(56, 52)
      Me.bt5.TabIndex = 97
      Me.bt5.Text = "5"
      Me.bt5.UseVisualStyleBackColor = False
      '
      'bt4
      '
      Me.bt4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.bt4.BackColor = System.Drawing.Color.White
      Me.bt4.BackgroundImage = CType(resources.GetObject("bt4.BackgroundImage"), System.Drawing.Image)
      Me.bt4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
      Me.bt4.Cursor = System.Windows.Forms.Cursors.Hand
      Me.bt4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.bt4.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bt4.ForeColor = System.Drawing.Color.White
      Me.bt4.Location = New System.Drawing.Point(178, 3)
      Me.bt4.Name = "bt4"
      Me.bt4.Size = New System.Drawing.Size(56, 52)
      Me.bt4.TabIndex = 96
      Me.bt4.Text = "4"
      Me.bt4.UseVisualStyleBackColor = False
      '
      'bt9
      '
      Me.bt9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.bt9.BackColor = System.Drawing.Color.White
      Me.bt9.BackgroundImage = CType(resources.GetObject("bt9.BackgroundImage"), System.Drawing.Image)
      Me.bt9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
      Me.bt9.Cursor = System.Windows.Forms.Cursors.Hand
      Me.bt9.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.bt9.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bt9.ForeColor = System.Drawing.Color.White
      Me.bt9.Location = New System.Drawing.Point(4, 111)
      Me.bt9.Name = "bt9"
      Me.bt9.Size = New System.Drawing.Size(56, 52)
      Me.bt9.TabIndex = 95
      Me.bt9.Text = "9"
      Me.bt9.UseVisualStyleBackColor = False
      '
      'bt8
      '
      Me.bt8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.bt8.BackColor = System.Drawing.Color.White
      Me.bt8.BackgroundImage = CType(resources.GetObject("bt8.BackgroundImage"), System.Drawing.Image)
      Me.bt8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
      Me.bt8.Cursor = System.Windows.Forms.Cursors.Hand
      Me.bt8.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.bt8.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bt8.ForeColor = System.Drawing.Color.White
      Me.bt8.Location = New System.Drawing.Point(178, 57)
      Me.bt8.Name = "bt8"
      Me.bt8.Size = New System.Drawing.Size(56, 52)
      Me.bt8.TabIndex = 94
      Me.bt8.Text = "8"
      Me.bt8.UseVisualStyleBackColor = False
      '
      'bt7
      '
      Me.bt7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.bt7.BackColor = System.Drawing.Color.White
      Me.bt7.BackgroundImage = CType(resources.GetObject("bt7.BackgroundImage"), System.Drawing.Image)
      Me.bt7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
      Me.bt7.Cursor = System.Windows.Forms.Cursors.Hand
      Me.bt7.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.bt7.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bt7.ForeColor = System.Drawing.Color.White
      Me.bt7.Location = New System.Drawing.Point(120, 57)
      Me.bt7.Name = "bt7"
      Me.bt7.Size = New System.Drawing.Size(56, 52)
      Me.bt7.TabIndex = 93
      Me.bt7.Text = "7"
      Me.bt7.UseVisualStyleBackColor = False
      '
      'bt1000
      '
      Me.bt1000.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.bt1000.BackColor = System.Drawing.Color.White
      Me.bt1000.BackgroundImage = CType(resources.GetObject("bt1000.BackgroundImage"), System.Drawing.Image)
      Me.bt1000.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
      Me.bt1000.Cursor = System.Windows.Forms.Cursors.Hand
      Me.bt1000.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.bt1000.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bt1000.ForeColor = System.Drawing.Color.White
      Me.bt1000.Location = New System.Drawing.Point(159, 225)
      Me.bt1000.Name = "bt1000"
      Me.bt1000.Size = New System.Drawing.Size(75, 54)
      Me.bt1000.TabIndex = 92
      Me.bt1000.Text = "P1000"
      Me.bt1000.UseVisualStyleBackColor = False
      '
      'bt500
      '
      Me.bt500.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.bt500.BackColor = System.Drawing.Color.White
      Me.bt500.BackgroundImage = CType(resources.GetObject("bt500.BackgroundImage"), System.Drawing.Image)
      Me.bt500.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
      Me.bt500.Cursor = System.Windows.Forms.Cursors.Hand
      Me.bt500.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.bt500.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bt500.ForeColor = System.Drawing.Color.White
      Me.bt500.Location = New System.Drawing.Point(82, 225)
      Me.bt500.Name = "bt500"
      Me.bt500.Size = New System.Drawing.Size(74, 54)
      Me.bt500.TabIndex = 91
      Me.bt500.Text = "P500"
      Me.bt500.UseVisualStyleBackColor = False
      '
      'bt400
      '
      Me.bt400.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.bt400.BackColor = System.Drawing.Color.White
      Me.bt400.BackgroundImage = CType(resources.GetObject("bt400.BackgroundImage"), System.Drawing.Image)
      Me.bt400.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
      Me.bt400.Cursor = System.Windows.Forms.Cursors.Hand
      Me.bt400.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.bt400.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bt400.ForeColor = System.Drawing.Color.White
      Me.bt400.Location = New System.Drawing.Point(4, 225)
      Me.bt400.Name = "bt400"
      Me.bt400.Size = New System.Drawing.Size(76, 54)
      Me.bt400.TabIndex = 90
      Me.bt400.Text = "P400"
      Me.bt400.UseVisualStyleBackColor = False
      '
      'bt300
      '
      Me.bt300.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.bt300.BackColor = System.Drawing.Color.White
      Me.bt300.BackgroundImage = CType(resources.GetObject("bt300.BackgroundImage"), System.Drawing.Image)
      Me.bt300.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
      Me.bt300.Cursor = System.Windows.Forms.Cursors.Hand
      Me.bt300.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.bt300.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bt300.ForeColor = System.Drawing.Color.White
      Me.bt300.Location = New System.Drawing.Point(159, 169)
      Me.bt300.Name = "bt300"
      Me.bt300.Size = New System.Drawing.Size(75, 54)
      Me.bt300.TabIndex = 89
      Me.bt300.Text = "P300"
      Me.bt300.UseVisualStyleBackColor = False
      '
      'bt200
      '
      Me.bt200.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.bt200.BackColor = System.Drawing.Color.White
      Me.bt200.BackgroundImage = CType(resources.GetObject("bt200.BackgroundImage"), System.Drawing.Image)
      Me.bt200.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
      Me.bt200.Cursor = System.Windows.Forms.Cursors.Hand
      Me.bt200.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.bt200.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bt200.ForeColor = System.Drawing.Color.White
      Me.bt200.Location = New System.Drawing.Point(82, 169)
      Me.bt200.Name = "bt200"
      Me.bt200.Size = New System.Drawing.Size(74, 54)
      Me.bt200.TabIndex = 88
      Me.bt200.Text = "P200"
      Me.bt200.UseVisualStyleBackColor = False
      '
      'bt100
      '
      Me.bt100.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.bt100.BackColor = System.Drawing.Color.White
      Me.bt100.BackgroundImage = CType(resources.GetObject("bt100.BackgroundImage"), System.Drawing.Image)
      Me.bt100.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
      Me.bt100.Cursor = System.Windows.Forms.Cursors.Hand
      Me.bt100.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.bt100.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bt100.ForeColor = System.Drawing.Color.White
      Me.bt100.Location = New System.Drawing.Point(4, 169)
      Me.bt100.Name = "bt100"
      Me.bt100.Size = New System.Drawing.Size(76, 54)
      Me.bt100.TabIndex = 87
      Me.bt100.Text = "P100"
      Me.bt100.UseVisualStyleBackColor = False
      '
      'Panel3
      '
      Me.Panel3.Controls.Add(Me.txtcash)
      Me.Panel3.Controls.Add(Me.Label4)
      Me.Panel3.Controls.Add(Me.txtPlateNo)
      Me.Panel3.Controls.Add(Me.Label7)
      Me.Panel3.Controls.Add(Me.txtDN)
      Me.Panel3.Controls.Add(Me.Label10)
      Me.Panel3.Controls.Add(Me.txtact)
      Me.Panel3.Controls.Add(Me.Label9)
      Me.Panel3.Controls.Add(Me.txtname)
      Me.Panel3.Controls.Add(Me.Label3)
      Me.Panel3.Location = New System.Drawing.Point(413, 316)
      Me.Panel3.Name = "Panel3"
      Me.Panel3.Size = New System.Drawing.Size(236, 204)
      Me.Panel3.TabIndex = 280
      '
      'txtcash
      '
      Me.txtcash.BackColor = System.Drawing.Color.White
      Me.txtcash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.txtcash.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
      Me.txtcash.Dock = System.Windows.Forms.DockStyle.Top
      Me.txtcash.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
      Me.txtcash.Location = New System.Drawing.Point(0, 142)
      Me.txtcash.Name = "txtcash"
      Me.txtcash.Size = New System.Drawing.Size(236, 24)
      Me.txtcash.TabIndex = 176
      Me.txtcash.Text = "0"
      Me.txtcash.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.BackColor = System.Drawing.Color.Transparent
      Me.Label4.Dock = System.Windows.Forms.DockStyle.Top
      Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label4.Location = New System.Drawing.Point(0, 129)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(91, 13)
      Me.Label4.TabIndex = 177
      Me.Label4.Text = "CASH PAYMENT"
      '
      'txtPlateNo
      '
      Me.txtPlateNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
      Me.txtPlateNo.Dock = System.Windows.Forms.DockStyle.Top
      Me.txtPlateNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtPlateNo.Location = New System.Drawing.Point(0, 109)
      Me.txtPlateNo.Name = "txtPlateNo"
      Me.txtPlateNo.Size = New System.Drawing.Size(236, 20)
      Me.txtPlateNo.TabIndex = 170
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.BackColor = System.Drawing.Color.Transparent
      Me.Label7.Dock = System.Windows.Forms.DockStyle.Top
      Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label7.Location = New System.Drawing.Point(0, 96)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(74, 13)
      Me.Label7.TabIndex = 175
      Me.Label7.Text = "Plate Number:"
      '
      'txtDN
      '
      Me.txtDN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
      Me.txtDN.Dock = System.Windows.Forms.DockStyle.Top
      Me.txtDN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtDN.Location = New System.Drawing.Point(0, 76)
      Me.txtDN.Name = "txtDN"
      Me.txtDN.Size = New System.Drawing.Size(236, 20)
      Me.txtDN.TabIndex = 169
      '
      'Label10
      '
      Me.Label10.AutoSize = True
      Me.Label10.BackColor = System.Drawing.Color.Transparent
      Me.Label10.Dock = System.Windows.Forms.DockStyle.Top
      Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label10.Location = New System.Drawing.Point(0, 63)
      Me.Label10.Name = "Label10"
      Me.Label10.Size = New System.Drawing.Size(118, 13)
      Me.Label10.TabIndex = 174
      Me.Label10.Text = "Driver Name/Comment:"
      '
      'txtact
      '
      Me.txtact.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
      Me.txtact.Dock = System.Windows.Forms.DockStyle.Top
      Me.txtact.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtact.Location = New System.Drawing.Point(0, 43)
      Me.txtact.Name = "txtact"
      Me.txtact.Size = New System.Drawing.Size(236, 20)
      Me.txtact.TabIndex = 168
      '
      'Label9
      '
      Me.Label9.AutoSize = True
      Me.Label9.BackColor = System.Drawing.Color.Transparent
      Me.Label9.Dock = System.Windows.Forms.DockStyle.Top
      Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label9.Location = New System.Drawing.Point(0, 30)
      Me.Label9.Name = "Label9"
      Me.Label9.Size = New System.Drawing.Size(70, 13)
      Me.Label9.TabIndex = 173
      Me.Label9.Text = "Account No.:"
      '
      'txtname
      '
      Me.txtname.AutoSize = True
      Me.txtname.BackColor = System.Drawing.Color.Transparent
      Me.txtname.Dock = System.Windows.Forms.DockStyle.Top
      Me.txtname.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
      Me.txtname.Location = New System.Drawing.Point(0, 13)
      Me.txtname.Name = "txtname"
      Me.txtname.Size = New System.Drawing.Size(48, 17)
      Me.txtname.TabIndex = 172
      Me.txtname.Text = "None"
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.BackColor = System.Drawing.Color.Transparent
      Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
      Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label3.Location = New System.Drawing.Point(0, 0)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(81, 13)
      Me.Label3.TabIndex = 171
      Me.Label3.Text = "Account Name:"
      '
      'Panel12
      '
      Me.Panel12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Panel12.BackColor = System.Drawing.Color.Gray
      Me.Panel12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
      Me.Panel12.Controls.Add(Me.txtplussd)
      Me.Panel12.Controls.Add(Me.txttax)
      Me.Panel12.Controls.Add(Me.txtdis)
      Me.Panel12.Controls.Add(Me.Label6)
      Me.Panel12.Controls.Add(Me.TXTVAT)
      Me.Panel12.Controls.Add(Me.txtvT)
      Me.Panel12.Location = New System.Drawing.Point(1060, 521)
      Me.Panel12.Name = "Panel12"
      Me.Panel12.Size = New System.Drawing.Size(290, 93)
      Me.Panel12.TabIndex = 282
      '
      'txtplussd
      '
      Me.txtplussd.Anchor = System.Windows.Forms.AnchorStyles.Right
      Me.txtplussd.AutoSize = True
      Me.txtplussd.BackColor = System.Drawing.Color.Transparent
      Me.txtplussd.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtplussd.ForeColor = System.Drawing.Color.Transparent
      Me.txtplussd.Location = New System.Drawing.Point(210, 68)
      Me.txtplussd.Name = "txtplussd"
      Me.txtplussd.Size = New System.Drawing.Size(78, 18)
      Me.txtplussd.TabIndex = 0
      Me.txtplussd.Text = "Discount"
      '
      'txttax
      '
      Me.txttax.AutoSize = True
      Me.txttax.BackColor = System.Drawing.Color.Transparent
      Me.txttax.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold)
      Me.txttax.ForeColor = System.Drawing.Color.Transparent
      Me.txttax.Location = New System.Drawing.Point(8, 7)
      Me.txttax.Name = "txttax"
      Me.txttax.Size = New System.Drawing.Size(65, 25)
      Me.txttax.TabIndex = 7
      Me.txttax.Text = "0.00"
      '
      'txtdis
      '
      Me.txtdis.AutoSize = True
      Me.txtdis.BackColor = System.Drawing.Color.Transparent
      Me.txtdis.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold)
      Me.txtdis.ForeColor = System.Drawing.Color.Transparent
      Me.txtdis.Location = New System.Drawing.Point(7, 65)
      Me.txtdis.Name = "txtdis"
      Me.txtdis.Size = New System.Drawing.Size(65, 25)
      Me.txtdis.TabIndex = 7
      Me.txtdis.Text = "0.00"
      '
      'Label6
      '
      Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Right
      Me.Label6.AutoSize = True
      Me.Label6.BackColor = System.Drawing.Color.Transparent
      Me.Label6.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label6.ForeColor = System.Drawing.Color.Transparent
      Me.Label6.Location = New System.Drawing.Point(247, 10)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(38, 18)
      Me.Label6.TabIndex = 8
      Me.Label6.Text = "Tax"
      '
      'TXTVAT
      '
      Me.TXTVAT.AutoSize = True
      Me.TXTVAT.BackColor = System.Drawing.Color.Transparent
      Me.TXTVAT.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold)
      Me.TXTVAT.ForeColor = System.Drawing.Color.Transparent
      Me.TXTVAT.Location = New System.Drawing.Point(7, 35)
      Me.TXTVAT.Name = "TXTVAT"
      Me.TXTVAT.Size = New System.Drawing.Size(65, 25)
      Me.TXTVAT.TabIndex = 7
      Me.TXTVAT.Text = "0.00"
      '
      'txtvT
      '
      Me.txtvT.Anchor = System.Windows.Forms.AnchorStyles.Right
      Me.txtvT.AutoSize = True
      Me.txtvT.BackColor = System.Drawing.Color.Transparent
      Me.txtvT.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtvT.ForeColor = System.Drawing.Color.Transparent
      Me.txtvT.Location = New System.Drawing.Point(220, 39)
      Me.txtvT.Name = "txtvT"
      Me.txtvT.Size = New System.Drawing.Size(70, 18)
      Me.txtvT.TabIndex = 8
      Me.txtvT.Text = "Vatable"
      '
      'DateTimePicker2
      '
      Me.DateTimePicker2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.DateTimePicker2.CustomFormat = "MM/dd/ yyyy/ hh:mm:ss tt"
      Me.DateTimePicker2.Enabled = False
      Me.DateTimePicker2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.DateTimePicker2.Location = New System.Drawing.Point(1130, 0)
      Me.DateTimePicker2.Name = "DateTimePicker2"
      Me.DateTimePicker2.Size = New System.Drawing.Size(213, 23)
      Me.DateTimePicker2.TabIndex = 267
      '
      'Label16
      '
      Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label16.AutoSize = True
      Me.Label16.BackColor = System.Drawing.Color.RoyalBlue
      Me.Label16.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label16.ForeColor = System.Drawing.Color.White
      Me.Label16.Location = New System.Drawing.Point(1047, 2)
      Me.Label16.Name = "Label16"
      Me.Label16.Size = New System.Drawing.Size(78, 16)
      Me.Label16.TabIndex = 266
      Me.Label16.Text = "Date Now:"
      '
      'DateTimePicker1
      '
      Me.DateTimePicker1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.DateTimePicker1.CustomFormat = "MM/dd/ yyyy/ hh:mm:ss tt"
      Me.DateTimePicker1.Enabled = False
      Me.DateTimePicker1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.DateTimePicker1.Location = New System.Drawing.Point(818, 0)
      Me.DateTimePicker1.Name = "DateTimePicker1"
      Me.DateTimePicker1.Size = New System.Drawing.Size(213, 23)
      Me.DateTimePicker1.TabIndex = 265
      '
      'Label15
      '
      Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label15.AutoSize = True
      Me.Label15.BackColor = System.Drawing.Color.RoyalBlue
      Me.Label15.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label15.ForeColor = System.Drawing.Color.White
      Me.Label15.Location = New System.Drawing.Point(721, 3)
      Me.Label15.Name = "Label15"
      Me.Label15.Size = New System.Drawing.Size(100, 16)
      Me.Label15.TabIndex = 264
      Me.Label15.Text = "Date Started:"
      '
      'Timer1
      '
      Me.Timer1.Enabled = True
      '
      'TabPage3
      '
      Me.TabPage3.Controls.Add(Me.TableLayoutPanel5)
      Me.TabPage3.Location = New System.Drawing.Point(4, 25)
      Me.TabPage3.Name = "TabPage3"
      Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
      Me.TabPage3.Size = New System.Drawing.Size(626, 152)
      Me.TabPage3.TabIndex = 2
      Me.TabPage3.Text = "OTHER"
      Me.TabPage3.UseVisualStyleBackColor = True
      '
      'TableLayoutPanel5
      '
      Me.TableLayoutPanel5.ColumnCount = 5
      Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
      Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
      Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
      Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
      Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
      Me.TableLayoutPanel5.Controls.Add(Me.btlastdrop, 3, 0)
      Me.TableLayoutPanel5.Controls.Add(Me.btCashdrop, 2, 0)
      Me.TableLayoutPanel5.Controls.Add(Me.btvoid, 0, 1)
      Me.TableLayoutPanel5.Controls.Add(Me.bddiscount, 0, 1)
      Me.TableLayoutPanel5.Controls.Add(Me.Button11, 4, 1)
      Me.TableLayoutPanel5.Controls.Add(Me.Button12, 1, 1)
      Me.TableLayoutPanel5.Controls.Add(Me.Button13, 2, 1)
      Me.TableLayoutPanel5.Controls.Add(Me.btsplit, 0, 0)
      Me.TableLayoutPanel5.Controls.Add(Me.btcalibration, 1, 0)
      Me.TableLayoutPanel5.Controls.Add(Me.btpayout, 4, 0)
      Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
      Me.TableLayoutPanel5.Location = New System.Drawing.Point(3, 3)
      Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
      Me.TableLayoutPanel5.RowCount = 2
      Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
      Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
      Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
      Me.TableLayoutPanel5.Size = New System.Drawing.Size(620, 146)
      Me.TableLayoutPanel5.TabIndex = 1
      '
      'btlastdrop
      '
      Me.btlastdrop.BackColor = System.Drawing.Color.White
      Me.btlastdrop.BackgroundImage = CType(resources.GetObject("btlastdrop.BackgroundImage"), System.Drawing.Image)
      Me.btlastdrop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
      Me.btlastdrop.Cursor = System.Windows.Forms.Cursors.Hand
      Me.btlastdrop.Dock = System.Windows.Forms.DockStyle.Fill
      Me.btlastdrop.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
      Me.btlastdrop.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.btlastdrop.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btlastdrop.ForeColor = System.Drawing.Color.White
      Me.btlastdrop.Location = New System.Drawing.Point(375, 3)
      Me.btlastdrop.Name = "btlastdrop"
      Me.btlastdrop.Size = New System.Drawing.Size(118, 67)
      Me.btlastdrop.TabIndex = 287
      Me.btlastdrop.Text = " LAST DROP"
      Me.btlastdrop.UseVisualStyleBackColor = False
      '
      'btCashdrop
      '
      Me.btCashdrop.BackColor = System.Drawing.Color.White
      Me.btCashdrop.BackgroundImage = CType(resources.GetObject("btCashdrop.BackgroundImage"), System.Drawing.Image)
      Me.btCashdrop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
      Me.btCashdrop.Cursor = System.Windows.Forms.Cursors.Hand
      Me.btCashdrop.Dock = System.Windows.Forms.DockStyle.Fill
      Me.btCashdrop.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
      Me.btCashdrop.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.btCashdrop.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btCashdrop.ForeColor = System.Drawing.Color.White
      Me.btCashdrop.Location = New System.Drawing.Point(251, 3)
      Me.btCashdrop.Name = "btCashdrop"
      Me.btCashdrop.Size = New System.Drawing.Size(118, 67)
      Me.btCashdrop.TabIndex = 287
      Me.btCashdrop.Text = "SAFE DROP"
      Me.btCashdrop.UseVisualStyleBackColor = False
      '
      'btvoid
      '
      Me.btvoid.BackColor = System.Drawing.Color.White
      Me.btvoid.BackgroundImage = CType(resources.GetObject("btvoid.BackgroundImage"), System.Drawing.Image)
      Me.btvoid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
      Me.btvoid.Cursor = System.Windows.Forms.Cursors.Hand
      Me.btvoid.Dock = System.Windows.Forms.DockStyle.Fill
      Me.btvoid.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
      Me.btvoid.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.btvoid.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold)
      Me.btvoid.ForeColor = System.Drawing.Color.White
      Me.btvoid.Location = New System.Drawing.Point(3, 76)
      Me.btvoid.Name = "btvoid"
      Me.btvoid.Size = New System.Drawing.Size(118, 67)
      Me.btvoid.TabIndex = 234
      Me.btvoid.Text = "VOID"
      Me.btvoid.UseVisualStyleBackColor = False
      '
      'bddiscount
      '
      Me.bddiscount.BackColor = System.Drawing.Color.White
      Me.bddiscount.BackgroundImage = CType(resources.GetObject("bddiscount.BackgroundImage"), System.Drawing.Image)
      Me.bddiscount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
      Me.bddiscount.Cursor = System.Windows.Forms.Cursors.Hand
      Me.bddiscount.Dock = System.Windows.Forms.DockStyle.Fill
      Me.bddiscount.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
      Me.bddiscount.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.bddiscount.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bddiscount.ForeColor = System.Drawing.Color.White
      Me.bddiscount.Location = New System.Drawing.Point(127, 76)
      Me.bddiscount.Name = "bddiscount"
      Me.bddiscount.Size = New System.Drawing.Size(118, 67)
      Me.bddiscount.TabIndex = 178
      Me.bddiscount.Text = " ADD CARD"
      Me.bddiscount.UseVisualStyleBackColor = False
      '
      'Button11
      '
      Me.Button11.BackColor = System.Drawing.Color.White
      Me.Button11.BackgroundImage = CType(resources.GetObject("Button11.BackgroundImage"), System.Drawing.Image)
      Me.Button11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
      Me.Button11.Cursor = System.Windows.Forms.Cursors.Hand
      Me.Button11.Dock = System.Windows.Forms.DockStyle.Fill
      Me.Button11.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
      Me.Button11.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.Button11.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Button11.ForeColor = System.Drawing.Color.White
      Me.Button11.Location = New System.Drawing.Point(499, 76)
      Me.Button11.Name = "Button11"
      Me.Button11.Size = New System.Drawing.Size(118, 67)
      Me.Button11.TabIndex = 182
      Me.Button11.Text = " "
      Me.Button11.UseVisualStyleBackColor = False
      '
      'Button12
      '
      Me.Button12.BackColor = System.Drawing.Color.White
      Me.Button12.BackgroundImage = CType(resources.GetObject("Button12.BackgroundImage"), System.Drawing.Image)
      Me.Button12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
      Me.Button12.Cursor = System.Windows.Forms.Cursors.Hand
      Me.Button12.Dock = System.Windows.Forms.DockStyle.Fill
      Me.Button12.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
      Me.Button12.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.Button12.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Button12.ForeColor = System.Drawing.Color.White
      Me.Button12.Location = New System.Drawing.Point(251, 76)
      Me.Button12.Name = "Button12"
      Me.Button12.Size = New System.Drawing.Size(118, 67)
      Me.Button12.TabIndex = 177
      Me.Button12.Text = " UPDATE CARD"
      Me.Button12.UseVisualStyleBackColor = False
      '
      'Button13
      '
      Me.Button13.BackColor = System.Drawing.Color.White
      Me.Button13.BackgroundImage = CType(resources.GetObject("Button13.BackgroundImage"), System.Drawing.Image)
      Me.Button13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
      Me.Button13.Cursor = System.Windows.Forms.Cursors.Hand
      Me.Button13.Dock = System.Windows.Forms.DockStyle.Fill
      Me.Button13.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
      Me.Button13.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.Button13.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Button13.ForeColor = System.Drawing.Color.White
      Me.Button13.Location = New System.Drawing.Point(375, 76)
      Me.Button13.Name = "Button13"
      Me.Button13.Size = New System.Drawing.Size(118, 67)
      Me.Button13.TabIndex = 180
      Me.Button13.Text = " "
      Me.Button13.UseVisualStyleBackColor = False
      '
      'btsplit
      '
      Me.btsplit.BackColor = System.Drawing.Color.White
      Me.btsplit.BackgroundImage = CType(resources.GetObject("btsplit.BackgroundImage"), System.Drawing.Image)
      Me.btsplit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
      Me.btsplit.Cursor = System.Windows.Forms.Cursors.Hand
      Me.btsplit.Dock = System.Windows.Forms.DockStyle.Fill
      Me.btsplit.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
      Me.btsplit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.btsplit.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btsplit.ForeColor = System.Drawing.Color.White
      Me.btsplit.Location = New System.Drawing.Point(3, 3)
      Me.btsplit.Name = "btsplit"
      Me.btsplit.Size = New System.Drawing.Size(118, 67)
      Me.btsplit.TabIndex = 183
      Me.btsplit.Text = " SPLIT"
      Me.btsplit.UseVisualStyleBackColor = False
      '
      'btcalibration
      '
      Me.btcalibration.BackColor = System.Drawing.Color.White
      Me.btcalibration.BackgroundImage = CType(resources.GetObject("btcalibration.BackgroundImage"), System.Drawing.Image)
      Me.btcalibration.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
      Me.btcalibration.Cursor = System.Windows.Forms.Cursors.Hand
      Me.btcalibration.Dock = System.Windows.Forms.DockStyle.Fill
      Me.btcalibration.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
      Me.btcalibration.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.btcalibration.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btcalibration.ForeColor = System.Drawing.Color.White
      Me.btcalibration.Location = New System.Drawing.Point(127, 3)
      Me.btcalibration.Name = "btcalibration"
      Me.btcalibration.Size = New System.Drawing.Size(118, 67)
      Me.btcalibration.TabIndex = 211
      Me.btcalibration.Text = " Calibration"
      Me.btcalibration.UseVisualStyleBackColor = False
      '
      'btpayout
      '
      Me.btpayout.BackColor = System.Drawing.Color.White
      Me.btpayout.BackgroundImage = CType(resources.GetObject("btpayout.BackgroundImage"), System.Drawing.Image)
      Me.btpayout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
      Me.btpayout.Cursor = System.Windows.Forms.Cursors.Hand
      Me.btpayout.Dock = System.Windows.Forms.DockStyle.Fill
      Me.btpayout.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
      Me.btpayout.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.btpayout.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btpayout.ForeColor = System.Drawing.Color.White
      Me.btpayout.Location = New System.Drawing.Point(499, 3)
      Me.btpayout.Name = "btpayout"
      Me.btpayout.Size = New System.Drawing.Size(118, 67)
      Me.btpayout.TabIndex = 233
      Me.btpayout.Text = " PAYOUT"
      Me.btpayout.UseVisualStyleBackColor = False
      '
      'TabPage2
      '
      Me.TabPage2.Controls.Add(Me.TableLayoutPanel4)
      Me.TabPage2.Location = New System.Drawing.Point(4, 25)
      Me.TabPage2.Name = "TabPage2"
      Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
      Me.TabPage2.Size = New System.Drawing.Size(626, 152)
      Me.TabPage2.TabIndex = 1
      Me.TabPage2.Text = "REPORT/RECORD"
      Me.TabPage2.UseVisualStyleBackColor = True
      '
      'TableLayoutPanel4
      '
      Me.TableLayoutPanel4.ColumnCount = 5
      Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
      Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
      Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
      Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
      Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
      Me.TableLayoutPanel4.Controls.Add(Me.btcredittocredit, 3, 0)
      Me.TableLayoutPanel4.Controls.Add(Me.btLoyaltyReport, 2, 0)
      Me.TableLayoutPanel4.Controls.Add(Me.btpump, 0, 1)
      Me.TableLayoutPanel4.Controls.Add(Me.btxreport, 0, 1)
      Me.TableLayoutPanel4.Controls.Add(Me.buttom123, 4, 1)
      Me.TableLayoutPanel4.Controls.Add(Me.btzreport, 1, 1)
      Me.TableLayoutPanel4.Controls.Add(Me.Btdub, 2, 1)
      Me.TableLayoutPanel4.Controls.Add(Me.btcr, 0, 0)
      Me.TableLayoutPanel4.Controls.Add(Me.btpumpreading, 1, 0)
      Me.TableLayoutPanel4.Controls.Add(Me.Button7, 4, 0)
      Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
      Me.TableLayoutPanel4.Location = New System.Drawing.Point(3, 3)
      Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
      Me.TableLayoutPanel4.RowCount = 2
      Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
      Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
      Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
      Me.TableLayoutPanel4.Size = New System.Drawing.Size(620, 146)
      Me.TableLayoutPanel4.TabIndex = 0
      '
      'btcredittocredit
      '
      Me.btcredittocredit.BackColor = System.Drawing.Color.White
      Me.btcredittocredit.BackgroundImage = CType(resources.GetObject("btcredittocredit.BackgroundImage"), System.Drawing.Image)
      Me.btcredittocredit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
      Me.btcredittocredit.Cursor = System.Windows.Forms.Cursors.Hand
      Me.btcredittocredit.Dock = System.Windows.Forms.DockStyle.Fill
      Me.btcredittocredit.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
      Me.btcredittocredit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.btcredittocredit.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btcredittocredit.ForeColor = System.Drawing.Color.White
      Me.btcredittocredit.Location = New System.Drawing.Point(375, 3)
      Me.btcredittocredit.Name = "btcredittocredit"
      Me.btcredittocredit.Size = New System.Drawing.Size(118, 67)
      Me.btcredittocredit.TabIndex = 287
      Me.btcredittocredit.Text = "RE-PRINT REDEEM"
      Me.btcredittocredit.UseVisualStyleBackColor = False
      '
      'btLoyaltyReport
      '
      Me.btLoyaltyReport.BackColor = System.Drawing.Color.White
      Me.btLoyaltyReport.BackgroundImage = CType(resources.GetObject("btLoyaltyReport.BackgroundImage"), System.Drawing.Image)
      Me.btLoyaltyReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
      Me.btLoyaltyReport.Cursor = System.Windows.Forms.Cursors.Hand
      Me.btLoyaltyReport.Dock = System.Windows.Forms.DockStyle.Fill
      Me.btLoyaltyReport.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
      Me.btLoyaltyReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.btLoyaltyReport.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btLoyaltyReport.ForeColor = System.Drawing.Color.White
      Me.btLoyaltyReport.Location = New System.Drawing.Point(251, 3)
      Me.btLoyaltyReport.Name = "btLoyaltyReport"
      Me.btLoyaltyReport.Size = New System.Drawing.Size(118, 67)
      Me.btLoyaltyReport.TabIndex = 287
      Me.btLoyaltyReport.Text = "Loyalty Report"
      Me.btLoyaltyReport.UseVisualStyleBackColor = False
      '
      'btpump
      '
      Me.btpump.BackColor = System.Drawing.Color.White
      Me.btpump.BackgroundImage = CType(resources.GetObject("btpump.BackgroundImage"), System.Drawing.Image)
      Me.btpump.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
      Me.btpump.Cursor = System.Windows.Forms.Cursors.Hand
      Me.btpump.Dock = System.Windows.Forms.DockStyle.Fill
      Me.btpump.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
      Me.btpump.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.btpump.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold)
      Me.btpump.ForeColor = System.Drawing.Color.White
      Me.btpump.Location = New System.Drawing.Point(3, 76)
      Me.btpump.Name = "btpump"
      Me.btpump.Size = New System.Drawing.Size(118, 67)
      Me.btpump.TabIndex = 234
      Me.btpump.UseVisualStyleBackColor = False
      '
      'btxreport
      '
      Me.btxreport.BackColor = System.Drawing.Color.White
      Me.btxreport.BackgroundImage = CType(resources.GetObject("btxreport.BackgroundImage"), System.Drawing.Image)
      Me.btxreport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
      Me.btxreport.Cursor = System.Windows.Forms.Cursors.Hand
      Me.btxreport.Dock = System.Windows.Forms.DockStyle.Fill
      Me.btxreport.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
      Me.btxreport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.btxreport.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btxreport.ForeColor = System.Drawing.Color.White
      Me.btxreport.Location = New System.Drawing.Point(127, 76)
      Me.btxreport.Name = "btxreport"
      Me.btxreport.Size = New System.Drawing.Size(118, 67)
      Me.btxreport.TabIndex = 178
      Me.btxreport.UseVisualStyleBackColor = False
      '
      'buttom123
      '
      Me.buttom123.BackColor = System.Drawing.Color.White
      Me.buttom123.BackgroundImage = CType(resources.GetObject("buttom123.BackgroundImage"), System.Drawing.Image)
      Me.buttom123.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
      Me.buttom123.Cursor = System.Windows.Forms.Cursors.Hand
      Me.buttom123.Dock = System.Windows.Forms.DockStyle.Fill
      Me.buttom123.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
      Me.buttom123.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.buttom123.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.buttom123.ForeColor = System.Drawing.Color.White
      Me.buttom123.Location = New System.Drawing.Point(499, 76)
      Me.buttom123.Name = "buttom123"
      Me.buttom123.Size = New System.Drawing.Size(118, 67)
      Me.buttom123.TabIndex = 182
      Me.buttom123.UseVisualStyleBackColor = False
      '
      'btzreport
      '
      Me.btzreport.BackColor = System.Drawing.Color.White
      Me.btzreport.BackgroundImage = CType(resources.GetObject("btzreport.BackgroundImage"), System.Drawing.Image)
      Me.btzreport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
      Me.btzreport.Cursor = System.Windows.Forms.Cursors.Hand
      Me.btzreport.Dock = System.Windows.Forms.DockStyle.Fill
      Me.btzreport.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
      Me.btzreport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.btzreport.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btzreport.ForeColor = System.Drawing.Color.White
      Me.btzreport.Location = New System.Drawing.Point(251, 76)
      Me.btzreport.Name = "btzreport"
      Me.btzreport.Size = New System.Drawing.Size(118, 67)
      Me.btzreport.TabIndex = 177
      Me.btzreport.UseVisualStyleBackColor = False
      '
      'Btdub
      '
      Me.Btdub.BackColor = System.Drawing.Color.White
      Me.Btdub.BackgroundImage = CType(resources.GetObject("Btdub.BackgroundImage"), System.Drawing.Image)
      Me.Btdub.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
      Me.Btdub.Cursor = System.Windows.Forms.Cursors.Hand
      Me.Btdub.Dock = System.Windows.Forms.DockStyle.Fill
      Me.Btdub.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
      Me.Btdub.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.Btdub.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Btdub.ForeColor = System.Drawing.Color.White
      Me.Btdub.Location = New System.Drawing.Point(375, 76)
      Me.Btdub.Name = "Btdub"
      Me.Btdub.Size = New System.Drawing.Size(118, 67)
      Me.Btdub.TabIndex = 180
      Me.Btdub.UseVisualStyleBackColor = False
      '
      'btcr
      '
      Me.btcr.BackColor = System.Drawing.Color.White
      Me.btcr.BackgroundImage = CType(resources.GetObject("btcr.BackgroundImage"), System.Drawing.Image)
      Me.btcr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
      Me.btcr.Cursor = System.Windows.Forms.Cursors.Hand
      Me.btcr.Dock = System.Windows.Forms.DockStyle.Fill
      Me.btcr.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
      Me.btcr.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.btcr.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btcr.ForeColor = System.Drawing.Color.White
      Me.btcr.Location = New System.Drawing.Point(3, 3)
      Me.btcr.Name = "btcr"
      Me.btcr.Size = New System.Drawing.Size(118, 67)
      Me.btcr.TabIndex = 183
      Me.btcr.Text = "Cashier Report"
      Me.btcr.UseVisualStyleBackColor = False
      '
      'btpumpreading
      '
      Me.btpumpreading.BackColor = System.Drawing.Color.White
      Me.btpumpreading.BackgroundImage = CType(resources.GetObject("btpumpreading.BackgroundImage"), System.Drawing.Image)
      Me.btpumpreading.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
      Me.btpumpreading.Cursor = System.Windows.Forms.Cursors.Hand
      Me.btpumpreading.Dock = System.Windows.Forms.DockStyle.Fill
      Me.btpumpreading.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
      Me.btpumpreading.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.btpumpreading.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btpumpreading.ForeColor = System.Drawing.Color.White
      Me.btpumpreading.Location = New System.Drawing.Point(127, 3)
      Me.btpumpreading.Name = "btpumpreading"
      Me.btpumpreading.Size = New System.Drawing.Size(118, 67)
      Me.btpumpreading.TabIndex = 211
      Me.btpumpreading.Text = "Pump Reading"
      Me.btpumpreading.UseVisualStyleBackColor = False
      '
      'Button7
      '
      Me.Button7.BackColor = System.Drawing.Color.White
      Me.Button7.BackgroundImage = CType(resources.GetObject("Button7.BackgroundImage"), System.Drawing.Image)
      Me.Button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
      Me.Button7.Cursor = System.Windows.Forms.Cursors.Hand
      Me.Button7.Dock = System.Windows.Forms.DockStyle.Fill
      Me.Button7.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
      Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.Button7.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Button7.ForeColor = System.Drawing.Color.White
      Me.Button7.Location = New System.Drawing.Point(499, 3)
      Me.Button7.Name = "Button7"
      Me.Button7.Size = New System.Drawing.Size(118, 67)
      Me.Button7.TabIndex = 233
      Me.Button7.UseVisualStyleBackColor = False
      '
      'TabPage1
      '
      Me.TabPage1.Controls.Add(Me.TableLayoutPanel1)
      Me.TabPage1.Location = New System.Drawing.Point(4, 25)
      Me.TabPage1.Name = "TabPage1"
      Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
      Me.TabPage1.Size = New System.Drawing.Size(626, 152)
      Me.TabPage1.TabIndex = 0
      Me.TabPage1.Text = "PUMP /ITEMS"
      Me.TabPage1.UseVisualStyleBackColor = True
      '
      'TableLayoutPanel1
      '
      Me.TableLayoutPanel1.ColumnCount = 3
      Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
      Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
      Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
      Me.TableLayoutPanel1.Controls.Add(Me.btclear, 2, 0)
      Me.TableLayoutPanel1.Controls.Add(Me.bttotalizer, 1, 0)
      Me.TableLayoutPanel1.Controls.Add(Me.btreedem, 2, 1)
      Me.TableLayoutPanel1.Controls.Add(Me.btchangep, 0, 1)
      Me.TableLayoutPanel1.Controls.Add(Me.btchangeuser, 0, 0)
      Me.TableLayoutPanel1.Controls.Add(Me.btnonfuel, 1, 1)
      Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
      Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
      Me.TableLayoutPanel1.RowCount = 2
      Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
      Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
      Me.TableLayoutPanel1.Size = New System.Drawing.Size(620, 146)
      Me.TableLayoutPanel1.TabIndex = 0
      '
      'btclear
      '
      Me.btclear.BackColor = System.Drawing.Color.White
      Me.btclear.BackgroundImage = CType(resources.GetObject("btclear.BackgroundImage"), System.Drawing.Image)
      Me.btclear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
      Me.btclear.Cursor = System.Windows.Forms.Cursors.Hand
      Me.btclear.Dock = System.Windows.Forms.DockStyle.Fill
      Me.btclear.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
      Me.btclear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.btclear.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btclear.ForeColor = System.Drawing.Color.White
      Me.btclear.Location = New System.Drawing.Point(415, 3)
      Me.btclear.Name = "btclear"
      Me.btclear.Size = New System.Drawing.Size(202, 67)
      Me.btclear.TabIndex = 232
      Me.btclear.Text = "(ESC) CLEAR"
      Me.btclear.UseVisualStyleBackColor = False
      '
      'bttotalizer
      '
      Me.bttotalizer.BackColor = System.Drawing.Color.White
      Me.bttotalizer.BackgroundImage = CType(resources.GetObject("bttotalizer.BackgroundImage"), System.Drawing.Image)
      Me.bttotalizer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
      Me.bttotalizer.Cursor = System.Windows.Forms.Cursors.Hand
      Me.bttotalizer.Dock = System.Windows.Forms.DockStyle.Fill
      Me.bttotalizer.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
      Me.bttotalizer.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.bttotalizer.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold)
      Me.bttotalizer.ForeColor = System.Drawing.Color.White
      Me.bttotalizer.Location = New System.Drawing.Point(209, 3)
      Me.bttotalizer.Name = "bttotalizer"
      Me.bttotalizer.Size = New System.Drawing.Size(200, 67)
      Me.bttotalizer.TabIndex = 226
      Me.bttotalizer.Text = "Get Totalizer"
      Me.bttotalizer.UseVisualStyleBackColor = False
      '
      'btreedem
      '
      Me.btreedem.BackColor = System.Drawing.Color.White
      Me.btreedem.BackgroundImage = CType(resources.GetObject("btreedem.BackgroundImage"), System.Drawing.Image)
      Me.btreedem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
      Me.btreedem.Cursor = System.Windows.Forms.Cursors.Hand
      Me.btreedem.Dock = System.Windows.Forms.DockStyle.Fill
      Me.btreedem.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
      Me.btreedem.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.btreedem.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btreedem.ForeColor = System.Drawing.Color.White
      Me.btreedem.Location = New System.Drawing.Point(415, 76)
      Me.btreedem.Name = "btreedem"
      Me.btreedem.Size = New System.Drawing.Size(202, 67)
      Me.btreedem.TabIndex = 229
      Me.btreedem.Text = "REDEEM"
      Me.btreedem.UseVisualStyleBackColor = False
      '
      'btchangep
      '
      Me.btchangep.BackColor = System.Drawing.Color.White
      Me.btchangep.BackgroundImage = CType(resources.GetObject("btchangep.BackgroundImage"), System.Drawing.Image)
      Me.btchangep.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
      Me.btchangep.Cursor = System.Windows.Forms.Cursors.Hand
      Me.btchangep.Dock = System.Windows.Forms.DockStyle.Fill
      Me.btchangep.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
      Me.btchangep.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.btchangep.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btchangep.ForeColor = System.Drawing.Color.White
      Me.btchangep.Location = New System.Drawing.Point(3, 76)
      Me.btchangep.Name = "btchangep"
      Me.btchangep.Size = New System.Drawing.Size(200, 67)
      Me.btchangep.TabIndex = 291
      Me.btchangep.Text = "CHANGE PRICE"
      Me.btchangep.UseVisualStyleBackColor = False
      '
      'btchangeuser
      '
      Me.btchangeuser.BackColor = System.Drawing.Color.White
      Me.btchangeuser.BackgroundImage = CType(resources.GetObject("btchangeuser.BackgroundImage"), System.Drawing.Image)
      Me.btchangeuser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
      Me.btchangeuser.Cursor = System.Windows.Forms.Cursors.Hand
      Me.btchangeuser.Dock = System.Windows.Forms.DockStyle.Fill
      Me.btchangeuser.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
      Me.btchangeuser.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.btchangeuser.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btchangeuser.ForeColor = System.Drawing.Color.White
      Me.btchangeuser.Location = New System.Drawing.Point(3, 3)
      Me.btchangeuser.Name = "btchangeuser"
      Me.btchangeuser.Size = New System.Drawing.Size(200, 67)
      Me.btchangeuser.TabIndex = 227
      Me.btchangeuser.Text = "Change User"
      Me.btchangeuser.UseVisualStyleBackColor = False
      '
      'btnonfuel
      '
      Me.btnonfuel.BackColor = System.Drawing.Color.White
      Me.btnonfuel.BackgroundImage = CType(resources.GetObject("btnonfuel.BackgroundImage"), System.Drawing.Image)
      Me.btnonfuel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
      Me.btnonfuel.Cursor = System.Windows.Forms.Cursors.Hand
      Me.btnonfuel.Dock = System.Windows.Forms.DockStyle.Fill
      Me.btnonfuel.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
      Me.btnonfuel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.btnonfuel.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold)
      Me.btnonfuel.ForeColor = System.Drawing.Color.White
      Me.btnonfuel.Location = New System.Drawing.Point(209, 76)
      Me.btnonfuel.Name = "btnonfuel"
      Me.btnonfuel.Size = New System.Drawing.Size(200, 67)
      Me.btnonfuel.TabIndex = 289
      Me.btnonfuel.Text = "ITEM"
      Me.btnonfuel.UseVisualStyleBackColor = False
      '
      'MenuBar
      '
      Me.MenuBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.MenuBar.Appearance = System.Windows.Forms.TabAppearance.Buttons
      Me.MenuBar.Controls.Add(Me.TabPage1)
      Me.MenuBar.Controls.Add(Me.TabPage2)
      Me.MenuBar.Controls.Add(Me.TabPage3)
      Me.MenuBar.Location = New System.Drawing.Point(15, 521)
      Me.MenuBar.Name = "MenuBar"
      Me.MenuBar.SelectedIndex = 0
      Me.MenuBar.Size = New System.Drawing.Size(634, 181)
      Me.MenuBar.TabIndex = 278
      '
      'Panel4
      '
      Me.Panel4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Panel4.BackColor = System.Drawing.Color.Gray
      Me.Panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
      Me.Panel4.Location = New System.Drawing.Point(1060, 521)
      Me.Panel4.Name = "Panel4"
      Me.Panel4.Size = New System.Drawing.Size(290, 57)
      Me.Panel4.TabIndex = 283
      '
      'BTCASHpoint
      '
      Me.BTCASHpoint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.BTCASHpoint.BackColor = System.Drawing.Color.White
      Me.BTCASHpoint.BackgroundImage = CType(resources.GetObject("BTCASHpoint.BackgroundImage"), System.Drawing.Image)
      Me.BTCASHpoint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
      Me.BTCASHpoint.Cursor = System.Windows.Forms.Cursors.Hand
      Me.BTCASHpoint.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.BTCASHpoint.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.BTCASHpoint.ForeColor = System.Drawing.Color.White
      Me.BTCASHpoint.Location = New System.Drawing.Point(793, 615)
      Me.BTCASHpoint.Name = "BTCASHpoint"
      Me.BTCASHpoint.Size = New System.Drawing.Size(131, 93)
      Me.BTCASHpoint.TabIndex = 287
      Me.BTCASHpoint.Text = "CASH Point"
      Me.BTCASHpoint.UseVisualStyleBackColor = False
      '
      'btDRAWER
      '
      Me.btDRAWER.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btDRAWER.BackColor = System.Drawing.Color.White
      Me.btDRAWER.BackgroundImage = CType(resources.GetObject("btDRAWER.BackgroundImage"), System.Drawing.Image)
      Me.btDRAWER.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
      Me.btDRAWER.Cursor = System.Windows.Forms.Cursors.Hand
      Me.btDRAWER.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
      Me.btDRAWER.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.btDRAWER.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold)
      Me.btDRAWER.ForeColor = System.Drawing.Color.White
      Me.btDRAWER.Location = New System.Drawing.Point(655, 615)
      Me.btDRAWER.Name = "btDRAWER"
      Me.btDRAWER.Size = New System.Drawing.Size(137, 93)
      Me.btDRAWER.TabIndex = 286
      Me.btDRAWER.Text = "OPEN DRAWER"
      Me.btDRAWER.UseVisualStyleBackColor = False
      '
      'Button1
      '
      Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Button1.BackColor = System.Drawing.Color.White
      Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
      Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
      Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
      Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
      Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.Button1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold)
      Me.Button1.ForeColor = System.Drawing.Color.White
      Me.Button1.Location = New System.Drawing.Point(655, 521)
      Me.Button1.Name = "Button1"
      Me.Button1.Size = New System.Drawing.Size(137, 93)
      Me.Button1.TabIndex = 269
      Me.Button1.Text = "Show Pump Transaction"
      Me.Button1.UseVisualStyleBackColor = False
      '
      'BTpoPoint
      '
      Me.BTpoPoint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.BTpoPoint.BackColor = System.Drawing.Color.White
      Me.BTpoPoint.BackgroundImage = CType(resources.GetObject("BTpoPoint.BackgroundImage"), System.Drawing.Image)
      Me.BTpoPoint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
      Me.BTpoPoint.Cursor = System.Windows.Forms.Cursors.Hand
      Me.BTpoPoint.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.BTpoPoint.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.BTpoPoint.ForeColor = System.Drawing.Color.White
      Me.BTpoPoint.Location = New System.Drawing.Point(793, 521)
      Me.BTpoPoint.Name = "BTpoPoint"
      Me.BTpoPoint.Size = New System.Drawing.Size(131, 93)
      Me.BTpoPoint.TabIndex = 285
      Me.BTpoPoint.Text = "PO Point"
      Me.BTpoPoint.UseVisualStyleBackColor = False
      '
      'btcash
      '
      Me.btcash.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btcash.BackColor = System.Drawing.Color.White
      Me.btcash.BackgroundImage = CType(resources.GetObject("btcash.BackgroundImage"), System.Drawing.Image)
      Me.btcash.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
      Me.btcash.Cursor = System.Windows.Forms.Cursors.Hand
      Me.btcash.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
      Me.btcash.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.btcash.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold)
      Me.btcash.ForeColor = System.Drawing.Color.White
      Me.btcash.Location = New System.Drawing.Point(926, 615)
      Me.btcash.Name = "btcash"
      Me.btcash.Size = New System.Drawing.Size(131, 93)
      Me.btcash.TabIndex = 283
      Me.btcash.Text = "CASH"
      Me.btcash.UseVisualStyleBackColor = False
      '
      'btpo
      '
      Me.btpo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btpo.BackColor = System.Drawing.Color.White
      Me.btpo.BackgroundImage = CType(resources.GetObject("btpo.BackgroundImage"), System.Drawing.Image)
      Me.btpo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
      Me.btpo.Cursor = System.Windows.Forms.Cursors.Hand
      Me.btpo.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue
      Me.btpo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.btpo.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btpo.ForeColor = System.Drawing.Color.White
      Me.btpo.Location = New System.Drawing.Point(926, 521)
      Me.btpo.Name = "btpo"
      Me.btpo.Size = New System.Drawing.Size(131, 93)
      Me.btpo.TabIndex = 284
      Me.btpo.Text = "P.O."
      Me.btpo.UseVisualStyleBackColor = False
      '
      'Panel7
      '
      Me.Panel7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Panel7.BackColor = System.Drawing.Color.White
      Me.Panel7.BackgroundImage = CType(resources.GetObject("Panel7.BackgroundImage"), System.Drawing.Image)
      Me.Panel7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
      Me.Panel7.Controls.Add(Me.txttotaldue)
      Me.Panel7.Controls.Add(Me.txtchangename)
      Me.Panel7.Controls.Add(Me.txttotalTender)
      Me.Panel7.Controls.Add(Me.Label2)
      Me.Panel7.Controls.Add(Me.txtchange)
      Me.Panel7.Controls.Add(Me.Label5)
      Me.Panel7.Location = New System.Drawing.Point(1060, 615)
      Me.Panel7.Name = "Panel7"
      Me.Panel7.Size = New System.Drawing.Size(290, 93)
      Me.Panel7.TabIndex = 281
      '
      'txttotaldue
      '
      Me.txttotaldue.AutoSize = True
      Me.txttotaldue.BackColor = System.Drawing.Color.Transparent
      Me.txttotaldue.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold)
      Me.txttotaldue.ForeColor = System.Drawing.Color.White
      Me.txttotaldue.Location = New System.Drawing.Point(3, 7)
      Me.txttotaldue.Name = "txttotaldue"
      Me.txttotaldue.Size = New System.Drawing.Size(65, 25)
      Me.txttotaldue.TabIndex = 6
      Me.txttotaldue.Text = "0.00"
      '
      'txtchangename
      '
      Me.txtchangename.Anchor = System.Windows.Forms.AnchorStyles.Right
      Me.txtchangename.AutoSize = True
      Me.txtchangename.BackColor = System.Drawing.Color.Transparent
      Me.txtchangename.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold)
      Me.txtchangename.ForeColor = System.Drawing.Color.White
      Me.txtchangename.Location = New System.Drawing.Point(210, 69)
      Me.txtchangename.Name = "txtchangename"
      Me.txtchangename.Size = New System.Drawing.Size(77, 18)
      Me.txtchangename.TabIndex = 9
      Me.txtchangename.Text = "CHANGE"
      '
      'txttotalTender
      '
      Me.txttotalTender.AutoSize = True
      Me.txttotalTender.BackColor = System.Drawing.Color.Transparent
      Me.txttotalTender.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold)
      Me.txttotalTender.ForeColor = System.Drawing.Color.White
      Me.txttotalTender.Location = New System.Drawing.Point(3, 37)
      Me.txttotalTender.Name = "txttotalTender"
      Me.txttotalTender.Size = New System.Drawing.Size(65, 25)
      Me.txttotalTender.TabIndex = 8
      Me.txttotalTender.Text = "0.00"
      '
      'Label2
      '
      Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
      Me.Label2.AutoSize = True
      Me.Label2.BackColor = System.Drawing.Color.Transparent
      Me.Label2.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold)
      Me.Label2.ForeColor = System.Drawing.Color.White
      Me.Label2.Location = New System.Drawing.Point(185, 10)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(102, 18)
      Me.Label2.TabIndex = 5
      Me.Label2.Text = "TOTAL DUE"
      '
      'txtchange
      '
      Me.txtchange.AutoSize = True
      Me.txtchange.BackColor = System.Drawing.Color.Transparent
      Me.txtchange.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold)
      Me.txtchange.ForeColor = System.Drawing.Color.White
      Me.txtchange.Location = New System.Drawing.Point(3, 67)
      Me.txtchange.Name = "txtchange"
      Me.txtchange.Size = New System.Drawing.Size(65, 25)
      Me.txtchange.TabIndex = 10
      Me.txtchange.Text = "0.00"
      '
      'Label5
      '
      Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right
      Me.Label5.AutoSize = True
      Me.Label5.BackColor = System.Drawing.Color.Transparent
      Me.Label5.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold)
      Me.Label5.ForeColor = System.Drawing.Color.White
      Me.Label5.Location = New System.Drawing.Point(153, 39)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(134, 18)
      Me.Label5.TabIndex = 7
      Me.Label5.Text = "TOTAL TENDER"
      '
      'btaddall
      '
      Me.btaddall.Location = New System.Drawing.Point(1273, 24)
      Me.btaddall.Name = "btaddall"
      Me.btaddall.Size = New System.Drawing.Size(75, 23)
      Me.btaddall.TabIndex = 288
      Me.btaddall.Text = "ADD ALL"
      Me.btaddall.UseVisualStyleBackColor = True
      '
      'MainForm
      '
      Me.ClientSize = New System.Drawing.Size(1350, 714)
      Me.Controls.Add(Me.btaddall)
      Me.Controls.Add(Me.Panel4)
      Me.Controls.Add(Me.BTCASHpoint)
      Me.Controls.Add(Me.btDRAWER)
      Me.Controls.Add(Me.Button1)
      Me.Controls.Add(Me.BTpoPoint)
      Me.Controls.Add(Me.btcash)
      Me.Controls.Add(Me.btpo)
      Me.Controls.Add(Me.Panel7)
      Me.Controls.Add(Me.Panel12)
      Me.Controls.Add(Me.Panel3)
      Me.Controls.Add(Me.Panel2)
      Me.Controls.Add(Me.MenuBar)
      Me.Controls.Add(Me.DataGridView2)
      Me.Controls.Add(Me.DataGridView1)
      Me.Controls.Add(Me.DateTimePicker2)
      Me.Controls.Add(Me.Label16)
      Me.Controls.Add(Me.DateTimePicker1)
      Me.Controls.Add(Me.Label15)
      Me.Controls.Add(Me.Label13)
      Me.Controls.Add(Me.txtuser)
      Me.Controls.Add(Me.Label14)
      Me.Controls.Add(Me.txtusername)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.toolStrip)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.KeyPreview = True
      Me.MaximumSize = New System.Drawing.Size(1366, 768)
      Me.MinimumSize = New System.Drawing.Size(1024, 700)
      Me.Name = "MainForm"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "PTS controller VB.NET application, version "
      Me.tableLayoutPanel.ResumeLayout(False)
      Me.Panel1.ResumeLayout(False)
      Me.toolStrip.ResumeLayout(False)
      Me.toolStrip.PerformLayout()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
      Me.Panel2.ResumeLayout(False)
      Me.Panel3.ResumeLayout(False)
      Me.Panel3.PerformLayout()
      Me.Panel12.ResumeLayout(False)
      Me.Panel12.PerformLayout()
      Me.TabPage3.ResumeLayout(False)
      Me.TableLayoutPanel5.ResumeLayout(False)
      Me.TabPage2.ResumeLayout(False)
      Me.TableLayoutPanel4.ResumeLayout(False)
      Me.TabPage1.ResumeLayout(False)
      Me.TableLayoutPanel1.ResumeLayout(False)
      Me.MenuBar.ResumeLayout(False)
      Me.Panel7.ResumeLayout(False)
      Me.Panel7.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

    End Sub

#End Region
    Private WithEvents tableLayoutPanel As TableLayoutPanel
    Private WithEvents toolStripLabel1 As ToolStripLabel
    Private WithEvents portListComboBox As ToolStripComboBox
    Private WithEvents portConnectionButton As ToolStripButton
    Private WithEvents toolStrip As ToolStrip
    Friend WithEvents Label13 As Label
    Friend WithEvents txtuser As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents txtusername As Label
    Public WithEvents DataGridView1 As DataGridView
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents ItemLookUp As DataGridViewTextBoxColumn
    Friend WithEvents Description As DataGridViewTextBoxColumn
    Friend WithEvents Quantity As DataGridViewTextBoxColumn
    Friend WithEvents UnitPrice As DataGridViewTextBoxColumn
    Friend WithEvents Amount As DataGridViewTextBoxColumn
    Friend WithEvents Discount As DataGridViewTextBoxColumn
    Friend WithEvents pointw As DataGridViewTextBoxColumn
    Friend WithEvents pointx As DataGridViewTextBoxColumn
    Friend WithEvents IDZ As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btdot As Button
    Friend WithEvents bt00 As Button
    Friend WithEvents bt0 As Button
    Friend WithEvents bt1 As Button
    Friend WithEvents bt2 As Button
    Friend WithEvents bt3 As Button
    Friend WithEvents bt6 As Button
    Friend WithEvents bt5 As Button
    Friend WithEvents bt4 As Button
    Friend WithEvents bt9 As Button
    Friend WithEvents bt8 As Button
    Friend WithEvents bt7 As Button
    Friend WithEvents bt1000 As Button
    Friend WithEvents bt500 As Button
    Friend WithEvents bt400 As Button
    Friend WithEvents bt300 As Button
    Friend WithEvents bt200 As Button
    Friend WithEvents bt100 As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents txtcash As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtPlateNo As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtDN As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtact As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtname As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel7 As Panel
    Friend WithEvents txttotaldue As Label
    Friend WithEvents txtchangename As Label
    Friend WithEvents txttotalTender As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtchange As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel12 As Panel
    Friend WithEvents txtplussd As Label
    Friend WithEvents txttax As Label
    Friend WithEvents txtdis As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents TXTVAT As Label
    Friend WithEvents txtvT As Label
    Friend WithEvents btcash As Button
    Friend WithEvents btpo As Button
    Friend WithEvents BTpoPoint As Button
    Friend WithEvents btDRAWER As Button
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents Label16 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label15 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents BTCASHpoint As Button
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TableLayoutPanel5 As TableLayoutPanel
    Friend WithEvents btlastdrop As Button
    Friend WithEvents btCashdrop As Button
    Friend WithEvents btvoid As Button
    Friend WithEvents bddiscount As Button
    Friend WithEvents Button11 As Button
    Friend WithEvents Button12 As Button
    Friend WithEvents Button13 As Button
    Friend WithEvents btsplit As Button
    Friend WithEvents btcalibration As Button
    Friend WithEvents btpayout As Button
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents btcredittocredit As Button
    Friend WithEvents btLoyaltyReport As Button
    Friend WithEvents btpump As Button
    Friend WithEvents btxreport As Button
    Friend WithEvents buttom123 As Button
    Friend WithEvents btzreport As Button
    Friend WithEvents Btdub As Button
    Friend WithEvents btcr As Button
    Friend WithEvents btpumpreading As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents btclear As Button
    Friend WithEvents btreedem As Button
    Friend WithEvents bttotalizer As Button
    Friend WithEvents btchangep As Button
    Friend WithEvents btnonfuel As Button
    Friend WithEvents btchangeuser As Button
    Friend WithEvents MenuBar As TabControl
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents btaddall As Button
  End Class
End Namespace