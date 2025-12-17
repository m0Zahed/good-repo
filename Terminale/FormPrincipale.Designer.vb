Namespace Terminale
	' Token: 0x02000009 RID: 9
	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
	Public Partial Class FormPrincipale
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x060000C1 RID: 193 RVA: 0x0000F698 File Offset: 0x0000D898
		<Global.System.Diagnostics.DebuggerNonUserCode()>
		Protected Overrides Sub Dispose(disposing As Boolean)
			Try
				If disposing AndAlso Me.components IsNot Nothing Then
					Me.components.Dispose()
				End If
			Finally
				MyBase.Dispose(disposing)
			End Try
		End Sub

		' Token: 0x060000C2 RID: 194 RVA: 0x0000F6D8 File Offset: 0x0000D8D8
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.Terminale.FormPrincipale))
			Dim dataGridViewCellStyle As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle2 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle3 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle4 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle5 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle6 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle7 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle8 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle9 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle10 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle11 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle12 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Dim dataGridViewCellStyle13 As Global.System.Windows.Forms.DataGridViewCellStyle = New Global.System.Windows.Forms.DataGridViewCellStyle()
			Me.TabControl = New Global.System.Windows.Forms.TabControl()
			Me.TabPage1 = New Global.System.Windows.Forms.TabPage()
			Me.lbl_Oven_st_emerg = New Global.System.Windows.Forms.Label()
			Me.lbl_reset_errors = New Global.System.Windows.Forms.Button()
			Me.lbl_reset_warning = New Global.System.Windows.Forms.Button()
			Me.lbl_Load_st_emerg = New Global.System.Windows.Forms.Label()
			Me.lbl_Unload_st_emerg = New Global.System.Windows.Forms.Label()
			Me.Lbl_Emergency = New Global.System.Windows.Forms.Label()
			Me.lbl_Paint_st_emerg = New Global.System.Windows.Forms.Label()
			Me.Lbl_Warning = New Global.System.Windows.Forms.Label()
			Me.Lbl_Errors = New Global.System.Windows.Forms.Label()
			Me.lbl_PLC_On = New Global.System.Windows.Forms.Label()
			Me.PnlRobot = New Global.System.Windows.Forms.Panel()
			Me.btn_force_unload_step = New Global.System.Windows.Forms.Button()
			Me.btn_Send_tcpip = New Global.System.Windows.Forms.Button()
			Me.lbl_act_option_l = New Global.System.Windows.Forms.Label()
			Me.GroupBox3 = New Global.System.Windows.Forms.GroupBox()
			Me.btn_oven_t_plus = New Global.System.Windows.Forms.Button()
			Me.btn_force_oven_timeout = New Global.System.Windows.Forms.Button()
			Me.btn_oven_t_min = New Global.System.Windows.Forms.Button()
			Me.lbl_timeout_oven_set = New Global.System.Windows.Forms.Label()
			Me.lbl_timeout_oven = New Global.System.Windows.Forms.Label()
			Me.lbl_mmOvenBelt = New Global.System.Windows.Forms.Label()
			Me.lbl_code_Oven = New Global.System.Windows.Forms.Label()
			Me.Pic_Oven_doorIN_open = New Global.System.Windows.Forms.PictureBox()
			Me.Pic_Oven_doorIN_close = New Global.System.Windows.Forms.PictureBox()
			Me.Pic_pres_end_oven = New Global.System.Windows.Forms.PictureBox()
			Me.Pic_pres_start_oven = New Global.System.Windows.Forms.PictureBox()
			Me.Pic_Piece_Oven = New Global.System.Windows.Forms.PictureBox()
			Me.GrpCarico = New Global.System.Windows.Forms.GroupBox()
			Me.lbl_act_option = New Global.System.Windows.Forms.Label()
			Me.lbl_act_batch = New Global.System.Windows.Forms.Label()
			Me.cmb_act_code = New Global.System.Windows.Forms.ComboBox()
			Me.lbl_act_code = New Global.System.Windows.Forms.Label()
			Me.lbl_act_batch_l = New Global.System.Windows.Forms.Label()
			Me.lbl_code_Unload_ST1 = New Global.System.Windows.Forms.Label()
			Me.Pic_pres_safe_unload = New Global.System.Windows.Forms.PictureBox()
			Me.Pic_Piece_Paint = New Global.System.Windows.Forms.PictureBox()
			Me.Pic_Piece_Unload_1 = New Global.System.Windows.Forms.PictureBox()
			Me.lbl_waiting_resume = New Global.System.Windows.Forms.Label()
			Me.lbl_mmUnloadBelt = New Global.System.Windows.Forms.Label()
			Me.lbl_mmPaintBelt = New Global.System.Windows.Forms.Label()
			Me.lbl_mmLoadBelt = New Global.System.Windows.Forms.Label()
			Me.GroupBox6 = New Global.System.Windows.Forms.GroupBox()
			Me.lbl_status_robot1_main = New Global.System.Windows.Forms.Label()
			Me.LblRobot1Busy = New Global.System.Windows.Forms.Label()
			Me.LblRobot1prgRun = New Global.System.Windows.Forms.Label()
			Me.PicRobot1Busy = New Global.System.Windows.Forms.PictureBox()
			Me.PicRobot1PrgRun = New Global.System.Windows.Forms.PictureBox()
			Me.Lbl_EmptyList_R1 = New Global.System.Windows.Forms.Label()
			Me.LblRobot1FouriIngombro = New Global.System.Windows.Forms.Label()
			Me.PicRobot1EmptyList = New Global.System.Windows.Forms.PictureBox()
			Me.PicRobot1FouriIngombro = New Global.System.Windows.Forms.PictureBox()
			Me.GroupBox5 = New Global.System.Windows.Forms.GroupBox()
			Me.lbl_Sirtek_plant_ready = New Global.System.Windows.Forms.Label()
			Me.Pic_Sirtek_plant_ready = New Global.System.Windows.Forms.PictureBox()
			Me.lbl_SR20G_R1_ready = New Global.System.Windows.Forms.Label()
			Me.Pic_SR20G_R1_ready = New Global.System.Windows.Forms.PictureBox()
			Me.Pic_unload_done = New Global.System.Windows.Forms.PictureBox()
			Me.lbl_confirm_button = New Global.System.Windows.Forms.Label()
			Me.lbl_plant_auto_ready = New Global.System.Windows.Forms.Label()
			Me.lbl_unload_done = New Global.System.Windows.Forms.Label()
			Me.Pic_plant_auto_ready = New Global.System.Windows.Forms.PictureBox()
			Me.Pic_confirm_button = New Global.System.Windows.Forms.PictureBox()
			Me.lbl_robots_ready = New Global.System.Windows.Forms.Label()
			Me.Pic_robots_ready = New Global.System.Windows.Forms.PictureBox()
			Me.Pic_coder_ready = New Global.System.Windows.Forms.PictureBox()
			Me.lbl_barriera_load = New Global.System.Windows.Forms.Label()
			Me.lbl_coder_ready = New Global.System.Windows.Forms.Label()
			Me.Pic_barrier_load_ready = New Global.System.Windows.Forms.PictureBox()
			Me.lbl_code_Paint = New Global.System.Windows.Forms.Label()
			Me.lbl_code_Load = New Global.System.Windows.Forms.Label()
			Me.Pic_pres_end_unload = New Global.System.Windows.Forms.PictureBox()
			Me.Pic_barrier_unload = New Global.System.Windows.Forms.PictureBox()
			Me.Pic_confirmed_unload = New Global.System.Windows.Forms.PictureBox()
			Me.Pic_pres_end_load = New Global.System.Windows.Forms.PictureBox()
			Me.Pic_barrier_load = New Global.System.Windows.Forms.PictureBox()
			Me.Pic_confirmed_load = New Global.System.Windows.Forms.PictureBox()
			Me.Pic_pres_start_paint = New Global.System.Windows.Forms.PictureBox()
			Me.Pic_doorIN_open = New Global.System.Windows.Forms.PictureBox()
			Me.Pic_pres_end_paint = New Global.System.Windows.Forms.PictureBox()
			Me.Pic_doorOUT_open = New Global.System.Windows.Forms.PictureBox()
			Me.Pic_doorOUT_close = New Global.System.Windows.Forms.PictureBox()
			Me.Pic_doorIN_close = New Global.System.Windows.Forms.PictureBox()
			Me.Pic_pres_start_unload = New Global.System.Windows.Forms.PictureBox()
			Me.Pic_pres_start_load = New Global.System.Windows.Forms.PictureBox()
			Me.LblDescrizione = New Global.System.Windows.Forms.Label()
			Me.Pic_Piece_Load = New Global.System.Windows.Forms.PictureBox()
			Me.LblScaricoConfermato = New Global.System.Windows.Forms.Label()
			Me.LblCaricoConfermato = New Global.System.Windows.Forms.Label()
			Me.PictureBox2 = New Global.System.Windows.Forms.PictureBox()
			Me.Lbl_MotorON_Plant = New Global.System.Windows.Forms.Label()
			Me.Lbl_Warning_cyc = New Global.System.Windows.Forms.Label()
			Me.LblLinea = New Global.System.Windows.Forms.Label()
			Me.Lbl_AUTO_Plant = New Global.System.Windows.Forms.Label()
			Me.LblAlarmaDes = New Global.System.Windows.Forms.Label()
			Me.TabPage3 = New Global.System.Windows.Forms.TabPage()
			Me.GrpManualComands = New Global.System.Windows.Forms.GroupBox()
			Me.BtnOvenDoor = New Global.System.Windows.Forms.Button()
			Me.BtnOpenDoorOUT = New Global.System.Windows.Forms.Button()
			Me.BtnOpenDoorIN = New Global.System.Windows.Forms.Button()
			Me.GrpLng = New Global.System.Windows.Forms.GroupBox()
			Me.BtnLngBra = New Global.System.Windows.Forms.Button()
			Me.BtnLngSpa = New Global.System.Windows.Forms.Button()
			Me.BtnLngFra = New Global.System.Windows.Forms.Button()
			Me.BtnLngGer = New Global.System.Windows.Forms.Button()
			Me.BtnLngEng = New Global.System.Windows.Forms.Button()
			Me.BtnLngIta = New Global.System.Windows.Forms.Button()
			Me.chb_password = New Global.System.Windows.Forms.CheckBox()
			Me.btn_par_edit = New Global.System.Windows.Forms.Button()
			Me.LblParametriGenerali = New Global.System.Windows.Forms.Label()
			Me.lvw_par = New Global.System.Windows.Forms.ListView()
			Me.ColumnHeader4 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader5 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader6 = New Global.System.Windows.Forms.ColumnHeader()
			Me.TabPage2 = New Global.System.Windows.Forms.TabPage()
			Me.grp_debug = New Global.System.Windows.Forms.GroupBox()
			Me.mmOven = New Global.System.Windows.Forms.Label()
			Me.lbl_mmnastro_oven = New Global.System.Windows.Forms.Label()
			Me.Label6 = New Global.System.Windows.Forms.Label()
			Me.Label5 = New Global.System.Windows.Forms.Label()
			Me.Label3 = New Global.System.Windows.Forms.Label()
			Me.Label2 = New Global.System.Windows.Forms.Label()
			Me.Label1 = New Global.System.Windows.Forms.Label()
			Me.mmPaint = New Global.System.Windows.Forms.Label()
			Me.lbl_mmnastro_unload = New Global.System.Windows.Forms.Label()
			Me.lbl_mmnastro_paint = New Global.System.Windows.Forms.Label()
			Me.lbl_FSM_err = New Global.System.Windows.Forms.Label()
			Me.lbl_debug_03 = New Global.System.Windows.Forms.Label()
			Me.lbl_debug_02 = New Global.System.Windows.Forms.Label()
			Me.lbl_debug_01 = New Global.System.Windows.Forms.Label()
			Me.GroupBox9 = New Global.System.Windows.Forms.GroupBox()
			Me.lbl_IMA_OUTPUT = New Global.System.Windows.Forms.Label()
			Me.lbl_IMA_INPUT = New Global.System.Windows.Forms.Label()
			Me.dgv_dout_IMA = New Global.System.Windows.Forms.DataGridView()
			Me.DataGridViewTextBoxColumn6 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn7 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.dgv_din_IMA = New Global.System.Windows.Forms.DataGridView()
			Me.DataGridViewTextBoxColumn5 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Value = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.lbl_digital_OUTPUT = New Global.System.Windows.Forms.Label()
			Me.lbl_digital_INPUT = New Global.System.Windows.Forms.Label()
			Me.dgv_dout = New Global.System.Windows.Forms.DataGridView()
			Me.DataGridViewImageColumn1 = New Global.System.Windows.Forms.DataGridViewImageColumn()
			Me.Column1 = New Global.System.Windows.Forms.DataGridViewButtonColumn()
			Me.DataGridViewTextBoxColumn1 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.dgv_din = New Global.System.Windows.Forms.DataGridView()
			Me.Column3 = New Global.System.Windows.Forms.DataGridViewImageColumn()
			Me.Column2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.btn_force = New Global.System.Windows.Forms.Button()
			Me.GroupBox8 = New Global.System.Windows.Forms.GroupBox()
			Me.lbl_cma_loadinf = New Global.System.Windows.Forms.Label()
			Me.Lbl_communicationPLC = New Global.System.Windows.Forms.Label()
			Me.GroupBox4 = New Global.System.Windows.Forms.GroupBox()
			Me.btn_reset_cyc = New Global.System.Windows.Forms.Button()
			Me.dgv_ciclica = New Global.System.Windows.Forms.DataGridView()
			Me.DataGridViewTextBoxColumn3 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn4 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column10 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.GroupBox2 = New Global.System.Windows.Forms.GroupBox()
			Me.Label12 = New Global.System.Windows.Forms.Label()
			Me.lbl_com_TCPIP_r1 = New Global.System.Windows.Forms.Label()
			Me.Label18 = New Global.System.Windows.Forms.Label()
			Me.Lbl_com_robot1_l = New Global.System.Windows.Forms.Label()
			Me.lbl_com_robot1 = New Global.System.Windows.Forms.Label()
			Me.lbl_status_robot1 = New Global.System.Windows.Forms.Label()
			Me.GroupBox1 = New Global.System.Windows.Forms.GroupBox()
			Me.dgv_master = New Global.System.Windows.Forms.DataGridView()
			Me.DataGridViewTextBoxColumn2 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column9 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewButtonColumn1 = New Global.System.Windows.Forms.DataGridViewButtonColumn()
			Me.TabPage4 = New Global.System.Windows.Forms.TabPage()
			Me.lvw_alarms = New Global.System.Windows.Forms.ListView()
			Me.ColumnHeader8 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader9 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader10 = New Global.System.Windows.Forms.ColumnHeader()
			Me.ColumnHeader11 = New Global.System.Windows.Forms.ColumnHeader()
			Me.dgv_ax = New Global.System.Windows.Forms.DataGridView()
			Me.Column7 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.cl_pos = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.cl_vel = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column4 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column5 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column6 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column8 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.MotorsManualMove = New Global.System.Windows.Forms.DataGridViewCheckBoxColumn()
			Me.Grp_stats = New Global.System.Windows.Forms.GroupBox()
			Me.btn_stat_edit = New Global.System.Windows.Forms.Button()
			Me.btn_Step_done = New Global.System.Windows.Forms.Button()
			Me.btn_stat_save = New Global.System.Windows.Forms.Button()
			Me.Button1 = New Global.System.Windows.Forms.Button()
			Me.btn_stat_delete = New Global.System.Windows.Forms.Button()
			Me.dgv_robot1_stats = New Global.System.Windows.Forms.DataGridView()
			Me.DataGridViewTextBoxColumn8 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn9 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.DataGridViewTextBoxColumn10 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column14 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column15 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column16 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column17 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.lbl_robot1_stats_l = New Global.System.Windows.Forms.Label()
			Me.btn_stat_clear = New Global.System.Windows.Forms.Button()
			Me.lbl_programlist_l = New Global.System.Windows.Forms.Label()
			Me.btn_stat_insert = New Global.System.Windows.Forms.Button()
			Me.btn_stat_refresh = New Global.System.Windows.Forms.Button()
			Me.dgv_programlist = New Global.System.Windows.Forms.DataGridView()
			Me.Column11 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column12 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Column13 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.il_led = New Global.System.Windows.Forms.ImageList(Me.components)
			Me.il_anta = New Global.System.Windows.Forms.ImageList(Me.components)
			Me.SerialPort1 = New Global.System.IO.Ports.SerialPort(Me.components)
			Me.tmr_barcode = New Global.System.Windows.Forms.Timer(Me.components)
			Me.tmr_start = New Global.System.Windows.Forms.Timer(Me.components)
			Me.tmr_eth = New Global.System.Windows.Forms.Timer(Me.components)
			Me.SerialPortBilancia = New Global.System.IO.Ports.SerialPort(Me.components)
			Me.SerialPort2 = New Global.System.IO.Ports.SerialPort(Me.components)
			Me.TmrShowDescrizione = New Global.System.Windows.Forms.Timer(Me.components)
			Me.TmrChekbox = New Global.System.Windows.Forms.Timer(Me.components)
			Me.tmr_psw = New Global.System.Windows.Forms.Timer(Me.components)
			Me.tmr_blink = New Global.System.Windows.Forms.Timer(Me.components)
			Me.btn_reset_cyc_main = New Global.System.Windows.Forms.Button()
			Me.TabControl.SuspendLayout()
			Me.TabPage1.SuspendLayout()
			Me.PnlRobot.SuspendLayout()
			Me.GroupBox3.SuspendLayout()
			CType(Me.Pic_Oven_doorIN_open, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.Pic_Oven_doorIN_close, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.Pic_pres_end_oven, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.Pic_pres_start_oven, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.Pic_Piece_Oven, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.GrpCarico.SuspendLayout()
			CType(Me.Pic_pres_safe_unload, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.Pic_Piece_Paint, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.Pic_Piece_Unload_1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.GroupBox6.SuspendLayout()
			CType(Me.PicRobot1Busy, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.PicRobot1PrgRun, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.PicRobot1EmptyList, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.PicRobot1FouriIngombro, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.GroupBox5.SuspendLayout()
			CType(Me.Pic_Sirtek_plant_ready, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.Pic_SR20G_R1_ready, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.Pic_unload_done, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.Pic_plant_auto_ready, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.Pic_confirm_button, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.Pic_robots_ready, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.Pic_coder_ready, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.Pic_barrier_load_ready, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.Pic_pres_end_unload, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.Pic_barrier_unload, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.Pic_confirmed_unload, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.Pic_pres_end_load, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.Pic_barrier_load, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.Pic_confirmed_load, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.Pic_pres_start_paint, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.Pic_doorIN_open, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.Pic_pres_end_paint, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.Pic_doorOUT_open, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.Pic_doorOUT_close, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.Pic_doorIN_close, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.Pic_pres_start_unload, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.Pic_pres_start_load, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.Pic_Piece_Load, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.PictureBox2, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.TabPage3.SuspendLayout()
			Me.GrpManualComands.SuspendLayout()
			Me.GrpLng.SuspendLayout()
			Me.TabPage2.SuspendLayout()
			Me.grp_debug.SuspendLayout()
			Me.GroupBox9.SuspendLayout()
			CType(Me.dgv_dout_IMA, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.dgv_din_IMA, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.dgv_dout, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.dgv_din, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.GroupBox8.SuspendLayout()
			Me.GroupBox4.SuspendLayout()
			CType(Me.dgv_ciclica, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.GroupBox2.SuspendLayout()
			Me.GroupBox1.SuspendLayout()
			CType(Me.dgv_master, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.TabPage4.SuspendLayout()
			CType(Me.dgv_ax, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.Grp_stats.SuspendLayout()
			CType(Me.dgv_robot1_stats, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.dgv_programlist, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.TabControl.Appearance = Global.System.Windows.Forms.TabAppearance.FlatButtons
			Me.TabControl.Controls.Add(Me.TabPage1)
			Me.TabControl.Controls.Add(Me.TabPage3)
			Me.TabControl.Controls.Add(Me.TabPage2)
			Me.TabControl.Controls.Add(Me.TabPage4)
			Me.TabControl.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.TabControl.ItemSize = New Global.System.Drawing.Size(238, 50)
			Me.TabControl.Location = New Global.System.Drawing.Point(5, 12)
			Me.TabControl.Name = "TabControl"
			Me.TabControl.Padding = New Global.System.Drawing.Point(47, 3)
			Me.TabControl.SelectedIndex = 0
			Me.TabControl.Size = New Global.System.Drawing.Size(1000, 972)
			Me.TabControl.SizeMode = Global.System.Windows.Forms.TabSizeMode.Fixed
			Me.TabControl.TabIndex = 26
			Me.TabPage1.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.TabPage1.Controls.Add(Me.lbl_Oven_st_emerg)
			Me.TabPage1.Controls.Add(Me.lbl_reset_errors)
			Me.TabPage1.Controls.Add(Me.lbl_reset_warning)
			Me.TabPage1.Controls.Add(Me.lbl_Load_st_emerg)
			Me.TabPage1.Controls.Add(Me.lbl_Unload_st_emerg)
			Me.TabPage1.Controls.Add(Me.Lbl_Emergency)
			Me.TabPage1.Controls.Add(Me.lbl_Paint_st_emerg)
			Me.TabPage1.Controls.Add(Me.Lbl_Warning)
			Me.TabPage1.Controls.Add(Me.Lbl_Errors)
			Me.TabPage1.Controls.Add(Me.lbl_PLC_On)
			Me.TabPage1.Controls.Add(Me.PnlRobot)
			Me.TabPage1.Controls.Add(Me.Lbl_MotorON_Plant)
			Me.TabPage1.Controls.Add(Me.Lbl_Warning_cyc)
			Me.TabPage1.Controls.Add(Me.LblLinea)
			Me.TabPage1.Controls.Add(Me.Lbl_AUTO_Plant)
			Me.TabPage1.Controls.Add(Me.LblAlarmaDes)
			Me.TabPage1.Location = New Global.System.Drawing.Point(4, 54)
			Me.TabPage1.Name = "TabPage1"
			Me.TabPage1.Padding = New Global.System.Windows.Forms.Padding(3)
			Me.TabPage1.Size = New Global.System.Drawing.Size(992, 914)
			Me.TabPage1.TabIndex = 0
			Me.TabPage1.Text = "PRINCIPAL"
			Me.TabPage1.UseVisualStyleBackColor = True
			Me.lbl_Oven_st_emerg.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.lbl_Oven_st_emerg.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F)
			Me.lbl_Oven_st_emerg.Location = New Global.System.Drawing.Point(224, 574)
			Me.lbl_Oven_st_emerg.Name = "lbl_Oven_st_emerg"
			Me.lbl_Oven_st_emerg.Size = New Global.System.Drawing.Size(180, 25)
			Me.lbl_Oven_st_emerg.TabIndex = 348
			Me.lbl_Oven_st_emerg.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.lbl_reset_errors.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 21F, Global.System.Drawing.FontStyle.Bold)
			Me.lbl_reset_errors.Location = New Global.System.Drawing.Point(956, 545)
			Me.lbl_reset_errors.Name = "lbl_reset_errors"
			Me.lbl_reset_errors.Size = New Global.System.Drawing.Size(30, 37)
			Me.lbl_reset_errors.TabIndex = 347
			Me.lbl_reset_errors.Text = "R"
			Me.lbl_reset_errors.UseVisualStyleBackColor = True
			Me.lbl_reset_warning.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 21F, Global.System.Drawing.FontStyle.Bold)
			Me.lbl_reset_warning.Location = New Global.System.Drawing.Point(956, 606)
			Me.lbl_reset_warning.Name = "lbl_reset_warning"
			Me.lbl_reset_warning.Size = New Global.System.Drawing.Size(30, 37)
			Me.lbl_reset_warning.TabIndex = 346
			Me.lbl_reset_warning.Text = "R"
			Me.lbl_reset_warning.UseVisualStyleBackColor = True
			Me.lbl_Load_st_emerg.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.lbl_Load_st_emerg.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F)
			Me.lbl_Load_st_emerg.Location = New Global.System.Drawing.Point(224, 547)
			Me.lbl_Load_st_emerg.Name = "lbl_Load_st_emerg"
			Me.lbl_Load_st_emerg.Size = New Global.System.Drawing.Size(180, 25)
			Me.lbl_Load_st_emerg.TabIndex = 345
			Me.lbl_Load_st_emerg.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.lbl_Unload_st_emerg.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.lbl_Unload_st_emerg.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F)
			Me.lbl_Unload_st_emerg.Location = New Global.System.Drawing.Point(224, 628)
			Me.lbl_Unload_st_emerg.Name = "lbl_Unload_st_emerg"
			Me.lbl_Unload_st_emerg.Size = New Global.System.Drawing.Size(180, 25)
			Me.lbl_Unload_st_emerg.TabIndex = 344
			Me.lbl_Unload_st_emerg.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Lbl_Emergency.AutoSize = True
			Me.Lbl_Emergency.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11F, Global.System.Drawing.FontStyle.Bold)
			Me.Lbl_Emergency.Location = New Global.System.Drawing.Point(224, 527)
			Me.Lbl_Emergency.Name = "Lbl_Emergency"
			Me.Lbl_Emergency.Size = New Global.System.Drawing.Size(113, 18)
			Me.Lbl_Emergency.TabIndex = 343
			Me.Lbl_Emergency.Text = "EMERGENZE"
			Me.lbl_Paint_st_emerg.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.lbl_Paint_st_emerg.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F)
			Me.lbl_Paint_st_emerg.Location = New Global.System.Drawing.Point(224, 601)
			Me.lbl_Paint_st_emerg.Name = "lbl_Paint_st_emerg"
			Me.lbl_Paint_st_emerg.Size = New Global.System.Drawing.Size(180, 25)
			Me.lbl_Paint_st_emerg.TabIndex = 342
			Me.lbl_Paint_st_emerg.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Lbl_Warning.AutoSize = True
			Me.Lbl_Warning.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11F, Global.System.Drawing.FontStyle.Bold)
			Me.Lbl_Warning.Location = New Global.System.Drawing.Point(447, 588)
			Me.Lbl_Warning.Name = "Lbl_Warning"
			Me.Lbl_Warning.Size = New Global.System.Drawing.Size(87, 18)
			Me.Lbl_Warning.TabIndex = 341
			Me.Lbl_Warning.Text = "WARNING"
			Me.Lbl_Errors.AutoSize = True
			Me.Lbl_Errors.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11F, Global.System.Drawing.FontStyle.Bold)
			Me.Lbl_Errors.Location = New Global.System.Drawing.Point(447, 523)
			Me.Lbl_Errors.Name = "Lbl_Errors"
			Me.Lbl_Errors.Size = New Global.System.Drawing.Size(76, 18)
			Me.Lbl_Errors.TabIndex = 340
			Me.Lbl_Errors.Text = "ALLARMI"
			Me.lbl_PLC_On.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.lbl_PLC_On.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F)
			Me.lbl_PLC_On.Location = New Global.System.Drawing.Point(14, 547)
			Me.lbl_PLC_On.Name = "lbl_PLC_On"
			Me.lbl_PLC_On.Size = New Global.System.Drawing.Size(180, 25)
			Me.lbl_PLC_On.TabIndex = 167
			Me.lbl_PLC_On.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.PnlRobot.BackColor = Global.System.Drawing.SystemColors.Window
			Me.PnlRobot.Controls.Add(Me.btn_reset_cyc_main)
			Me.PnlRobot.Controls.Add(Me.btn_force_unload_step)
			Me.PnlRobot.Controls.Add(Me.btn_Send_tcpip)
			Me.PnlRobot.Controls.Add(Me.lbl_act_option_l)
			Me.PnlRobot.Controls.Add(Me.GroupBox3)
			Me.PnlRobot.Controls.Add(Me.lbl_mmOvenBelt)
			Me.PnlRobot.Controls.Add(Me.lbl_code_Oven)
			Me.PnlRobot.Controls.Add(Me.Pic_Oven_doorIN_open)
			Me.PnlRobot.Controls.Add(Me.Pic_Oven_doorIN_close)
			Me.PnlRobot.Controls.Add(Me.Pic_pres_end_oven)
			Me.PnlRobot.Controls.Add(Me.Pic_pres_start_oven)
			Me.PnlRobot.Controls.Add(Me.Pic_Piece_Oven)
			Me.PnlRobot.Controls.Add(Me.GrpCarico)
			Me.PnlRobot.Controls.Add(Me.lbl_code_Unload_ST1)
			Me.PnlRobot.Controls.Add(Me.Pic_pres_safe_unload)
			Me.PnlRobot.Controls.Add(Me.Pic_Piece_Paint)
			Me.PnlRobot.Controls.Add(Me.Pic_Piece_Unload_1)
			Me.PnlRobot.Controls.Add(Me.lbl_waiting_resume)
			Me.PnlRobot.Controls.Add(Me.lbl_mmUnloadBelt)
			Me.PnlRobot.Controls.Add(Me.lbl_mmPaintBelt)
			Me.PnlRobot.Controls.Add(Me.lbl_mmLoadBelt)
			Me.PnlRobot.Controls.Add(Me.GroupBox6)
			Me.PnlRobot.Controls.Add(Me.GroupBox5)
			Me.PnlRobot.Controls.Add(Me.lbl_code_Paint)
			Me.PnlRobot.Controls.Add(Me.lbl_code_Load)
			Me.PnlRobot.Controls.Add(Me.Pic_pres_end_unload)
			Me.PnlRobot.Controls.Add(Me.Pic_barrier_unload)
			Me.PnlRobot.Controls.Add(Me.Pic_confirmed_unload)
			Me.PnlRobot.Controls.Add(Me.Pic_pres_end_load)
			Me.PnlRobot.Controls.Add(Me.Pic_barrier_load)
			Me.PnlRobot.Controls.Add(Me.Pic_confirmed_load)
			Me.PnlRobot.Controls.Add(Me.Pic_pres_start_paint)
			Me.PnlRobot.Controls.Add(Me.Pic_doorIN_open)
			Me.PnlRobot.Controls.Add(Me.Pic_pres_end_paint)
			Me.PnlRobot.Controls.Add(Me.Pic_doorOUT_open)
			Me.PnlRobot.Controls.Add(Me.Pic_doorOUT_close)
			Me.PnlRobot.Controls.Add(Me.Pic_doorIN_close)
			Me.PnlRobot.Controls.Add(Me.Pic_pres_start_unload)
			Me.PnlRobot.Controls.Add(Me.Pic_pres_start_load)
			Me.PnlRobot.Controls.Add(Me.LblDescrizione)
			Me.PnlRobot.Controls.Add(Me.Pic_Piece_Load)
			Me.PnlRobot.Controls.Add(Me.LblScaricoConfermato)
			Me.PnlRobot.Controls.Add(Me.LblCaricoConfermato)
			Me.PnlRobot.Controls.Add(Me.PictureBox2)
			Me.PnlRobot.Location = New Global.System.Drawing.Point(3, 3)
			Me.PnlRobot.Name = "PnlRobot"
			Me.PnlRobot.Size = New Global.System.Drawing.Size(1228, 518)
			Me.PnlRobot.TabIndex = 104
			Me.btn_force_unload_step.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 10.5F, Global.System.Drawing.FontStyle.Bold)
			Me.btn_force_unload_step.Location = New Global.System.Drawing.Point(791, 246)
			Me.btn_force_unload_step.Name = "btn_force_unload_step"
			Me.btn_force_unload_step.Size = New Global.System.Drawing.Size(125, 39)
			Me.btn_force_unload_step.TabIndex = 360
			Me.btn_force_unload_step.Text = "Force"
			Me.btn_force_unload_step.UseVisualStyleBackColor = True
			Me.btn_force_unload_step.Visible = False
			Me.btn_Send_tcpip.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 10.5F, Global.System.Drawing.FontStyle.Bold)
			Me.btn_Send_tcpip.Location = New Global.System.Drawing.Point(284, 27)
			Me.btn_Send_tcpip.Name = "btn_Send_tcpip"
			Me.btn_Send_tcpip.Size = New Global.System.Drawing.Size(79, 33)
			Me.btn_Send_tcpip.TabIndex = 359
			Me.btn_Send_tcpip.Text = "Update"
			Me.btn_Send_tcpip.UseVisualStyleBackColor = True
			Me.lbl_act_option_l.BackColor = Global.System.Drawing.Color.White
			Me.lbl_act_option_l.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lbl_act_option_l.Location = New Global.System.Drawing.Point(293, 27)
			Me.lbl_act_option_l.Name = "lbl_act_option_l"
			Me.lbl_act_option_l.Size = New Global.System.Drawing.Size(55, 23)
			Me.lbl_act_option_l.TabIndex = 354
			Me.lbl_act_option_l.Text = "OPT."
			Me.lbl_act_option_l.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.GroupBox3.BackColor = Global.System.Drawing.SystemColors.Window
			Me.GroupBox3.Controls.Add(Me.btn_oven_t_plus)
			Me.GroupBox3.Controls.Add(Me.btn_force_oven_timeout)
			Me.GroupBox3.Controls.Add(Me.btn_oven_t_min)
			Me.GroupBox3.Controls.Add(Me.lbl_timeout_oven_set)
			Me.GroupBox3.Controls.Add(Me.lbl_timeout_oven)
			Me.GroupBox3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 10.5F, Global.System.Drawing.FontStyle.Bold)
			Me.GroupBox3.Location = New Global.System.Drawing.Point(74, 279)
			Me.GroupBox3.Name = "GroupBox3"
			Me.GroupBox3.Size = New Global.System.Drawing.Size(295, 87)
			Me.GroupBox3.TabIndex = 343
			Me.GroupBox3.TabStop = False
			Me.GroupBox3.Text = "LOAD"
			Me.btn_oven_t_plus.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btn_oven_t_plus.Location = New Global.System.Drawing.Point(262, 23)
			Me.btn_oven_t_plus.Name = "btn_oven_t_plus"
			Me.btn_oven_t_plus.Size = New Global.System.Drawing.Size(27, 22)
			Me.btn_oven_t_plus.TabIndex = 350
			Me.btn_oven_t_plus.Text = "+"
			Me.btn_oven_t_plus.TextAlign = Global.System.Drawing.ContentAlignment.TopCenter
			Me.btn_oven_t_plus.UseVisualStyleBackColor = True
			Me.btn_force_oven_timeout.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btn_force_oven_timeout.Location = New Global.System.Drawing.Point(222, 48)
			Me.btn_force_oven_timeout.Name = "btn_force_oven_timeout"
			Me.btn_force_oven_timeout.Size = New Global.System.Drawing.Size(67, 22)
			Me.btn_force_oven_timeout.TabIndex = 349
			Me.btn_force_oven_timeout.Text = "done"
			Me.btn_force_oven_timeout.UseVisualStyleBackColor = True
			Me.btn_oven_t_min.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.btn_oven_t_min.Location = New Global.System.Drawing.Point(222, 23)
			Me.btn_oven_t_min.Name = "btn_oven_t_min"
			Me.btn_oven_t_min.Size = New Global.System.Drawing.Size(27, 22)
			Me.btn_oven_t_min.TabIndex = 348
			Me.btn_oven_t_min.Text = "-"
			Me.btn_oven_t_min.TextAlign = Global.System.Drawing.ContentAlignment.TopCenter
			Me.btn_oven_t_min.UseVisualStyleBackColor = True
			Me.lbl_timeout_oven_set.BackColor = Global.System.Drawing.Color.White
			Me.lbl_timeout_oven_set.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.lbl_timeout_oven_set.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F)
			Me.lbl_timeout_oven_set.Location = New Global.System.Drawing.Point(121, 23)
			Me.lbl_timeout_oven_set.Name = "lbl_timeout_oven_set"
			Me.lbl_timeout_oven_set.Size = New Global.System.Drawing.Size(86, 42)
			Me.lbl_timeout_oven_set.TabIndex = 327
			Me.lbl_timeout_oven_set.Text = "00:00"
			Me.lbl_timeout_oven_set.TextAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.lbl_timeout_oven.BackColor = Global.System.Drawing.Color.White
			Me.lbl_timeout_oven.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.lbl_timeout_oven.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F)
			Me.lbl_timeout_oven.Location = New Global.System.Drawing.Point(15, 23)
			Me.lbl_timeout_oven.Name = "lbl_timeout_oven"
			Me.lbl_timeout_oven.Size = New Global.System.Drawing.Size(86, 42)
			Me.lbl_timeout_oven.TabIndex = 326
			Me.lbl_timeout_oven.Text = "00:00"
			Me.lbl_timeout_oven.TextAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.lbl_mmOvenBelt.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.lbl_mmOvenBelt.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.5F, Global.System.Drawing.FontStyle.Bold)
			Me.lbl_mmOvenBelt.Location = New Global.System.Drawing.Point(250, 83)
			Me.lbl_mmOvenBelt.Name = "lbl_mmOvenBelt"
			Me.lbl_mmOvenBelt.Size = New Global.System.Drawing.Size(115, 25)
			Me.lbl_mmOvenBelt.TabIndex = 358
			Me.lbl_mmOvenBelt.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.lbl_mmOvenBelt.Visible = False
			Me.lbl_code_Oven.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.lbl_code_Oven.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.5F, Global.System.Drawing.FontStyle.Bold)
			Me.lbl_code_Oven.Location = New Global.System.Drawing.Point(234, 202)
			Me.lbl_code_Oven.Name = "lbl_code_Oven"
			Me.lbl_code_Oven.Size = New Global.System.Drawing.Size(146, 28)
			Me.lbl_code_Oven.TabIndex = 357
			Me.lbl_code_Oven.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Pic_Oven_doorIN_open.BackColor = Global.System.Drawing.Color.Silver
			Me.Pic_Oven_doorIN_open.Location = New Global.System.Drawing.Point(400, 135)
			Me.Pic_Oven_doorIN_open.Name = "Pic_Oven_doorIN_open"
			Me.Pic_Oven_doorIN_open.Size = New Global.System.Drawing.Size(25, 25)
			Me.Pic_Oven_doorIN_open.TabIndex = 356
			Me.Pic_Oven_doorIN_open.TabStop = False
			Me.Pic_Oven_doorIN_close.BackColor = Global.System.Drawing.Color.Silver
			Me.Pic_Oven_doorIN_close.Location = New Global.System.Drawing.Point(400, 164)
			Me.Pic_Oven_doorIN_close.Name = "Pic_Oven_doorIN_close"
			Me.Pic_Oven_doorIN_close.Size = New Global.System.Drawing.Size(25, 25)
			Me.Pic_Oven_doorIN_close.TabIndex = 355
			Me.Pic_Oven_doorIN_close.TabStop = False
			Me.Pic_pres_end_oven.BackColor = Global.System.Drawing.Color.Silver
			Me.Pic_pres_end_oven.Location = New Global.System.Drawing.Point(369, 114)
			Me.Pic_pres_end_oven.Name = "Pic_pres_end_oven"
			Me.Pic_pres_end_oven.Size = New Global.System.Drawing.Size(25, 25)
			Me.Pic_pres_end_oven.TabIndex = 354
			Me.Pic_pres_end_oven.TabStop = False
			Me.Pic_pres_start_oven.BackColor = Global.System.Drawing.Color.Silver
			Me.Pic_pres_start_oven.Location = New Global.System.Drawing.Point(221, 114)
			Me.Pic_pres_start_oven.Name = "Pic_pres_start_oven"
			Me.Pic_pres_start_oven.Size = New Global.System.Drawing.Size(25, 25)
			Me.Pic_pres_start_oven.TabIndex = 353
			Me.Pic_pres_start_oven.TabStop = False
			Me.Pic_Piece_Oven.Image = CType(componentResourceManager.GetObject("Pic_Piece_Oven.Image"), Global.System.Drawing.Image)
			Me.Pic_Piece_Oven.Location = New Global.System.Drawing.Point(255, 141)
			Me.Pic_Piece_Oven.Name = "Pic_Piece_Oven"
			Me.Pic_Piece_Oven.Size = New Global.System.Drawing.Size(106, 38)
			Me.Pic_Piece_Oven.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.Pic_Piece_Oven.TabIndex = 352
			Me.Pic_Piece_Oven.TabStop = False
			Me.Pic_Piece_Oven.Tag = "17"
			Me.Pic_Piece_Oven.Visible = False
			Me.GrpCarico.Controls.Add(Me.lbl_act_option)
			Me.GrpCarico.Controls.Add(Me.lbl_act_batch)
			Me.GrpCarico.Controls.Add(Me.cmb_act_code)
			Me.GrpCarico.Controls.Add(Me.lbl_act_code)
			Me.GrpCarico.Controls.Add(Me.lbl_act_batch_l)
			Me.GrpCarico.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GrpCarico.Location = New Global.System.Drawing.Point(2, 0)
			Me.GrpCarico.Name = "GrpCarico"
			Me.GrpCarico.Size = New Global.System.Drawing.Size(275, 74)
			Me.GrpCarico.TabIndex = 138
			Me.GrpCarico.TabStop = False
			Me.GrpCarico.Text = "Progama"
			Me.lbl_act_option.BackColor = Global.System.Drawing.SystemColors.Control
			Me.lbl_act_option.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.lbl_act_option.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 7F, Global.System.Drawing.FontStyle.Bold)
			Me.lbl_act_option.Location = New Global.System.Drawing.Point(313, 40)
			Me.lbl_act_option.Name = "lbl_act_option"
			Me.lbl_act_option.Size = New Global.System.Drawing.Size(141, 27)
			Me.lbl_act_option.TabIndex = 353
			Me.lbl_act_option.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.lbl_act_batch.BackColor = Global.System.Drawing.SystemColors.Control
			Me.lbl_act_batch.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.lbl_act_batch.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 7F, Global.System.Drawing.FontStyle.Bold)
			Me.lbl_act_batch.Location = New Global.System.Drawing.Point(313, 17)
			Me.lbl_act_batch.Name = "lbl_act_batch"
			Me.lbl_act_batch.Size = New Global.System.Drawing.Size(141, 23)
			Me.lbl_act_batch.TabIndex = 352
			Me.lbl_act_batch.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.cmb_act_code.BackColor = Global.System.Drawing.SystemColors.Window
			Me.cmb_act_code.DropDownStyle = Global.System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmb_act_code.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 16F, Global.System.Drawing.FontStyle.Bold)
			Me.cmb_act_code.FormattingEnabled = True
			Me.cmb_act_code.IntegralHeight = False
			Me.cmb_act_code.ItemHeight = 25
			Me.cmb_act_code.Location = New Global.System.Drawing.Point(11, 27)
			Me.cmb_act_code.Name = "cmb_act_code"
			Me.cmb_act_code.RightToLeft = Global.System.Windows.Forms.RightToLeft.No
			Me.cmb_act_code.Size = New Global.System.Drawing.Size(249, 33)
			Me.cmb_act_code.Sorted = True
			Me.cmb_act_code.TabIndex = 296
			Me.lbl_act_code.BackColor = Global.System.Drawing.SystemColors.Control
			Me.lbl_act_code.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.lbl_act_code.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F)
			Me.lbl_act_code.Location = New Global.System.Drawing.Point(11, 20)
			Me.lbl_act_code.Name = "lbl_act_code"
			Me.lbl_act_code.Size = New Global.System.Drawing.Size(249, 47)
			Me.lbl_act_code.TabIndex = 348
			Me.lbl_act_code.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.lbl_act_batch_l.BackColor = Global.System.Drawing.Color.White
			Me.lbl_act_batch_l.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lbl_act_batch_l.Location = New Global.System.Drawing.Point(165, 27)
			Me.lbl_act_batch_l.Name = "lbl_act_batch_l"
			Me.lbl_act_batch_l.Size = New Global.System.Drawing.Size(37, 23)
			Me.lbl_act_batch_l.TabIndex = 352
			Me.lbl_act_batch_l.Text = "L."
			Me.lbl_act_batch_l.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.lbl_code_Unload_ST1.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.lbl_code_Unload_ST1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.5F, Global.System.Drawing.FontStyle.Bold)
			Me.lbl_code_Unload_ST1.Location = New Global.System.Drawing.Point(781, 202)
			Me.lbl_code_Unload_ST1.Name = "lbl_code_Unload_ST1"
			Me.lbl_code_Unload_ST1.Size = New Global.System.Drawing.Size(146, 28)
			Me.lbl_code_Unload_ST1.TabIndex = 351
			Me.lbl_code_Unload_ST1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Pic_pres_safe_unload.BackColor = Global.System.Drawing.Color.Silver
			Me.Pic_pres_safe_unload.Location = New Global.System.Drawing.Point(945, 81)
			Me.Pic_pres_safe_unload.Name = "Pic_pres_safe_unload"
			Me.Pic_pres_safe_unload.Size = New Global.System.Drawing.Size(25, 25)
			Me.Pic_pres_safe_unload.TabIndex = 350
			Me.Pic_pres_safe_unload.TabStop = False
			Me.Pic_pres_safe_unload.Visible = False
			Me.Pic_Piece_Paint.Image = CType(componentResourceManager.GetObject("Pic_Piece_Paint.Image"), Global.System.Drawing.Image)
			Me.Pic_Piece_Paint.Location = New Global.System.Drawing.Point(534, 141)
			Me.Pic_Piece_Paint.Name = "Pic_Piece_Paint"
			Me.Pic_Piece_Paint.Size = New Global.System.Drawing.Size(106, 38)
			Me.Pic_Piece_Paint.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.Pic_Piece_Paint.TabIndex = 301
			Me.Pic_Piece_Paint.TabStop = False
			Me.Pic_Piece_Paint.Tag = "17"
			Me.Pic_Piece_Paint.Visible = False
			Me.Pic_Piece_Unload_1.Image = CType(componentResourceManager.GetObject("Pic_Piece_Unload_1.Image"), Global.System.Drawing.Image)
			Me.Pic_Piece_Unload_1.Location = New Global.System.Drawing.Point(807, 141)
			Me.Pic_Piece_Unload_1.Name = "Pic_Piece_Unload_1"
			Me.Pic_Piece_Unload_1.Size = New Global.System.Drawing.Size(106, 38)
			Me.Pic_Piece_Unload_1.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.Pic_Piece_Unload_1.TabIndex = 300
			Me.Pic_Piece_Unload_1.TabStop = False
			Me.Pic_Piece_Unload_1.Tag = "17"
			Me.Pic_Piece_Unload_1.Visible = False
			Me.lbl_waiting_resume.BackColor = Global.System.Drawing.Color.White
			Me.lbl_waiting_resume.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.lbl_waiting_resume.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14F, Global.System.Drawing.FontStyle.Bold)
			Me.lbl_waiting_resume.ForeColor = Global.System.Drawing.Color.Black
			Me.lbl_waiting_resume.Location = New Global.System.Drawing.Point(470, 18)
			Me.lbl_waiting_resume.Name = "lbl_waiting_resume"
			Me.lbl_waiting_resume.Size = New Global.System.Drawing.Size(500, 58)
			Me.lbl_waiting_resume.TabIndex = 348
			Me.lbl_waiting_resume.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.lbl_waiting_resume.Visible = False
			Me.lbl_mmUnloadBelt.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.lbl_mmUnloadBelt.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.5F, Global.System.Drawing.FontStyle.Bold)
			Me.lbl_mmUnloadBelt.Location = New Global.System.Drawing.Point(791, 83)
			Me.lbl_mmUnloadBelt.Name = "lbl_mmUnloadBelt"
			Me.lbl_mmUnloadBelt.Size = New Global.System.Drawing.Size(136, 25)
			Me.lbl_mmUnloadBelt.TabIndex = 345
			Me.lbl_mmUnloadBelt.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.lbl_mmUnloadBelt.Visible = False
			Me.lbl_mmPaintBelt.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.lbl_mmPaintBelt.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lbl_mmPaintBelt.Location = New Global.System.Drawing.Point(525, 83)
			Me.lbl_mmPaintBelt.Name = "lbl_mmPaintBelt"
			Me.lbl_mmPaintBelt.Size = New Global.System.Drawing.Size(136, 25)
			Me.lbl_mmPaintBelt.TabIndex = 344
			Me.lbl_mmPaintBelt.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.lbl_mmPaintBelt.Visible = False
			Me.lbl_mmLoadBelt.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.lbl_mmLoadBelt.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.5F, Global.System.Drawing.FontStyle.Bold)
			Me.lbl_mmLoadBelt.Location = New Global.System.Drawing.Point(801, 51)
			Me.lbl_mmLoadBelt.Name = "lbl_mmLoadBelt"
			Me.lbl_mmLoadBelt.Size = New Global.System.Drawing.Size(115, 25)
			Me.lbl_mmLoadBelt.TabIndex = 343
			Me.lbl_mmLoadBelt.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.lbl_mmLoadBelt.Visible = False
			Me.GroupBox6.BackColor = Global.System.Drawing.SystemColors.Window
			Me.GroupBox6.Controls.Add(Me.lbl_status_robot1_main)
			Me.GroupBox6.Controls.Add(Me.LblRobot1Busy)
			Me.GroupBox6.Controls.Add(Me.LblRobot1prgRun)
			Me.GroupBox6.Controls.Add(Me.PicRobot1Busy)
			Me.GroupBox6.Controls.Add(Me.PicRobot1PrgRun)
			Me.GroupBox6.Controls.Add(Me.Lbl_EmptyList_R1)
			Me.GroupBox6.Controls.Add(Me.LblRobot1FouriIngombro)
			Me.GroupBox6.Controls.Add(Me.PicRobot1EmptyList)
			Me.GroupBox6.Controls.Add(Me.PicRobot1FouriIngombro)
			Me.GroupBox6.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 10.5F, Global.System.Drawing.FontStyle.Bold)
			Me.GroupBox6.Location = New Global.System.Drawing.Point(779, 351)
			Me.GroupBox6.Name = "GroupBox6"
			Me.GroupBox6.Size = New Global.System.Drawing.Size(191, 152)
			Me.GroupBox6.TabIndex = 341
			Me.GroupBox6.TabStop = False
			Me.GroupBox6.Text = "ROBOT1"
			Me.lbl_status_robot1_main.BackColor = Global.System.Drawing.Color.Lime
			Me.lbl_status_robot1_main.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.lbl_status_robot1_main.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F, Global.System.Drawing.FontStyle.Bold)
			Me.lbl_status_robot1_main.Location = New Global.System.Drawing.Point(22, 21)
			Me.lbl_status_robot1_main.Name = "lbl_status_robot1_main"
			Me.lbl_status_robot1_main.Size = New Global.System.Drawing.Size(155, 19)
			Me.lbl_status_robot1_main.TabIndex = 286
			Me.lbl_status_robot1_main.Text = "Sato Robot"
			Me.lbl_status_robot1_main.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.LblRobot1Busy.BackColor = Global.System.Drawing.Color.White
			Me.LblRobot1Busy.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.LblRobot1Busy.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F)
			Me.LblRobot1Busy.Location = New Global.System.Drawing.Point(45, 46)
			Me.LblRobot1Busy.Name = "LblRobot1Busy"
			Me.LblRobot1Busy.Size = New Global.System.Drawing.Size(139, 18)
			Me.LblRobot1Busy.TabIndex = 282
			Me.LblRobot1Busy.Text = "Robot Pronto"
			Me.LblRobot1Busy.TextAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.LblRobot1prgRun.BackColor = Global.System.Drawing.Color.White
			Me.LblRobot1prgRun.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.LblRobot1prgRun.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F)
			Me.LblRobot1prgRun.Location = New Global.System.Drawing.Point(45, 69)
			Me.LblRobot1prgRun.Name = "LblRobot1prgRun"
			Me.LblRobot1prgRun.Size = New Global.System.Drawing.Size(139, 18)
			Me.LblRobot1prgRun.TabIndex = 283
			Me.LblRobot1prgRun.Text = "program run"
			Me.LblRobot1prgRun.TextAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.PicRobot1Busy.BackColor = Global.System.Drawing.Color.Silver
			Me.PicRobot1Busy.Location = New Global.System.Drawing.Point(23, 46)
			Me.PicRobot1Busy.Name = "PicRobot1Busy"
			Me.PicRobot1Busy.Size = New Global.System.Drawing.Size(15, 15)
			Me.PicRobot1Busy.TabIndex = 284
			Me.PicRobot1Busy.TabStop = False
			Me.PicRobot1PrgRun.BackColor = Global.System.Drawing.Color.Silver
			Me.PicRobot1PrgRun.Location = New Global.System.Drawing.Point(23, 69)
			Me.PicRobot1PrgRun.Name = "PicRobot1PrgRun"
			Me.PicRobot1PrgRun.Size = New Global.System.Drawing.Size(15, 15)
			Me.PicRobot1PrgRun.TabIndex = 285
			Me.PicRobot1PrgRun.TabStop = False
			Me.Lbl_EmptyList_R1.BackColor = Global.System.Drawing.Color.White
			Me.Lbl_EmptyList_R1.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.Lbl_EmptyList_R1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F)
			Me.Lbl_EmptyList_R1.Location = New Global.System.Drawing.Point(45, 115)
			Me.Lbl_EmptyList_R1.Name = "Lbl_EmptyList_R1"
			Me.Lbl_EmptyList_R1.Size = New Global.System.Drawing.Size(139, 18)
			Me.Lbl_EmptyList_R1.TabIndex = 336
			Me.Lbl_EmptyList_R1.Text = "Lista Vuota"
			Me.Lbl_EmptyList_R1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.LblRobot1FouriIngombro.BackColor = Global.System.Drawing.Color.White
			Me.LblRobot1FouriIngombro.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.LblRobot1FouriIngombro.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F)
			Me.LblRobot1FouriIngombro.Location = New Global.System.Drawing.Point(45, 92)
			Me.LblRobot1FouriIngombro.Name = "LblRobot1FouriIngombro"
			Me.LblRobot1FouriIngombro.Size = New Global.System.Drawing.Size(139, 18)
			Me.LblRobot1FouriIngombro.TabIndex = 287
			Me.LblRobot1FouriIngombro.Text = "Robot fuori ingombro"
			Me.LblRobot1FouriIngombro.TextAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.PicRobot1EmptyList.BackColor = Global.System.Drawing.Color.Silver
			Me.PicRobot1EmptyList.Location = New Global.System.Drawing.Point(23, 115)
			Me.PicRobot1EmptyList.Name = "PicRobot1EmptyList"
			Me.PicRobot1EmptyList.Size = New Global.System.Drawing.Size(15, 15)
			Me.PicRobot1EmptyList.TabIndex = 335
			Me.PicRobot1EmptyList.TabStop = False
			Me.PicRobot1FouriIngombro.BackColor = Global.System.Drawing.Color.Silver
			Me.PicRobot1FouriIngombro.Location = New Global.System.Drawing.Point(23, 92)
			Me.PicRobot1FouriIngombro.Name = "PicRobot1FouriIngombro"
			Me.PicRobot1FouriIngombro.Size = New Global.System.Drawing.Size(15, 15)
			Me.PicRobot1FouriIngombro.TabIndex = 288
			Me.PicRobot1FouriIngombro.TabStop = False
			Me.GroupBox5.BackColor = Global.System.Drawing.SystemColors.Window
			Me.GroupBox5.Controls.Add(Me.lbl_Sirtek_plant_ready)
			Me.GroupBox5.Controls.Add(Me.Pic_Sirtek_plant_ready)
			Me.GroupBox5.Controls.Add(Me.lbl_SR20G_R1_ready)
			Me.GroupBox5.Controls.Add(Me.Pic_SR20G_R1_ready)
			Me.GroupBox5.Controls.Add(Me.Pic_unload_done)
			Me.GroupBox5.Controls.Add(Me.lbl_confirm_button)
			Me.GroupBox5.Controls.Add(Me.lbl_plant_auto_ready)
			Me.GroupBox5.Controls.Add(Me.lbl_unload_done)
			Me.GroupBox5.Controls.Add(Me.Pic_plant_auto_ready)
			Me.GroupBox5.Controls.Add(Me.Pic_confirm_button)
			Me.GroupBox5.Controls.Add(Me.lbl_robots_ready)
			Me.GroupBox5.Controls.Add(Me.Pic_robots_ready)
			Me.GroupBox5.Controls.Add(Me.Pic_coder_ready)
			Me.GroupBox5.Controls.Add(Me.lbl_barriera_load)
			Me.GroupBox5.Controls.Add(Me.lbl_coder_ready)
			Me.GroupBox5.Controls.Add(Me.Pic_barrier_load_ready)
			Me.GroupBox5.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 10.5F, Global.System.Drawing.FontStyle.Bold)
			Me.GroupBox5.Location = New Global.System.Drawing.Point(74, 372)
			Me.GroupBox5.Name = "GroupBox5"
			Me.GroupBox5.Size = New Global.System.Drawing.Size(337, 131)
			Me.GroupBox5.TabIndex = 340
			Me.GroupBox5.TabStop = False
			Me.GroupBox5.Text = "LOAD"
			Me.lbl_Sirtek_plant_ready.BackColor = Global.System.Drawing.Color.White
			Me.lbl_Sirtek_plant_ready.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.lbl_Sirtek_plant_ready.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F)
			Me.lbl_Sirtek_plant_ready.Location = New Global.System.Drawing.Point(204, 91)
			Me.lbl_Sirtek_plant_ready.Name = "lbl_Sirtek_plant_ready"
			Me.lbl_Sirtek_plant_ready.Size = New Global.System.Drawing.Size(122, 18)
			Me.lbl_Sirtek_plant_ready.TabIndex = 342
			Me.lbl_Sirtek_plant_ready.Text = "Sirtek plant ready"
			Me.lbl_Sirtek_plant_ready.TextAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Pic_Sirtek_plant_ready.BackColor = Global.System.Drawing.Color.Silver
			Me.Pic_Sirtek_plant_ready.Location = New Global.System.Drawing.Point(180, 94)
			Me.Pic_Sirtek_plant_ready.Name = "Pic_Sirtek_plant_ready"
			Me.Pic_Sirtek_plant_ready.Size = New Global.System.Drawing.Size(15, 15)
			Me.Pic_Sirtek_plant_ready.TabIndex = 341
			Me.Pic_Sirtek_plant_ready.TabStop = False
			Me.lbl_SR20G_R1_ready.BackColor = Global.System.Drawing.Color.White
			Me.lbl_SR20G_R1_ready.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.lbl_SR20G_R1_ready.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F)
			Me.lbl_SR20G_R1_ready.Location = New Global.System.Drawing.Point(204, 67)
			Me.lbl_SR20G_R1_ready.Name = "lbl_SR20G_R1_ready"
			Me.lbl_SR20G_R1_ready.Size = New Global.System.Drawing.Size(122, 18)
			Me.lbl_SR20G_R1_ready.TabIndex = 339
			Me.lbl_SR20G_R1_ready.Text = "SR20G R1"
			Me.lbl_SR20G_R1_ready.TextAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Pic_SR20G_R1_ready.BackColor = Global.System.Drawing.Color.Silver
			Me.Pic_SR20G_R1_ready.Location = New Global.System.Drawing.Point(180, 70)
			Me.Pic_SR20G_R1_ready.Name = "Pic_SR20G_R1_ready"
			Me.Pic_SR20G_R1_ready.Size = New Global.System.Drawing.Size(15, 15)
			Me.Pic_SR20G_R1_ready.TabIndex = 337
			Me.Pic_SR20G_R1_ready.TabStop = False
			Me.Pic_unload_done.BackColor = Global.System.Drawing.Color.Silver
			Me.Pic_unload_done.Location = New Global.System.Drawing.Point(180, 46)
			Me.Pic_unload_done.Name = "Pic_unload_done"
			Me.Pic_unload_done.Size = New Global.System.Drawing.Size(15, 15)
			Me.Pic_unload_done.TabIndex = 336
			Me.Pic_unload_done.TabStop = False
			Me.lbl_confirm_button.BackColor = Global.System.Drawing.Color.White
			Me.lbl_confirm_button.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.lbl_confirm_button.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F)
			Me.lbl_confirm_button.Location = New Global.System.Drawing.Point(48, 43)
			Me.lbl_confirm_button.Name = "lbl_confirm_button"
			Me.lbl_confirm_button.Size = New Global.System.Drawing.Size(122, 18)
			Me.lbl_confirm_button.TabIndex = 326
			Me.lbl_confirm_button.Text = "Confirm Button"
			Me.lbl_confirm_button.TextAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.lbl_plant_auto_ready.BackColor = Global.System.Drawing.Color.White
			Me.lbl_plant_auto_ready.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.lbl_plant_auto_ready.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F)
			Me.lbl_plant_auto_ready.Location = New Global.System.Drawing.Point(48, 19)
			Me.lbl_plant_auto_ready.Name = "lbl_plant_auto_ready"
			Me.lbl_plant_auto_ready.Size = New Global.System.Drawing.Size(122, 18)
			Me.lbl_plant_auto_ready.TabIndex = 325
			Me.lbl_plant_auto_ready.Text = "Plant Auto Ready"
			Me.lbl_plant_auto_ready.TextAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.lbl_unload_done.BackColor = Global.System.Drawing.Color.White
			Me.lbl_unload_done.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.lbl_unload_done.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F)
			Me.lbl_unload_done.Location = New Global.System.Drawing.Point(204, 43)
			Me.lbl_unload_done.Name = "lbl_unload_done"
			Me.lbl_unload_done.Size = New Global.System.Drawing.Size(122, 18)
			Me.lbl_unload_done.TabIndex = 335
			Me.lbl_unload_done.Text = "Unload Done"
			Me.lbl_unload_done.TextAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Pic_plant_auto_ready.BackColor = Global.System.Drawing.Color.Silver
			Me.Pic_plant_auto_ready.Location = New Global.System.Drawing.Point(24, 22)
			Me.Pic_plant_auto_ready.Name = "Pic_plant_auto_ready"
			Me.Pic_plant_auto_ready.Size = New Global.System.Drawing.Size(15, 15)
			Me.Pic_plant_auto_ready.TabIndex = 327
			Me.Pic_plant_auto_ready.TabStop = False
			Me.Pic_confirm_button.BackColor = Global.System.Drawing.Color.Silver
			Me.Pic_confirm_button.Location = New Global.System.Drawing.Point(24, 46)
			Me.Pic_confirm_button.Name = "Pic_confirm_button"
			Me.Pic_confirm_button.Size = New Global.System.Drawing.Size(15, 15)
			Me.Pic_confirm_button.TabIndex = 328
			Me.Pic_confirm_button.TabStop = False
			Me.lbl_robots_ready.BackColor = Global.System.Drawing.Color.White
			Me.lbl_robots_ready.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.lbl_robots_ready.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F)
			Me.lbl_robots_ready.Location = New Global.System.Drawing.Point(48, 67)
			Me.lbl_robots_ready.Name = "lbl_robots_ready"
			Me.lbl_robots_ready.Size = New Global.System.Drawing.Size(122, 18)
			Me.lbl_robots_ready.TabIndex = 329
			Me.lbl_robots_ready.Text = "Robot pronti"
			Me.lbl_robots_ready.TextAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Pic_robots_ready.BackColor = Global.System.Drawing.Color.Silver
			Me.Pic_robots_ready.Location = New Global.System.Drawing.Point(24, 70)
			Me.Pic_robots_ready.Name = "Pic_robots_ready"
			Me.Pic_robots_ready.Size = New Global.System.Drawing.Size(15, 15)
			Me.Pic_robots_ready.TabIndex = 330
			Me.Pic_robots_ready.TabStop = False
			Me.Pic_coder_ready.BackColor = Global.System.Drawing.Color.Silver
			Me.Pic_coder_ready.Location = New Global.System.Drawing.Point(180, 22)
			Me.Pic_coder_ready.Name = "Pic_coder_ready"
			Me.Pic_coder_ready.Size = New Global.System.Drawing.Size(15, 15)
			Me.Pic_coder_ready.TabIndex = 334
			Me.Pic_coder_ready.TabStop = False
			Me.lbl_barriera_load.BackColor = Global.System.Drawing.Color.White
			Me.lbl_barriera_load.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.lbl_barriera_load.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F)
			Me.lbl_barriera_load.Location = New Global.System.Drawing.Point(48, 91)
			Me.lbl_barriera_load.Name = "lbl_barriera_load"
			Me.lbl_barriera_load.Size = New Global.System.Drawing.Size(122, 18)
			Me.lbl_barriera_load.TabIndex = 331
			Me.lbl_barriera_load.Text = "Barrier"
			Me.lbl_barriera_load.TextAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.lbl_coder_ready.BackColor = Global.System.Drawing.Color.White
			Me.lbl_coder_ready.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.lbl_coder_ready.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9F)
			Me.lbl_coder_ready.Location = New Global.System.Drawing.Point(204, 19)
			Me.lbl_coder_ready.Name = "lbl_coder_ready"
			Me.lbl_coder_ready.Size = New Global.System.Drawing.Size(122, 18)
			Me.lbl_coder_ready.TabIndex = 333
			Me.lbl_coder_ready.Text = "Code ready"
			Me.lbl_coder_ready.TextAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.Pic_barrier_load_ready.BackColor = Global.System.Drawing.Color.Silver
			Me.Pic_barrier_load_ready.Location = New Global.System.Drawing.Point(24, 94)
			Me.Pic_barrier_load_ready.Name = "Pic_barrier_load_ready"
			Me.Pic_barrier_load_ready.Size = New Global.System.Drawing.Size(15, 15)
			Me.Pic_barrier_load_ready.TabIndex = 332
			Me.Pic_barrier_load_ready.TabStop = False
			Me.lbl_code_Paint.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.lbl_code_Paint.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.5F, Global.System.Drawing.FontStyle.Bold)
			Me.lbl_code_Paint.Location = New Global.System.Drawing.Point(504, 325)
			Me.lbl_code_Paint.Name = "lbl_code_Paint"
			Me.lbl_code_Paint.Size = New Global.System.Drawing.Size(157, 28)
			Me.lbl_code_Paint.TabIndex = 323
			Me.lbl_code_Paint.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.lbl_code_Load.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.lbl_code_Load.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.5F, Global.System.Drawing.FontStyle.Bold)
			Me.lbl_code_Load.Location = New Global.System.Drawing.Point(49, 202)
			Me.lbl_code_Load.Name = "lbl_code_Load"
			Me.lbl_code_Load.Size = New Global.System.Drawing.Size(146, 28)
			Me.lbl_code_Load.TabIndex = 322
			Me.lbl_code_Load.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Pic_pres_end_unload.BackColor = Global.System.Drawing.Color.Silver
			Me.Pic_pres_end_unload.Location = New Global.System.Drawing.Point(922, 114)
			Me.Pic_pres_end_unload.Name = "Pic_pres_end_unload"
			Me.Pic_pres_end_unload.Size = New Global.System.Drawing.Size(25, 25)
			Me.Pic_pres_end_unload.TabIndex = 321
			Me.Pic_pres_end_unload.TabStop = False
			Me.Pic_barrier_unload.BackColor = Global.System.Drawing.Color.Silver
			Me.Pic_barrier_unload.Location = New Global.System.Drawing.Point(929, 223)
			Me.Pic_barrier_unload.Name = "Pic_barrier_unload"
			Me.Pic_barrier_unload.Size = New Global.System.Drawing.Size(25, 25)
			Me.Pic_barrier_unload.TabIndex = 320
			Me.Pic_barrier_unload.TabStop = False
			Me.Pic_confirmed_unload.BackColor = Global.System.Drawing.Color.Silver
			Me.Pic_confirmed_unload.Location = New Global.System.Drawing.Point(929, 254)
			Me.Pic_confirmed_unload.Name = "Pic_confirmed_unload"
			Me.Pic_confirmed_unload.Size = New Global.System.Drawing.Size(25, 25)
			Me.Pic_confirmed_unload.TabIndex = 319
			Me.Pic_confirmed_unload.TabStop = False
			Me.Pic_pres_end_load.BackColor = Global.System.Drawing.Color.Silver
			Me.Pic_pres_end_load.Location = New Global.System.Drawing.Point(170, 109)
			Me.Pic_pres_end_load.Name = "Pic_pres_end_load"
			Me.Pic_pres_end_load.Size = New Global.System.Drawing.Size(25, 25)
			Me.Pic_pres_end_load.TabIndex = 318
			Me.Pic_pres_end_load.TabStop = False
			Me.Pic_barrier_load.BackColor = Global.System.Drawing.Color.Silver
			Me.Pic_barrier_load.Location = New Global.System.Drawing.Point(18, 223)
			Me.Pic_barrier_load.Name = "Pic_barrier_load"
			Me.Pic_barrier_load.Size = New Global.System.Drawing.Size(25, 25)
			Me.Pic_barrier_load.TabIndex = 317
			Me.Pic_barrier_load.TabStop = False
			Me.Pic_confirmed_load.BackColor = Global.System.Drawing.Color.Silver
			Me.Pic_confirmed_load.Location = New Global.System.Drawing.Point(18, 254)
			Me.Pic_confirmed_load.Name = "Pic_confirmed_load"
			Me.Pic_confirmed_load.Size = New Global.System.Drawing.Size(25, 25)
			Me.Pic_confirmed_load.TabIndex = 316
			Me.Pic_confirmed_load.TabStop = False
			Me.Pic_pres_start_paint.BackColor = Global.System.Drawing.Color.Silver
			Me.Pic_pres_start_paint.Location = New Global.System.Drawing.Point(447, 114)
			Me.Pic_pres_start_paint.Name = "Pic_pres_start_paint"
			Me.Pic_pres_start_paint.Size = New Global.System.Drawing.Size(25, 25)
			Me.Pic_pres_start_paint.TabIndex = 315
			Me.Pic_pres_start_paint.TabStop = False
			Me.Pic_doorIN_open.BackColor = Global.System.Drawing.Color.Silver
			Me.Pic_doorIN_open.Location = New Global.System.Drawing.Point(442, 249)
			Me.Pic_doorIN_open.Name = "Pic_doorIN_open"
			Me.Pic_doorIN_open.Size = New Global.System.Drawing.Size(25, 25)
			Me.Pic_doorIN_open.TabIndex = 314
			Me.Pic_doorIN_open.TabStop = False
			Me.Pic_pres_end_paint.BackColor = Global.System.Drawing.Color.Silver
			Me.Pic_pres_end_paint.Location = New Global.System.Drawing.Point(699, 114)
			Me.Pic_pres_end_paint.Name = "Pic_pres_end_paint"
			Me.Pic_pres_end_paint.Size = New Global.System.Drawing.Size(25, 25)
			Me.Pic_pres_end_paint.TabIndex = 313
			Me.Pic_pres_end_paint.TabStop = False
			Me.Pic_doorOUT_open.BackColor = Global.System.Drawing.Color.Silver
			Me.Pic_doorOUT_open.Location = New Global.System.Drawing.Point(713, 250)
			Me.Pic_doorOUT_open.Name = "Pic_doorOUT_open"
			Me.Pic_doorOUT_open.Size = New Global.System.Drawing.Size(25, 25)
			Me.Pic_doorOUT_open.TabIndex = 312
			Me.Pic_doorOUT_open.TabStop = False
			Me.Pic_doorOUT_close.BackColor = Global.System.Drawing.Color.Silver
			Me.Pic_doorOUT_close.Location = New Global.System.Drawing.Point(713, 280)
			Me.Pic_doorOUT_close.Name = "Pic_doorOUT_close"
			Me.Pic_doorOUT_close.Size = New Global.System.Drawing.Size(25, 25)
			Me.Pic_doorOUT_close.TabIndex = 311
			Me.Pic_doorOUT_close.TabStop = False
			Me.Pic_doorIN_close.BackColor = Global.System.Drawing.Color.Silver
			Me.Pic_doorIN_close.Location = New Global.System.Drawing.Point(442, 279)
			Me.Pic_doorIN_close.Name = "Pic_doorIN_close"
			Me.Pic_doorIN_close.Size = New Global.System.Drawing.Size(25, 25)
			Me.Pic_doorIN_close.TabIndex = 310
			Me.Pic_doorIN_close.TabStop = False
			Me.Pic_pres_start_unload.BackColor = Global.System.Drawing.Color.Silver
			Me.Pic_pres_start_unload.Location = New Global.System.Drawing.Point(781, 114)
			Me.Pic_pres_start_unload.Name = "Pic_pres_start_unload"
			Me.Pic_pres_start_unload.Size = New Global.System.Drawing.Size(25, 25)
			Me.Pic_pres_start_unload.TabIndex = 307
			Me.Pic_pres_start_unload.TabStop = False
			Me.Pic_pres_start_load.BackColor = Global.System.Drawing.Color.Silver
			Me.Pic_pres_start_load.Location = New Global.System.Drawing.Point(33, 109)
			Me.Pic_pres_start_load.Name = "Pic_pres_start_load"
			Me.Pic_pres_start_load.Size = New Global.System.Drawing.Size(25, 25)
			Me.Pic_pres_start_load.TabIndex = 306
			Me.Pic_pres_start_load.TabStop = False
			Me.LblDescrizione.AutoSize = True
			Me.LblDescrizione.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.LblDescrizione.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.LblDescrizione.Location = New Global.System.Drawing.Point(566, 420)
			Me.LblDescrizione.Name = "LblDescrizione"
			Me.LblDescrizione.Size = New Global.System.Drawing.Size(37, 26)
			Me.LblDescrizione.TabIndex = 305
			Me.LblDescrizione.Text = "No"
			Me.LblDescrizione.TextAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.LblDescrizione.Visible = False
			Me.Pic_Piece_Load.Image = CType(componentResourceManager.GetObject("Pic_Piece_Load.Image"), Global.System.Drawing.Image)
			Me.Pic_Piece_Load.Location = New Global.System.Drawing.Point(56, 141)
			Me.Pic_Piece_Load.Name = "Pic_Piece_Load"
			Me.Pic_Piece_Load.Size = New Global.System.Drawing.Size(106, 38)
			Me.Pic_Piece_Load.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.Pic_Piece_Load.TabIndex = 302
			Me.Pic_Piece_Load.TabStop = False
			Me.Pic_Piece_Load.Tag = "17"
			Me.Pic_Piece_Load.Visible = False
			Me.LblScaricoConfermato.BackColor = Global.System.Drawing.Color.White
			Me.LblScaricoConfermato.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.LblScaricoConfermato.Location = New Global.System.Drawing.Point(886, 288)
			Me.LblScaricoConfermato.Name = "LblScaricoConfermato"
			Me.LblScaricoConfermato.Size = New Global.System.Drawing.Size(84, 33)
			Me.LblScaricoConfermato.TabIndex = 299
			Me.LblScaricoConfermato.Text = "Descarga Confirmada"
			Me.LblScaricoConfermato.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.LblCaricoConfermato.BackColor = Global.System.Drawing.Color.White
			Me.LblCaricoConfermato.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.LblCaricoConfermato.Location = New Global.System.Drawing.Point(7, 288)
			Me.LblCaricoConfermato.Name = "LblCaricoConfermato"
			Me.LblCaricoConfermato.Size = New Global.System.Drawing.Size(72, 33)
			Me.LblCaricoConfermato.TabIndex = 298
			Me.LblCaricoConfermato.Text = "Conferma Carico"
			Me.LblCaricoConfermato.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.PictureBox2.Image = CType(componentResourceManager.GetObject("PictureBox2.Image"), Global.System.Drawing.Image)
			Me.PictureBox2.InitialImage = CType(componentResourceManager.GetObject("PictureBox2.InitialImage"), Global.System.Drawing.Image)
			Me.PictureBox2.Location = New Global.System.Drawing.Point(4, 4)
			Me.PictureBox2.Name = "PictureBox2"
			Me.PictureBox2.Size = New Global.System.Drawing.Size(975, 410)
			Me.PictureBox2.SizeMode = Global.System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.PictureBox2.TabIndex = 107
			Me.PictureBox2.TabStop = False
			Me.Lbl_MotorON_Plant.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.Lbl_MotorON_Plant.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F)
			Me.Lbl_MotorON_Plant.Location = New Global.System.Drawing.Point(14, 630)
			Me.Lbl_MotorON_Plant.Name = "Lbl_MotorON_Plant"
			Me.Lbl_MotorON_Plant.Size = New Global.System.Drawing.Size(180, 25)
			Me.Lbl_MotorON_Plant.TabIndex = 157
			Me.Lbl_MotorON_Plant.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Lbl_Warning_cyc.BackColor = Global.System.Drawing.Color.Yellow
			Me.Lbl_Warning_cyc.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.Lbl_Warning_cyc.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14F, Global.System.Drawing.FontStyle.Bold)
			Me.Lbl_Warning_cyc.ForeColor = Global.System.Drawing.Color.Black
			Me.Lbl_Warning_cyc.Location = New Global.System.Drawing.Point(450, 606)
			Me.Lbl_Warning_cyc.Name = "Lbl_Warning_cyc"
			Me.Lbl_Warning_cyc.Size = New Global.System.Drawing.Size(500, 37)
			Me.Lbl_Warning_cyc.TabIndex = 339
			Me.Lbl_Warning_cyc.Text = "WARNINGS"
			Me.Lbl_Warning_cyc.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.LblLinea.AutoSize = True
			Me.LblLinea.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11F, Global.System.Drawing.FontStyle.Bold)
			Me.LblLinea.Location = New Global.System.Drawing.Point(10, 527)
			Me.LblLinea.Name = "LblLinea"
			Me.LblLinea.Size = New Global.System.Drawing.Size(54, 18)
			Me.LblLinea.TabIndex = 70
			Me.LblLinea.Text = "LINEA"
			Me.Lbl_AUTO_Plant.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.Lbl_AUTO_Plant.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F)
			Me.Lbl_AUTO_Plant.Location = New Global.System.Drawing.Point(14, 600)
			Me.Lbl_AUTO_Plant.Name = "Lbl_AUTO_Plant"
			Me.Lbl_AUTO_Plant.Size = New Global.System.Drawing.Size(180, 25)
			Me.Lbl_AUTO_Plant.TabIndex = 61
			Me.Lbl_AUTO_Plant.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.LblAlarmaDes.BackColor = Global.System.Drawing.Color.Red
			Me.LblAlarmaDes.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.LblAlarmaDes.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14F, Global.System.Drawing.FontStyle.Bold)
			Me.LblAlarmaDes.ForeColor = Global.System.Drawing.Color.Black
			Me.LblAlarmaDes.Location = New Global.System.Drawing.Point(450, 545)
			Me.LblAlarmaDes.Name = "LblAlarmaDes"
			Me.LblAlarmaDes.Size = New Global.System.Drawing.Size(500, 37)
			Me.LblAlarmaDes.TabIndex = 160
			Me.LblAlarmaDes.Text = "ALARMS"
			Me.LblAlarmaDes.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.TabPage3.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.TabPage3.Controls.Add(Me.GrpManualComands)
			Me.TabPage3.Controls.Add(Me.GrpLng)
			Me.TabPage3.Controls.Add(Me.chb_password)
			Me.TabPage3.Controls.Add(Me.btn_par_edit)
			Me.TabPage3.Controls.Add(Me.LblParametriGenerali)
			Me.TabPage3.Controls.Add(Me.lvw_par)
			Me.TabPage3.Location = New Global.System.Drawing.Point(4, 54)
			Me.TabPage3.Name = "TabPage3"
			Me.TabPage3.Padding = New Global.System.Windows.Forms.Padding(3)
			Me.TabPage3.Size = New Global.System.Drawing.Size(992, 914)
			Me.TabPage3.TabIndex = 2
			Me.TabPage3.Text = "PARAMETROS"
			Me.TabPage3.UseVisualStyleBackColor = True
			Me.GrpManualComands.Controls.Add(Me.BtnOvenDoor)
			Me.GrpManualComands.Controls.Add(Me.BtnOpenDoorOUT)
			Me.GrpManualComands.Controls.Add(Me.BtnOpenDoorIN)
			Me.GrpManualComands.Enabled = False
			Me.GrpManualComands.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GrpManualComands.ForeColor = Global.System.Drawing.Color.Blue
			Me.GrpManualComands.Location = New Global.System.Drawing.Point(669, 211)
			Me.GrpManualComands.Name = "GrpManualComands"
			Me.GrpManualComands.Size = New Global.System.Drawing.Size(219, 208)
			Me.GrpManualComands.TabIndex = 58
			Me.GrpManualComands.TabStop = False
			Me.GrpManualComands.Text = "Manual Comands"
			Me.BtnOvenDoor.Enabled = False
			Me.BtnOvenDoor.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.BtnOvenDoor.ForeColor = Global.System.Drawing.SystemColors.ActiveCaptionText
			Me.BtnOvenDoor.Location = New Global.System.Drawing.Point(9, 136)
			Me.BtnOvenDoor.Name = "BtnOvenDoor"
			Me.BtnOvenDoor.Size = New Global.System.Drawing.Size(200, 43)
			Me.BtnOvenDoor.TabIndex = 5
			Me.BtnOvenDoor.Text = "Open Oven Door"
			Me.BtnOvenDoor.TextAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.BtnOvenDoor.UseVisualStyleBackColor = True
			Me.BtnOpenDoorOUT.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.BtnOpenDoorOUT.ForeColor = Global.System.Drawing.SystemColors.ActiveCaptionText
			Me.BtnOpenDoorOUT.Location = New Global.System.Drawing.Point(9, 83)
			Me.BtnOpenDoorOUT.Name = "BtnOpenDoorOUT"
			Me.BtnOpenDoorOUT.Size = New Global.System.Drawing.Size(200, 43)
			Me.BtnOpenDoorOUT.TabIndex = 4
			Me.BtnOpenDoorOUT.Text = "Open Door OUT"
			Me.BtnOpenDoorOUT.TextAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.BtnOpenDoorOUT.UseVisualStyleBackColor = True
			Me.BtnOpenDoorIN.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.BtnOpenDoorIN.ForeColor = Global.System.Drawing.SystemColors.ActiveCaptionText
			Me.BtnOpenDoorIN.Location = New Global.System.Drawing.Point(9, 30)
			Me.BtnOpenDoorIN.Name = "BtnOpenDoorIN"
			Me.BtnOpenDoorIN.Size = New Global.System.Drawing.Size(200, 43)
			Me.BtnOpenDoorIN.TabIndex = 3
			Me.BtnOpenDoorIN.Text = "Open Door IN"
			Me.BtnOpenDoorIN.TextAlign = Global.System.Drawing.ContentAlignment.MiddleLeft
			Me.BtnOpenDoorIN.UseVisualStyleBackColor = True
			Me.GrpLng.Controls.Add(Me.BtnLngBra)
			Me.GrpLng.Controls.Add(Me.BtnLngSpa)
			Me.GrpLng.Controls.Add(Me.BtnLngFra)
			Me.GrpLng.Controls.Add(Me.BtnLngGer)
			Me.GrpLng.Controls.Add(Me.BtnLngEng)
			Me.GrpLng.Controls.Add(Me.BtnLngIta)
			Me.GrpLng.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.GrpLng.ForeColor = Global.System.Drawing.Color.Blue
			Me.GrpLng.Location = New Global.System.Drawing.Point(669, 52)
			Me.GrpLng.Name = "GrpLng"
			Me.GrpLng.Size = New Global.System.Drawing.Size(219, 153)
			Me.GrpLng.TabIndex = 48
			Me.GrpLng.TabStop = False
			Me.GrpLng.Text = "Language"
			Me.BtnLngBra.BackColor = Global.System.Drawing.SystemColors.Control
			Me.BtnLngBra.Enabled = False
			Me.BtnLngBra.Image = CType(componentResourceManager.GetObject("BtnLngBra.Image"), Global.System.Drawing.Image)
			Me.BtnLngBra.Location = New Global.System.Drawing.Point(152, 89)
			Me.BtnLngBra.Name = "BtnLngBra"
			Me.BtnLngBra.Size = New Global.System.Drawing.Size(58, 54)
			Me.BtnLngBra.TabIndex = 57
			Me.BtnLngBra.Tag = ""
			Me.BtnLngBra.UseVisualStyleBackColor = False
			Me.BtnLngSpa.BackColor = Global.System.Drawing.SystemColors.Control
			Me.BtnLngSpa.Enabled = False
			Me.BtnLngSpa.Image = CType(componentResourceManager.GetObject("BtnLngSpa.Image"), Global.System.Drawing.Image)
			Me.BtnLngSpa.Location = New Global.System.Drawing.Point(81, 89)
			Me.BtnLngSpa.Name = "BtnLngSpa"
			Me.BtnLngSpa.Size = New Global.System.Drawing.Size(58, 54)
			Me.BtnLngSpa.TabIndex = 56
			Me.BtnLngSpa.Tag = ""
			Me.BtnLngSpa.UseVisualStyleBackColor = False
			Me.BtnLngFra.BackColor = Global.System.Drawing.SystemColors.Control
			Me.BtnLngFra.Enabled = False
			Me.BtnLngFra.Image = CType(componentResourceManager.GetObject("BtnLngFra.Image"), Global.System.Drawing.Image)
			Me.BtnLngFra.Location = New Global.System.Drawing.Point(10, 89)
			Me.BtnLngFra.Name = "BtnLngFra"
			Me.BtnLngFra.Size = New Global.System.Drawing.Size(58, 54)
			Me.BtnLngFra.TabIndex = 52
			Me.BtnLngFra.Tag = ""
			Me.BtnLngFra.UseVisualStyleBackColor = False
			Me.BtnLngGer.BackColor = Global.System.Drawing.SystemColors.Control
			Me.BtnLngGer.Enabled = False
			Me.BtnLngGer.Image = CType(componentResourceManager.GetObject("BtnLngGer.Image"), Global.System.Drawing.Image)
			Me.BtnLngGer.Location = New Global.System.Drawing.Point(152, 25)
			Me.BtnLngGer.Name = "BtnLngGer"
			Me.BtnLngGer.Size = New Global.System.Drawing.Size(58, 54)
			Me.BtnLngGer.TabIndex = 54
			Me.BtnLngGer.Tag = ""
			Me.BtnLngGer.UseVisualStyleBackColor = False
			Me.BtnLngEng.BackColor = Global.System.Drawing.SystemColors.Control
			Me.BtnLngEng.Enabled = False
			Me.BtnLngEng.Image = CType(componentResourceManager.GetObject("BtnLngEng.Image"), Global.System.Drawing.Image)
			Me.BtnLngEng.Location = New Global.System.Drawing.Point(81, 26)
			Me.BtnLngEng.Name = "BtnLngEng"
			Me.BtnLngEng.Size = New Global.System.Drawing.Size(58, 54)
			Me.BtnLngEng.TabIndex = 53
			Me.BtnLngEng.Tag = ""
			Me.BtnLngEng.UseVisualStyleBackColor = False
			Me.BtnLngIta.BackColor = Global.System.Drawing.SystemColors.Control
			Me.BtnLngIta.Enabled = False
			Me.BtnLngIta.FlatAppearance.BorderColor = Global.System.Drawing.Color.White
			Me.BtnLngIta.FlatAppearance.MouseDownBackColor = Global.System.Drawing.Color.Transparent
			Me.BtnLngIta.Image = CType(componentResourceManager.GetObject("BtnLngIta.Image"), Global.System.Drawing.Image)
			Me.BtnLngIta.Location = New Global.System.Drawing.Point(10, 26)
			Me.BtnLngIta.Name = "BtnLngIta"
			Me.BtnLngIta.Size = New Global.System.Drawing.Size(58, 54)
			Me.BtnLngIta.TabIndex = 51
			Me.BtnLngIta.Tag = "0"
			Me.BtnLngIta.UseVisualStyleBackColor = False
			Me.chb_password.Appearance = Global.System.Windows.Forms.Appearance.Button
			Me.chb_password.Location = New Global.System.Drawing.Point(679, 447)
			Me.chb_password.Name = "chb_password"
			Me.chb_password.Size = New Global.System.Drawing.Size(200, 43)
			Me.chb_password.TabIndex = 8
			Me.chb_password.Text = "Password"
			Me.chb_password.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.chb_password.UseVisualStyleBackColor = True
			Me.btn_par_edit.Location = New Global.System.Drawing.Point(679, 497)
			Me.btn_par_edit.Name = "btn_par_edit"
			Me.btn_par_edit.Size = New Global.System.Drawing.Size(120, 34)
			Me.btn_par_edit.TabIndex = 7
			Me.btn_par_edit.Text = "Modifica"
			Me.btn_par_edit.UseVisualStyleBackColor = True
			Me.LblParametriGenerali.AutoSize = True
			Me.LblParametriGenerali.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.LblParametriGenerali.Location = New Global.System.Drawing.Point(8, 15)
			Me.LblParametriGenerali.Name = "LblParametriGenerali"
			Me.LblParametriGenerali.Size = New Global.System.Drawing.Size(162, 24)
			Me.LblParametriGenerali.TabIndex = 6
			Me.LblParametriGenerali.Text = "Parametri generali"
			Me.lvw_par.Columns.AddRange(New Global.System.Windows.Forms.ColumnHeader() { Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6 })
			Me.lvw_par.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lvw_par.FullRowSelect = True
			Me.lvw_par.GridLines = True
			Me.lvw_par.HeaderStyle = Global.System.Windows.Forms.ColumnHeaderStyle.Nonclickable
			Me.lvw_par.HideSelection = False
			Me.lvw_par.Location = New Global.System.Drawing.Point(12, 52)
			Me.lvw_par.MultiSelect = False
			Me.lvw_par.Name = "lvw_par"
			Me.lvw_par.Size = New Global.System.Drawing.Size(488, 554)
			Me.lvw_par.TabIndex = 5
			Me.lvw_par.UseCompatibleStateImageBehavior = False
			Me.lvw_par.View = Global.System.Windows.Forms.View.Details
			Me.ColumnHeader4.Text = "N"
			Me.ColumnHeader4.Width = 40
			Me.ColumnHeader5.Text = "Parametro"
			Me.ColumnHeader5.Width = 340
			Me.ColumnHeader6.Text = "Valore"
			Me.ColumnHeader6.Width = 80
			Me.TabPage2.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.TabPage2.Controls.Add(Me.grp_debug)
			Me.TabPage2.Controls.Add(Me.GroupBox9)
			Me.TabPage2.Controls.Add(Me.GroupBox8)
			Me.TabPage2.Controls.Add(Me.GroupBox4)
			Me.TabPage2.Controls.Add(Me.GroupBox2)
			Me.TabPage2.Controls.Add(Me.GroupBox1)
			Me.TabPage2.Location = New Global.System.Drawing.Point(4, 54)
			Me.TabPage2.Name = "TabPage2"
			Me.TabPage2.Padding = New Global.System.Windows.Forms.Padding(3)
			Me.TabPage2.Size = New Global.System.Drawing.Size(992, 914)
			Me.TabPage2.TabIndex = 1
			Me.TabPage2.Text = "DIAGNOSTICO"
			Me.TabPage2.UseVisualStyleBackColor = True
			Me.grp_debug.Controls.Add(Me.mmOven)
			Me.grp_debug.Controls.Add(Me.lbl_mmnastro_oven)
			Me.grp_debug.Controls.Add(Me.Label6)
			Me.grp_debug.Controls.Add(Me.Label5)
			Me.grp_debug.Controls.Add(Me.Label3)
			Me.grp_debug.Controls.Add(Me.Label2)
			Me.grp_debug.Controls.Add(Me.Label1)
			Me.grp_debug.Controls.Add(Me.mmPaint)
			Me.grp_debug.Controls.Add(Me.lbl_mmnastro_unload)
			Me.grp_debug.Controls.Add(Me.lbl_mmnastro_paint)
			Me.grp_debug.Controls.Add(Me.lbl_FSM_err)
			Me.grp_debug.Controls.Add(Me.lbl_debug_03)
			Me.grp_debug.Controls.Add(Me.lbl_debug_02)
			Me.grp_debug.Controls.Add(Me.lbl_debug_01)
			Me.grp_debug.Location = New Global.System.Drawing.Point(6, 223)
			Me.grp_debug.Name = "grp_debug"
			Me.grp_debug.Size = New Global.System.Drawing.Size(375, 115)
			Me.grp_debug.TabIndex = 74
			Me.grp_debug.TabStop = False
			Me.grp_debug.Text = "DEBUG"
			Me.mmOven.AutoSize = True
			Me.mmOven.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11.25F)
			Me.mmOven.Location = New Global.System.Drawing.Point(10, 43)
			Me.mmOven.Name = "mmOven"
			Me.mmOven.Size = New Global.System.Drawing.Size(69, 18)
			Me.mmOven.TabIndex = 358
			Me.mmOven.Text = "mmOven"
			Me.lbl_mmnastro_oven.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.lbl_mmnastro_oven.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 6.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lbl_mmnastro_oven.Location = New Global.System.Drawing.Point(103, 43)
			Me.lbl_mmnastro_oven.Name = "lbl_mmnastro_oven"
			Me.lbl_mmnastro_oven.Size = New Global.System.Drawing.Size(88, 22)
			Me.lbl_mmnastro_oven.TabIndex = 357
			Me.lbl_mmnastro_oven.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label6.AutoSize = True
			Me.Label6.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11.25F)
			Me.Label6.Location = New Global.System.Drawing.Point(199, 68)
			Me.Label6.Name = "Label6"
			Me.Label6.Size = New Global.System.Drawing.Size(72, 18)
			Me.Label6.TabIndex = 354
			Me.Label6.Text = "debug_03"
			Me.Label5.AutoSize = True
			Me.Label5.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11.25F)
			Me.Label5.Location = New Global.System.Drawing.Point(199, 43)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New Global.System.Drawing.Size(72, 18)
			Me.Label5.TabIndex = 353
			Me.Label5.Text = "debug_02"
			Me.Label3.AutoSize = True
			Me.Label3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11.25F)
			Me.Label3.Location = New Global.System.Drawing.Point(199, 18)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New Global.System.Drawing.Size(72, 18)
			Me.Label3.TabIndex = 352
			Me.Label3.Text = "debug_01"
			Me.Label2.AutoSize = True
			Me.Label2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11.25F)
			Me.Label2.Location = New Global.System.Drawing.Point(14, 18)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New Global.System.Drawing.Size(82, 18)
			Me.Label2.TabIndex = 351
			Me.Label2.Text = "Term_ErrC"
			Me.Label1.AutoSize = True
			Me.Label1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11.25F)
			Me.Label1.Location = New Global.System.Drawing.Point(14, 89)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New Global.System.Drawing.Size(81, 18)
			Me.Label1.TabIndex = 350
			Me.Label1.Text = "mmUnload"
			Me.mmPaint.AutoSize = True
			Me.mmPaint.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11.25F)
			Me.mmPaint.Location = New Global.System.Drawing.Point(14, 64)
			Me.mmPaint.Name = "mmPaint"
			Me.mmPaint.Size = New Global.System.Drawing.Size(67, 18)
			Me.mmPaint.TabIndex = 43
			Me.mmPaint.Text = "mmPaint"
			Me.lbl_mmnastro_unload.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.lbl_mmnastro_unload.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 6.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lbl_mmnastro_unload.Location = New Global.System.Drawing.Point(103, 89)
			Me.lbl_mmnastro_unload.Name = "lbl_mmnastro_unload"
			Me.lbl_mmnastro_unload.Size = New Global.System.Drawing.Size(88, 22)
			Me.lbl_mmnastro_unload.TabIndex = 349
			Me.lbl_mmnastro_unload.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.lbl_mmnastro_paint.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.lbl_mmnastro_paint.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 6.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lbl_mmnastro_paint.Location = New Global.System.Drawing.Point(103, 64)
			Me.lbl_mmnastro_paint.Name = "lbl_mmnastro_paint"
			Me.lbl_mmnastro_paint.Size = New Global.System.Drawing.Size(88, 22)
			Me.lbl_mmnastro_paint.TabIndex = 348
			Me.lbl_mmnastro_paint.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.lbl_FSM_err.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.lbl_FSM_err.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 6.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lbl_FSM_err.Location = New Global.System.Drawing.Point(103, 18)
			Me.lbl_FSM_err.Name = "lbl_FSM_err"
			Me.lbl_FSM_err.Size = New Global.System.Drawing.Size(88, 22)
			Me.lbl_FSM_err.TabIndex = 347
			Me.lbl_FSM_err.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.lbl_debug_03.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.lbl_debug_03.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 6.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lbl_debug_03.Location = New Global.System.Drawing.Point(275, 68)
			Me.lbl_debug_03.Name = "lbl_debug_03"
			Me.lbl_debug_03.Size = New Global.System.Drawing.Size(88, 22)
			Me.lbl_debug_03.TabIndex = 346
			Me.lbl_debug_03.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.lbl_debug_02.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.lbl_debug_02.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 6.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lbl_debug_02.Location = New Global.System.Drawing.Point(275, 43)
			Me.lbl_debug_02.Name = "lbl_debug_02"
			Me.lbl_debug_02.Size = New Global.System.Drawing.Size(88, 22)
			Me.lbl_debug_02.TabIndex = 345
			Me.lbl_debug_02.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.lbl_debug_01.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.lbl_debug_01.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 6.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lbl_debug_01.Location = New Global.System.Drawing.Point(275, 18)
			Me.lbl_debug_01.Name = "lbl_debug_01"
			Me.lbl_debug_01.Size = New Global.System.Drawing.Size(88, 22)
			Me.lbl_debug_01.TabIndex = 344
			Me.lbl_debug_01.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.GroupBox9.Controls.Add(Me.lbl_IMA_OUTPUT)
			Me.GroupBox9.Controls.Add(Me.lbl_IMA_INPUT)
			Me.GroupBox9.Controls.Add(Me.dgv_dout_IMA)
			Me.GroupBox9.Controls.Add(Me.dgv_din_IMA)
			Me.GroupBox9.Controls.Add(Me.lbl_digital_OUTPUT)
			Me.GroupBox9.Controls.Add(Me.lbl_digital_INPUT)
			Me.GroupBox9.Controls.Add(Me.dgv_dout)
			Me.GroupBox9.Controls.Add(Me.dgv_din)
			Me.GroupBox9.Controls.Add(Me.btn_force)
			Me.GroupBox9.Location = New Global.System.Drawing.Point(387, -2)
			Me.GroupBox9.Name = "GroupBox9"
			Me.GroupBox9.Size = New Global.System.Drawing.Size(603, 656)
			Me.GroupBox9.TabIndex = 48
			Me.GroupBox9.TabStop = False
			Me.lbl_IMA_OUTPUT.AutoSize = True
			Me.lbl_IMA_OUTPUT.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11F, Global.System.Drawing.FontStyle.Bold)
			Me.lbl_IMA_OUTPUT.Location = New Global.System.Drawing.Point(302, 392)
			Me.lbl_IMA_OUTPUT.Name = "lbl_IMA_OUTPUT"
			Me.lbl_IMA_OUTPUT.Size = New Global.System.Drawing.Size(109, 18)
			Me.lbl_IMA_OUTPUT.TabIndex = 81
			Me.lbl_IMA_OUTPUT.Text = "Uscite digitali"
			Me.lbl_IMA_INPUT.AutoSize = True
			Me.lbl_IMA_INPUT.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11F, Global.System.Drawing.FontStyle.Bold)
			Me.lbl_IMA_INPUT.Location = New Global.System.Drawing.Point(27, 392)
			Me.lbl_IMA_INPUT.Name = "lbl_IMA_INPUT"
			Me.lbl_IMA_INPUT.Size = New Global.System.Drawing.Size(120, 18)
			Me.lbl_IMA_INPUT.TabIndex = 80
			Me.lbl_IMA_INPUT.Text = "Ingressi digitali"
			Me.dgv_dout_IMA.AllowUserToAddRows = False
			Me.dgv_dout_IMA.AllowUserToDeleteRows = False
			Me.dgv_dout_IMA.AllowUserToResizeColumns = False
			Me.dgv_dout_IMA.AllowUserToResizeRows = False
			Me.dgv_dout_IMA.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.dgv_dout_IMA.ColumnHeadersHeightSizeMode = Global.System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
			Me.dgv_dout_IMA.ColumnHeadersVisible = False
			Me.dgv_dout_IMA.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7 })
			dataGridViewCellStyle.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle.BackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle.ForeColor = Global.System.Drawing.SystemColors.ControlText
			dataGridViewCellStyle.SelectionBackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle.SelectionForeColor = Global.System.Drawing.SystemColors.ControlText
			dataGridViewCellStyle.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgv_dout_IMA.DefaultCellStyle = dataGridViewCellStyle
			Me.dgv_dout_IMA.EditMode = Global.System.Windows.Forms.DataGridViewEditMode.EditOnF2
			Me.dgv_dout_IMA.GridColor = Global.System.Drawing.Color.White
			Me.dgv_dout_IMA.Location = New Global.System.Drawing.Point(306, 417)
			Me.dgv_dout_IMA.MultiSelect = False
			Me.dgv_dout_IMA.Name = "dgv_dout_IMA"
			Me.dgv_dout_IMA.[ReadOnly] = True
			Me.dgv_dout_IMA.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			Me.dgv_dout_IMA.RowHeadersVisible = False
			Me.dgv_dout_IMA.RowHeadersWidthSizeMode = Global.System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
			Me.dgv_dout_IMA.ScrollBars = Global.System.Windows.Forms.ScrollBars.Vertical
			Me.dgv_dout_IMA.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgv_dout_IMA.ShowCellErrors = False
			Me.dgv_dout_IMA.ShowCellToolTips = False
			Me.dgv_dout_IMA.ShowEditingIcon = False
			Me.dgv_dout_IMA.ShowRowErrors = False
			Me.dgv_dout_IMA.Size = New Global.System.Drawing.Size(276, 232)
			Me.dgv_dout_IMA.TabIndex = 79
			Me.DataGridViewTextBoxColumn6.HeaderText = "Ingresso digitale"
			Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
			Me.DataGridViewTextBoxColumn6.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn6.Width = 210
			Me.DataGridViewTextBoxColumn7.HeaderText = "Value"
			Me.DataGridViewTextBoxColumn7.MinimumWidth = 32
			Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
			Me.DataGridViewTextBoxColumn7.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn7.Width = 50
			Me.dgv_din_IMA.AllowUserToAddRows = False
			Me.dgv_din_IMA.AllowUserToDeleteRows = False
			Me.dgv_din_IMA.AllowUserToResizeColumns = False
			Me.dgv_din_IMA.AllowUserToResizeRows = False
			Me.dgv_din_IMA.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.dgv_din_IMA.ColumnHeadersHeightSizeMode = Global.System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
			Me.dgv_din_IMA.ColumnHeadersVisible = False
			Me.dgv_din_IMA.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.DataGridViewTextBoxColumn5, Me.Value })
			dataGridViewCellStyle2.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle2.BackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle2.ForeColor = Global.System.Drawing.SystemColors.ControlText
			dataGridViewCellStyle2.SelectionBackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle2.SelectionForeColor = Global.System.Drawing.SystemColors.ControlText
			dataGridViewCellStyle2.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgv_din_IMA.DefaultCellStyle = dataGridViewCellStyle2
			Me.dgv_din_IMA.EditMode = Global.System.Windows.Forms.DataGridViewEditMode.EditOnF2
			Me.dgv_din_IMA.GridColor = Global.System.Drawing.Color.White
			Me.dgv_din_IMA.Location = New Global.System.Drawing.Point(18, 417)
			Me.dgv_din_IMA.MultiSelect = False
			Me.dgv_din_IMA.Name = "dgv_din_IMA"
			Me.dgv_din_IMA.[ReadOnly] = True
			Me.dgv_din_IMA.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
			Me.dgv_din_IMA.RowHeadersVisible = False
			Me.dgv_din_IMA.RowHeadersWidthSizeMode = Global.System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
			Me.dgv_din_IMA.ScrollBars = Global.System.Windows.Forms.ScrollBars.Vertical
			Me.dgv_din_IMA.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgv_din_IMA.ShowCellErrors = False
			Me.dgv_din_IMA.ShowCellToolTips = False
			Me.dgv_din_IMA.ShowEditingIcon = False
			Me.dgv_din_IMA.ShowRowErrors = False
			Me.dgv_din_IMA.Size = New Global.System.Drawing.Size(276, 232)
			Me.dgv_din_IMA.TabIndex = 78
			Me.DataGridViewTextBoxColumn5.HeaderText = "Ingresso digitale"
			Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
			Me.DataGridViewTextBoxColumn5.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn5.Width = 210
			Me.Value.HeaderText = "Value"
			Me.Value.MinimumWidth = 32
			Me.Value.Name = "Value"
			Me.Value.[ReadOnly] = True
			Me.Value.Width = 50
			Me.lbl_digital_OUTPUT.AutoSize = True
			Me.lbl_digital_OUTPUT.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11F, Global.System.Drawing.FontStyle.Bold)
			Me.lbl_digital_OUTPUT.Location = New Global.System.Drawing.Point(302, 13)
			Me.lbl_digital_OUTPUT.Name = "lbl_digital_OUTPUT"
			Me.lbl_digital_OUTPUT.Size = New Global.System.Drawing.Size(109, 18)
			Me.lbl_digital_OUTPUT.TabIndex = 77
			Me.lbl_digital_OUTPUT.Text = "Uscite digitali"
			Me.lbl_digital_INPUT.AutoSize = True
			Me.lbl_digital_INPUT.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11F, Global.System.Drawing.FontStyle.Bold)
			Me.lbl_digital_INPUT.Location = New Global.System.Drawing.Point(13, 13)
			Me.lbl_digital_INPUT.Name = "lbl_digital_INPUT"
			Me.lbl_digital_INPUT.Size = New Global.System.Drawing.Size(120, 18)
			Me.lbl_digital_INPUT.TabIndex = 76
			Me.lbl_digital_INPUT.Text = "Ingressi digitali"
			Me.dgv_dout.AllowUserToAddRows = False
			Me.dgv_dout.AllowUserToDeleteRows = False
			Me.dgv_dout.AllowUserToResizeColumns = False
			Me.dgv_dout.AllowUserToResizeRows = False
			Me.dgv_dout.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.dgv_dout.ColumnHeadersHeightSizeMode = Global.System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
			Me.dgv_dout.ColumnHeadersVisible = False
			Me.dgv_dout.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.DataGridViewImageColumn1, Me.Column1, Me.DataGridViewTextBoxColumn1 })
			dataGridViewCellStyle3.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle3.BackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle3.ForeColor = Global.System.Drawing.SystemColors.ControlText
			dataGridViewCellStyle3.SelectionBackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle3.SelectionForeColor = Global.System.Drawing.SystemColors.ControlText
			dataGridViewCellStyle3.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgv_dout.DefaultCellStyle = dataGridViewCellStyle3
			Me.dgv_dout.EditMode = Global.System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
			Me.dgv_dout.GridColor = Global.System.Drawing.Color.White
			Me.dgv_dout.Location = New Global.System.Drawing.Point(306, 35)
			Me.dgv_dout.MultiSelect = False
			Me.dgv_dout.Name = "dgv_dout"
			Me.dgv_dout.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.None
			Me.dgv_dout.RowHeadersVisible = False
			Me.dgv_dout.RowHeadersWidthSizeMode = Global.System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
			Me.dgv_dout.ScrollBars = Global.System.Windows.Forms.ScrollBars.Vertical
			Me.dgv_dout.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgv_dout.ShowCellErrors = False
			Me.dgv_dout.ShowCellToolTips = False
			Me.dgv_dout.ShowEditingIcon = False
			Me.dgv_dout.ShowRowErrors = False
			Me.dgv_dout.Size = New Global.System.Drawing.Size(276, 354)
			Me.dgv_dout.TabIndex = 75
			Me.DataGridViewImageColumn1.HeaderText = "S"
			Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
			Me.DataGridViewImageColumn1.Width = 25
			Me.Column1.HeaderText = "F"
			Me.Column1.Name = "Column1"
			Me.Column1.Width = 25
			Me.DataGridViewTextBoxColumn1.HeaderText = "Ingresso digitale"
			Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
			Me.DataGridViewTextBoxColumn1.Width = 230
			Me.dgv_din.AllowUserToAddRows = False
			Me.dgv_din.AllowUserToDeleteRows = False
			Me.dgv_din.AllowUserToResizeColumns = False
			Me.dgv_din.AllowUserToResizeRows = False
			Me.dgv_din.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.dgv_din.ColumnHeadersHeightSizeMode = Global.System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
			Me.dgv_din.ColumnHeadersVisible = False
			Me.dgv_din.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Column3, Me.Column2 })
			dataGridViewCellStyle4.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle4.BackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle4.ForeColor = Global.System.Drawing.SystemColors.ControlText
			dataGridViewCellStyle4.SelectionBackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle4.SelectionForeColor = Global.System.Drawing.SystemColors.ControlText
			dataGridViewCellStyle4.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgv_din.DefaultCellStyle = dataGridViewCellStyle4
			Me.dgv_din.EditMode = Global.System.Windows.Forms.DataGridViewEditMode.EditOnF2
			Me.dgv_din.GridColor = Global.System.Drawing.Color.White
			Me.dgv_din.Location = New Global.System.Drawing.Point(18, 35)
			Me.dgv_din.MultiSelect = False
			Me.dgv_din.Name = "dgv_din"
			Me.dgv_din.[ReadOnly] = True
			Me.dgv_din.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.None
			Me.dgv_din.RowHeadersVisible = False
			Me.dgv_din.RowHeadersWidthSizeMode = Global.System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
			Me.dgv_din.ScrollBars = Global.System.Windows.Forms.ScrollBars.Vertical
			Me.dgv_din.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgv_din.ShowCellErrors = False
			Me.dgv_din.ShowCellToolTips = False
			Me.dgv_din.ShowEditingIcon = False
			Me.dgv_din.ShowRowErrors = False
			Me.dgv_din.Size = New Global.System.Drawing.Size(276, 354)
			Me.dgv_din.TabIndex = 74
			Me.Column3.HeaderText = "S"
			Me.Column3.Name = "Column3"
			Me.Column3.[ReadOnly] = True
			Me.Column3.Width = 25
			Me.Column2.HeaderText = "Ingresso digitale"
			Me.Column2.Name = "Column2"
			Me.Column2.[ReadOnly] = True
			Me.Column2.Width = 255
			Me.btn_force.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 10.5F, Global.System.Drawing.FontStyle.Bold)
			Me.btn_force.Location = New Global.System.Drawing.Point(494, 11)
			Me.btn_force.Name = "btn_force"
			Me.btn_force.Size = New Global.System.Drawing.Size(79, 23)
			Me.btn_force.TabIndex = 73
			Me.btn_force.Text = "Force"
			Me.btn_force.UseVisualStyleBackColor = True
			Me.GroupBox8.Controls.Add(Me.lbl_cma_loadinf)
			Me.GroupBox8.Controls.Add(Me.Lbl_communicationPLC)
			Me.GroupBox8.Location = New Global.System.Drawing.Point(6, 3)
			Me.GroupBox8.Name = "GroupBox8"
			Me.GroupBox8.Size = New Global.System.Drawing.Size(375, 80)
			Me.GroupBox8.TabIndex = 73
			Me.GroupBox8.TabStop = False
			Me.lbl_cma_loadinf.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.lbl_cma_loadinf.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11.25F, Global.System.Drawing.FontStyle.Bold)
			Me.lbl_cma_loadinf.Location = New Global.System.Drawing.Point(6, 39)
			Me.lbl_cma_loadinf.Name = "lbl_cma_loadinf"
			Me.lbl_cma_loadinf.Size = New Global.System.Drawing.Size(226, 24)
			Me.lbl_cma_loadinf.TabIndex = 64
			Me.lbl_cma_loadinf.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Lbl_communicationPLC.AutoSize = True
			Me.Lbl_communicationPLC.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11F, Global.System.Drawing.FontStyle.Bold)
			Me.Lbl_communicationPLC.Location = New Global.System.Drawing.Point(3, 11)
			Me.Lbl_communicationPLC.Name = "Lbl_communicationPLC"
			Me.Lbl_communicationPLC.Size = New Global.System.Drawing.Size(152, 18)
			Me.Lbl_communicationPLC.TabIndex = 63
			Me.Lbl_communicationPLC.Text = "Comunicazione plc"
			Me.GroupBox4.Controls.Add(Me.btn_reset_cyc)
			Me.GroupBox4.Controls.Add(Me.dgv_ciclica)
			Me.GroupBox4.Location = New Global.System.Drawing.Point(6, 501)
			Me.GroupBox4.Name = "GroupBox4"
			Me.GroupBox4.Size = New Global.System.Drawing.Size(375, 151)
			Me.GroupBox4.TabIndex = 66
			Me.GroupBox4.TabStop = False
			Me.GroupBox4.Text = "Ciclic State"
			Me.btn_reset_cyc.Location = New Global.System.Drawing.Point(243, 102)
			Me.btn_reset_cyc.Name = "btn_reset_cyc"
			Me.btn_reset_cyc.Size = New Global.System.Drawing.Size(126, 42)
			Me.btn_reset_cyc.TabIndex = 8
			Me.btn_reset_cyc.Text = "Reset"
			Me.btn_reset_cyc.UseVisualStyleBackColor = True
			Me.dgv_ciclica.AllowUserToAddRows = False
			Me.dgv_ciclica.AllowUserToDeleteRows = False
			Me.dgv_ciclica.AllowUserToResizeColumns = False
			Me.dgv_ciclica.AllowUserToResizeRows = False
			Me.dgv_ciclica.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.dgv_ciclica.ColumnHeadersHeightSizeMode = Global.System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
			Me.dgv_ciclica.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.Column10 })
			dataGridViewCellStyle5.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle5.BackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle5.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle5.ForeColor = Global.System.Drawing.SystemColors.ControlText
			dataGridViewCellStyle5.SelectionBackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle5.SelectionForeColor = Global.System.Drawing.SystemColors.ControlText
			dataGridViewCellStyle5.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgv_ciclica.DefaultCellStyle = dataGridViewCellStyle5
			Me.dgv_ciclica.EditMode = Global.System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
			Me.dgv_ciclica.GridColor = Global.System.Drawing.SystemColors.ActiveBorder
			Me.dgv_ciclica.Location = New Global.System.Drawing.Point(6, 20)
			Me.dgv_ciclica.MultiSelect = False
			Me.dgv_ciclica.Name = "dgv_ciclica"
			Me.dgv_ciclica.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.None
			Me.dgv_ciclica.RowHeadersVisible = False
			Me.dgv_ciclica.RowHeadersWidthSizeMode = Global.System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
			Me.dgv_ciclica.ScrollBars = Global.System.Windows.Forms.ScrollBars.Vertical
			Me.dgv_ciclica.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgv_ciclica.ShowCellErrors = False
			Me.dgv_ciclica.ShowCellToolTips = False
			Me.dgv_ciclica.ShowEditingIcon = False
			Me.dgv_ciclica.ShowRowErrors = False
			Me.dgv_ciclica.Size = New Global.System.Drawing.Size(363, 125)
			Me.dgv_ciclica.TabIndex = 7
			Me.DataGridViewTextBoxColumn3.HeaderText = "Function"
			Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
			Me.DataGridViewTextBoxColumn3.Width = 180
			Me.DataGridViewTextBoxColumn4.HeaderText = "PLC"
			Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
			Me.DataGridViewTextBoxColumn4.Width = 50
			Me.Column10.HeaderText = "VB"
			Me.Column10.Name = "Column10"
			Me.Column10.Width = 150
			Me.GroupBox2.Controls.Add(Me.Label12)
			Me.GroupBox2.Controls.Add(Me.lbl_com_TCPIP_r1)
			Me.GroupBox2.Controls.Add(Me.Label18)
			Me.GroupBox2.Controls.Add(Me.Lbl_com_robot1_l)
			Me.GroupBox2.Controls.Add(Me.lbl_com_robot1)
			Me.GroupBox2.Controls.Add(Me.lbl_status_robot1)
			Me.GroupBox2.Location = New Global.System.Drawing.Point(6, 89)
			Me.GroupBox2.Name = "GroupBox2"
			Me.GroupBox2.Size = New Global.System.Drawing.Size(375, 128)
			Me.GroupBox2.TabIndex = 67
			Me.GroupBox2.TabStop = False
			Me.GroupBox2.Text = "Robot 1"
			Me.Label12.AutoSize = True
			Me.Label12.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11.25F)
			Me.Label12.Location = New Global.System.Drawing.Point(6, 99)
			Me.Label12.Name = "Label12"
			Me.Label12.Size = New Global.System.Drawing.Size(128, 18)
			Me.Label12.TabIndex = 44
			Me.Label12.Text = "Stato com TCP/IP"
			Me.lbl_com_TCPIP_r1.BackColor = Global.System.Drawing.Color.Lime
			Me.lbl_com_TCPIP_r1.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.lbl_com_TCPIP_r1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 10.5F, Global.System.Drawing.FontStyle.Bold)
			Me.lbl_com_TCPIP_r1.Location = New Global.System.Drawing.Point(140, 92)
			Me.lbl_com_TCPIP_r1.Name = "lbl_com_TCPIP_r1"
			Me.lbl_com_TCPIP_r1.Size = New Global.System.Drawing.Size(225, 24)
			Me.lbl_com_TCPIP_r1.TabIndex = 43
			Me.lbl_com_TCPIP_r1.Text = "Stato Comunicazione"
			Me.lbl_com_TCPIP_r1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.Label18.AutoSize = True
			Me.Label18.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11.25F)
			Me.Label18.Location = New Global.System.Drawing.Point(6, 65)
			Me.Label18.Name = "Label18"
			Me.Label18.Size = New Global.System.Drawing.Size(87, 18)
			Me.Label18.TabIndex = 42
			Me.Label18.Text = "Robot State"
			Me.Lbl_com_robot1_l.AutoSize = True
			Me.Lbl_com_robot1_l.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.Lbl_com_robot1_l.Location = New Global.System.Drawing.Point(6, 25)
			Me.Lbl_com_robot1_l.Name = "Lbl_com_robot1_l"
			Me.Lbl_com_robot1_l.Size = New Global.System.Drawing.Size(109, 18)
			Me.Lbl_com_robot1_l.TabIndex = 39
			Me.Lbl_com_robot1_l.Text = "State com PLC"
			Me.lbl_com_robot1.BackColor = Global.System.Drawing.Color.Lime
			Me.lbl_com_robot1.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.lbl_com_robot1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 10.5F, Global.System.Drawing.FontStyle.Bold)
			Me.lbl_com_robot1.Location = New Global.System.Drawing.Point(140, 19)
			Me.lbl_com_robot1.Name = "lbl_com_robot1"
			Me.lbl_com_robot1.Size = New Global.System.Drawing.Size(225, 24)
			Me.lbl_com_robot1.TabIndex = 1
			Me.lbl_com_robot1.Text = "Stato Comunicazione"
			Me.lbl_com_robot1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.lbl_status_robot1.BackColor = Global.System.Drawing.Color.Lime
			Me.lbl_status_robot1.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.lbl_status_robot1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 10.5F, Global.System.Drawing.FontStyle.Bold)
			Me.lbl_status_robot1.Location = New Global.System.Drawing.Point(140, 59)
			Me.lbl_status_robot1.Name = "lbl_status_robot1"
			Me.lbl_status_robot1.Size = New Global.System.Drawing.Size(225, 24)
			Me.lbl_status_robot1.TabIndex = 0
			Me.lbl_status_robot1.Text = "Sato Robot"
			Me.lbl_status_robot1.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.GroupBox1.Controls.Add(Me.dgv_master)
			Me.GroupBox1.Location = New Global.System.Drawing.Point(6, 340)
			Me.GroupBox1.Name = "GroupBox1"
			Me.GroupBox1.Size = New Global.System.Drawing.Size(375, 151)
			Me.GroupBox1.TabIndex = 64
			Me.GroupBox1.TabStop = False
			Me.GroupBox1.Text = "Axes Masterization"
			Me.dgv_master.AllowUserToAddRows = False
			Me.dgv_master.AllowUserToDeleteRows = False
			Me.dgv_master.AllowUserToResizeColumns = False
			Me.dgv_master.AllowUserToResizeRows = False
			Me.dgv_master.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.dgv_master.ColumnHeadersHeightSizeMode = Global.System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
			Me.dgv_master.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.DataGridViewTextBoxColumn2, Me.Column9, Me.DataGridViewButtonColumn1 })
			dataGridViewCellStyle6.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle6.BackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle6.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle6.ForeColor = Global.System.Drawing.SystemColors.ControlText
			dataGridViewCellStyle6.SelectionBackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle6.SelectionForeColor = Global.System.Drawing.SystemColors.ControlText
			dataGridViewCellStyle6.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgv_master.DefaultCellStyle = dataGridViewCellStyle6
			Me.dgv_master.EditMode = Global.System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
			Me.dgv_master.GridColor = Global.System.Drawing.SystemColors.ActiveBorder
			Me.dgv_master.Location = New Global.System.Drawing.Point(6, 19)
			Me.dgv_master.MultiSelect = False
			Me.dgv_master.Name = "dgv_master"
			Me.dgv_master.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.None
			Me.dgv_master.RowHeadersVisible = False
			Me.dgv_master.RowHeadersWidthSizeMode = Global.System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
			Me.dgv_master.ScrollBars = Global.System.Windows.Forms.ScrollBars.Vertical
			Me.dgv_master.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgv_master.ShowCellErrors = False
			Me.dgv_master.ShowCellToolTips = False
			Me.dgv_master.ShowEditingIcon = False
			Me.dgv_master.ShowRowErrors = False
			Me.dgv_master.Size = New Global.System.Drawing.Size(363, 125)
			Me.dgv_master.TabIndex = 6
			Me.DataGridViewTextBoxColumn2.HeaderText = "Asse"
			Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
			Me.DataGridViewTextBoxColumn2.Width = 200
			Me.Column9.HeaderText = "Quota"
			Me.Column9.Name = "Column9"
			Me.DataGridViewButtonColumn1.HeaderText = "Master"
			Me.DataGridViewButtonColumn1.Name = "DataGridViewButtonColumn1"
			Me.DataGridViewButtonColumn1.Width = 60
			Me.TabPage4.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.TabPage4.Controls.Add(Me.lvw_alarms)
			Me.TabPage4.Controls.Add(Me.dgv_ax)
			Me.TabPage4.Controls.Add(Me.Grp_stats)
			Me.TabPage4.Location = New Global.System.Drawing.Point(4, 54)
			Me.TabPage4.Name = "TabPage4"
			Me.TabPage4.Padding = New Global.System.Windows.Forms.Padding(3)
			Me.TabPage4.Size = New Global.System.Drawing.Size(992, 914)
			Me.TabPage4.TabIndex = 3
			Me.TabPage4.Text = "ALARMAS"
			Me.TabPage4.UseVisualStyleBackColor = True
			Me.lvw_alarms.Columns.AddRange(New Global.System.Windows.Forms.ColumnHeader() { Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11 })
			Me.lvw_alarms.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lvw_alarms.FullRowSelect = True
			Me.lvw_alarms.GridLines = True
			Me.lvw_alarms.HideSelection = False
			Me.lvw_alarms.Location = New Global.System.Drawing.Point(6, 6)
			Me.lvw_alarms.MultiSelect = False
			Me.lvw_alarms.Name = "lvw_alarms"
			Me.lvw_alarms.Size = New Global.System.Drawing.Size(975, 446)
			Me.lvw_alarms.TabIndex = 0
			Me.lvw_alarms.UseCompatibleStateImageBehavior = False
			Me.lvw_alarms.View = Global.System.Windows.Forms.View.Details
			Me.ColumnHeader8.Text = "Ora"
			Me.ColumnHeader8.Width = 140
			Me.ColumnHeader9.Text = "Asse"
			Me.ColumnHeader9.Width = 100
			Me.ColumnHeader10.Text = "Codice"
			Me.ColumnHeader10.Width = 83
			Me.ColumnHeader11.Text = "Testo"
			Me.ColumnHeader11.Width = 820
			Me.dgv_ax.AllowUserToAddRows = False
			Me.dgv_ax.AllowUserToDeleteRows = False
			Me.dgv_ax.AllowUserToResizeColumns = False
			Me.dgv_ax.AllowUserToResizeRows = False
			Me.dgv_ax.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.dgv_ax.ColumnHeadersHeightSizeMode = Global.System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
			Me.dgv_ax.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Column7, Me.cl_pos, Me.cl_vel, Me.Column4, Me.Column5, Me.Column6, Me.Column8, Me.MotorsManualMove })
			dataGridViewCellStyle7.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			dataGridViewCellStyle7.BackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle7.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			dataGridViewCellStyle7.ForeColor = Global.System.Drawing.SystemColors.ControlText
			dataGridViewCellStyle7.SelectionBackColor = Global.System.Drawing.SystemColors.Window
			dataGridViewCellStyle7.SelectionForeColor = Global.System.Drawing.SystemColors.ControlText
			dataGridViewCellStyle7.WrapMode = Global.System.Windows.Forms.DataGridViewTriState.[False]
			Me.dgv_ax.DefaultCellStyle = dataGridViewCellStyle7
			Me.dgv_ax.EditMode = Global.System.Windows.Forms.DataGridViewEditMode.EditOnF2
			Me.dgv_ax.Location = New Global.System.Drawing.Point(6, 470)
			Me.dgv_ax.Name = "dgv_ax"
			Me.dgv_ax.RowHeadersBorderStyle = Global.System.Windows.Forms.DataGridViewHeaderBorderStyle.None
			Me.dgv_ax.RowHeadersVisible = False
			Me.dgv_ax.RowHeadersWidth = 10
			Me.dgv_ax.RowHeadersWidthSizeMode = Global.System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
			Me.dgv_ax.RowTemplate.Height = 25
			Me.dgv_ax.ScrollBars = Global.System.Windows.Forms.ScrollBars.None
			Me.dgv_ax.SelectionMode = Global.System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
			Me.dgv_ax.ShowCellErrors = False
			Me.dgv_ax.ShowCellToolTips = False
			Me.dgv_ax.ShowEditingIcon = False
			Me.dgv_ax.ShowRowErrors = False
			Me.dgv_ax.Size = New Global.System.Drawing.Size(1000, 176)
			Me.dgv_ax.TabIndex = 65
			dataGridViewCellStyle8.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
			Me.Column7.DefaultCellStyle = dataGridViewCellStyle8
			Me.Column7.HeaderText = "Axe"
			Me.Column7.Name = "Column7"
			Me.Column7.[ReadOnly] = True
			Me.Column7.SortMode = Global.System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
			Me.Column7.Width = 140
			dataGridViewCellStyle9.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.cl_pos.DefaultCellStyle = dataGridViewCellStyle9
			Me.cl_pos.HeaderText = "Pos mm"
			Me.cl_pos.Name = "cl_pos"
			Me.cl_pos.[ReadOnly] = True
			Me.cl_pos.SortMode = Global.System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
			Me.cl_pos.Width = 90
			dataGridViewCellStyle10.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.cl_vel.DefaultCellStyle = dataGridViewCellStyle10
			Me.cl_vel.HeaderText = "V m/min"
			Me.cl_vel.Name = "cl_vel"
			Me.cl_vel.[ReadOnly] = True
			Me.cl_vel.SortMode = Global.System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
			Me.cl_vel.Width = 80
			dataGridViewCellStyle11.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column4.DefaultCellStyle = dataGridViewCellStyle11
			Me.Column4.HeaderText = "e mm"
			Me.Column4.Name = "Column4"
			Me.Column4.[ReadOnly] = True
			Me.Column4.SortMode = Global.System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
			Me.Column4.Width = 70
			dataGridViewCellStyle12.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column5.DefaultCellStyle = dataGridViewCellStyle12
			Me.Column5.HeaderText = "i A"
			Me.Column5.Name = "Column5"
			Me.Column5.[ReadOnly] = True
			Me.Column5.SortMode = Global.System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
			Me.Column5.Width = 70
			dataGridViewCellStyle13.Alignment = Global.System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
			Me.Column6.DefaultCellStyle = dataGridViewCellStyle13
			Me.Column6.HeaderText = "T °C"
			Me.Column6.Name = "Column6"
			Me.Column6.[ReadOnly] = True
			Me.Column6.SortMode = Global.System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
			Me.Column6.Width = 70
			Me.Column8.HeaderText = "Alarms"
			Me.Column8.Name = "Column8"
			Me.Column8.[ReadOnly] = True
			Me.Column8.Width = 410
			Me.MotorsManualMove.HeaderText = "Move"
			Me.MotorsManualMove.Name = "MotorsManualMove"
			Me.MotorsManualMove.Width = 60
			Me.Grp_stats.Controls.Add(Me.btn_stat_edit)
			Me.Grp_stats.Controls.Add(Me.btn_Step_done)
			Me.Grp_stats.Controls.Add(Me.btn_stat_save)
			Me.Grp_stats.Controls.Add(Me.Button1)
			Me.Grp_stats.Controls.Add(Me.btn_stat_delete)
			Me.Grp_stats.Controls.Add(Me.dgv_robot1_stats)
			Me.Grp_stats.Controls.Add(Me.lbl_robot1_stats_l)
			Me.Grp_stats.Controls.Add(Me.btn_stat_clear)
			Me.Grp_stats.Controls.Add(Me.lbl_programlist_l)
			Me.Grp_stats.Controls.Add(Me.btn_stat_insert)
			Me.Grp_stats.Controls.Add(Me.btn_stat_refresh)
			Me.Grp_stats.Controls.Add(Me.dgv_programlist)
			Me.Grp_stats.Location = New Global.System.Drawing.Point(11, 19)
			Me.Grp_stats.Name = "Grp_stats"
			Me.Grp_stats.Size = New Global.System.Drawing.Size(976, 390)
			Me.Grp_stats.TabIndex = 89
			Me.Grp_stats.TabStop = False
			Me.btn_stat_edit.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 10.5F, Global.System.Drawing.FontStyle.Bold)
			Me.btn_stat_edit.Location = New Global.System.Drawing.Point(5, 521)
			Me.btn_stat_edit.Name = "btn_stat_edit"
			Me.btn_stat_edit.Size = New Global.System.Drawing.Size(99, 32)
			Me.btn_stat_edit.TabIndex = 75
			Me.btn_stat_edit.Text = "EDIT"
			Me.btn_stat_edit.UseVisualStyleBackColor = True
			Me.btn_Step_done.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 10.5F, Global.System.Drawing.FontStyle.Bold)
			Me.btn_Step_done.Location = New Global.System.Drawing.Point(504, 21)
			Me.btn_Step_done.Name = "btn_Step_done"
			Me.btn_Step_done.Size = New Global.System.Drawing.Size(129, 23)
			Me.btn_Step_done.TabIndex = 87
			Me.btn_Step_done.Text = "btn_Step_done"
			Me.btn_Step_done.UseVisualStyleBackColor = True
			Me.btn_Step_done.Visible = False
			Me.btn_stat_save.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 10.5F, Global.System.Drawing.FontStyle.Bold)
			Me.btn_stat_save.Location = New Global.System.Drawing.Point(129, 606)
			Me.btn_stat_save.Name = "btn_stat_save"
			Me.btn_stat_save.Size = New Global.System.Drawing.Size(99, 32)
			Me.btn_stat_save.TabIndex = 74
			Me.btn_stat_save.Text = "SAVE"
			Me.btn_stat_save.UseVisualStyleBackColor = True
			Me.Button1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 10.5F, Global.System.Drawing.FontStyle.Bold)
			Me.Button1.Location = New Global.System.Drawing.Point(402, 21)
			Me.Button1.Name = "Button1"
			Me.Button1.Size = New Global.System.Drawing.Size(79, 23)
			Me.Button1.TabIndex = 86
			Me.Button1.Text = "Force"
			Me.Button1.UseVisualStyleBackColor = True
			Me.btn_stat_delete.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 10.5F, Global.System.Drawing.FontStyle.Bold)
			Me.btn_stat_delete.Location = New Global.System.Drawing.Point(5, 607)
			Me.btn_stat_delete.Name = "btn_stat_delete"
			Me.btn_stat_delete.Size = New Global.System.Drawing.Size(99, 32)
			Me.btn_stat_delete.TabIndex = 77
			Me.btn_stat_delete.Text = "DELETE"
			Me.btn_stat_delete.UseVisualStyleBackColor = True
			Me.dgv_robot1_stats.AllowUserToAddRows = False
			Me.dgv_robot1_stats.AllowUserToDeleteRows = False
			Me.dgv_robot1_stats.AllowUserToResizeColumns = False
			Me.dgv_robot1_stats.AllowUserToResizeRows = False
			Me.dgv_robot1_stats.ColumnHeadersHeightSizeMode = Global.System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
			Me.dgv_robot1_stats.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.Column14, Me.Column15, Me.Column16, Me.Column17 })
			Me.dgv_robot1_stats.Enabled = False
			Me.dgv_robot1_stats.Location = New Global.System.Drawing.Point(399, 53)
			Me.dgv_robot1_stats.MultiSelect = False
			Me.dgv_robot1_stats.Name = "dgv_robot1_stats"
			Me.dgv_robot1_stats.[ReadOnly] = True
			Me.dgv_robot1_stats.Size = New Global.System.Drawing.Size(550, 465)
			Me.dgv_robot1_stats.TabIndex = 81
			Me.DataGridViewTextBoxColumn8.HeaderText = "Program name"
			Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
			Me.DataGridViewTextBoxColumn8.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn8.Width = 120
			Me.DataGridViewTextBoxColumn9.HeaderText = "Lotto"
			Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
			Me.DataGridViewTextBoxColumn9.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn9.Width = 80
			Me.DataGridViewTextBoxColumn10.HeaderText = "Par opzionale"
			Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
			Me.DataGridViewTextBoxColumn10.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn10.Width = 60
			Me.Column14.HeaderText = "Ora produzione"
			Me.Column14.Name = "Column14"
			Me.Column14.[ReadOnly] = True
			Me.Column14.Width = 50
			Me.Column15.HeaderText = "T lavoro"
			Me.Column15.Name = "Column15"
			Me.Column15.[ReadOnly] = True
			Me.Column15.Width = 60
			Me.Column16.HeaderText = "T pausa"
			Me.Column16.Name = "Column16"
			Me.Column16.[ReadOnly] = True
			Me.Column16.Width = 60
			Me.Column17.HeaderText = "T pistola"
			Me.Column17.Name = "Column17"
			Me.Column17.[ReadOnly] = True
			Me.Column17.Width = 60
			Me.lbl_robot1_stats_l.AutoSize = True
			Me.lbl_robot1_stats_l.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lbl_robot1_stats_l.Location = New Global.System.Drawing.Point(648, 18)
			Me.lbl_robot1_stats_l.Name = "lbl_robot1_stats_l"
			Me.lbl_robot1_stats_l.Size = New Global.System.Drawing.Size(237, 24)
			Me.lbl_robot1_stats_l.TabIndex = 84
			Me.lbl_robot1_stats_l.Text = "STATISTICHE ROBOT 1"
			Me.btn_stat_clear.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 10.5F, Global.System.Drawing.FontStyle.Bold)
			Me.btn_stat_clear.Location = New Global.System.Drawing.Point(129, 521)
			Me.btn_stat_clear.Name = "btn_stat_clear"
			Me.btn_stat_clear.Size = New Global.System.Drawing.Size(99, 32)
			Me.btn_stat_clear.TabIndex = 78
			Me.btn_stat_clear.Text = "CLEAR"
			Me.btn_stat_clear.UseVisualStyleBackColor = True
			Me.lbl_programlist_l.AutoSize = True
			Me.lbl_programlist_l.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lbl_programlist_l.Location = New Global.System.Drawing.Point(6, 21)
			Me.lbl_programlist_l.Name = "lbl_programlist_l"
			Me.lbl_programlist_l.Size = New Global.System.Drawing.Size(161, 24)
			Me.lbl_programlist_l.TabIndex = 83
			Me.lbl_programlist_l.Text = "PROGRAM LIST"
			Me.btn_stat_insert.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 10.5F, Global.System.Drawing.FontStyle.Bold)
			Me.btn_stat_insert.Location = New Global.System.Drawing.Point(5, 564)
			Me.btn_stat_insert.Name = "btn_stat_insert"
			Me.btn_stat_insert.Size = New Global.System.Drawing.Size(99, 32)
			Me.btn_stat_insert.TabIndex = 79
			Me.btn_stat_insert.Text = "INSERT"
			Me.btn_stat_insert.UseVisualStyleBackColor = True
			Me.btn_stat_refresh.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 10.5F, Global.System.Drawing.FontStyle.Bold)
			Me.btn_stat_refresh.Location = New Global.System.Drawing.Point(129, 565)
			Me.btn_stat_refresh.Name = "btn_stat_refresh"
			Me.btn_stat_refresh.Size = New Global.System.Drawing.Size(99, 32)
			Me.btn_stat_refresh.TabIndex = 80
			Me.btn_stat_refresh.Text = "REFRESH"
			Me.btn_stat_refresh.UseVisualStyleBackColor = True
			Me.dgv_programlist.AllowUserToDeleteRows = False
			Me.dgv_programlist.AllowUserToResizeColumns = False
			Me.dgv_programlist.AllowUserToResizeRows = False
			Me.dgv_programlist.ColumnHeadersHeightSizeMode = Global.System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
			Me.dgv_programlist.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.Column11, Me.Column12, Me.Column13 })
			Me.dgv_programlist.Enabled = False
			Me.dgv_programlist.Location = New Global.System.Drawing.Point(6, 53)
			Me.dgv_programlist.Name = "dgv_programlist"
			Me.dgv_programlist.Size = New Global.System.Drawing.Size(374, 465)
			Me.dgv_programlist.TabIndex = 76
			Me.Column11.HeaderText = "Program name"
			Me.Column11.Name = "Column11"
			Me.Column11.Width = 150
			Me.Column12.HeaderText = "Lotto"
			Me.Column12.Name = "Column12"
			Me.Column13.HeaderText = "Opzionale"
			Me.Column13.Name = "Column13"
			Me.Column13.Width = 80
			Me.il_led.ImageStream = CType(componentResourceManager.GetObject("il_led.ImageStream"), Global.System.Windows.Forms.ImageListStreamer)
			Me.il_led.TransparentColor = Global.System.Drawing.Color.Transparent
			Me.il_led.Images.SetKeyName(0, "led_green_on.png")
			Me.il_led.Images.SetKeyName(1, "led_green_off.png")
			Me.il_led.Images.SetKeyName(2, "led_arancione_on.png")
			Me.il_led.Images.SetKeyName(3, "led_arancione_off.png")
			Me.il_anta.ImageStream = CType(componentResourceManager.GetObject("il_anta.ImageStream"), Global.System.Windows.Forms.ImageListStreamer)
			Me.il_anta.TransparentColor = Global.System.Drawing.Color.Transparent
			Me.il_anta.Images.SetKeyName(0, "Tasca1.png")
			Me.il_anta.Images.SetKeyName(1, "Tasca2.png")
			Me.SerialPort1.PortName = "COM5"
			Me.tmr_eth.Interval = 500
			Me.SerialPortBilancia.DataBits = 7
			Me.SerialPortBilancia.Parity = Global.System.IO.Ports.Parity.Even
			Me.TmrShowDescrizione.Interval = 10000
			Me.TmrChekbox.Interval = 1000
			Me.tmr_blink.Interval = 2000
			Me.btn_reset_cyc_main.Location = New Global.System.Drawing.Point(525, 449)
			Me.btn_reset_cyc_main.Name = "btn_reset_cyc_main"
			Me.btn_reset_cyc_main.Size = New Global.System.Drawing.Size(125, 39)
			Me.btn_reset_cyc_main.TabIndex = 361
			Me.btn_reset_cyc_main.Text = "Reset"
			Me.btn_reset_cyc_main.UseVisualStyleBackColor = True
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Inherit
			MyBase.ClientSize = New Global.System.Drawing.Size(1020, 725)
			MyBase.Controls.Add(Me.TabControl)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.Fixed3D
			MyBase.Icon = CType(componentResourceManager.GetObject("$this.Icon"), Global.System.Drawing.Icon)
			MyBase.MaximizeBox = False
			Me.MaximumSize = New Global.System.Drawing.Size(1042, 790)
			Me.MinimumSize = New Global.System.Drawing.Size(1024, 768)
			MyBase.Name = "FormPrincipale"
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "SIRTEK Terminal "
			MyBase.TopMost = True
			Me.TabControl.ResumeLayout(False)
			Me.TabPage1.ResumeLayout(False)
			Me.TabPage1.PerformLayout()
			Me.PnlRobot.ResumeLayout(False)
			Me.PnlRobot.PerformLayout()
			Me.GroupBox3.ResumeLayout(False)
			CType(Me.Pic_Oven_doorIN_open, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.Pic_Oven_doorIN_close, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.Pic_pres_end_oven, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.Pic_pres_start_oven, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.Pic_Piece_Oven, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.GrpCarico.ResumeLayout(False)
			CType(Me.Pic_pres_safe_unload, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.Pic_Piece_Paint, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.Pic_Piece_Unload_1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.GroupBox6.ResumeLayout(False)
			CType(Me.PicRobot1Busy, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.PicRobot1PrgRun, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.PicRobot1EmptyList, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.PicRobot1FouriIngombro, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.GroupBox5.ResumeLayout(False)
			CType(Me.Pic_Sirtek_plant_ready, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.Pic_SR20G_R1_ready, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.Pic_unload_done, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.Pic_plant_auto_ready, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.Pic_confirm_button, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.Pic_robots_ready, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.Pic_coder_ready, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.Pic_barrier_load_ready, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.Pic_pres_end_unload, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.Pic_barrier_unload, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.Pic_confirmed_unload, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.Pic_pres_end_load, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.Pic_barrier_load, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.Pic_confirmed_load, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.Pic_pres_start_paint, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.Pic_doorIN_open, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.Pic_pres_end_paint, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.Pic_doorOUT_open, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.Pic_doorOUT_close, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.Pic_doorIN_close, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.Pic_pres_start_unload, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.Pic_pres_start_load, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.Pic_Piece_Load, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.PictureBox2, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.TabPage3.ResumeLayout(False)
			Me.TabPage3.PerformLayout()
			Me.GrpManualComands.ResumeLayout(False)
			Me.GrpLng.ResumeLayout(False)
			Me.TabPage2.ResumeLayout(False)
			Me.grp_debug.ResumeLayout(False)
			Me.grp_debug.PerformLayout()
			Me.GroupBox9.ResumeLayout(False)
			Me.GroupBox9.PerformLayout()
			CType(Me.dgv_dout_IMA, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.dgv_din_IMA, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.dgv_dout, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.dgv_din, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.GroupBox8.ResumeLayout(False)
			Me.GroupBox8.PerformLayout()
			Me.GroupBox4.ResumeLayout(False)
			CType(Me.dgv_ciclica, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.GroupBox2.ResumeLayout(False)
			Me.GroupBox2.PerformLayout()
			Me.GroupBox1.ResumeLayout(False)
			CType(Me.dgv_master, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.TabPage4.ResumeLayout(False)
			CType(Me.dgv_ax, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.Grp_stats.ResumeLayout(False)
			Me.Grp_stats.PerformLayout()
			CType(Me.dgv_robot1_stats, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.dgv_programlist, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x040000E4 RID: 228
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
