Imports System
Imports System.ComponentModel
Imports System.Configuration
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.IO.Ports
Imports System.Net
Imports System.Net.Sockets
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Windows.Forms
Imports BR.AN.PviServices
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports Microsoft.VisualBasic.FileIO
Imports Terminale.My

Namespace Terminale
	' Token: 0x02000009 RID: 9
	Partial Public Class FormPrincipale
		Inherits Form

		' Token: 0x06000032 RID: 50 RVA: 0x00002C10 File Offset: 0x00000E10
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.Form1_Load
			AddHandler MyBase.DoubleClick, AddressOf Me.Form1_DClick
			Me.ax_pos_vb = New Single(4) {}
			Me.cnt_pieces_vb = New Single(2) {}
			Me.ax_status_vb = New Integer(4) {}
			Me.ax_status_color = New Color(4) {}
			Me.StatoPresence = New Boolean(100) {}
			Me.debug_var_VB = New Double(100) {}
			Me.cma_labels = New String(700) {}
			Me.Piece_Presence_vb = New Integer(4) {}
			Me.Lng = "ITA"
			Me.abs_encoder = New FormPrincipale.master_abs_enc(31) {}
			Me.di_string = New String(150) {}
			Me.do_string = New String(150) {}
			Me.vis_stato_ciclica = New Integer(31) {}
			Me.master_data = New Integer(31) {}
			Me.idx_IMA_R1 = 0
			Me.idx_IMA_R2 = 10
			Me.idx_DIG_IN = 48
			Me.idx_DIG_OUT = 32
			Me.send_active = New Boolean(2) {}
			Me.check_active = New Boolean(2) {}
			Me.send_string = New String(2) {}
			Me.check_string = New String(2) {}
			Me.send_code = New String(2) {}
			Me.send_res = New String(2) {}
			Me.tmr_send = New Integer(2) {}
			Me.IpServer = "101.103.107"
			Me.error_on_1 = True
			Me.StrLabels = New String(700) {}
			Me.InitializeComponent()
		End Sub

		' Token: 0x06000033 RID: 51 RVA: 0x00002D9C File Offset: 0x00000F9C
		Private Sub Form1_Load(sender As Object, e As EventArgs)
			Me.load_ini()
			Me.LoadPar()
			Me.load_alarms()
			Me.disable_psw_cmds()
			Me.AddHandler_PicCassa()
			If Me.connection_delay < 10.0F Then
				Me.connection_delay = 10.0F
			End If
			Me.tmr_start.Interval = CInt(Math.Round(CDbl((Me.connection_delay * 1000.0F))))
			Me.tmr_start.Start()
			Me.tmr_psw.Interval = 600000
			Me.tmr_psw.Start()
			Me.tmr_blink.Interval = 1000
			Me.tmr_blink.Start()
			Me.TabControl.Enabled = False
			Me.CaricaStringhe()
			Me.InitDiagIO()
			Me.StartListeningR1()
			Me.Lbl_Warning_cyc.AutoEllipsis = True
			Me.cmb_act_code.Items.Clear()
			Me.VisRemoteFeature()
			Me.Load_R1_stats()
			Me.Pic_Piece_Load.Visible = True
			Me.Pic_Piece_Paint.Visible = True
			Me.Pic_Piece_Unload_1.Visible = True
			Me.lbl_code_Load.Text = ""
			Me.lbl_code_Paint.Text = ""
			Me.lbl_code_Unload_ST1.Text = ""
			Me.clear_warn_vb()
			Me.clear_error_vb()
		End Sub

		' Token: 0x06000034 RID: 52 RVA: 0x00002EE8 File Offset: 0x000010E8
		Private Sub tmr_start_Tick(sender As Object, e As EventArgs)
			Me.TabControl.Enabled = True
			Me.tmr_eth.Interval = 500
			Me.tmr_eth.Start()
			Me.load_pvi()
			If Me.R1_Connected = 2 Then
				Dim text As String = "<15>"
				Me.send_stringa(text)
			Else
				Me.Terminal_ErrCode_vb = 38
				Me.VisWarning()
			End If
			Me.tmr_start.[Stop]()
		End Sub

		' Token: 0x06000035 RID: 53 RVA: 0x00002F54 File Offset: 0x00001154
		Private Sub Form1_DClick(sender As Object, e As EventArgs)
			If Interaction.MsgBox(Me.StrLabels(502), MsgBoxStyle.OkCancel Or MsgBoxStyle.AbortRetryIgnore Or MsgBoxStyle.Critical Or MsgBoxStyle.Question, Nothing) = MsgBoxResult.Yes Then
				Me.TabControl.Enabled = True
				Me.tmr_eth.Interval = 500
				Me.tmr_eth.Start()
				Me.load_pvi()
				Me.tmr_start.[Stop]()
				If Me.R1_Connected = 2 Then
					Dim text As String = "<15>"
					Me.send_stringa(text)
				Else
					Me.Terminal_ErrCode_vb = 38
					Me.VisWarning()
				End If
			End If
			MyBase.TopMost = False
		End Sub

		' Token: 0x06000036 RID: 54 RVA: 0x00002FE0 File Offset: 0x000011E0
		Private Function load_ini() As String
			Dim text As String = ""
			Dim result As String
			Try
				Dim cfgDataPath As String = ConfigurationManager.AppSettings("DataPath")
				If Not String.IsNullOrEmpty(cfgDataPath) Then
					If Not cfgDataPath.EndsWith("\") Then
						cfgDataPath += "\"
					End If
					If MyProject.Computer.FileSystem.DirectoryExists(cfgDataPath) Then
						Path.DATA_PATH = cfgDataPath
					Else
						text = "DataPath in app.config does not exist: " + cfgDataPath + " Function: " + MethodBase.GetCurrentMethod().Name
					End If
				End If

				Dim text2 As String = Application.StartupPath + "\init.ini"
				If Not MyProject.Computer.FileSystem.FileExists(text2) Then
					If text.Length = 0 Then
						text = "File init.ini not found. Function: " + MethodBase.GetCurrentMethod().Name
					End If
					result = text
				Else
					Using streamReader As StreamReader = New StreamReader(text2)
						While streamReader.Peek() > -1
							Dim text3 As String = streamReader.ReadLine()
							If Not text3.StartsWith("#") And Operators.CompareString(Strings.Trim(text3), "", False) <> 0 Then
								If Operators.CompareString(Strings.UCase(text3), Strings.UCase("End"), False) = 0 Then
									Exit While
								End If
								Dim array As String() = Strings.Split(text3, "=", -1, CompareMethod.Binary)
								Dim text4 As String = Strings.Trim(array(0))
								Dim text5 As String = Strings.Trim(array(1))
								Select Case Strings.UCase(text4)
									Case "DELAY PVI"
										Me.connection_delay = Conversions.ToSingle(text5)
									Case "CPU ADDRESS"
										Me.cpu_address = text5
									Case "PATH DATA"
										Dim iniDataPath As String = text5
										If Not iniDataPath.EndsWith("\") Then
											iniDataPath += "\"
										End If
										Path.DATA_PATH = iniDataPath
										If Not MyProject.Computer.FileSystem.DirectoryExists(Path.DATA_PATH) Then
											text = "Data Path is not correct in the ini file. Function: " + MethodBase.GetCurrentMethod().Name
											Interaction.MsgBox("Data Path is not correct in the ini file", MsgBoxStyle.OkOnly, Nothing)
											Return text
										End If
									Case "DATA PROGRAMS REMOTE"
										Path.PATH_PROGRAMS_REMOTE = text5
									Case "DATA PROGRAMS"
										Path.PATH_PROGRAMS = text5
									Case "DATA STATS REMOTE"
										Path.PATH_STATS_REMOTE = text5
									Case "CPU DESTINATION STATION"
										Me.destination_station = text5
									Case "CPU SOURCE STATION"
										Me.source_station = text5
								End Select
							End If
						End While
					End Using
					result = text
				End If
			Catch ex As System.Exception
				text = Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name
				result = text
			End Try
			Return result
		End Function

		' Token: 0x06000037 RID: 55 RVA: 0x00003308 File Offset: 0x00001508
		Private Sub frmMain_Close(sender As Object, e As FormClosingEventArgs)
			Try
				If Interaction.MsgBox(Me.StrLabels(503), MsgBoxStyle.YesNo Or MsgBoxStyle.Critical, Nothing) = MsgBoxResult.No Then
					e.Cancel = True
				End If
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x06000038 RID: 56 RVA: 0x0000337C File Offset: 0x0000157C
		Private Sub load_pvi()
			Try
				If Me.service Is Nothing Then
					Me.service = New Service("3B")
					If Me.service IsNot Nothing Then
						AddHandler Me.service.Connected, AddressOf Me.service_Connected
						AddHandler Me.service.[Error], AddressOf Me.service_Error
						Me.service.Connect()
					End If
				End If
			Catch ex As System.Exception
				Interaction.MsgBox("load_pvi() : " + ex.Message, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x06000039 RID: 57 RVA: 0x00003420 File Offset: 0x00001620
		Private Sub service_Connected(sender As Object, e As PviEventArgs)
			Try
				Application.DoEvents()
				Me.connect_cpu()
			Catch ex As System.Exception
				Interaction.MsgBox("service_Connected() : " + ex.Message, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x0600003A RID: 58 RVA: 0x00003474 File Offset: 0x00001674
		Private Sub service_Error(sender As Object, e As PviEventArgs)
			Dim errorText As String = e.ErrorText
			Debug.WriteLine("Service_error , " + errorText)
		End Sub

		' Token: 0x0600003B RID: 59 RVA: 0x00003490 File Offset: 0x00001690
		Private Sub connect_cpu()
			If Me.cpu Is Nothing Then
				Me.cpu = New Cpu(Me.service, "cpu")
				If Me.cpu Is Nothing Then
					Me.lbl_cma_loadinf.Text = "errore istanziamento cpu"
					Return
				End If
				AddHandler Me.cpu.Connected, AddressOf Me.cpu_Connected
				AddHandler Me.cpu.[Error], AddressOf Me.cpu_Error
				AddHandler Me.cpu.Disconnected, AddressOf Me.cpu_disconnected
				Me.cpu.Connection.DeviceType = DeviceType.TcpIp
				Me.cpu.Connection.TcpIp.SourceStation = 20
				Me.cpu.Connection.TcpIp.DestinationStation = 0
				Me.cpu.Connection.TcpIp.DestinationIpAddress = Me.cpu_address
				Me.cpu.Connection.TcpIp.ResponseTimeout = 1000
				Me.cpu.Connect()
			End If
		End Sub

		' Token: 0x0600003C RID: 60 RVA: 0x0000359C File Offset: 0x0000179C
		Private Sub cpu_Connected(sender As Object, e As PviEventArgs)
			Try
				If Me.cpu.IsConnected Then
					Me.lbl_cma_loadinf.Text = " PLC connesso"
					Me.lbl_cma_loadinf.BackColor = Color.Lime
					Me.connect_var()
				End If
			Catch ex As System.Exception
				Interaction.MsgBox("cpu_Connected() : " + ex.Message, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x0600003D RID: 61 RVA: 0x00003618 File Offset: 0x00001818
		Private Sub cpu_Error(sender As Object, e As PviEventArgs)
			Me.pvi_error = True
		End Sub

		' Token: 0x0600003E RID: 62 RVA: 0x00003621 File Offset: 0x00001821
		Private Sub cpu_disconnected(sender As Object, e As PviEventArgs)
			Me.lbl_cma_loadinf.BackColor = Color.Red
		End Sub

		' Token: 0x0600003F RID: 63 RVA: 0x00003634 File Offset: 0x00001834
		Private Sub connect_var()
			Me.stato_ciclica = New Variable(Me.cpu, "stato_ciclica")
			If Me.stato_ciclica IsNot Nothing Then
				AddHandler Me.stato_ciclica.Connected, AddressOf Me.var_connected
				AddHandler Me.stato_ciclica.[Error], AddressOf Me.var_connect_error
				AddHandler Me.stato_ciclica.ValueChanged, AddressOf Me.stato_ciclica_ValueChanged
				Me.stato_ciclica.RefreshTime = 500
				Me.stato_ciclica.Polling = True
				Me.stato_ciclica.Active = True
				Me.stato_ciclica.Connect()
				Me.var_inst_counter += 1
				Me.IMA_R1_in = New Variable(Me.cpu, "IMA_R1_in")
				If Me.IMA_R1_in IsNot Nothing Then
					AddHandler Me.IMA_R1_in.Connected, AddressOf Me.var_connected
					AddHandler Me.IMA_R1_in.[Error], AddressOf Me.var_connect_error
					AddHandler Me.IMA_R1_in.ValueChanged, AddressOf Me.IMA_R1_in_ValueChanged
					Me.IMA_R1_in.RefreshTime = 500
					Me.IMA_R1_in.Polling = True
					Me.IMA_R1_in.Active = True
					Me.IMA_R1_in.Connect()
					Me.var_inst_counter += 1
					Me.IMA_R2_in = New Variable(Me.cpu, "IMA_R2_in")
					If Me.IMA_R2_in IsNot Nothing Then
						AddHandler Me.IMA_R2_in.Connected, AddressOf Me.var_connected
						AddHandler Me.IMA_R2_in.[Error], AddressOf Me.var_connect_error
						AddHandler Me.IMA_R2_in.ValueChanged, AddressOf Me.IMA_R2_in_ValueChanged
						Me.IMA_R2_in.RefreshTime = 500
						Me.IMA_R2_in.Polling = True
						Me.IMA_R2_in.Active = True
						Me.IMA_R2_in.Connect()
						Me.var_inst_counter += 1
						Me.IMA_IN_vb = New Variable(Me.cpu, "IMA_IN_vb")
						If Me.IMA_IN_vb IsNot Nothing Then
							AddHandler Me.IMA_IN_vb.Connected, AddressOf Me.var_connected
							AddHandler Me.IMA_IN_vb.[Error], AddressOf Me.var_connect_error
							AddHandler Me.IMA_IN_vb.ValueChanged, AddressOf Me.IMA_IN_vb_ValueChanged
							Me.IMA_IN_vb.RefreshTime = 500
							Me.IMA_IN_vb.Polling = True
							Me.IMA_IN_vb.Active = True
							Me.IMA_IN_vb.Connect()
							Me.var_inst_counter += 1
							Me.IMA_OUT_vb = New Variable(Me.cpu, "IMA_OUT_vb")
							If Me.IMA_OUT_vb IsNot Nothing Then
								AddHandler Me.IMA_OUT_vb.Connected, AddressOf Me.var_connected
								AddHandler Me.IMA_OUT_vb.[Error], AddressOf Me.var_connect_error
								AddHandler Me.IMA_OUT_vb.ValueChanged, AddressOf Me.IMA_OUT_vb_ValueChanged
								Me.IMA_OUT_vb.RefreshTime = 500
								Me.IMA_OUT_vb.Polling = True
								Me.IMA_OUT_vb.Active = True
								Me.IMA_OUT_vb.Connect()
								Me.var_inst_counter += 1
								Me.vis_error_list = New Variable(Me.cpu, "vis_error_list")
								If Me.vis_error_list IsNot Nothing Then
									AddHandler Me.vis_error_list.Connected, AddressOf Me.var_connected
									AddHandler Me.vis_error_list.[Error], AddressOf Me.var_connect_error
									AddHandler Me.vis_error_list.ValueRead, AddressOf Me.vis_error_list_ValueRead
									Me.vis_error_list.RefreshTime = 0
									Me.vis_error_list.Polling = True
									Me.vis_error_list.Active = True
									Me.vis_error_list.Connect()
									Me.var_inst_counter += 1
									Me.vis_error = New Variable(Me.cpu, "vis_error")
									If Me.vis_error IsNot Nothing Then
										AddHandler Me.vis_error.Connected, AddressOf Me.var_connected
										AddHandler Me.vis_error.[Error], AddressOf Me.var_connect_error
										AddHandler Me.vis_error.ValueChanged, AddressOf Me.vis_error_ValueChanged
										Me.vis_error.RefreshTime = 500
										Me.vis_error.Polling = True
										Me.vis_error.Active = False
										Me.vis_error.Connect()
										Me.var_inst_counter += 1
										Me.axis_status = New Variable(Me.cpu, "axis_status")
										If Me.axis_status IsNot Nothing Then
											AddHandler Me.axis_status.Connected, AddressOf Me.var_connected
											AddHandler Me.axis_status.[Error], AddressOf Me.var_connect_error
											AddHandler Me.axis_status.ValueChanged, AddressOf Me.axis_status_ValueChanged
											Me.axis_status.RefreshTime = 500
											Me.axis_status.Polling = True
											Me.axis_status.Active = True
											Me.axis_status.Connect()
											Me.var_inst_counter += 1
											Me.man_ax = New Variable(Me.cpu, "man_ax")
											If Me.man_ax IsNot Nothing Then
												AddHandler Me.man_ax.Connected, AddressOf Me.var_connected
												AddHandler Me.man_ax.[Error], AddressOf Me.var_connect_error
												Me.man_ax.RefreshTime = 0
												Me.man_ax.Polling = True
												Me.man_ax.Active = True
												Me.man_ax.Connect()
												Me.var_inst_counter += 1
												Me.reset_auto = New Variable(Me.cpu, "reset_auto")
												If Me.reset_auto IsNot Nothing Then
													AddHandler Me.reset_auto.Connected, AddressOf Me.var_connected
													AddHandler Me.reset_auto.[Error], AddressOf Me.var_connect_error
													Me.reset_auto.RefreshTime = 0
													Me.reset_auto.Polling = True
													Me.reset_auto.Active = True
													Me.reset_auto.Connect()
													Me.var_inst_counter += 1
													Me.cmd_master = New Variable(Me.cpu, "cmd_master")
													If Me.cmd_master IsNot Nothing Then
														AddHandler Me.cmd_master.Connected, AddressOf Me.var_connected
														AddHandler Me.cmd_master.[Error], AddressOf Me.var_connect_error
														Me.cmd_master.RefreshTime = 0
														Me.cmd_master.Polling = True
														Me.cmd_master.Active = True
														Me.cmd_master.Connect()
														Me.var_inst_counter += 1
														Me.MainStepDone = New Variable(Me.cpu, "MainStepDone")
														If Me.MainStepDone IsNot Nothing Then
															AddHandler Me.MainStepDone.Connected, AddressOf Me.var_connected
															AddHandler Me.MainStepDone.[Error], AddressOf Me.var_connect_error
															AddHandler Me.MainStepDone.ValueChanged, AddressOf Me.MainStepDone_ValueChanged
															Me.MainStepDone.RefreshTime = 500
															Me.MainStepDone.Polling = True
															Me.MainStepDone.Active = True
															Me.MainStepDone.Connect()
															Me.var_inst_counter += 1
															Me.par_VB = New Variable(Me.cpu, "par_VB")
															If Me.par_VB IsNot Nothing Then
																AddHandler Me.par_VB.Connected, AddressOf Me.var_connected
																AddHandler Me.par_VB.[Error], AddressOf Me.var_connect_error
																AddHandler Me.par_VB.ValueChanged, AddressOf Me.par_VB_ValueChanged
																Me.par_VB.WriteValueAutomatic = False
																Me.par_VB.RefreshTime = 0
																Me.par_VB.Polling = True
																Me.par_VB.Active = True
																Me.par_VB.Connect()
																Me.var_inst_counter += 1
																Me.presence = New Variable(Me.cpu, "presence")
																If Me.presence IsNot Nothing Then
																	AddHandler Me.presence.Connected, AddressOf Me.var_connected
																	AddHandler Me.presence.[Error], AddressOf Me.var_connect_error
																	AddHandler Me.presence.ValueChanged, AddressOf Me.presence_ValueChanged
																	Me.presence.RefreshTime = 300
																	Me.presence.Polling = True
																	Me.presence.Active = True
																	Me.presence.Connect()
																	Me.var_inst_counter += 1
																	Me.debug_var = New Variable(Me.cpu, "debug_var")
																	If Me.debug_var IsNot Nothing Then
																		AddHandler Me.debug_var.Connected, AddressOf Me.var_connected
																		AddHandler Me.debug_var.[Error], AddressOf Me.var_connect_error
																		AddHandler Me.debug_var.ValueChanged, AddressOf Me.debug_var_ValueChanged
																		Me.debug_var.RefreshTime = 300
																		Me.debug_var.Polling = True
																		Me.debug_var.Active = True
																		Me.debug_var.Connect()
																		Me.var_inst_counter += 1
																		Me.ax_status = New Variable(Me.cpu, "ax_status")
																		If Me.ax_status IsNot Nothing Then
																			AddHandler Me.ax_status.Connected, AddressOf Me.var_connected
																			AddHandler Me.ax_status.[Error], AddressOf Me.var_connect_error
																			AddHandler Me.ax_status.ValueChanged, AddressOf Me.ax_status_ValueChanged
																			Me.ax_status.RefreshTime = 500
																			Me.ax_status.Polling = True
																			Me.ax_status.Active = True
																			Me.ax_status.Connect()
																			Me.var_inst_counter += 1
																			Me.DIn = New Variable(Me.cpu, "DIn")
																			If Me.DIn IsNot Nothing Then
																				AddHandler Me.DIn.Connected, AddressOf Me.var_connected
																				AddHandler Me.DIn.[Error], AddressOf Me.var_connect_error
																				AddHandler Me.DIn.ValueChanged, AddressOf Me.DIn_ValueChanged
																				Me.DIn.RefreshTime = 500
																				Me.DIn.Polling = True
																				Me.DIn.Active = True
																				Me.DIn.Connect()
																				Me.var_inst_counter += 1
																				Me.DOut = New Variable(Me.cpu, "DOut")
																				If Me.DOut IsNot Nothing Then
																					AddHandler Me.DOut.Connected, AddressOf Me.var_connected
																					AddHandler Me.DOut.[Error], AddressOf Me.var_connect_error
																					AddHandler Me.DOut.ValueChanged, AddressOf Me.DOut_ValueChanged
																					Me.DOut.RefreshTime = 500
																					Me.DOut.Polling = True
																					Me.DOut.Active = True
																					Me.DOut.Connect()
																					Me.var_inst_counter += 1
																					Me.FDOut = New Variable(Me.cpu, "FDout")
																					If Me.FDOut IsNot Nothing Then
																						AddHandler Me.FDOut.Connected, AddressOf Me.var_connected
																						AddHandler Me.FDOut.[Error], AddressOf Me.var_connect_error
																						Me.FDOut.RefreshTime = 500
																						Me.FDOut.Polling = True
																						Me.FDOut.Active = True
																						Me.FDOut.Connect()
																						Me.var_inst_counter += 1
																						Me.force_out = New Variable(Me.cpu, "force_out")
																						If Me.force_out IsNot Nothing Then
																							AddHandler Me.force_out.Connected, AddressOf Me.var_connected
																							AddHandler Me.force_out.[Error], AddressOf Me.var_connect_error
																							Me.force_out.RefreshTime = -1
																							Me.force_out.Polling = True
																							Me.force_out.Active = True
																							Me.force_out.Connect()
																							Me.var_inst_counter += 1
																							Me.abs_enc = New Variable(Me.cpu, "abs_enc")
																							If Me.abs_enc IsNot Nothing Then
																								AddHandler Me.abs_enc.Connected, AddressOf Me.var_connected
																								AddHandler Me.abs_enc.ValueRead, AddressOf Me.abs_enc_ValueRead
																								AddHandler Me.abs_enc.[Error], AddressOf Me.var_connect_error
																								Me.abs_enc.WriteValueAutomatic = False
																								Me.abs_enc.RefreshTime = -1
																								Me.abs_enc.Polling = True
																								Me.abs_enc.Active = True
																								Me.abs_enc.Connect()
																								Me.var_inst_counter += 1
																								Me.cmd_TogglePaintDoorIN = New Variable(Me.cpu, "cmd_TogglePaintDoorIN")
																								If Me.cmd_TogglePaintDoorIN IsNot Nothing Then
																									AddHandler Me.cmd_TogglePaintDoorIN.Connected, AddressOf Me.var_connected
																									AddHandler Me.cmd_TogglePaintDoorIN.[Error], AddressOf Me.var_connect_error
																									Me.cmd_TogglePaintDoorIN.RefreshTime = 0
																									Me.cmd_TogglePaintDoorIN.Polling = True
																									Me.cmd_TogglePaintDoorIN.Active = True
																									Me.cmd_TogglePaintDoorIN.Connect()
																									Me.var_inst_counter += 1
																									Me.cmd_TogglePaintDoorOUT = New Variable(Me.cpu, "cmd_TogglePaintDoorOUT")
																									If Me.cmd_TogglePaintDoorOUT IsNot Nothing Then
																										AddHandler Me.cmd_TogglePaintDoorOUT.Connected, AddressOf Me.var_connected
																										AddHandler Me.cmd_TogglePaintDoorOUT.[Error], AddressOf Me.var_connect_error
																										Me.cmd_TogglePaintDoorOUT.RefreshTime = 0
																										Me.cmd_TogglePaintDoorOUT.Polling = True
																										Me.cmd_TogglePaintDoorOUT.Active = True
																										Me.cmd_TogglePaintDoorOUT.Connect()
																										Me.var_inst_counter += 1
																										Me.Prog_Code = New Variable(Me.cpu, "Prog_Code")
																										If Me.Prog_Code IsNot Nothing Then
																											AddHandler Me.Prog_Code.Connected, AddressOf Me.var_connected
																											AddHandler Me.Prog_Code.[Error], AddressOf Me.var_connect_error
																											AddHandler Me.Prog_Code.ValueChanged, AddressOf Me.Prog_Code_ValueChanged
																											Me.Prog_Code.RefreshTime = 300
																											Me.Prog_Code.Polling = True
																											Me.Prog_Code.Active = True
																											Me.Prog_Code.Connect()
																											Me.var_inst_counter += 1
																											Me.Terminal_ErrCode = New Variable(Me.cpu, "Terminal_ErrCode")
																											If Me.Terminal_ErrCode IsNot Nothing Then
																												AddHandler Me.Terminal_ErrCode.Connected, AddressOf Me.var_connected
																												AddHandler Me.Terminal_ErrCode.[Error], AddressOf Me.var_connect_error
																												AddHandler Me.Terminal_ErrCode.ValueChanged, AddressOf Me.Terminal_ErrCode_ValueChanged
																												Me.Terminal_ErrCode.RefreshTime = 300
																												Me.Terminal_ErrCode.Polling = True
																												Me.Terminal_ErrCode.Active = True
																												Me.Terminal_ErrCode.Connect()
																												Me.var_inst_counter += 1
																												Me.LoadTape = New Variable(Me.cpu, "LoadTape")
																												If Me.LoadTape IsNot Nothing Then
																													AddHandler Me.LoadTape.Connected, AddressOf Me.var_connected
																													AddHandler Me.LoadTape.[Error], AddressOf Me.var_connect_error
																													AddHandler Me.LoadTape.ValueChanged, AddressOf Me.LoadTape_ValueChanged
																													Me.LoadTape.RefreshTime = 300
																													Me.LoadTape.Polling = True
																													Me.LoadTape.Active = True
																													Me.LoadTape.Connect()
																													Me.var_inst_counter += 1
																													Me.OvenTape = New Variable(Me.cpu, "OvenTape")
																													If Me.OvenTape IsNot Nothing Then
																														AddHandler Me.OvenTape.Connected, AddressOf Me.var_connected
																														AddHandler Me.OvenTape.[Error], AddressOf Me.var_connect_error
																														AddHandler Me.OvenTape.ValueChanged, AddressOf Me.OvenTape_ValueChanged
																														Me.OvenTape.RefreshTime = 300
																														Me.OvenTape.Polling = True
																														Me.OvenTape.Active = True
																														Me.OvenTape.Connect()
																														Me.var_inst_counter += 1
																														Me.PaintTape = New Variable(Me.cpu, "PaintTape")
																														If Me.PaintTape IsNot Nothing Then
																															AddHandler Me.PaintTape.Connected, AddressOf Me.var_connected
																															AddHandler Me.PaintTape.[Error], AddressOf Me.var_connect_error
																															AddHandler Me.PaintTape.ValueChanged, AddressOf Me.PaintTape_ValueChanged
																															Me.PaintTape.RefreshTime = 300
																															Me.PaintTape.Polling = True
																															Me.PaintTape.Active = True
																															Me.PaintTape.Connect()
																															Me.var_inst_counter += 1
																															Me.UnloadTape = New Variable(Me.cpu, "UnloadTape")
																															If Me.UnloadTape IsNot Nothing Then
																																AddHandler Me.UnloadTape.Connected, AddressOf Me.var_connected
																																AddHandler Me.UnloadTape.[Error], AddressOf Me.var_connect_error
																																AddHandler Me.UnloadTape.ValueChanged, AddressOf Me.UnloadTape_ValueChanged
																																Me.UnloadTape.RefreshTime = 300
																																Me.UnloadTape.Polling = True
																																Me.UnloadTape.Active = True
																																Me.UnloadTape.Connect()
																																Me.var_inst_counter += 1
																																Me.reset_error_vb = New Variable(Me.cpu, "reset_error_vb")
																																If Me.reset_error_vb IsNot Nothing Then
																																	AddHandler Me.reset_error_vb.Connected, AddressOf Me.var_connected
																																	AddHandler Me.reset_error_vb.[Error], AddressOf Me.var_connect_error
																																	AddHandler Me.reset_error_vb.ValueChanged, AddressOf Me.reset_error_vb_ValueChanged
																																	Me.reset_error_vb.RefreshTime = 300
																																	Me.reset_error_vb.Polling = True
																																	Me.reset_error_vb.Active = True
																																	Me.reset_error_vb.Connect()
																																	Me.var_inst_counter += 1
																																	Me.waiting_resume = New Variable(Me.cpu, "waiting_resume")
																																	If Me.waiting_resume IsNot Nothing Then
																																		AddHandler Me.waiting_resume.Connected, AddressOf Me.var_connected
																																		AddHandler Me.waiting_resume.[Error], AddressOf Me.var_connect_error
																																		AddHandler Me.waiting_resume.ValueChanged, AddressOf Me.waiting_resume_vb_ValueChanged
																																		Me.waiting_resume.RefreshTime = 300
																																		Me.waiting_resume.Polling = True
																																		Me.waiting_resume.Active = True
																																		Me.waiting_resume.Connect()
																																		Me.var_inst_counter += 1
																																		Me.clk_oven = New Variable(Me.cpu, "clk_oven")
																																		If Me.clk_oven IsNot Nothing Then
																																			AddHandler Me.clk_oven.Connected, AddressOf Me.var_connected
																																			AddHandler Me.clk_oven.[Error], AddressOf Me.var_connect_error
																																			AddHandler Me.clk_oven.ValueChanged, AddressOf Me.clk_oven_ValueChanged
																																			Me.clk_oven.RefreshTime = 300
																																			Me.clk_oven.Polling = True
																																			Me.clk_oven.Active = True
																																			Me.clk_oven.Connect()
																																			Me.var_inst_counter += 1
																																			Me.cmd_Oven_auto_step = New Variable(Me.cpu, "cmd_Oven_auto_step")
																																			If Me.cmd_Oven_auto_step IsNot Nothing Then
																																				AddHandler Me.cmd_Oven_auto_step.Connected, AddressOf Me.var_connected
																																				AddHandler Me.cmd_Oven_auto_step.[Error], AddressOf Me.var_connect_error
																																				Me.cmd_Oven_auto_step.RefreshTime = 300
																																				Me.cmd_Oven_auto_step.Polling = True
																																				Me.cmd_Oven_auto_step.Active = True
																																				Me.cmd_Oven_auto_step.Connect()
																																				Me.var_inst_counter += 1
																																				Me.cmd_str_oven_t = New Variable(Me.cpu, "cmd_str_oven_t")
																																				If Me.cmd_str_oven_t IsNot Nothing Then
																																					AddHandler Me.cmd_str_oven_t.Connected, AddressOf Me.var_connected
																																					AddHandler Me.cmd_str_oven_t.[Error], AddressOf Me.var_connect_error
																																					AddHandler Me.cmd_str_oven_t.ValueChanged, AddressOf Me.cmd_str_oven_t_ValueChanged
																																					Me.cmd_str_oven_t.RefreshTime = 300
																																					Me.cmd_str_oven_t.Polling = True
																																					Me.cmd_str_oven_t.Active = True
																																					Me.cmd_str_oven_t.Connect()
																																					Me.var_inst_counter += 1
																																					Me.oven_time_end = New Variable(Me.cpu, "oven_time_end")
																																					If Me.oven_time_end IsNot Nothing Then
																																						AddHandler Me.oven_time_end.Connected, AddressOf Me.var_connected
																																						AddHandler Me.oven_time_end.[Error], AddressOf Me.var_connect_error
																																						Me.oven_time_end.RefreshTime = 300
																																						Me.oven_time_end.Polling = True
																																						Me.oven_time_end.Active = True
																																						Me.oven_time_end.Connect()
																																						Me.var_inst_counter += 1
																																						Me.clk_paint = New Variable(Me.cpu, "clk_paint")
																																						If Me.clk_paint IsNot Nothing Then
																																							AddHandler Me.clk_paint.Connected, AddressOf Me.var_connected
																																							AddHandler Me.clk_paint.[Error], AddressOf Me.var_connect_error
																																							Me.clk_paint.RefreshTime = 300
																																							Me.clk_paint.Polling = True
																																							Me.clk_paint.Active = True
																																							Me.clk_paint.Connect()
																																							Me.var_inst_counter += 1
																																							Me.DI_Force_Unload = New Variable(Me.cpu, "DI_Force_Unload")
																																							If Me.DI_Force_Unload IsNot Nothing Then
																																								AddHandler Me.DI_Force_Unload.Connected, AddressOf Me.var_connected
																																								AddHandler Me.DI_Force_Unload.[Error], AddressOf Me.var_connect_error
																																								Me.DI_Force_Unload.RefreshTime = 300
																																								Me.DI_Force_Unload.Polling = True
																																								Me.DI_Force_Unload.Active = True
																																								Me.DI_Force_Unload.Connect()
																																								Me.var_inst_counter += 1
																																								Me.flag_force_unload = New Variable(Me.cpu, "flag_force_unload")
																																								If Me.flag_force_unload IsNot Nothing Then
																																									AddHandler Me.flag_force_unload.Connected, AddressOf Me.var_connected
																																									AddHandler Me.flag_force_unload.[Error], AddressOf Me.var_connect_error
																																									AddHandler Me.flag_force_unload.ValueChanged, AddressOf Me.flag_force_unload_ValueChanged
																																									Me.flag_force_unload.RefreshTime = 300
																																									Me.flag_force_unload.Polling = True
																																									Me.flag_force_unload.Active = True
																																									Me.flag_force_unload.Connect()
																																									Me.var_inst_counter += 1
																																								End If
																																							End If
																																						End If
																																					End If
																																				End If
																																			End If
																																		End If
																																	End If
																																End If
																															End If
																														End If
																													End If
																												End If
																											End If
																										End If
																									End If
																								End If
																							End If
																						End If
																					End If
																				End If
																			End If
																		End If
																	End If
																End If
															End If
														End If
													End If
												End If
											End If
										End If
									End If
								End If
							End If
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x06000040 RID: 64 RVA: 0x00004E04 File Offset: 0x00003004
		Private Sub var_connected(sender As Object, e As PviEventArgs)
			Dim variable As Variable = CType(sender, Variable)
			Me.var_con_counter += 1
			If Me.var_inst_counter = Me.var_con_counter Then
				Me.pvi_ok = True
				Me.download_par()
				Me.vis_error.Active = True
				Me.lbl_PLC_On.BackColor = Color.Lime
				Me.lbl_PLC_On.Text = "PLC OK"
				Me.force_out.Value = New Value(False)
			End If
		End Sub

		' Token: 0x06000041 RID: 65 RVA: 0x00004E80 File Offset: 0x00003080
		Private Sub var_connect_error(sender As Object, e As PviEventArgs)
			Dim variable As Variable = CType(sender, Variable)
			Dim str As String = "Variable error : " + variable.Name.ToString() + " , " + e.ErrorText
			Me.add_log(-1, 100, "var_connect : " + str)
		End Sub

		' Token: 0x06000042 RID: 66 RVA: 0x00004ECC File Offset: 0x000030CC
		Private Sub ax_status_ValueChanged(sender As Object, e As VariableEventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Dim variable As Variable = CType(sender, Variable)
				Dim num As Integer = 0
				Do
					Me.ax_status_vb(num) = Conversions.ToInteger(variable.Value(num).ToString())
					Select Case Me.ax_status_vb(num)
						Case 0
							Me.ax_status_color(num) = Color.Empty
						Case 1
							Me.ax_status_color(num) = Color.White
						Case 2
							Me.ax_status_color(num) = Color.Cyan
						Case 3
							Me.ax_status_color(num) = Color.Lime
						Case 4
							Me.ax_status_color(num) = Color.Yellow
						Case 5
							Me.ax_status_color(num) = Color.Red
						Case 6
							Me.ax_status_color(num) = Color.Orange
					End Select
					num += 1
				Loop While num <= 3
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x06000043 RID: 67 RVA: 0x00005008 File Offset: 0x00003208
		Private Sub par_VB_ValueChanged(sender As Object, e As VariableEventArgs)
			Try
				Dim variable As Variable = CType(sender, Variable)
				Me.timeout_oven_vb = Conversions.ToDouble(variable.Value(46).ToString())
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x06000044 RID: 68 RVA: 0x00005080 File Offset: 0x00003280
		Private Sub presence_ValueChanged(sender As Object, e As VariableEventArgs)
			Try
				Dim variable As Variable = CType(sender, Variable)
				Dim num As Integer = Math.Min(Me.StatoPresence.Length, variable.Value.ArrayLength) - 1
				For i As Integer = 0 To num
					Me.StatoPresence(i) = Conversions.ToBoolean(variable.Value(i).ToString())
				Next
				Me.VisPresence()
				If (If((-If((Me.StatoPresence(34) > False), 1, 0)), 1, 0) And Not Me.DO_Unload_Confirm_Lamp_old) <> 0 Then
					Me.lbl_code_Unload_ST1.Text = ""
				End If
				If Me.StatoPresence(3) And Not Me.DI_Load_Confirm_Btn_OLD Then
					Me.update_prog_code_to_PLC()
				End If
				Me.DI_Load_Confirm_Btn_OLD = Me.StatoPresence(3)
				Me.DO_Load_Confirm_Lamp_OLD = Me.StatoPresence(5)
				Me.DO_Unload_Confirm_Lamp_old = If((-If((Me.StatoPresence(34) > False), 1, 0)), 1, 0)
				Me.DO_AUTO_Lamp_OLD = Me.StatoPresence(40)
				Me.DI_Empty_Line_OLD = Me.StatoPresence(42)
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x06000045 RID: 69 RVA: 0x000051B8 File Offset: 0x000033B8
		Private Sub debug_var_ValueChanged(sender As Object, e As VariableEventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				If Me.grp_debug.Visible Then
					Dim variable As Variable = CType(sender, Variable)
					Dim num As Integer = Math.Min(Me.debug_var_VB.Length, variable.Value.ArrayLength) - 1
					For i As Integer = 0 To num
						Me.debug_var_VB(i) = Conversions.ToDouble(variable.Value(i).ToString())
					Next
					If Me.pvi_ok Then
						Me.lbl_debug_02.Text = Me.debug_var_VB(1).ToString()
						Me.lbl_debug_03.Text = Me.debug_var_VB(2).ToString()
						Me.lbl_FSM_err.Text = Me.debug_var_VB(3).ToString()
						Me.lbl_mmnastro_oven.Text = Me.debug_var_VB(4).ToString()
						Me.lbl_mmnastro_paint.Text = Me.debug_var_VB(5).ToString()
						Me.lbl_mmnastro_unload.Text = Me.debug_var_VB(6).ToString()
					End If
				End If
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x06000046 RID: 70 RVA: 0x00005328 File Offset: 0x00003528
		Private Sub DIn_ValueChanged(sender As Object, e As VariableEventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Dim variable As Variable = CType(sender, Variable)
				Dim num As Integer = Me.dgv_din.RowCount - 1
				For i As Integer = 0 To num
					If Conversions.ToBoolean(variable.Value(i).ToString()) Then
						Me.dgv_din(0, i).Value = Me.il_led.Images(0)
						Me.dgv_din(0, 28).Value = Me.il_led.Images(0)
						Me.dgv_din(0, 32).Value = Me.il_led.Images(0)
					Else
						Me.dgv_din(0, i).Value = Me.il_led.Images(1)
						Me.dgv_din(0, 28).Value = Me.il_led.Images(1)
						Me.dgv_din(0, 32).Value = Me.il_led.Images(1)
					End If
				Next
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x06000047 RID: 71 RVA: 0x000054A0 File Offset: 0x000036A0
		Private Sub DOut_ValueChanged(sender As Object, e As VariableEventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Dim variable As Variable = CType(sender, Variable)
				Dim num As Integer = Me.dgv_dout.RowCount - 1
				For i As Integer = 0 To num
					If Conversions.ToBoolean(variable.Value(i).ToString()) Then
						Me.dgv_dout(0, i).Value = Me.il_led.Images(2)
					Else
						Me.dgv_dout(0, i).Value = Me.il_led.Images(3)
					End If
				Next
				Dim flag As Boolean = Conversions.ToBoolean(variable.Value(0).ToString())
				Dim flag2 As Boolean = Conversions.ToBoolean(variable.Value(3).ToString())
				If flag Then
					Me.Lbl_AUTO_Plant.Text = Me.cma_labels(32)
					Me.Lbl_AUTO_Plant.BackColor = Color.Lime
				Else
					Me.Lbl_AUTO_Plant.Text = Me.cma_labels(33)
					Me.Lbl_AUTO_Plant.BackColor = Color.Silver
				End If
				If flag2 Then
					Me.Lbl_MotorON_Plant.Text = Me.cma_labels(34)
					Me.Lbl_MotorON_Plant.BackColor = Color.Lime
				Else
					Me.Lbl_MotorON_Plant.Text = Me.cma_labels(35)
					Me.Lbl_MotorON_Plant.BackColor = Color.Silver
				End If
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x06000048 RID: 72 RVA: 0x00005648 File Offset: 0x00003848
		Private Sub axis_status_ValueChanged(sender As Object, e As VariableEventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Dim variable As Variable = CType(sender, Variable)
				Dim num As Integer = 0
				Do
					Dim array As Single() = New Single(5) {}
					array(0) = Conversions.ToSingle(variable.Value("ax_status[" + Conversions.ToString(num) + "].pos").ToString())
					array(1) = Conversions.ToSingle(variable.Value("ax_status[" + Conversions.ToString(num) + "].vel").ToString())
					array(2) = Conversions.ToSingle(variable.Value("ax_status[" + Conversions.ToString(num) + "].err").ToString())
					array(3) = Conversions.ToSingle(variable.Value("ax_status[" + Conversions.ToString(num) + "].curr").ToString())
					array(4) = Conversions.ToSingle(variable.Value("ax_status[" + Conversions.ToString(num) + "].temp").ToString())
					Me.dgv_ax(1, num).Value = variable.Value("ax_status[" + Conversions.ToString(num) + "].pos").ToString()
					Me.dgv_ax(2, num).Value = Strings.Format(array(1), "0.0")
					Me.dgv_ax(3, num).Value = Strings.Format(array(2), "0.00")
					Me.dgv_ax(4, num).Value = Strings.Format(array(3), "0.0")
					Me.dgv_ax(5, num).Value = Strings.Format(array(4), "0.0")
					If Conversions.ToInteger(variable.Value("ax_status[" + Conversions.ToString(num) + "].err_code").ToString()) > 0 Then
						Me.dgv_ax(6, num).Style.ForeColor = Color.Red
						Me.dgv_ax(6, num).Value = variable.Value("ax_status[" + Conversions.ToString(num) + "].err_code").ToString() + " : " + variable.Value("ax_status[" + Conversions.ToString(num) + "].error_string").ToString()
					Else
						Me.dgv_ax(6, num).Style.ForeColor = Color.Black
						Me.dgv_ax(6, num).Value = ""
					End If
					num += 1
				Loop While num <= 3
				Me.dgv_master(1, 0).Value = variable.Value("ax_status[0].pos").ToString()
				Me.dgv_master(1, 1).Value = variable.Value("ax_status[1].pos").ToString()
				Me.dgv_master(1, 2).Value = variable.Value("ax_status[2].pos").ToString()
				Me.dgv_master(1, 3).Value = variable.Value("ax_status[3].pos").ToString()
				Me.lbl_mmLoadBelt.Text = variable.Value("ax_status[0].pos").ToString()
				Me.lbl_mmPaintBelt.Text = variable.Value("ax_status[1].pos").ToString()
				Me.lbl_mmUnloadBelt.Text = variable.Value("ax_status[2].pos").ToString()
				Me.lbl_mmOvenBelt.Text = variable.Value("ax_status[3].pos").ToString()
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x06000049 RID: 73 RVA: 0x00005A70 File Offset: 0x00003C70
		Private Sub MainStepDone_ValueChanged(sender As Object, e As VariableEventArgs)
			Try
				Dim flag As Boolean = Conversions.ToBoolean(CType(sender, Variable).Value.ToString())
				If (flag And Not Me.MainStepDone_vb_old) AndAlso Me.par_en_remote_programlist AndAlso (Operators.CompareString(Me.Progr_Code_vb, "", False) <> 0 And Operators.CompareString(Me.Progr_Code_vb, "EMPTY_CODE", False) <> 0 And Operators.CompareString(Me.Progr_Code_vb, "<1&EMPTY CODE&|>", False) <> 0 And Operators.CompareString(Me.Progr_Code_vb, "<1&&|>", False) <> 0) Then
					Me.Load_prg_list()
				End If
				Me.MainStepDone_vb_old = flag
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x0600004A RID: 74 RVA: 0x00005B54 File Offset: 0x00003D54
		Private Sub IMA_R1_in_ValueChanged(sender As Object, e As VariableEventArgs)
			Try
				Dim variable As Variable = CType(sender, Variable)
				Me.R1_safe_position_vb = If((-If((Convert.ToBoolean((Conversions.ToLong(variable.Value(33).ToString()) And 4L) = 4L) > False), 1, 0)), 1, 0)
				Me.R1_carter_Low_vb = Convert.ToBoolean((Conversions.ToLong(variable.Value(34).ToString()) And 32L) = 32L)
				Me.R1_status_idx_vb = Conversions.ToInteger(variable.Value(2).ToString())
				Me.R1_n_list_vb = Conversions.ToInteger(variable.Value(3).ToString())
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Exclamation, "IMA_R1_in_ValueChanged")
			End Try
		End Sub

		' Token: 0x0600004B RID: 75 RVA: 0x00005C44 File Offset: 0x00003E44
		Private Sub IMA_R2_in_ValueChanged(sender As Object, e As VariableEventArgs)
			Try
				Dim variable As Variable = CType(sender, Variable)
				Me.R2_safe_position_vb = If((-If((Convert.ToBoolean((Conversions.ToLong(variable.Value(33).ToString()) And 4L) = 4L) > False), 1, 0)), 1, 0)
				Me.R2_status_idx_vb = Conversions.ToInteger(variable.Value(33).ToString())
				Me.R2_n_list_vb = Conversions.ToInteger(variable.Value(34).ToString())
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Exclamation, "IMA_R2_in_ValueChanged")
			End Try
		End Sub

		' Token: 0x0600004C RID: 76 RVA: 0x00005D0C File Offset: 0x00003F0C
		Private Sub IMA_IN_vb_ValueChanged(sender As Object, e As VariableEventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Dim variable As Variable = CType(sender, Variable)
				If Me.dgv_din_IMA.Visible Then
					Dim num As Integer = Me.dgv_din_IMA.RowCount - 1
					For i As Integer = 0 To num
						Dim num2 As Double = Conversions.ToDouble(variable.Value(i).ToString())
						Me.dgv_din_IMA(1, i).Value = num2
					Next
				End If
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Exclamation, "IMA_IN_vb_ValueChanged")
			End Try
		End Sub

		' Token: 0x0600004D RID: 77 RVA: 0x00005DC4 File Offset: 0x00003FC4
		Private Sub IMA_OUT_vb_ValueChanged(sender As Object, e As VariableEventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Dim variable As Variable = CType(sender, Variable)
				If Me.dgv_dout_IMA.Visible Then
					Dim num As Integer = Me.dgv_dout_IMA.RowCount - 1
					For i As Integer = 0 To num
						Dim num2 As Integer = Conversions.ToInteger(variable.Value(i).ToString())
						Me.dgv_dout_IMA(1, i).Value = num2
					Next
				End If
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Exclamation, "IMA_OUT_vb_ValueChanged")
			End Try
		End Sub

		' Token: 0x0600004E RID: 78 RVA: 0x00005E7C File Offset: 0x0000407C
		Private Sub Prog_Code_ValueChanged(sender As Object, e As VariableEventArgs)
			Try
				Dim variable As Variable = CType(sender, Variable)
				Me.Progr_Code_vb = variable.Value.ToString()
				Me.lbl_debug_01.Text = Me.Progr_Code_vb
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Exclamation, "Progr_Code_ValueChanged")
			End Try
		End Sub

		' Token: 0x0600004F RID: 79 RVA: 0x00005F00 File Offset: 0x00004100
		Private Sub Terminal_ErrCode_ValueChanged(sender As Object, e As VariableEventArgs)
			Try
				Dim variable As Variable = CType(sender, Variable)
				Me.Terminal_ErrCode_vb = Conversions.ToInteger(variable.Value.ToString())
				Me.VisWarning()
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Exclamation, "Terminal_ErrCode_ValueChanged")
			End Try
		End Sub

		' Token: 0x06000050 RID: 80 RVA: 0x00005F7C File Offset: 0x0000417C
		Private Sub LoadTape_ValueChanged(sender As Object, e As VariableEventArgs)
			Try
				Dim variable As Variable = CType(sender, Variable)
				Me.LoadTape_vb.DI_Barrier = Conversions.ToBoolean(variable.Value("DI_Barrier").ToString())
				Me.LoadTape_vb.DI_Confirm_Btn = Conversions.ToBoolean(variable.Value("DI_Confirm_Btn").ToString())
				Me.LoadTape_vb.DI_DoorIN_close = Conversions.ToBoolean(variable.Value("DI_DoorIN_close").ToString())
				Me.LoadTape_vb.DI_DoorIN_open = Conversions.ToBoolean(variable.Value("DI_DoorIN_open").ToString())
				Me.LoadTape_vb.DI_DoorOUT_close = Conversions.ToBoolean(variable.Value("DI_DoorOUT_close").ToString())
				Me.LoadTape_vb.DI_DoorOUT_open = Conversions.ToBoolean(variable.Value("DI_DoorOUT_open").ToString())
				Me.LoadTape_vb.DI_Emerg_Btn = Conversions.ToBoolean(variable.Value("DI_Emerg_Btn").ToString())
				Me.LoadTape_vb.DI_Presence_end = Conversions.ToBoolean(variable.Value("DI_Presence_end").ToString())
				Me.LoadTape_vb.DI_Presence_start = Conversions.ToBoolean(variable.Value("DI_Presence_start").ToString())
				Me.LoadTape_vb.DO_Confirm_Lamp = Conversions.ToBoolean(variable.Value("DO_Confirm_Lamp").ToString())
				Me.LoadTape_vb.DO_DoorIN_close = Conversions.ToBoolean(variable.Value("DO_DoorIN_close").ToString())
				Me.LoadTape_vb.DO_DoorIN_open = Conversions.ToBoolean(variable.Value("DO_DoorIN_open").ToString())
				Me.LoadTape_vb.DO_DoorIN_Open_Lamp = Conversions.ToBoolean(variable.Value("DO_DoorIN_Open_Lamp").ToString())
				Me.LoadTape_vb.DO_DoorOUT_close = Conversions.ToBoolean(variable.Value("DO_DoorOUT_close").ToString())
				Me.LoadTape_vb.DO_DoorOUT_open = Conversions.ToBoolean(variable.Value("DO_DoorOUT_open").ToString())
				Me.LoadTape_vb.DO_DoorOUT_Open_Lamp = Conversions.ToBoolean(variable.Value("DO_DoorOUT_Open_Lamp").ToString())
				Me.LoadTape_vb.DO_Doors_Locked = Conversions.ToBoolean(variable.Value("DO_Doors_Locked").ToString())
				Me.VisActPieceCode()
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Exclamation, "reset_error_vb_ValueChanged")
			End Try
		End Sub

		' Token: 0x06000051 RID: 81 RVA: 0x00006264 File Offset: 0x00004464
		Private Sub OvenTape_ValueChanged(sender As Object, e As VariableEventArgs)
			Try
				Dim variable As Variable = CType(sender, Variable)
				Me.OvenTape_vb.DI_Barrier = Conversions.ToBoolean(variable.Value("DI_Barrier").ToString())
				Me.OvenTape_vb.DI_Confirm_Btn = Conversions.ToBoolean(variable.Value("DI_Confirm_Btn").ToString())
				Me.OvenTape_vb.DI_DoorIN_close = Conversions.ToBoolean(variable.Value("DI_DoorIN_close").ToString())
				Me.OvenTape_vb.DI_DoorIN_open = Conversions.ToBoolean(variable.Value("DI_DoorIN_open").ToString())
				Me.OvenTape_vb.DI_DoorOUT_close = Conversions.ToBoolean(variable.Value("DI_DoorOUT_close").ToString())
				Me.OvenTape_vb.DI_DoorOUT_open = Conversions.ToBoolean(variable.Value("DI_DoorOUT_open").ToString())
				Me.OvenTape_vb.DI_Emerg_Btn = Conversions.ToBoolean(variable.Value("DI_Emerg_Btn").ToString())
				Me.OvenTape_vb.DI_Presence_end = Conversions.ToBoolean(variable.Value("DI_Presence_end").ToString())
				Me.OvenTape_vb.DI_Presence_start = Conversions.ToBoolean(variable.Value("DI_Presence_start").ToString())
				Me.OvenTape_vb.DO_Confirm_Lamp = Conversions.ToBoolean(variable.Value("DO_Confirm_Lamp").ToString())
				Me.OvenTape_vb.DO_DoorIN_close = Conversions.ToBoolean(variable.Value("DO_DoorIN_close").ToString())
				Me.OvenTape_vb.DO_DoorIN_open = Conversions.ToBoolean(variable.Value("DO_DoorIN_open").ToString())
				Me.OvenTape_vb.DO_DoorIN_Open_Lamp = Conversions.ToBoolean(variable.Value("DO_DoorIN_Open_Lamp").ToString())
				Me.OvenTape_vb.DO_DoorOUT_close = Conversions.ToBoolean(variable.Value("DO_DoorOUT_close").ToString())
				Me.OvenTape_vb.DO_DoorOUT_open = Conversions.ToBoolean(variable.Value("DO_DoorOUT_open").ToString())
				Me.OvenTape_vb.DO_DoorOUT_Open_Lamp = Conversions.ToBoolean(variable.Value("DO_DoorOUT_Open_Lamp").ToString())
				Me.OvenTape_vb.DO_Doors_Locked = Conversions.ToBoolean(variable.Value("DO_Doors_Locked").ToString())
				Me.OvenTape_vb.Prog_Code = variable.Value("Prog_Code").ToString()
				Me.VisActPieceCode()
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Exclamation, "reset_error_vb_ValueChanged")
			End Try
		End Sub

		' Token: 0x06000052 RID: 82 RVA: 0x0000656C File Offset: 0x0000476C
		Private Sub PaintTape_ValueChanged(sender As Object, e As VariableEventArgs)
			Try
				Dim variable As Variable = CType(sender, Variable)
				Me.PaintTape_vb.DI_Barrier = Conversions.ToBoolean(variable.Value("DI_Barrier").ToString())
				Me.PaintTape_vb.DI_Confirm_Btn = Conversions.ToBoolean(variable.Value("DI_Confirm_Btn").ToString())
				Me.PaintTape_vb.DI_DoorIN_close = Conversions.ToBoolean(variable.Value("DI_DoorIN_close").ToString())
				Me.PaintTape_vb.DI_DoorIN_open = Conversions.ToBoolean(variable.Value("DI_DoorIN_open").ToString())
				Me.PaintTape_vb.DI_DoorOUT_close = Conversions.ToBoolean(variable.Value("DI_DoorOUT_close").ToString())
				Me.PaintTape_vb.DI_DoorOUT_open = Conversions.ToBoolean(variable.Value("DI_DoorOUT_open").ToString())
				Me.PaintTape_vb.DI_Emerg_Btn = Conversions.ToBoolean(variable.Value("DI_Emerg_Btn").ToString())
				Me.PaintTape_vb.DI_Presence_end = Conversions.ToBoolean(variable.Value("DI_Presence_end").ToString())
				Me.PaintTape_vb.DI_Presence_start = Conversions.ToBoolean(variable.Value("DI_Presence_start").ToString())
				Me.PaintTape_vb.DO_Confirm_Lamp = Conversions.ToBoolean(variable.Value("DO_Confirm_Lamp").ToString())
				Me.PaintTape_vb.DO_DoorIN_close = Conversions.ToBoolean(variable.Value("DO_DoorIN_close").ToString())
				Me.PaintTape_vb.DO_DoorIN_open = Conversions.ToBoolean(variable.Value("DO_DoorIN_open").ToString())
				Me.PaintTape_vb.DO_DoorIN_Open_Lamp = Conversions.ToBoolean(variable.Value("DO_DoorIN_Open_Lamp").ToString())
				Me.PaintTape_vb.DO_DoorOUT_close = Conversions.ToBoolean(variable.Value("DO_DoorOUT_close").ToString())
				Me.PaintTape_vb.DO_DoorOUT_open = Conversions.ToBoolean(variable.Value("DO_DoorOUT_open").ToString())
				Me.PaintTape_vb.DO_DoorOUT_Open_Lamp = Conversions.ToBoolean(variable.Value("DO_DoorOUT_Open_Lamp").ToString())
				Me.PaintTape_vb.DO_Doors_Locked = Conversions.ToBoolean(variable.Value("DO_Doors_Locked").ToString())
				Me.PaintTape_vb.Prog_Code = variable.Value("Prog_Code").ToString()
				Me.VisActPieceCode()
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Exclamation, "reset_error_vb_ValueChanged")
			End Try
		End Sub

		' Token: 0x06000053 RID: 83 RVA: 0x00006874 File Offset: 0x00004A74
		Private Sub UnloadTape_ValueChanged(sender As Object, e As VariableEventArgs)
			Try
				Dim variable As Variable = CType(sender, Variable)
				Me.UnloadTape_vb.DI_Barrier = Conversions.ToBoolean(variable.Value("DI_Barrier").ToString())
				Me.UnloadTape_vb.DI_Confirm_Btn = Conversions.ToBoolean(variable.Value("DI_Confirm_Btn").ToString())
				Me.UnloadTape_vb.DI_DoorIN_close = Conversions.ToBoolean(variable.Value("DI_DoorIN_close").ToString())
				Me.UnloadTape_vb.DI_DoorIN_open = Conversions.ToBoolean(variable.Value("DI_DoorIN_open").ToString())
				Me.UnloadTape_vb.DI_DoorOUT_close = Conversions.ToBoolean(variable.Value("DI_DoorOUT_close").ToString())
				Me.UnloadTape_vb.DI_DoorOUT_open = Conversions.ToBoolean(variable.Value("DI_DoorOUT_open").ToString())
				Me.UnloadTape_vb.DI_Emerg_Btn = Conversions.ToBoolean(variable.Value("DI_Emerg_Btn").ToString())
				Me.UnloadTape_vb.DI_Presence_end = Conversions.ToBoolean(variable.Value("DI_Presence_end").ToString())
				Me.UnloadTape_vb.DI_Presence_start = Conversions.ToBoolean(variable.Value("DI_Presence_start").ToString())
				Me.UnloadTape_vb.DO_Confirm_Lamp = Conversions.ToBoolean(variable.Value("DO_Confirm_Lamp").ToString())
				Me.UnloadTape_vb.DO_DoorIN_close = Conversions.ToBoolean(variable.Value("DO_DoorIN_close").ToString())
				Me.UnloadTape_vb.DO_DoorIN_open = Conversions.ToBoolean(variable.Value("DO_DoorIN_open").ToString())
				Me.UnloadTape_vb.DO_DoorIN_Open_Lamp = Conversions.ToBoolean(variable.Value("DO_DoorIN_Open_Lamp").ToString())
				Me.UnloadTape_vb.DO_DoorOUT_close = Conversions.ToBoolean(variable.Value("DO_DoorOUT_close").ToString())
				Me.UnloadTape_vb.DO_DoorOUT_open = Conversions.ToBoolean(variable.Value("DO_DoorOUT_open").ToString())
				Me.UnloadTape_vb.DO_DoorOUT_Open_Lamp = Conversions.ToBoolean(variable.Value("DO_DoorOUT_Open_Lamp").ToString())
				Me.UnloadTape_vb.DO_Doors_Locked = Conversions.ToBoolean(variable.Value("DO_Doors_Locked").ToString())
				Me.UnloadTape_vb.Prog_Code = variable.Value("Prog_Code").ToString()
				Me.VisActPieceCode()
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Exclamation, "reset_error_vb_ValueChanged")
			End Try
		End Sub

		' Token: 0x06000054 RID: 84 RVA: 0x00006B7C File Offset: 0x00004D7C
		Private Sub reset_error_vb_ValueChanged(sender As Object, e As VariableEventArgs)
			Try
				If Conversions.ToBoolean(CType(sender, Variable).Value.ToString()) Then
					Me.clear_error_vb()
				End If
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Exclamation, "reset_error_vb_ValueChanged")
			End Try
		End Sub

		' Token: 0x06000055 RID: 85 RVA: 0x00006BF4 File Offset: 0x00004DF4
		Private Sub waiting_resume_vb_ValueChanged(sender As Object, e As VariableEventArgs)
			Try
				If Conversions.ToBoolean(CType(sender, Variable).Value.ToString()) Then
					Me.lbl_waiting_resume.Visible = True
					Me.lbl_waiting_resume.Text = Me.cma_labels(482)
					Me.lbl_waiting_resume.BackColor = Color.Red
				Else
					Me.lbl_waiting_resume.Visible = False
				End If
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Exclamation, "waiting_resume_vb_ValueChanged")
			End Try
		End Sub

		' Token: 0x06000056 RID: 86 RVA: 0x00006CA4 File Offset: 0x00004EA4
		Private Sub DO_AUTO_Lamp_ValueChanged(sender As Object, e As VariableEventArgs)
			Try
				Dim variable As Variable = CType(sender, Variable)
				Me.Terminal_ErrCode_vb = Conversions.ToInteger(variable.Value.ToString())
				Me.VisWarning()
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Exclamation, "Terminal_ErrCode_ValueChanged")
			End Try
		End Sub

		' Token: 0x06000057 RID: 87 RVA: 0x00006D20 File Offset: 0x00004F20
		Private Sub clk_oven_ValueChanged(sender As Object, e As VariableEventArgs)
			Try
				Dim variable As Variable = CType(sender, Variable)
				Me.clk_oven_VB = Conversions.ToInteger(variable.Value.ToString())
				Me.Vis_Timeout_Oven()
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Exclamation, "clk_oven_ValueChanged")
			End Try
		End Sub

		' Token: 0x06000058 RID: 88 RVA: 0x00006D9C File Offset: 0x00004F9C
		Private Sub flag_force_unload_ValueChanged(sender As Object, e As VariableEventArgs)
			Try
				Dim variable As Variable = CType(sender, Variable)
				Me.flag_force_unload_vb = Conversions.ToInteger(variable.Value.ToString())
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Exclamation, "flag_force_unload_ValueChanged")
			Catch ex As System.Exception
			End Try
		End Sub

		' Token: 0x06000059 RID: 89 RVA: 0x00006E14 File Offset: 0x00005014
		Private Sub cmd_str_oven_t_ValueChanged(sender As Object, e As VariableEventArgs)
			Try
				Dim variable As Variable = CType(sender, Variable)
				Me.cmd_str_oven_t_vb = Conversions.ToBoolean(variable.Value.ToString())
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Exclamation, "cmd_str_oven_t_ValueChanged")
			End Try
		End Sub

		' Token: 0x0600005A RID: 90 RVA: 0x00006E8C File Offset: 0x0000508C
		Private Sub dgvPrjDwgs_CellMouseEnter(sender As Object, e As DataGridViewCellEventArgs)
			Try
				If Not Me.psw_popup Then
					Me.dgv_ax.EndEdit()
					Interaction.MsgBox(Me.StrLabels(505), MsgBoxStyle.OkOnly, Nothing)
				ElseIf e.RowIndex > -1 Then
					Me.TmrChekbox.Interval = 500
					Me.TmrChekbox.Start()
					Me.dgv_ax.DefaultCellStyle.SelectionBackColor = Color.Red
					Application.DoEvents()
					Application.DoEvents()
					Me.dgv_ax.Refresh()
					Me.dgv_ax.BringToFront()
				End If
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x0600005B RID: 91 RVA: 0x00006F64 File Offset: 0x00005164
		Private Sub TmrChekbox_Tick(sender As Object, e As EventArgs)
			Try
				Me.TmrChekbox.[Stop]()
				Application.DoEvents()
				Application.DoEvents()
				Me.dgv_ax.Refresh()
				Me.dgv_ax.EndEdit()
				If Me.pvi_ok Then
					' The following expression was wrapped in a checked-expression
					Dim num As Short = CShort((Me.dgv_ax.RowCount - 1))
					For num2 As Short = 0S To num
						If Conversions.ToBoolean(Me.dgv_ax.Rows(CInt(num2)).Cells(7).Value) Then
							Me.man_ax.Value(CInt(num2)) = New Value(1)
						Else
							Me.man_ax.Value(CInt(num2)) = New Value(0)
						End If
					Next
				End If
				Me.TmrChekbox.[Stop]()
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x0600005C RID: 92 RVA: 0x0000706C File Offset: 0x0000526C
		Private Sub LoadPar()
			Try
				Me.LoadingPar = True
				Using streamReader As StreamReader = New StreamReader(Path.DATA_PATH + "PAR.txt")
					While streamReader.Peek() >= 0
						Dim array As String() = Strings.Split(streamReader.ReadLine(), "|", -1, CompareMethod.Binary)
						Dim value As ListViewItem = New ListViewItem(array)
						If Operators.CompareString(array(0), "Lng", False) = 0 Then
							Me.Lng = array(1)
						Else
							Me.lvw_par.Items.Add(value)
						End If
					End While
				End Using
				Me.par_en_remote_programlist = Conversions.ToBoolean(Me.lvw_par.Items(53).SubItems(2).Text)
				Me.par_en_remote_path = Conversions.ToBoolean(Me.lvw_par.Items(54).SubItems(2).Text)
				Me.par_en_oven_door = Conversions.ToBoolean(Me.lvw_par.Items(36).SubItems(2).Text)
				If Me.par_en_remote_path And Me.par_en_remote_programlist Then
					Me.Grp_stats.Enabled = True
				Else
					Me.Grp_stats.Enabled = False
				End If
				If Me.par_en_oven_door Then
					Me.Pic_Oven_doorIN_close.Visible = True
					Me.Pic_Oven_doorIN_open.Visible = True
				Else
					Me.Pic_Oven_doorIN_close.Visible = False
					Me.Pic_Oven_doorIN_open.Visible = False
				End If
			Catch ex As System.Exception
				Interaction.MsgBox("LoadPar : " + ex.Message, MsgBoxStyle.Critical, Nothing)
			Finally
				Me.LoadingPar = False
			End Try
		End Sub

		' Token: 0x0600005D RID: 93 RVA: 0x0000727C File Offset: 0x0000547C
		Private Sub SavePar()
			Try
				Using streamWriter As StreamWriter = New StreamWriter(Path.DATA_PATH + "PAR.txt")
					Dim num2 As Integer = Me.lvw_par.Items.Count - 1
					For i As Integer = 0 To num2
						streamWriter.WriteLine(String.Concat(New String() {Me.lvw_par.Items(i).SubItems(0).Text, "|", Me.lvw_par.Items(i).SubItems(1).Text, "|", Me.lvw_par.Items(i).SubItems(2).Text}))
					Next
					streamWriter.WriteLine("Lng|" + Me.Lng)
				End Using
			Catch ex As System.Exception
				Interaction.MsgBox("SavePar : " + ex.Message, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x0600005E RID: 94 RVA: 0x00007418 File Offset: 0x00005618
		Private Sub btn_par_edit_Click(sender As Object, e As EventArgs)
			If Me.lvw_par.SelectedIndices.Count > 0 Then
				Dim index As Integer = Me.lvw_par.SelectedIndices(0)
				Dim frmTouchNum As frmTouchNum = New frmTouchNum()
				frmTouchNum.ShowDialog()
				If frmTouchNum.responce Then
					Me.lvw_par.Items(index).SubItems(2).Text = frmTouchNum.value
					Me.SavePar()
					Me.download_par()
				End If
			End If
		End Sub

		' Token: 0x0600005F RID: 95 RVA: 0x00007494 File Offset: 0x00005694
		Private Sub btn_mod_par_Click(sender As Object, e As EventArgs)
			If Me.lvw_par.SelectedIndices.Count > 0 Then
				Dim index As Integer = Me.lvw_par.SelectedIndices(0)
				Dim frmTouchNum As frmTouchNum = New frmTouchNum()
				frmTouchNum.ShowDialog()
				If frmTouchNum.responce Then
					Me.lvw_par.Items(index).SubItems(2).Text = frmTouchNum.value
					Me.SavePar()
					Me.download_par()
				End If
			End If
		End Sub

		' Token: 0x06000060 RID: 96 RVA: 0x00007510 File Offset: 0x00005710
		Private Sub download_par()
			Dim i As Integer = 0
			Try
				If Me.pvi_ok Then
					Dim num As Integer = Me.lvw_par.Items.Count - 1
					i = 0
					While i <= num
						Dim value As Single
						Try
							value = Conversions.ToSingle(Me.lvw_par.Items(i).SubItems(2).Text)
						Catch ex As System.Exception
							value = 0F
						End Try
						Me.par_VB.Value(i) = New Value(value)
						i += 1
					End While
					Me.par_VB.WriteValue()
				End If
			Catch ex2 As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x06000061 RID: 97 RVA: 0x00007600 File Offset: 0x00005800
		Private Sub lvw_par_SelectedIndexChanged(sender As Object, e As EventArgs)
			If Not Me.psw_popup Then
				Interaction.MsgBox(Me.StrLabels(505), MsgBoxStyle.OkOnly, Nothing)
			End If
		End Sub

		' Token: 0x06000062 RID: 98 RVA: 0x00007620 File Offset: 0x00005820
		Private Sub btn_super_psw_Click(sender As Object, e As EventArgs)
			Try
				Dim frmTouchKey As frmTouchKey = New frmTouchKey()
				frmTouchKey.UcTouchKey.InsertPassword = True
				frmTouchKey.ShowDialog()
				If frmTouchKey.Responce Then
					If Operators.CompareString(frmTouchKey.KeyText, "CMAH123", False) = 0 Then
						Me.enable_super_psw_cmds()
					Else
						Interaction.MsgBox(Me.StrLabels(506), MsgBoxStyle.Exclamation, Nothing)
					End If
				End If
			Catch ex As System.Exception
				Interaction.MsgBox("btn_super_psw_Click() : " + ex.Message, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x06000063 RID: 99 RVA: 0x00007700 File Offset: 0x00005900
		Private Sub LoadDI()
			Try
				Dim text As String = Path.DATA_PATH + "DI - " + Me.Lng + ".txt"
				If Not New FileInfo(text).Exists Then
					Interaction.MsgBox("DI file not found. Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
					text = Path.DATA_PATH + "DI - ITA.txt"
				End If
				Dim i As Integer = 0
				Using streamReader As StreamReader = New StreamReader(text)
					While streamReader.Peek() >= 0
						Dim array As String() = Strings.Split(streamReader.ReadLine(), "|", -1, CompareMethod.Binary)
						Me.di_string(i) = array(1)
						i += 1
					End While
				End Using
			Catch ex As System.Exception
				Interaction.MsgBox(ex.Message + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x06000064 RID: 100 RVA: 0x00007834 File Offset: 0x00005A34
		Private Sub LoadDO()
			Try
				Dim text As String = Path.DATA_PATH + "DO - " + Me.Lng + ".txt"
				If Not New FileInfo(text).Exists Then
					Interaction.MsgBox("DO file not found. Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
					text = Path.DATA_PATH + "DO - ITA.txt"
				End If
				Dim i As Integer = 0
				Using streamReader As StreamReader = New StreamReader(text)
					While streamReader.Peek() >= 0
						Dim array As String() = Strings.Split(streamReader.ReadLine(), "|", -1, CompareMethod.Binary)
						Me.do_string(i) = array(1)
						i += 1
					End While
				End Using
			Catch ex As System.Exception
				Interaction.MsgBox(ex.Message + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x06000065 RID: 101 RVA: 0x00007968 File Offset: 0x00005B68
		Private Sub InitDiagIO()
			Me.LoadDI()
			Me.LoadDO()
			Me.dgv_din.RowCount = Me.idx_DIG_IN
			Dim num As Integer = Me.idx_DIG_IN - 1
			For i As Integer = 0 To num
				Me.dgv_din(0, i).Value = Me.il_led.Images(1)
				Me.dgv_din(1, i).Value = Strings.Format(i, "00") + " - " + Me.di_string(i)
			Next
			Me.dgv_dout.RowCount = Me.idx_DIG_OUT
			Me.dgv_dout.Columns(1).Visible = False
			Dim num2 As Integer = Me.idx_DIG_OUT - 1
			For j As Integer = 0 To num2
				Me.dgv_dout(0, j).Value = Me.il_led.Images(3)
				Me.dgv_dout(2, j).Value = Strings.Format(j, "00") + " - " + Me.do_string(j)
			Next
			Me.dgv_din_IMA.RowCount = 40
			Dim num3 As Integer = Me.dgv_din_IMA.RowCount - 1
			For k As Integer = 0 To num3
				Me.dgv_din_IMA(0, k).Value = Strings.Format(k, "00") + " - " + Me.di_string(k + Me.idx_DIG_IN)
				Me.dgv_din_IMA(1, k).Value = 0
			Next
			Me.dgv_dout_IMA.RowCount = 30
			Dim num4 As Integer = Me.dgv_dout_IMA.RowCount - 1
			For l As Integer = 0 To num4
				Me.dgv_dout_IMA(0, l).Value = Strings.Format(l, "00") + " - " + Me.do_string(l + Me.idx_DIG_OUT)
				Me.dgv_dout_IMA(1, l).Value = 0
			Next
			Me.dgv_ax.RowCount = 13
			Me.dgv_ax(0, 0).Value = Me.cma_labels(90).ToString()
			Me.dgv_ax(0, 1).Value = Me.cma_labels(91).ToString()
			Me.dgv_ax(0, 2).Value = Me.cma_labels(92).ToString()
			Me.dgv_ax(0, 3).Value = Me.cma_labels(93).ToString()
			Dim num5 As Integer = 0
			Do
				num5 += 1
			Loop While num5 <= 3
			Me.InitMaster()
		End Sub

		' Token: 0x06000066 RID: 102 RVA: 0x00007C3C File Offset: 0x00005E3C
		Private Sub btn_force_Click(sender As Object, e As EventArgs)
			Try
				Me.dgv_dout_IMA.[ReadOnly] = Not Me.dgv_dout_IMA.[ReadOnly]
				Me.dgv_dout.Columns(1).Visible = Not Me.dgv_dout.Columns(1).Visible
				If Me.pvi_ok Then
					Me.force_out.Value = New Value(Me.dgv_dout.Columns(1).Visible)
				End If
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x06000067 RID: 103 RVA: 0x00007D08 File Offset: 0x00005F08
		Private Sub dgv_dout_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
			If TypeOf CType(sender, DataGridView).Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso Me.pvi_ok Then
				Dim flag As Boolean = Conversions.ToBoolean(Me.DOut.Value(e.RowIndex).ToString())
				Me.FDOut.Value(e.RowIndex) = New Value(Not flag)
			End If
		End Sub

		' Token: 0x06000068 RID: 104 RVA: 0x00007D7C File Offset: 0x00005F7C
		Private Sub dgv_dout_IMA_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs)
			Try
				If Not Me.dgv_dout_IMA.[ReadOnly] Then
					' The following expression was wrapped in a checked-expression
					Dim num As Integer = Me.dgv_dout_IMA.RowCount - 1
					Dim num2 As Integer = 0
					Dim num3 As Integer
					If num2 <= num Then
						Conversions.ToInteger(Me.dgv_dout_IMA.SelectedCells(num2).RowIndex.ToString())
						num3 = Conversions.ToInteger(Me.dgv_dout_IMA.SelectedCells(num2).RowIndex.ToString())
					End If
					If Me.pvi_ok Then
						Me.IMA_OUT_vb.Value(num3) = New Value(RuntimeHelpers.GetObjectValue(Me.dgv_dout_IMA(1, num3).Value))
					End If
				End If
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x06000069 RID: 105 RVA: 0x00007E78 File Offset: 0x00006078
		Private Sub InitMaster()
			Me.dgv_master.RowCount = 4
			Me.dgv_master(0, 0).Value = Me.cma_labels(90).ToString()
			Me.dgv_master(0, 1).Value = Me.cma_labels(91).ToString()
			Me.dgv_master(0, 2).Value = Me.cma_labels(92).ToString()
			Me.dgv_master(0, 3).Value = Me.cma_labels(93).ToString()
			Me.dgv_ciclica.RowCount = 4
			Me.dgv_ciclica(0, 0).Value = Me.cma_labels(98)
			Me.dgv_ciclica(0, 1).Value = Me.cma_labels(99)
			Me.dgv_ciclica(0, 2).Value = Me.cma_labels(100)
			Me.dgv_ciclica(0, 3).Value = Me.cma_labels(101)
		End Sub

		' Token: 0x0600006A RID: 106 RVA: 0x00007F8C File Offset: 0x0000618C
		Private Sub dgv_master_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
			If TypeOf CType(sender, DataGridView).Columns(e.ColumnIndex) Is DataGridViewButtonColumn Then
				' The following expression was wrapped in a checked-expression
				Dim value As Integer = e.RowIndex + 1
				If Me.pvi_ok Then
					Me.cmd_master.Value = New Value(value)
				End If
			End If
		End Sub

		' Token: 0x0600006B RID: 107 RVA: 0x00007FD8 File Offset: 0x000061D8
		Private Sub stato_ciclica_ValueChanged(sender As Object, e As VariableEventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Dim variable As Variable = CType(sender, Variable)
				Dim num As Integer = Me.dgv_ciclica.RowCount - 1
				For i As Integer = 0 To num
					Me.vis_stato_ciclica(i) = Conversions.ToInteger(variable.Value(i).ToString())
					Me.dgv_ciclica(1, i).Value = Me.vis_stato_ciclica(i)
				Next
			Catch ex As System.Exception
				Me.add_log(-1, 100, Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name)
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x0600006C RID: 108 RVA: 0x000080B4 File Offset: 0x000062B4
		Private Sub btn_reset_cyc_Click(sender As Object, e As EventArgs)
			If Interaction.MsgBox(Me.StrLabels(507), MsgBoxStyle.YesNo Or MsgBoxStyle.Critical, Nothing) = MsgBoxResult.Yes Then
				If Me.pvi_ok Then
					Me.reset_auto.Value = New Value(True)
				End If
				Me.add_log(-1, 200, "Reset by Operator on VB")
			End If
		End Sub

		' Token: 0x0600006D RID: 109 RVA: 0x00008104 File Offset: 0x00006304
		Public Sub abs_enc_ValueRead(sender As Object, e As PviEventArgs)
			Try
				Dim variable As Variable = CType(sender, Variable)
				Dim num2 As Integer = 0
				Do
					Me.abs_encoder(num2).master_ok = Conversions.ToBoolean(variable.Value("abs_enc[" + Conversions.ToString(num2) + "].master_ok").ToString())
					Me.abs_encoder(num2).offset = Conversions.ToInteger(variable.Value("abs_enc[" + Conversions.ToString(num2) + "].offset").ToString())
					Me.abs_encoder(num2).n_overflow = Conversions.ToInteger(variable.Value("abs_enc[" + Conversions.ToString(num2) + "].n_overflow").ToString())
					Me.abs_encoder(num2).n_mod_overflow = Conversions.ToInteger(variable.Value("abs_enc[" + Conversions.ToString(num2) + "].n_mod_overflow").ToString())
					Me.abs_encoder(num2).rest = Conversions.ToSingle(variable.Value("abs_enc[" + Conversions.ToString(num2) + "].rest").ToString())
					Me.abs_encoder(num2).actual_pos = Conversions.ToInteger(variable.Value("abs_enc[" + Conversions.ToString(num2) + "].actual_pos").ToString())
					If Conversions.ToBoolean(variable.Value("abs_enc[" + Conversions.ToString(num2) + "].master_ok").ToString()) Then
						Me.master_data(num2) = Conversions.ToInteger(variable.Value("abs_enc[" + Conversions.ToString(num2) + "].offset").ToString())
					Else
						Me.master_data(num2) = 0
					End If
					num2 += 1
				Loop While num2 <= 31
				Me.write_master_data_file()
			Catch ex As System.Exception
				Interaction.MsgBox("abs_enc_ValueRead() : " + ex.Message, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x0600006E RID: 110 RVA: 0x00008384 File Offset: 0x00006584
		Public Sub StartListeningR1()
			Me.ServerPortR1 = 13000
			Dim iphostEntry As IPHostEntry = Dns.Resolve(Dns.GetHostName())
			Dim num As Short = -1S
			Me.FindCorrectIp(num, iphostEntry)
			If num = -1S Then
				Me.R1_Connected = 0
				num = 0S
			End If
			Dim address As IPAddress = iphostEntry.AddressList(CInt(num))
			Dim localEP As IPEndPoint = New IPEndPoint(address, Me.ServerPortR1)
			Dim socket As Socket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
			Me.ServerR1 = socket
			Try
				socket.Bind(localEP)
				socket.Listen(100)
				Me.R1_Connected = 1
				socket.BeginAccept(AddressOf Me.AcceptCallbackR1, socket)
			Catch ex As System.Exception
				Interaction.MsgBox("StartListeningR1() : " + Information.Err().Description, MsgBoxStyle.Critical, "CMA Robotics")
			End Try
		End Sub

		' Token: 0x0600006F RID: 111 RVA: 0x00008458 File Offset: 0x00006658
		Public Sub AcceptCallbackR1(ar As IAsyncResult)
			Dim socket As Socket = CType(ar.AsyncState, Socket)
			Dim socket2 As Socket = socket.EndAccept(ar)
			Try
				Me.ServerR1 = socket
				Me.ClientR1 = socket2
				Dim stateObject As FormPrincipale.StateObject = New FormPrincipale.StateObject()
				stateObject.workSocket = socket2
				socket2.BeginReceive(stateObject.buffer, 0, stateObject.BufferSize, SocketFlags.None, AddressOf Me.ReadCallbackR1, stateObject)
				Me.lbl_com_TCPIP_r1.BackColor = Color.Lime
				Me.R1_Connected = 2
				Dim text As String = "<15>"
				Me.send_stringa(text)
			Catch ex As System.Exception
				Interaction.MsgBox("AcceptCallbackR1: " + Information.Err().Description, MsgBoxStyle.Critical, "CMA Robotics")
			End Try
		End Sub

		' Token: 0x06000070 RID: 112 RVA: 0x00008520 File Offset: 0x00006720
		Public Sub ReadCallbackR1(ar As IAsyncResult)
			Try
				Dim stateObject As FormPrincipale.StateObject = CType(ar.AsyncState, FormPrincipale.StateObject)
				Dim workSocket As Socket = stateObject.workSocket
				Dim num As Integer = workSocket.EndReceive(ar)
				If num > 0 Then
					stateObject.sb.Append(Encoding.ASCII.GetString(stateObject.buffer, 0, num))
					Dim text As String = stateObject.sb.ToString()
					Dim text2 As String = Strings.Left(text, 4)
					If Operators.CompareString(text2, "<15&", False) = 0 Then
						' The following expression was wrapped in a checked-expression
						text2 = Strings.Right(text, text.Length - 4)
						text2 = text2
						Me.read_stringa(text2)
					End If
					stateObject.sb.Length = 0
					If Me.send_active(0) Then
						Me.send_res(0) = text
						Me.R1_rec_string = text
					End If
					If Me.check_active(0) Then
						Me.check_active(0) = False
						Me.R1_rec_string = text
					End If
					workSocket.BeginReceive(stateObject.buffer, 0, stateObject.BufferSize, SocketFlags.None, AddressOf Me.ReadCallbackR1, stateObject)
				Else
					If workSocket.Connected Then
						Me.ClientR1.Shutdown(SocketShutdown.Both)
						Me.ClientR1.Close()
						Me.ClientR1 = Nothing
						Me.ServerR1.BeginAccept(AddressOf Me.AcceptCallbackR1, Me.ServerR1)
					End If
					Me.R1_Connected = 3
				End If
			Catch ex As SocketException
				Interaction.MsgBox("ReadCallbackR1 SocketException(): " + Information.Err().Description, MsgBoxStyle.Critical, "CMA Robotics")
				Me.ClientR1.Shutdown(SocketShutdown.Both)
				Me.ClientR1.Close()
				Me.ClientR1 = Nothing
				Me.R1_Connected = 3
				Me.ServerR1.BeginAccept(AddressOf Me.AcceptCallbackR1, Me.ServerR1)
			Catch ex2 As System.Exception
				Interaction.MsgBox("ReadCallbackR1(): " + Information.Err().Description, MsgBoxStyle.Critical, "CMA Robotics")
				Me.ClientR1.Shutdown(SocketShutdown.Both)
				Me.ClientR1.Close()
				Me.ClientR1 = Nothing
				Me.R1_Connected = 3
				Me.ServerR1.BeginAccept(AddressOf Me.AcceptCallbackR1, Me.ServerR1)
			End Try
		End Sub

		' Token: 0x06000071 RID: 113 RVA: 0x00008778 File Offset: 0x00006978
		Private Sub btn_Send_tcpip_Click(sender As Object, e As EventArgs)
			If Me.R1_Connected = 2 Then
				Dim text As String = "<15>"
				Me.send_stringa(text)
				Return
			End If
			Me.Terminal_ErrCode_vb = 38
			Me.VisWarning()
		End Sub

		' Token: 0x06000072 RID: 114 RVA: 0x000087AC File Offset: 0x000069AC
		Private Sub send_stringa(ByRef send_string As String)
			Try
				Dim s As String = send_string
				Dim bytes As Byte() = Encoding.ASCII.GetBytes(s)
				Me.ClientR1.Send(bytes, bytes.Length, SocketFlags.None)
			Catch ex As System.Exception
				Interaction.MsgBox("send_stringa : " + ex.Message, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x06000073 RID: 115 RVA: 0x00008860 File Offset: 0x00006A60
		Private Sub read_stringa(rec_string As String)
			' The following expression was wrapped in a checked-statement
			Try
				rec_string = Strings.Left(rec_string, rec_string.Length - 1)
				Me.split_string = Strings.Split(rec_string, "&", -1, CompareMethod.Binary)
				Me.robot_program = New String(Me.split_string.Length - 1 + 1 - 1) {}
				Dim num As Integer = Me.split_string.Length - 1
				For i As Integer = 0 To num
					Me.robot_program(i) = Me.split_string(i)
				Next
			Catch ex As System.Exception
				Interaction.MsgBox("read_stringa: " + Information.Err().Description, MsgBoxStyle.Critical, "CMA Robotics")
			End Try
		End Sub

		' Token: 0x06000074 RID: 116 RVA: 0x00008910 File Offset: 0x00006B10
		Private Sub SendCallbackR1(ar As IAsyncResult)
			Try
				CType(ar.AsyncState, Socket).EndSend(ar)
			Catch ex As System.Exception
				Interaction.MsgBox("SendCallbackTerm() : " + Information.Err().Description, MsgBoxStyle.Critical, "CMA Robotics")
			End Try
		End Sub

		' Token: 0x06000075 RID: 117 RVA: 0x00008970 File Offset: 0x00006B70
		Private Sub FindCorrectIp(ByRef IpIdx As Short, ByRef ipHostInfo As IPHostEntry)
			Try
				IpIdx = -1S
				Dim num As Short = CShort((ipHostInfo.AddressList.Length - 1))
				For num2 As Short = 0S To num
					If ipHostInfo.AddressList(CInt(num2)).ToString().StartsWith(Me.IpServer) Then
						IpIdx = num2
						Exit For
					End If
				Next
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, "CMA Robotics")
			End Try
		End Sub

		' Token: 0x06000076 RID: 118 RVA: 0x00008A08 File Offset: 0x00006C08
		Private Sub write_master_data_file()
			' The following expression was wrapped in a checked-statement
			Try
				Dim streamWriter As StreamWriter = New StreamWriter(Path.DATA_PATH + "MASTER\MASTER.txt")
				streamWriter.WriteLine("#MASTER")
				Dim num As Integer = 0
				Do
					streamWriter.WriteLine(String.Concat(New String() {"AX", Conversions.ToString(num + 1), ":", Conversions.ToString(Me.abs_encoder(num).master_ok), ";", Conversions.ToString(Me.abs_encoder(num).offset), ";", Conversions.ToString(Me.abs_encoder(num).n_overflow), ";", Conversions.ToString(Me.abs_encoder(num).n_mod_overflow), ";", Conversions.ToString(Me.abs_encoder(num).rest), ";", Conversions.ToString(Me.abs_encoder(num).actual_pos)}))
					num += 1
				Loop While num <= 31
				streamWriter.Close()
				Interaction.MsgBox(Me.StrLabels(508), MsgBoxStyle.OkOnly, Nothing)
			Catch ex As System.Exception
				Interaction.MsgBox("write_master_data_file() : " + ex.Message, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x06000077 RID: 119 RVA: 0x00008B94 File Offset: 0x00006D94
		Private Sub write_enc_value()
			Try
				Dim num2 As Integer = 0
				Do
					Me.abs_enc.Value("[" + Conversions.ToString(num2) + "].offset") = Me.abs_encoder(num2).offset
					Me.abs_enc.Value("[" + Conversions.ToString(num2) + "].n_overflow") = Me.abs_encoder(num2).n_overflow
					Me.abs_enc.Value("[" + Conversions.ToString(num2) + "].n_mod_overflow") = Me.abs_encoder(num2).n_mod_overflow
					Me.abs_enc.Value("[" + Conversions.ToString(num2) + "].rest") = Me.abs_encoder(num2).rest
					Me.abs_enc.Value("[" + Conversions.ToString(num2) + "].actual_pos") = Me.abs_encoder(num2).actual_pos
					num2 += 1
				Loop While num2 <= 31
				Me.abs_enc.WriteValue()
			Catch ex As System.Exception
				Interaction.MsgBox("Write_enc_value() : " + ex.Message, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x06000078 RID: 120 RVA: 0x00008D70 File Offset: 0x00006F70
		Private Sub read_master_data_file()
			' The following expression was wrapped in a checked-statement
			Try
				Dim streamReader As StreamReader = New StreamReader(Path.DATA_PATH + "MASTER\MASTER.txt")
				streamReader.ReadLine()
				Dim num As Integer = 0
				Do
					Dim array As String() = streamReader.ReadLine().Split(New Char() {":"c})(1).Split(New Char() {";"c})
					Me.abs_encoder(num).master_ok = Conversions.ToBoolean(array(0))
					Me.abs_encoder(num).offset = Conversions.ToInteger(array(1))
					Me.abs_encoder(num).n_overflow = Conversions.ToInteger(array(2))
					Me.abs_encoder(num).n_mod_overflow = Conversions.ToInteger(array(3))
					Me.abs_encoder(num).rest = Conversions.ToSingle(array(4))
					Me.abs_encoder(num).actual_pos = Conversions.ToInteger(array(5))
					num += 1
				Loop While num <= 31
				Interaction.MsgBox(Me.StrLabels(509), MsgBoxStyle.OkOnly, Nothing)
				streamReader.Close()
			Catch ex As System.Exception
				Interaction.MsgBox("read_master_data_file() : " + ex.Message, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x06000079 RID: 121 RVA: 0x00008EC8 File Offset: 0x000070C8
		Private Sub Psw_master()
			Try
				Dim frmTouchKey As frmTouchKey = New frmTouchKey()
				frmTouchKey.UcTouchKey.InsertPassword = True
				frmTouchKey.ShowDialog()
				If frmTouchKey.Responce Then
					If Operators.CompareString(frmTouchKey.KeyText, "CMA3B123", False) = 0 Then
						Me.psw_popup_master = True
					Else
						Interaction.MsgBox(Me.StrLabels(506), MsgBoxStyle.Exclamation, Nothing)
					End If
				End If
			Catch ex As System.Exception
				Interaction.MsgBox("Psw_master() : " + ex.Message, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x0600007A RID: 122 RVA: 0x00008FA8 File Offset: 0x000071A8
		Private Sub vis_error_ValueChanged(sender As Object, e As VariableEventArgs)
			Try
				If Conversions.ToBoolean(CType(sender, Variable).Value.ToString()) Then
					Me.vis_error_list.ReadValue()
				End If
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x0600007B RID: 123 RVA: 0x00009020 File Offset: 0x00007220
		Private Sub vis_error_list_ValueRead(sender As Object, e As PviEventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Dim variable As Variable = CType(sender, Variable)
				Me.new_date = String.Concat(New String() {Strings.Format(DateAndTime.Now.Year, "0000"), "_", Strings.Format(DateAndTime.Now.Month, "00"), "_", Strings.Format(DateAndTime.Now.Day, "00")})
				If Operators.CompareString(Me.new_date, Me.act_date, False) <> 0 Then
					Me.lvw_alarms.Items.Clear()
				End If
				Dim num As Integer = variable.Value("count")
				If num > 0 Then
					Dim num2 As Integer = num - 1
					For i As Integer = 0 To num2
						Dim listViewItem As ListViewItem = New ListViewItem()
						listViewItem.Text = String.Concat(New String() {Strings.Format(DateAndTime.Now.Hour, "00"), ":", Strings.Format(DateAndTime.Now.Minute, "00"), ":", Strings.Format(DateAndTime.Now.Second, "00")})
						Dim num3 As Integer = Conversions.ToInteger(variable.Value("list[" + Conversions.ToString(i) + "].ax").ToString())
						If num3 >= 0 Then
							listViewItem.SubItems.Add("Ax" + Conversions.ToString(num3))
							Dim value As Integer = Conversions.ToInteger(variable.Value("list[" + Conversions.ToString(i) + "].code").ToString())
							Dim text As String = variable.Value("list[" + Conversions.ToString(i) + "].string").ToString()
							listViewItem.SubItems.Add(Conversions.ToString(value))
							listViewItem.SubItems.Add(text)
							Me.LblAlarmaDes.Text = "Ax " + Conversions.ToString(num3) + " Error: " + Conversions.ToString(value)
							Me.LblAlarmaDes.BackColor = Color.Red
						Else
							listViewItem.SubItems.Add("CYC")
							Dim num4 As Integer = Conversions.ToInteger(variable.Value("list[" + Conversions.ToString(i) + "].code").ToString())
							Dim text2 As String = variable.Value("list[" + Conversions.ToString(i) + "].string").ToString()
							listViewItem.SubItems.Add(variable.Value("list[" + Conversions.ToString(i) + "].code").ToString())
							If Me.StrLabels(550 + num4) IsNot Nothing Then
								listViewItem.SubItems.Add(Me.StrLabels(550 + num4))
								listViewItem.SubItems.Add(text2)
								Me.LblAlarmaDes.Text = Me.StrLabels(550 + num4)
								Me.LblAlarmaDes.BackColor = Color.Red
							End If
						End If
						Me.lvw_alarms.Items.Add(listViewItem)
					Next
				End If
				Me.vis_error.Value = New Value(False)
				Me.save_alarms()
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x0600007C RID: 124 RVA: 0x0000941C File Offset: 0x0000761C
		Private Sub add_log(ax As Integer, code As Integer, desc As String)
			Try
				Dim listViewItem As ListViewItem = New ListViewItem()
				listViewItem.Text = String.Concat(New String() {Strings.Format(DateAndTime.Now.Hour, "00"), ":", Strings.Format(DateAndTime.Now.Minute, "00"), ":", Strings.Format(DateAndTime.Now.Second, "00")})
				If ax >= 0 Then
					listViewItem.SubItems.Add("Ax" + Conversions.ToString(ax))
				Else
					listViewItem.SubItems.Add("CYC")
				End If
				listViewItem.SubItems.Add(Conversions.ToString(code))
				listViewItem.SubItems.Add(desc)
				Me.lvw_alarms.Items.Add(listViewItem)
				Me.save_alarms()
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x0600007D RID: 125 RVA: 0x00009560 File Offset: 0x00007760
		Private Sub save_alarms()
			Try
				Me.act_date = String.Concat(New String() {Strings.Format(DateAndTime.Now.Year, "0000"), "_", Strings.Format(DateAndTime.Now.Month, "00"), "_", Strings.Format(DateAndTime.Now.Day, "00")})
				Using streamWriter As StreamWriter = New StreamWriter(Path.DATA_PATH + "ALARM\" + Me.act_date + ".xls")
					If Me.lvw_alarms.Items.Count > 0 Then
						Dim num2 As Integer = Me.lvw_alarms.Items.Count - 1
						For i As Integer = 0 To num2
							Dim value As String = String.Concat(New String() {Me.lvw_alarms.Items(i).SubItems(0).Text, vbTab, Me.lvw_alarms.Items(i).SubItems(1).Text, vbTab, Me.lvw_alarms.Items(i).SubItems(2).Text, vbTab, Me.lvw_alarms.Items(i).SubItems(3).Text})
							streamWriter.WriteLine(value)
						Next
					End If
				End Using
			Catch ex As System.Exception
				Interaction.MsgBox("save_alarms() : " + ex.Message, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x0600007E RID: 126 RVA: 0x000097A8 File Offset: 0x000079A8
		Private Sub load_alarms()
			Try
				Me.act_date = String.Concat(New String() {Strings.Format(DateAndTime.Now.Year, "0000"), "_", Strings.Format(DateAndTime.Now.Month, "00"), "_", Strings.Format(DateAndTime.Now.Day, "00")})
				Dim text As String = Path.DATA_PATH + "ALARM\" + Me.act_date + ".xls"
				If New FileInfo(text).Exists Then
					Using streamReader As StreamReader = New StreamReader(text)
						While streamReader.Peek() >= 0
							Dim items As String() = Strings.Split(streamReader.ReadLine(), vbTab, -1, CompareMethod.Binary)
							Dim value As ListViewItem = New ListViewItem(items)
							Me.lvw_alarms.Items.Add(value)
						End While
					End Using
				End If
			Catch ex As System.Exception
				Interaction.MsgBox("load_alarms() : " + ex.Message, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x0600007F RID: 127 RVA: 0x00009944 File Offset: 0x00007B44
		Private Sub VisPresence()
			Try
				If Me.StatoPresence(0) Then
					Me.Pic_Piece_Load.Visible = True
					Me.LoadTape_vb.DI_Presence_start = True
					Me.Pic_pres_start_load.BackColor = Color.LimeGreen
				Else
					Me.LoadTape_vb.DI_Presence_start = False
					Me.Pic_pres_start_load.BackColor = Color.Silver
				End If
				If Me.StatoPresence(1) Then
					Me.Pic_Piece_Load.Visible = True
					Me.LoadTape_vb.DI_Presence_end = True
					Me.Pic_pres_end_load.BackColor = Color.LimeGreen
				Else
					Me.LoadTape_vb.DI_Presence_end = False
					Me.Pic_pres_end_load.BackColor = Color.Silver
				End If
				If Me.StatoPresence(4) Then
					Me.LoadTape_vb.DI_Barrier = True
					Me.Pic_barrier_load.BackColor = Color.LimeGreen
				Else
					Me.LoadTape_vb.DI_Barrier = False
					Me.Pic_barrier_load.BackColor = Color.Red
				End If
				If Me.StatoPresence(5) Then
					Me.LoadTape_vb.DO_Confirm_Lamp = True
					Me.Pic_confirmed_load.BackColor = Color.LimeGreen
				Else
					Me.LoadTape_vb.DO_Confirm_Lamp = False
					Me.Pic_confirmed_load.BackColor = Color.Silver
				End If
				If Me.StatoPresence(6) Then
					Me.Pic_Piece_Load.Visible = True
					Me.Piece_Presence_vb(0) = -1
				Else
					Me.Pic_Piece_Load.Visible = False
					Me.Piece_Presence_vb(0) = 0
				End If
				If Me.StatoPresence(10) Then
					Me.OvenTape_vb.DI_Presence_start = True
					Me.Pic_pres_start_oven.BackColor = Color.LimeGreen
					Me.Pic_Piece_Oven.Visible = True
				Else
					Me.OvenTape_vb.DI_Presence_start = False
					Me.Pic_pres_start_oven.BackColor = Color.Silver
				End If
				If Me.StatoPresence(11) Then
					Me.OvenTape_vb.DI_Presence_end = True
					Me.Pic_pres_end_oven.BackColor = Color.LimeGreen
					Me.Pic_Piece_Oven.Visible = True
				Else
					Me.OvenTape_vb.DI_Presence_end = False
					Me.Pic_pres_end_oven.BackColor = Color.Silver
				End If
				If Me.StatoPresence(12) Then
					Me.OvenTape_vb.DI_DoorIN_close = True
					Me.Pic_Oven_doorIN_close.BackColor = Color.LimeGreen
				Else
					Me.OvenTape_vb.DI_DoorIN_close = False
					Me.Pic_Oven_doorIN_close.BackColor = Color.Silver
				End If
				If Me.StatoPresence(13) Then
					Me.OvenTape_vb.DI_DoorIN_open = True
					Me.Pic_Oven_doorIN_close.BackColor = Color.LimeGreen
					Me.BtnOvenDoor.Text = "Close Oven Door"
				Else
					Me.OvenTape_vb.DI_DoorIN_open = False
					Me.Pic_Oven_doorIN_close.BackColor = Color.Silver
					Me.BtnOvenDoor.Text = "Open Oven Door"
				End If
				If Me.StatoPresence(16) Then
					Me.Pic_Piece_Oven.Visible = True
					Me.Piece_Presence_vb(1) = -1
				Else
					Me.Pic_Piece_Oven.Visible = False
					Me.Piece_Presence_vb(1) = 0
				End If
				If Me.StatoPresence(20) Then
					Me.PaintTape_vb.DI_DoorIN_close = True
					Me.Pic_doorIN_close.BackColor = Color.LimeGreen
				Else
					Me.PaintTape_vb.DI_DoorIN_close = False
					Me.Pic_doorIN_close.BackColor = Color.Silver
				End If
				If Me.StatoPresence(21) Then
					Me.PaintTape_vb.DI_DoorIN_open = True
					Me.Pic_doorIN_open.BackColor = Color.LimeGreen
					Me.BtnOpenDoorIN.Text = "Close Door IN"
				Else
					Me.PaintTape_vb.DI_DoorIN_open = False
					Me.Pic_doorIN_open.BackColor = Color.Silver
					Me.BtnOpenDoorIN.Text = "Open Door IN"
				End If
				If Me.StatoPresence(22) Then
					Me.PaintTape_vb.DI_DoorOUT_close = True
					Me.Pic_doorOUT_close.BackColor = Color.LimeGreen
				Else
					Me.PaintTape_vb.DI_DoorOUT_close = False
					Me.Pic_doorOUT_close.BackColor = Color.Silver
				End If
				If Me.StatoPresence(23) Then
					Me.PaintTape_vb.DI_DoorOUT_open = True
					Me.Pic_doorOUT_open.BackColor = Color.LimeGreen
					Me.BtnOpenDoorOUT.Text = "Close Door OUT"
				Else
					Me.PaintTape_vb.DI_DoorOUT_open = False
					Me.Pic_doorOUT_open.BackColor = Color.Silver
					Me.BtnOpenDoorOUT.Text = "Open Door OUT"
				End If
				If Me.StatoPresence(24) Then
					Me.PaintTape_vb.DI_Presence_start = True
					Me.Pic_pres_start_paint.BackColor = Color.LimeGreen
					Me.Pic_Piece_Paint.Visible = True
				Else
					Me.PaintTape_vb.DI_Presence_start = False
					Me.Pic_pres_start_paint.BackColor = Color.Silver
				End If
				If Me.StatoPresence(25) Then
					Me.PaintTape_vb.DI_Presence_end = True
					Me.Pic_pres_end_paint.BackColor = Color.LimeGreen
					Me.Pic_Piece_Paint.Visible = True
				Else
					Me.PaintTape_vb.DI_Presence_end = False
					Me.Pic_pres_end_paint.BackColor = Color.Silver
				End If
				If Me.StatoPresence(33) Then
					Me.Pic_Piece_Paint.Visible = True
					Me.Piece_Presence_vb(2) = -1
				Else
					Me.Pic_Piece_Paint.Visible = False
					Me.Piece_Presence_vb(2) = 0
				End If
				If Me.StatoPresence(49) Then
					Me.UnloadTape_vb.DI_Presence_start = True
					Me.Pic_pres_start_unload.BackColor = Color.LimeGreen
					Me.Pic_Piece_Unload_1.Visible = True
				Else
					Me.UnloadTape_vb.DI_Presence_start = False
					Me.Pic_pres_start_unload.BackColor = Color.Silver
				End If
				If Me.StatoPresence(50) Then
					Me.UnloadTape_vb.DI_Presence_end = True
					Me.Pic_pres_end_unload.BackColor = Color.LimeGreen
					Me.Pic_Piece_Unload_1.Visible = True
				Else
					Me.UnloadTape_vb.DI_Presence_end = False
					Me.Pic_pres_end_unload.BackColor = Color.Silver
				End If
				If Me.StatoPresence(53) Then
					Me.UnloadTape_vb.DI_Barrier = True
					Me.Pic_barrier_unload.BackColor = Color.LimeGreen
				Else
					Me.UnloadTape_vb.DI_Barrier = False
					Me.Pic_barrier_unload.BackColor = Color.Red
				End If
				If Me.StatoPresence(54) Then
					Me.UnloadTape_vb.DO_Confirm_Lamp = True
					Me.Pic_confirmed_unload.BackColor = Color.LimeGreen
				Else
					Me.UnloadTape_vb.DO_Confirm_Lamp = False
					Me.Pic_confirmed_unload.BackColor = Color.Silver
				End If
				If Me.StatoPresence(55) Then
					Me.Pic_pres_safe_unload.BackColor = Color.LimeGreen
				Else
					Me.Pic_pres_safe_unload.BackColor = Color.Silver
				End If
				If Me.StatoPresence(57) Then
					Me.Pic_Piece_Unload_1.Visible = True
					Me.Piece_Presence_vb(3) = -1
				Else
					Me.Pic_Piece_Unload_1.Visible = False
					Me.Piece_Presence_vb(3) = 0
				End If
				If Me.StatoPresence(63) Then
					Me.PicRobot1Busy.BackColor = Color.LimeGreen
				Else
					Me.PicRobot1Busy.BackColor = Color.Silver
				End If
				If Me.StatoPresence(65) Then
					Me.PicRobot1FouriIngombro.BackColor = Color.LimeGreen
				Else
					Me.PicRobot1FouriIngombro.BackColor = Color.Silver
				End If
				If Me.StatoPresence(68) Then
					Me.PicRobot1EmptyList.BackColor = Color.LimeGreen
				Else
					Me.PicRobot1EmptyList.BackColor = Color.Silver
				End If
				If Me.StatoPresence(70) Then
					Me.PicRobot1PrgRun.BackColor = Color.LimeGreen
				Else
					Me.PicRobot1PrgRun.BackColor = Color.Silver
				End If
				If Me.StatoPresence(60) Then
					Me.Pic_plant_auto_ready.BackColor = Color.LimeGreen
				Else
					Me.Pic_plant_auto_ready.BackColor = Color.Silver
				End If
				If Me.StatoPresence(5) Then
					Me.Pic_confirm_button.BackColor = Color.LimeGreen
					Me.cmb_act_code.Enabled = False
				Else
					Me.Pic_confirm_button.BackColor = Color.Silver
					Me.cmb_act_code.Enabled = True
				End If
				If ((Me.StatoPresence(63) And Me.StatoPresence(65)) Or Conversions.ToDouble(Me.lvw_par.Items(51).SubItems(2).Text) = 0.0) And ((Me.StatoPresence(64) And Me.StatoPresence(66)) Or (Conversions.ToDouble(Me.lvw_par.Items(52).SubItems(2).Text) = 0.0 And Me.R1_carter_Low_vb)) Then
					Me.Pic_robots_ready.BackColor = Color.LimeGreen
				Else
					Me.Pic_robots_ready.BackColor = Color.Silver
				End If
				If Me.StatoPresence(4) Then
					Me.Pic_barrier_load_ready.BackColor = Color.LimeGreen
				Else
					Me.Pic_barrier_load_ready.BackColor = Color.Silver
				End If
				If Me.StatoPresence(67) Or (Me.StatoPresence(0) Or Me.StatoPresence(1)) Then
					Me.Pic_coder_ready.BackColor = Color.LimeGreen
				Else
					Me.Pic_coder_ready.BackColor = Color.Silver
				End If
				If Me.StatoPresence(54) Then
					Me.Pic_unload_done.BackColor = Color.LimeGreen
				Else
					Me.Pic_unload_done.BackColor = Color.Silver
				End If
				If Me.StatoPresence(72) Then
					Me.lbl_Load_st_emerg.BackColor = Color.LimeGreen
				Else
					Me.lbl_Load_st_emerg.BackColor = Color.Red
				End If
				If Me.StatoPresence(73) Then
					Me.lbl_Oven_st_emerg.BackColor = Color.LimeGreen
				Else
					Me.lbl_Oven_st_emerg.BackColor = Color.Red
				End If
				If Me.StatoPresence(74) Then
					Me.lbl_Paint_st_emerg.BackColor = Color.LimeGreen
				Else
					Me.lbl_Paint_st_emerg.BackColor = Color.Red
				End If
				If Me.StatoPresence(75) Then
					Me.lbl_Unload_st_emerg.BackColor = Color.LimeGreen
				Else
					Me.lbl_Unload_st_emerg.BackColor = Color.Red
				End If
				If Me.StatoPresence(76) Then
					Me.Pic_SR20G_R1_ready.BackColor = Color.LimeGreen
				Else
					Me.Pic_SR20G_R1_ready.BackColor = Color.Red
				End If
				If Me.StatoPresence(77) Then
					Me.Pic_Sirtek_plant_ready.BackColor = Color.LimeGreen
				Else
					Me.Pic_Sirtek_plant_ready.BackColor = Color.Red
				End If
				Me.AddLogMsg()
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x06000080 RID: 128 RVA: 0x0000A3CC File Offset: 0x000085CC
		Private Sub VisWarning()
			Try
				Select Case Me.Terminal_ErrCode_vb
					Case 0
						Me.Lbl_Warning_cyc.BackColor = Color.White
						Me.Lbl_Warning_cyc.ForeColor = Color.Black
						Me.Lbl_Warning_cyc.Text = ""
						GoTo IL_C9D
					Case 1
						Me.Lbl_Warning_cyc.Visible = True
						Me.Lbl_Warning_cyc.BackColor = Color.Yellow
						Me.Lbl_Warning_cyc.Text = Me.cma_labels(151)
						Me.add_log(-1, 151, Me.cma_labels(151))
						GoTo IL_C9D
					Case 2
						Me.Lbl_Warning_cyc.Visible = True
						Me.Lbl_Warning_cyc.BackColor = Color.Yellow
						Me.Lbl_Warning_cyc.Text = Me.cma_labels(152)
						Me.add_log(-1, 152, Me.cma_labels(152))
						GoTo IL_C9D
					Case 3
						Me.Lbl_Warning_cyc.Visible = True
						Me.Lbl_Warning_cyc.BackColor = Color.Yellow
						Me.Lbl_Warning_cyc.Text = Me.cma_labels(153)
						Me.add_log(-1, 153, Me.cma_labels(153))
						GoTo IL_C9D
					Case 4
						Me.Lbl_Warning_cyc.Visible = True
						Me.Lbl_Warning_cyc.BackColor = Color.Yellow
						Me.Lbl_Warning_cyc.Text = Me.cma_labels(154)
						Me.add_log(-1, 154, Me.cma_labels(154))
						GoTo IL_C9D
					Case 5
						Me.Lbl_Warning_cyc.Visible = True
						Me.Lbl_Warning_cyc.BackColor = Color.Yellow
						Me.Lbl_Warning_cyc.Text = Me.cma_labels(155)
						Me.add_log(-1, 155, Me.cma_labels(155))
						GoTo IL_C9D
					Case 6
						Me.Lbl_Warning_cyc.Visible = True
						Me.Lbl_Warning_cyc.BackColor = Color.Yellow
						Me.Lbl_Warning_cyc.Text = Me.cma_labels(156)
						Me.add_log(-1, 156, Me.cma_labels(156))
						GoTo IL_C9D
					Case 7
						Me.Lbl_Warning_cyc.Visible = True
						Me.Lbl_Warning_cyc.BackColor = Color.Yellow
						Me.Lbl_Warning_cyc.Text = Me.cma_labels(157)
						Me.add_log(-1, 157, Me.cma_labels(157))
						GoTo IL_C9D
					Case 8
						Me.Lbl_Warning_cyc.Visible = True
						Me.Lbl_Warning_cyc.BackColor = Color.Yellow
						Me.Lbl_Warning_cyc.Text = Me.cma_labels(158)
						Me.add_log(-1, 158, Me.cma_labels(158))
						GoTo IL_C9D
					Case 9
						Me.Lbl_Warning_cyc.Visible = True
						Me.Lbl_Warning_cyc.BackColor = Color.Yellow
						Me.Lbl_Warning_cyc.Text = Me.cma_labels(159)
						Me.add_log(-1, 159, Me.cma_labels(159))
						GoTo IL_C9D
					Case 10
						Me.Lbl_Warning_cyc.Visible = True
						Me.Lbl_Warning_cyc.BackColor = Color.Yellow
						Me.Lbl_Warning_cyc.Text = Me.cma_labels(160)
						Me.add_log(-1, 160, Me.cma_labels(160))
						GoTo IL_C9D
					Case 11
						Me.Lbl_Warning_cyc.Visible = True
						Me.Lbl_Warning_cyc.BackColor = Color.Yellow
						Me.Lbl_Warning_cyc.Text = Me.cma_labels(161)
						Me.add_log(-1, 161, Me.cma_labels(161))
						GoTo IL_C9D
					Case 12
						Me.Lbl_Warning_cyc.Visible = True
						Me.Lbl_Warning_cyc.BackColor = Color.Yellow
						Me.Lbl_Warning_cyc.Text = Me.cma_labels(162)
						Me.add_log(-1, 162, Me.cma_labels(162))
						GoTo IL_C9D
					Case 13
						Me.Lbl_Warning_cyc.Visible = True
						Me.Lbl_Warning_cyc.BackColor = Color.Yellow
						Me.Lbl_Warning_cyc.Text = Me.cma_labels(163)
						Me.add_log(-1, 163, Me.cma_labels(163))
						GoTo IL_C9D
					Case 14
						Me.Lbl_Warning_cyc.Visible = True
						Me.Lbl_Warning_cyc.BackColor = Color.Yellow
						Me.Lbl_Warning_cyc.Text = Me.cma_labels(164)
						Me.add_log(-1, 164, Me.cma_labels(164))
						GoTo IL_C9D
					Case 15
						Me.Lbl_Warning_cyc.Visible = True
						Me.Lbl_Warning_cyc.BackColor = Color.Yellow
						Me.Lbl_Warning_cyc.Text = Me.cma_labels(165)
						Me.add_log(-1, 165, Me.cma_labels(165))
						GoTo IL_C9D
					Case 16
						Me.Lbl_Warning_cyc.Visible = True
						Me.Lbl_Warning_cyc.BackColor = Color.Yellow
						Me.Lbl_Warning_cyc.Text = Me.cma_labels(166)
						Me.add_log(-1, 166, Me.cma_labels(166))
						GoTo IL_C9D
					Case 17
						Me.Lbl_Warning_cyc.Visible = True
						Me.Lbl_Warning_cyc.BackColor = Color.Yellow
						Me.Lbl_Warning_cyc.Text = Me.cma_labels(167)
						Me.add_log(-1, 167, Me.cma_labels(167))
						GoTo IL_C9D
					Case 18
						Me.Lbl_Warning_cyc.Visible = True
						Me.Lbl_Warning_cyc.BackColor = Color.Yellow
						Me.Lbl_Warning_cyc.Text = Me.cma_labels(168)
						Me.add_log(-1, 168, Me.cma_labels(168))
						GoTo IL_C9D
					Case 19
						Me.Lbl_Warning_cyc.Visible = True
						Me.Lbl_Warning_cyc.BackColor = Color.Yellow
						Me.Lbl_Warning_cyc.Text = Me.cma_labels(169)
						Me.add_log(-1, 169, Me.cma_labels(169))
						GoTo IL_C9D
					Case 20
						Me.Lbl_Warning_cyc.Visible = True
						Me.Lbl_Warning_cyc.BackColor = Color.Yellow
						Me.Lbl_Warning_cyc.Text = Me.cma_labels(170)
						Me.add_log(-1, 170, Me.cma_labels(170))
						GoTo IL_C9D
					Case 21
						Me.Lbl_Warning_cyc.Visible = True
						Me.Lbl_Warning_cyc.BackColor = Color.Yellow
						Me.Lbl_Warning_cyc.Text = Me.cma_labels(171)
						Me.add_log(-1, 171, Me.cma_labels(171))
						GoTo IL_C9D
					Case 22
						Me.Lbl_Warning_cyc.Visible = True
						Me.Lbl_Warning_cyc.BackColor = Color.Yellow
						Me.Lbl_Warning_cyc.Text = Me.cma_labels(172)
						Me.add_log(-1, 172, Me.cma_labels(172))
						GoTo IL_C9D
					Case 23
						Me.Lbl_Warning_cyc.Visible = True
						Me.Lbl_Warning_cyc.BackColor = Color.Yellow
						Me.Lbl_Warning_cyc.Text = Me.cma_labels(173)
						Me.add_log(-1, 173, Me.cma_labels(173))
						GoTo IL_C9D
					Case 24
						Me.Lbl_Warning_cyc.Visible = True
						Me.Lbl_Warning_cyc.BackColor = Color.Yellow
						Me.Lbl_Warning_cyc.Text = Me.cma_labels(174)
						Me.add_log(-1, 174, Me.cma_labels(174))
						GoTo IL_C9D
					Case 25
						Me.Lbl_Warning_cyc.Visible = True
						Me.Lbl_Warning_cyc.BackColor = Color.Yellow
						Me.Lbl_Warning_cyc.Text = Me.cma_labels(175)
						Me.add_log(-1, 175, Me.cma_labels(175))
						GoTo IL_C9D
					Case 26
						Me.Lbl_Warning_cyc.Visible = True
						Me.Lbl_Warning_cyc.BackColor = Color.Yellow
						Me.Lbl_Warning_cyc.Text = Me.cma_labels(176)
						Me.add_log(-1, 176, Me.cma_labels(176))
						GoTo IL_C9D
					Case 27
						Me.Lbl_Warning_cyc.Visible = True
						Me.Lbl_Warning_cyc.BackColor = Color.Yellow
						Me.Lbl_Warning_cyc.Text = Me.cma_labels(177)
						Me.add_log(-1, 177, Me.cma_labels(177))
						GoTo IL_C9D
					Case 28
						Me.Lbl_Warning_cyc.Visible = True
						Me.Lbl_Warning_cyc.BackColor = Color.Yellow
						Me.Lbl_Warning_cyc.Text = Me.cma_labels(178)
						Me.add_log(-1, 178, Me.cma_labels(178))
						GoTo IL_C9D
					Case 29
						Me.Lbl_Warning_cyc.Visible = True
						Me.Lbl_Warning_cyc.BackColor = Color.Yellow
						Me.Lbl_Warning_cyc.Text = Me.cma_labels(179)
						Me.add_log(-1, 179, Me.cma_labels(179))
						GoTo IL_C9D
					Case 30
						Me.Lbl_Warning_cyc.Visible = True
						Me.Lbl_Warning_cyc.BackColor = Color.Yellow
						Me.Lbl_Warning_cyc.Text = Me.cma_labels(180)
						Me.add_log(-1, 180, Me.cma_labels(180))
						GoTo IL_C9D
					Case 31
						Me.Lbl_Warning_cyc.Visible = True
						Me.Lbl_Warning_cyc.BackColor = Color.Yellow
						Me.Lbl_Warning_cyc.Text = Me.cma_labels(181)
						Me.add_log(-1, 181, Me.cma_labels(181))
						GoTo IL_C9D
					Case 32
						Me.Lbl_Warning_cyc.Visible = True
						Me.Lbl_Warning_cyc.BackColor = Color.Yellow
						Me.Lbl_Warning_cyc.Text = Me.cma_labels(182)
						Me.add_log(-1, 182, Me.cma_labels(182))
						GoTo IL_C9D
					Case 33
						Me.Lbl_Warning_cyc.Visible = True
						Me.Lbl_Warning_cyc.BackColor = Color.Yellow
						Me.Lbl_Warning_cyc.Text = Me.cma_labels(183)
						Me.add_log(-1, 183, Me.cma_labels(183))
						GoTo IL_C9D
					Case 34
						Me.Lbl_Warning_cyc.Visible = True
						Me.Lbl_Warning_cyc.BackColor = Color.Yellow
						Me.Lbl_Warning_cyc.Text = Me.cma_labels(184)
						Me.add_log(-1, 184, Me.cma_labels(184))
						GoTo IL_C9D
					Case 36
						Me.Lbl_Warning_cyc.Visible = True
						Me.Lbl_Warning_cyc.BackColor = Color.Yellow
						Me.Lbl_Warning_cyc.Text = Me.cma_labels(186)
						Me.add_log(-1, 186, Me.cma_labels(186))
						GoTo IL_C9D
					Case 37
						Me.Lbl_Warning_cyc.Visible = True
						Me.Lbl_Warning_cyc.BackColor = Color.Yellow
						Me.Lbl_Warning_cyc.Text = Me.cma_labels(187)
						Me.add_log(-1, 187, Me.cma_labels(187))
						GoTo IL_C9D
					Case 38
						Me.Lbl_Warning_cyc.Visible = True
						Me.Lbl_Warning_cyc.BackColor = Color.Yellow
						Me.Lbl_Warning_cyc.Text = Me.cma_labels(188)
						Me.add_log(-1, 187, Me.cma_labels(188))
						GoTo IL_C9D
				End Select
				Me.Lbl_Warning_cyc.BackColor = Color.White
				Me.Lbl_Warning_cyc.ForeColor = Color.Black
				Me.Lbl_Warning_cyc.Text = ""
IL_C9D:
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x06000081 RID: 129 RVA: 0x0000B0CC File Offset: 0x000092CC
		Private Sub VisRemoteFeature()
			Try
				If Me.par_en_remote_programlist Then
					Me.lbl_act_code.Visible = True
					Me.cmb_act_code.Visible = False
					Me.dgv_programlist.Enabled = True
					Me.UpdateProgramList()
				Else
					Me.lbl_act_code.Visible = False
					Me.cmb_act_code.Visible = True
					Me.dgv_programlist.Enabled = False
				End If
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x06000082 RID: 130 RVA: 0x0000B178 File Offset: 0x00009378
		Private Sub VisActPieceCode()
			Try
				Dim array As String() = New String(3) {}
				If Me.OvenTape_vb.Prog_Code IsNot Nothing Then
					array = Me.OvenTape_vb.Prog_Code.Trim("<>".ToCharArray()).Split(New Char() {"&"c})
					If array.Length > 1 Then
						Me.lbl_code_Oven.Text = array(1)
					Else
						Me.lbl_code_Oven.Text = ""
					End If
				Else
					Me.lbl_code_Oven.Text = ""
				End If
				If Me.PaintTape_vb.Prog_Code IsNot Nothing Then
					array = Me.PaintTape_vb.Prog_Code.Trim("<>".ToCharArray()).Split(New Char() {"&"c})
					If array.Length > 1 Then
						Me.lbl_code_Paint.Text = array(1)
					Else
						Me.lbl_code_Paint.Text = ""
					End If
				Else
					Me.lbl_code_Paint.Text = ""
				End If
				If Me.UnloadTape_vb.Prog_Code IsNot Nothing Then
					array = Me.UnloadTape_vb.Prog_Code.Trim("<>".ToCharArray()).Split(New Char() {"&"c})
					If array.Length > 1 Then
						Me.lbl_code_Unload_ST1.Text = array(1)
					Else
						Me.lbl_code_Unload_ST1.Text = ""
					End If
				Else
					Me.lbl_code_Unload_ST1.Text = ""
				End If
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x06000083 RID: 131 RVA: 0x0000B330 File Offset: 0x00009530
		Private Sub AddLogMsg()
			If Me.StatoPresence(5) And Not Me.DO_Load_Confirm_Lamp_OLD Then
				Me.add_log(-1, 201, Me.cma_labels(301))
			End If
			If (If((-If((Me.StatoPresence(34) > False), 1, 0)), 1, 0) And Not Me.DO_Unload_Confirm_Lamp_old) <> 0 Then
				Me.add_log(-1, 202, Me.cma_labels(302))
			End If
			If Me.StatoPresence(40) And Not Me.DO_AUTO_Lamp_OLD Then
				Me.add_log(-1, 203, Me.cma_labels(303))
			End If
			If Not Me.StatoPresence(40) And Me.DO_AUTO_Lamp_OLD Then
				Me.add_log(-1, 204, Me.cma_labels(304))
			End If
			If Me.StatoPresence(42) And Not Me.DI_Empty_Line_OLD Then
				Me.add_log(-1, 205, Me.cma_labels(305))
			End If
			If Not Me.StatoPresence(42) And Me.DI_Empty_Line_OLD Then
				Me.add_log(-1, 206, Me.cma_labels(306))
			End If
		End Sub

		' Token: 0x06000084 RID: 132 RVA: 0x0000B450 File Offset: 0x00009650
		Private Sub AddHandler_PicCassa()
			Try
				AddHandler Me.BtnLngIta.Click, AddressOf Me.BntLng
				AddHandler Me.BtnLngEng.Click, AddressOf Me.BntLng
				AddHandler Me.BtnLngGer.Click, AddressOf Me.BntLng
				AddHandler Me.BtnLngSpa.Click, AddressOf Me.BntLng
				AddHandler Me.BtnLngFra.Click, AddressOf Me.BntLng
				AddHandler Me.BtnLngBra.Click, AddressOf Me.BntLng
				AddHandler Me.Pic_barrier_load.Click, AddressOf Me.PicClick
				AddHandler Me.Pic_barrier_unload.Click, AddressOf Me.PicClick
				AddHandler Me.Pic_confirmed_load.Click, AddressOf Me.PicClick
				AddHandler Me.Pic_confirmed_unload.Click, AddressOf Me.PicClick
				AddHandler Me.Pic_Oven_doorIN_open.Click, AddressOf Me.PicClick
				AddHandler Me.Pic_Oven_doorIN_close.Click, AddressOf Me.PicClick
				AddHandler Me.Pic_doorIN_open.Click, AddressOf Me.PicClick
				AddHandler Me.Pic_doorIN_close.Click, AddressOf Me.PicClick
				AddHandler Me.Pic_doorOUT_open.Click, AddressOf Me.PicClick
				AddHandler Me.Pic_doorOUT_close.Click, AddressOf Me.PicClick
				AddHandler Me.Pic_Piece_Load.Click, AddressOf Me.PicClick
				AddHandler Me.Pic_Piece_Paint.Click, AddressOf Me.PicClick
				AddHandler Me.Pic_Piece_Unload_1.Click, AddressOf Me.PicClick
				AddHandler Me.Pic_pres_start_load.Click, AddressOf Me.PicClick
				AddHandler Me.Pic_pres_end_load.Click, AddressOf Me.PicClick
				AddHandler Me.Pic_pres_end_oven.Click, AddressOf Me.PicClick
				AddHandler Me.Pic_pres_start_oven.Click, AddressOf Me.PicClick
				AddHandler Me.Pic_pres_start_paint.Click, AddressOf Me.PicClick
				AddHandler Me.Pic_pres_end_paint.Click, AddressOf Me.PicClick
				AddHandler Me.Pic_pres_start_unload.Click, AddressOf Me.PicClick
				AddHandler Me.Pic_pres_end_unload.Click, AddressOf Me.PicClick
				AddHandler Me.Pic_pres_safe_unload.Click, AddressOf Me.PicClick
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x06000085 RID: 133 RVA: 0x0000B734 File Offset: 0x00009934
		Private Sub PicClick(sender As Object, e As EventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Me.TmrShowDescrizione.[Stop]()
				Dim pictureBox As PictureBox = CType(sender, PictureBox)
				Me.LblDescrizione.Text = Conversions.ToString(pictureBox.Tag)
				Me.LblDescrizione.BringToFront()
				Me.LblDescrizione.Location = New Point(pictureBox.Location.X + pictureBox.Size.Width + 2, pictureBox.Location.Y)
				If Me.LblDescrizione.Location.X + Me.LblDescrizione.Size.Width > MyBase.Size.Width Then
					Dim location As Point = Me.LblDescrizione.Location
					location.X = location.X - Me.LblDescrizione.Size.Width - pictureBox.Size.Width - 5
					Me.LblDescrizione.Location = New Point(location.X, Me.LblDescrizione.Location.Y)
				End If
				Me.LblDescrizione.Visible = True
				Me.TmrShowDescrizione.Start()
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x06000086 RID: 134 RVA: 0x0000B8BC File Offset: 0x00009ABC
		Private Sub Tmr_Blink_Tick(sender As Object, e As EventArgs)
			Try
				If Me.flag_force_unload_vb <> 0 Then
					If Me.btn_force_unload_step.BackColor = SystemColors.Window Then
						Me.btn_force_unload_step.BackColor = Color.Orange
					Else
						Me.btn_force_unload_step.BackColor = SystemColors.Window
					End If
				End If
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x06000087 RID: 135 RVA: 0x0000B954 File Offset: 0x00009B54
		Private Sub TmrShowDescrizione_Tick(sender As Object, e As EventArgs)
			Try
				Me.TmrShowDescrizione.[Stop]()
				Me.LblDescrizione.Visible = False
				If Me.flag_force_unload_vb <> 0 Then
					If Me.btn_force_unload_step.BackColor = SystemColors.Control Then
						Me.btn_force_unload_step.BackColor = Color.Orange
					Else
						Me.btn_force_unload_step.BackColor = SystemColors.Control
					End If
				End If
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x06000088 RID: 136 RVA: 0x0000BA04 File Offset: 0x00009C04
		Private Sub LblDescrizione_Click(sender As Object, e As EventArgs)
			Me.LblDescrizione.Visible = False
		End Sub

		' Token: 0x06000089 RID: 137 RVA: 0x0000BA14 File Offset: 0x00009C14
		Private Sub Vis_Timeout_Oven()
			' The following expression was wrapped in a checked-statement
			Try
				' The following expression was wrapped in a unchecked-expression
				Dim num As Integer = CInt((CLng(Math.Round(CDbl(Me.clk_oven_VB) * 0.012)) / 60L))
				Dim num2 As Integer = CInt(Math.Round(CDbl(Me.clk_oven_VB) * 0.012 - CDbl((num * 60))))
				Dim num3 As Integer = CInt(Math.Round(Me.timeout_oven_vb))
				Dim num4 As Integer = CInt(Math.Round(Me.timeout_oven_vb * 60.0 - CDbl((num3 * 60))))
				If num > 0 Then
					num = num
				End If
				Dim s As String = "0:" + num.ToString() + ":" + num2.ToString()
				Dim timeSpan As TimeSpan = TimeSpan.Parse("0:" + num3.ToString() + ":" + num4.ToString())
				Dim ts As TimeSpan = TimeSpan.Parse(s)
				Dim timeSpan2 As TimeSpan = timeSpan.Subtract(ts)
				Me.lbl_timeout_oven.Text = timeSpan2.ToString()
				Me.lbl_timeout_oven.Text = String.Format("{0}:{1}", timeSpan2.Minutes.ToString("d2"), timeSpan2.Seconds.ToString("d2"))
				Me.lbl_timeout_oven_set.Text = String.Format("{0}:{1}", timeSpan.Minutes.ToString("d2"), timeSpan.Seconds.ToString("d2"))
				If num2 = 0 And num = 0 Then
					Me.lbl_timeout_oven.BackColor = Color.Lime
					Me.lbl_timeout_oven.Text = "00:00"
				Else
					Me.lbl_timeout_oven.BackColor = Color.Yellow
				End If
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x0600008A RID: 138 RVA: 0x0000BC08 File Offset: 0x00009E08
		Private Sub btn_force_oven_timeout_Click(sender As Object, e As EventArgs)
			Try
				If Not Me.cmd_str_oven_t_vb Then
					Me.cmd_str_oven_t_vb = True
					Me.cmd_str_oven_t.Value = New Value(True)
				Else
					Me.clk_oven.Value = New Value(Me.timeout_oven_vb * 60.0 / 0.012)
					Me.oven_time_end.Value = New Value(True)
				End If
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x0600008B RID: 139 RVA: 0x0000BCBC File Offset: 0x00009EBC
		Private Sub btn_oven_t_min_Click(sender As Object, e As EventArgs)
			Try
				If Me.clk_oven_VB > 0 Then
					' The following expression was wrapped in a checked-expression
					' The following expression was wrapped in a unchecked-expression
					Me.clk_oven_VB = CInt(Math.Round(CDbl(Me.clk_oven_VB) + 5000.0))
					Me.clk_oven.Value = New Value(Me.clk_oven_VB)
				End If
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x0600008C RID: 140 RVA: 0x0000BD4C File Offset: 0x00009F4C
		Private Sub btn_oven_t_plus_Click(sender As Object, e As EventArgs)
			Try
				' The following expression was wrapped in a checked-expression
				' The following expression was wrapped in a unchecked-expression
				Me.clk_oven_VB = CInt(Math.Round(CDbl(Me.clk_oven_VB) - 5000.0))
				If Me.clk_oven_VB > 0 Then
					Me.clk_oven.Value = New Value(Me.clk_oven_VB)
				Else
					Me.clk_oven.Value = New Value(0)
				End If
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x0600008D RID: 141 RVA: 0x0000BDF0 File Offset: 0x00009FF0
		Private Sub btn_force_unload_step_Click(sender As Object, e As EventArgs)
			Try
				If Me.pvi_ok Then
					Me.DI_Force_Unload.Value = True
				End If
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x0600008E RID: 142 RVA: 0x0000BE60 File Offset: 0x0000A060
		Private Sub cmb_act_code_Click(sender As Object, e As EventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Me.cmb_act_code.Items.Clear()
				If Me.robot_program IsNot Nothing Then
					Dim array As String() = New String(Me.robot_program.Length - 1 + 1 - 1) {}
					Dim num As Integer = Me.split_string.Length - 1
					For i As Integer = 0 To num
						array(i) = Strings.Left(Me.robot_program(i), Me.robot_program(i).Length - 4)
						Me.cmb_act_code.Items.Add(array(i))
					Next
				End If
				Me.cmb_act_code.Items.Add("EMPTY CODE")
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " cmb_act_code_Click: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Exclamation, "cmb_act_code_Click")
			End Try
		End Sub

		' Token: 0x0600008F RID: 143 RVA: 0x0000BF44 File Offset: 0x0000A144
		Private Sub cmb_act_code_SelectedIndexChanged(sender As Object, e As EventArgs)
			Try
				MyBase.TopMost = False
				If Me.cmb_act_code.SelectedIndex >= 0 Then
					Me.lbl_code_Load.Text = Me.cmb_act_code.Items(Me.cmb_act_code.SelectedIndex).ToString()
					Me.progr_code_tmp = "<1&" + Me.lbl_code_Load.Text + ">"
				End If
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " cmb_act_code_Click: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Exclamation, "cmb_act_code_SelectedIndexChanged")
			End Try
		End Sub

		' Token: 0x06000090 RID: 144 RVA: 0x0000BFFC File Offset: 0x0000A1FC
		Private Sub lbl_act_code_Click(sender As Object, e As EventArgs)
			Try
				Dim frmCodeList As frmCodeList = New frmCodeList()
				frmCodeList.ShowDialog()
				If frmCodeList.WriteOK Then
					Me.lbl_act_code.Text = frmCodeList.code
					Me.lbl_act_batch.Text = frmCodeList.code_batch
					Me.lbl_act_option.Text = frmCodeList.code_opt
					Me.lbl_code_Load.Text = Me.lbl_act_code.Text
					Me.progr_code_tmp = String.Concat(New String() {"<1&", Me.lbl_act_code.Text, "&", Me.lbl_act_batch.Text, "|", Me.lbl_act_option.Text, ">"})
				End If
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x06000091 RID: 145 RVA: 0x0000C10C File Offset: 0x0000A30C
		Private Sub lbl_act_batch_Click(sender As Object, e As EventArgs)
			Try
				If Not Me.StatoPresence(5) Then
					Dim frmTouchKey As frmTouchKey = New frmTouchKey()
					frmTouchKey.ShowDialog()
					If frmTouchKey.Responce Then
						Me.lbl_act_batch.Text = frmTouchKey.KeyText
					End If
					Me.progr_code_tmp = String.Concat(New String() {"<1&", Me.lbl_code_Load.Text, "&", Me.lbl_act_batch.Text, "|", Me.lbl_act_option.Text, ">"})
				Else
					Me.add_log(-1, 207, Me.cma_labels(500))
				End If
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x06000092 RID: 146 RVA: 0x0000C208 File Offset: 0x0000A408
		Private Sub lbl_act_option_Click(sender As Object, e As EventArgs)
			Try
				If Not Me.StatoPresence(5) Then
					Dim frmTouchKey As frmTouchKey = New frmTouchKey()
					frmTouchKey.ShowDialog()
					If frmTouchKey.Responce Then
						Me.lbl_act_option.Text = frmTouchKey.KeyText
					End If
					Me.progr_code_tmp = String.Concat(New String() {"<1&", Me.lbl_code_Load.Text, "&", Me.lbl_act_batch.Text, "|", Me.lbl_act_option.Text, ">"})
				Else
					Me.add_log(-1, 207, Me.cma_labels(500))
				End If
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x06000093 RID: 147 RVA: 0x0000C304 File Offset: 0x0000A504
		Private Sub load_new_code()
			Try
				If Me.par_en_remote_programlist Then
					Me.lbl_act_code.Text = Conversions.ToString(Me.dgv_programlist(0, 0).Value)
					Me.lbl_act_batch.Text = Conversions.ToString(Me.dgv_programlist(1, 0).Value)
					Me.lbl_act_option.Text = Conversions.ToString(Me.dgv_programlist(2, 0).Value)
					Me.lbl_code_Load.Text = Me.lbl_act_code.Text
					Me.progr_code_tmp = String.Concat(New String() {"<1&", Me.lbl_code_Load.Text, "&", Me.lbl_act_batch.Text, "|", Me.lbl_act_option.Text, ">"})
				End If
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " load_new_code(): " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Exclamation, "cmb_act_code_SelectedIndexChanged")
			End Try
		End Sub

		' Token: 0x06000094 RID: 148 RVA: 0x0000C440 File Offset: 0x0000A640
		Public Sub update_prog_code_to_PLC()
			Try
				If Me.pvi_ok Then
					If Me.progr_code_tmp IsNot Nothing Then
						Me.Prog_Code.Value = New Value(Me.progr_code_tmp)
						Me.add_log(-1, 208, String.Concat(New String() {Me.cma_labels(300), " ", Me.lbl_code_Load.Text, " | ", Me.lbl_act_batch.Text, " | ", Me.lbl_act_option.Text}))
					End If
				Else
					Me.add_log(-1, 209, "PVI not ready")
				End If
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " update_prog_code() " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Exclamation, "cmb_act_code_SelectedIndexChanged")
			End Try
		End Sub

		' Token: 0x06000095 RID: 149 RVA: 0x0000C540 File Offset: 0x0000A740
		Public Sub ProcessDirectory(PROG_PATH As String)
			Try
				If Directory.Exists(PROG_PATH) Then
					Dim files As String() = Directory.GetFiles(PROG_PATH)
					If files IsNot Nothing Then
						For Each path As String In files
							Me.ProcessFile(path)
						Next
						For Each childPath As String In Directory.GetDirectories(PROG_PATH)
							Me.ProcessDirectory(childPath)
						Next
					End If
				End If
			Catch ex As System.Exception
				Interaction.MsgBox("ProcessDirectory() : " + ex.Message, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x06000096 RID: 150 RVA: 0x0000C5E4 File Offset: 0x0000A7E4
		Public Sub ProcessFile(path As String)
			' The following expression was wrapped in a checked-statement
			Try
				Dim text As String = Strings.Trim(path)
				Dim num As Integer = 0
				Do
					Dim num2 As Integer = text.IndexOf("\")
					If num2 = -1 Then
						Exit Do
					End If
					text = Strings.Right(text, text.Length - num2 - 1)
					num += 1
				Loop While num <= 100
				text = Strings.Left(text, text.Length - 4)
				Me.cmb_act_code.Items.Add(text)
				Console.WriteLine("Processed file '{0}'.", text)
			Catch ex As System.Exception
				Interaction.MsgBox("ProcessFile() : " + ex.Message, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x06000097 RID: 151 RVA: 0x0000C68C File Offset: 0x0000A88C
		Private Sub ConnectionLabels()
			Select Case Me.R1_status_idx_vb
				Case 0
					Me.lbl_status_robot1_main.Text = Me.cma_labels(80)
					Me.lbl_status_robot1.Text = Me.cma_labels(80)
					Me.lbl_status_robot1_main.BackColor = Color.Gray
					Me.lbl_status_robot1.BackColor = Color.Gray
					Me.lbl_com_robot1.Text = Me.cma_labels(80)
					Me.lbl_com_robot1.BackColor = Color.DarkOrange
				Case 1
					Me.lbl_status_robot1_main.Text = Me.cma_labels(81)
					Me.lbl_status_robot1.Text = Me.cma_labels(81)
					Me.lbl_status_robot1_main.BackColor = Color.Orange
					Me.lbl_status_robot1.BackColor = Color.Orange
					Me.lbl_com_robot1.Text = Me.cma_labels(87)
					Me.lbl_com_robot1.BackColor = Color.Lime
				Case 2
					Me.lbl_status_robot1_main.Text = Me.cma_labels(82)
					Me.lbl_status_robot1.Text = Me.cma_labels(82)
					Me.lbl_status_robot1_main.BackColor = Color.Orange
					Me.lbl_status_robot1.BackColor = Color.Orange
					Me.lbl_com_robot1.Text = Me.cma_labels(87)
					Me.lbl_com_robot1.BackColor = Color.Lime
				Case 3
					Me.lbl_status_robot1_main.Text = Me.cma_labels(83)
					Me.lbl_status_robot1.Text = Me.cma_labels(83)
					Me.lbl_status_robot1_main.BackColor = Color.Lime
					Me.lbl_status_robot1.BackColor = Color.Lime
					Me.lbl_com_robot1.Text = Me.cma_labels(87)
					Me.lbl_com_robot1.BackColor = Color.Lime
				Case 4
					Me.lbl_status_robot1_main.Text = Me.cma_labels(84)
					Me.lbl_status_robot1.Text = Me.cma_labels(84)
					Me.lbl_status_robot1_main.BackColor = Color.Orange
					Me.lbl_status_robot1.BackColor = Color.Orange
					Me.lbl_com_robot1.Text = Me.cma_labels(87)
					Me.lbl_com_robot1.BackColor = Color.Lime
				Case 5
					Me.lbl_status_robot1_main.Text = Me.cma_labels(85)
					Me.lbl_status_robot1.Text = Me.cma_labels(85)
					Me.lbl_status_robot1_main.BackColor = Color.Yellow
					Me.lbl_status_robot1.BackColor = Color.Yellow
					Me.lbl_com_robot1.Text = Me.cma_labels(87)
					Me.lbl_com_robot1.BackColor = Color.Lime
				Case 6
					Me.lbl_status_robot1_main.Text = Me.cma_labels(86)
					Me.lbl_status_robot1.Text = Me.cma_labels(86)
					Me.lbl_status_robot1.BackColor = Color.Lime
					Me.lbl_com_robot1.Text = Me.cma_labels(87)
					Me.lbl_com_robot1.BackColor = Color.Lime
					If Me.blink_step Mod 2.0 = 0.0 Then
						Me.lbl_status_robot1_main.BackColor = Color.Lime
					Else
						Me.lbl_status_robot1_main.BackColor = Color.White
					End If
				Case 7
					Me.lbl_status_robot1_main.Text = Me.cma_labels(88)
					Me.lbl_status_robot1.Text = Me.cma_labels(88)
					Me.lbl_status_robot1_main.BackColor = Color.Red
					Me.lbl_status_robot1.BackColor = Color.Red
					Me.lbl_com_robot1.Text = Me.cma_labels(87)
					Me.lbl_com_robot1.BackColor = Color.Lime
			End Select
			Select Case Me.R1_Connected
				Case 0
					Me.lbl_com_TCPIP_r1.Text = Me.cma_labels(530)
					Me.lbl_com_TCPIP_r1.BackColor = Color.DarkOrange
					Return
				Case 1
					Me.lbl_com_TCPIP_r1.Text = Me.cma_labels(530)
					Me.lbl_com_TCPIP_r1.BackColor = Color.Yellow
					If Me.R1_Connected <> Me.R1_Connected_old AndAlso Me.R1_Connected = 3 Then
						Dim text As String = "<15>"
						Me.send_stringa(text)
					End If
					Me.R1_Connected_old = Me.R1_Connected
					Return
				Case 2
					Me.lbl_com_TCPIP_r1.Text = Me.cma_labels(532)
					Me.lbl_com_TCPIP_r1.BackColor = Color.Lime
					Return
				Case 3
					Me.lbl_com_TCPIP_r1.Text = Me.cma_labels(534)
					Me.lbl_com_TCPIP_r1.BackColor = Color.Red
					Return
				Case Else
					Return
			End Select
		End Sub

		' Token: 0x06000098 RID: 152 RVA: 0x0000CB68 File Offset: 0x0000AD68
		Private Sub lbl_reset_warning_Click(sender As Object, e As EventArgs)
			Try
				If Me.pvi_ok Then
					Me.Terminal_ErrCode.Value = New Value(0)
				End If
				Me.clear_warn_vb()
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x06000099 RID: 153 RVA: 0x0000CBDC File Offset: 0x0000ADDC
		Private Sub lbl_reset_errors_Click(sender As Object, e As EventArgs)
			Me.clear_error_vb()
		End Sub

		' Token: 0x0600009A RID: 154 RVA: 0x0000CBE4 File Offset: 0x0000ADE4
		Private Sub clear_error_vb()
			Try
				Me.LblAlarmaDes.Text = ""
				Me.LblAlarmaDes.BackColor = Color.White
				If Me.pvi_ok Then
					Me.reset_error_vb.Value = New Value(True)
				End If
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x0600009B RID: 155 RVA: 0x0000CC74 File Offset: 0x0000AE74
		Private Sub clear_warn_vb()
			Try
				If Me.pvi_ok Then
					Me.Lbl_Warning_cyc.Text = ""
					Me.Lbl_Warning_cyc.BackColor = Color.White
				End If
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x0600009C RID: 156 RVA: 0x0000CCF0 File Offset: 0x0000AEF0
		Private Sub UpdateProgramList()
			Try
				Dim programListPath As String = Path.DATA_PATH + Path.PATH_PRODLIST + "ProgramList.txt"
				If New FileInfo(programListPath).Exists Then
					Dim lineCount As Integer = File.ReadAllLines(programListPath).Length
					If lineCount > 19 Then
						Me.dgv_programlist.RowCount = lineCount
					Else
						Me.dgv_programlist.RowCount = 20
					End If
					Dim row As Integer = 0
					Using streamReader As StreamReader = New StreamReader(programListPath)
						While streamReader.Peek() >= 0
							Dim array As String() = Strings.Split(streamReader.ReadLine(), "|", -1, CompareMethod.Binary)
							Me.dgv_programlist(0, row).Value = array(0)
							Me.dgv_programlist(1, row).Value = array(1)
							Me.dgv_programlist(2, row).Value = array(2)
							row += 1
						End While
					End Using
					If row <= 20 Then
						For i As Integer = row To 19
							Me.dgv_programlist(0, i).Value = ""
							Me.dgv_programlist(1, i).Value = ""
							Me.dgv_programlist(2, i).Value = ""
						Next
					End If
					Me.load_new_code()
				Else
					Interaction.MsgBox(String.Concat(New String() {Me.StrLabels(511), " (", programListPath, ")"}), MsgBoxStyle.Critical, Nothing)
					Me.dgv_programlist.Enabled = False
				End If
			Catch ex As System.Exception
				Interaction.MsgBox("UpdateProgramList : " + ex.Message, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x0600009D RID: 157 RVA: 0x0000CF38 File Offset: 0x0000B138
		Private Sub SaveProgramList()
			Try
				Dim programListPath As String = Path.DATA_PATH + Path.PATH_PRODLIST + "ProgramList.txt"
				If New FileInfo(programListPath).Exists Then
					Using streamWriter As StreamWriter = New StreamWriter(programListPath)
						Dim num2 As Integer = Me.dgv_programlist.RowCount - 1
						For i As Integer = 0 To num2
							If Operators.ConditionalCompareObjectNotEqual(Me.dgv_programlist(0, i).Value, "", False) Then
								streamWriter.WriteLine(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Me.dgv_programlist(0, i).Value, "|"), Me.dgv_programlist(1, i).Value), "|"), Me.dgv_programlist(2, i).Value))
							End If
						Next
					End Using
				Else
					Interaction.MsgBox(Me.StrLabels(511) + " (" + Path.PATH_PROGRAMS_REMOTE + "ProgramList.txt)", MsgBoxStyle.Critical, Nothing)
					Me.dgv_programlist.Enabled = False
				End If
			Catch ex As System.Exception
				Interaction.MsgBox("SaveProgramList : " + ex.Message, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x0600009E RID: 158 RVA: 0x0000D104 File Offset: 0x0000B304
		Private Sub DeleteCode(INDEX_TO_DEL As Integer)
			' The following expression was wrapped in a checked-statement
			Try
				Dim streamWriter As StreamWriter = New StreamWriter(Path.DATA_PATH + Path.PATH_PRODLIST + "ProgramList.txt")
				Dim num As Integer = Me.dgv_programlist.RowCount - 1
				For i As Integer = 0 To num
					If i <> INDEX_TO_DEL AndAlso Operators.ConditionalCompareObjectNotEqual(Me.dgv_programlist(0, i).Value, "", False) Then
						streamWriter.WriteLine(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Me.dgv_programlist(0, i).Value, "|"), Me.dgv_programlist(1, i).Value), "|"), Me.dgv_programlist(2, i).Value))
					End If
				Next
				streamWriter.Close()
				Me.UpdateProgramList()
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x0600009F RID: 159 RVA: 0x0000D21C File Offset: 0x0000B41C
		Private Function find_code_idx(code_name As String) As Integer
			' The following expression was wrapped in a checked-statement
			Dim result As Integer
			Try
				Dim array As String() = Strings.Split(code_name, "&", -1, CompareMethod.Binary)
				Dim num As Integer = Me.dgv_programlist.RowCount - 1
				Dim num2 As Integer
				For i As Integer = 0 To num
					If Operators.ConditionalCompareObjectEqual(Me.dgv_programlist(0, i).Value, array(1), False) Then
						num2 = i
					End If
				Next
				result = num2
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
				result = 0
			End Try
			Return result
		End Function

		' Token: 0x060000A0 RID: 160 RVA: 0x0000D2C4 File Offset: 0x0000B4C4
		Private Sub btn_stat_save_Click(sender As Object, e As EventArgs)
			Me.SaveProgramList()
		End Sub

		' Token: 0x060000A1 RID: 161 RVA: 0x0000D2CC File Offset: 0x0000B4CC
		Private Sub btn_stat_edit_Click(sender As Object, e As EventArgs)
			Try
				If Me.dgv_programlist.CurrentCell.RowIndex >= 0 Then
					Dim rowIndex As Integer = Me.dgv_programlist.CurrentCell.RowIndex
					Dim columnIndex As Integer = Me.dgv_programlist.CurrentCell.ColumnIndex
					Dim frmTouchKey As frmTouchKey = New frmTouchKey()
					frmTouchKey.ShowDialog()
					If frmTouchKey.Responce Then
						Me.dgv_programlist(columnIndex, rowIndex).Value = frmTouchKey.KeyText
					End If
				End If
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x060000A2 RID: 162 RVA: 0x0000D384 File Offset: 0x0000B584
		Private Sub btn_stat_insert_Click(sender As Object, e As EventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Dim streamWriter As StreamWriter = New StreamWriter(Path.DATA_PATH + Path.PATH_PRODLIST + "ProgramList.txt")
				Dim rowIndex As Integer = Me.dgv_programlist.CurrentCell.RowIndex
				Dim num As Integer = Me.dgv_programlist.RowCount - 1
				For i As Integer = 0 To num
					If i = rowIndex Then
						streamWriter.WriteLine("||")
					End If
					streamWriter.WriteLine(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Me.dgv_programlist(0, i).Value, "|"), Me.dgv_programlist(1, i).Value), "|"), Me.dgv_programlist(2, i).Value))
				Next
				streamWriter.Close()
				Me.UpdateProgramList()
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x060000A3 RID: 163 RVA: 0x0000D494 File Offset: 0x0000B694
		Private Sub btn_stat_delete_Click(sender As Object, e As EventArgs)
			Try
				Me.DeleteCode(Me.dgv_programlist.CurrentCell.RowIndex)
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x060000A4 RID: 164 RVA: 0x0000D500 File Offset: 0x0000B700
		Private Sub btn_stat_clear_Click(sender As Object, e As EventArgs)
			Try
				Using streamWriter As StreamWriter = New StreamWriter(Path.DATA_PATH + Path.PATH_PRODLIST + "ProgramList.txt")
				End Using
				Me.UpdateProgramList()
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x060000A5 RID: 165 RVA: 0x0000D578 File Offset: 0x0000B778
		Private Sub btn_stat_refresh_Click(sender As Object, e As EventArgs)
			Try
				Dim today As DateTime = DateAndTime.Today
				Dim text As String = Path.PATH_PROGRAMS_REMOTE + "ProgramList.txt"
				Dim destinationFileName As String = Path.DATA_PATH + Path.PATH_PRODLIST + "ProgramList.txt"
				If Not New FileInfo(text).Exists Then
					Me.add_log(-1, 210, String.Concat(New String() {Me.cma_labels(511), "( ", Path.DATA_PATH, Path.PATH_PRODLIST, "ProgramList.txt )"}))
				ElseIf Interaction.MsgBox(Me.cma_labels(121), MsgBoxStyle.OkCancel Or MsgBoxStyle.Critical Or MsgBoxStyle.Question, Nothing) = MsgBoxResult.Ok Then
					MyProject.Computer.FileSystem.CopyFile(text, destinationFileName, True)
					Me.UpdateProgramList()
					MyProject.Computer.FileSystem.DeleteFile(text, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin, UICancelOption.ThrowException)
				End If
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x060000A6 RID: 166 RVA: 0x0000D68C File Offset: 0x0000B88C
		Private Sub Load_prg_list()
			Me.find_code_idx(Me.Progr_Code_vb)
			Me.DeleteCode(Me.find_code_idx(Me.Progr_Code_vb))
		End Sub

		' Token: 0x060000A7 RID: 167 RVA: 0x0000D6B0 File Offset: 0x0000B8B0
		Private Sub Load_R1_stats()
			Try
				Dim today As DateTime = DateAndTime.Today
				Dim text As String = Path.DATA_PATH + Path.PATH_STATS + "StatsRobot1_" + Me.day2file(today)
				If Not New FileInfo(text).Exists Then
					Me.dgv_robot1_stats.RowCount = 11
					For row As Integer = 0 To 10
						For col As Integer = 0 To 6
							Me.dgv_robot1_stats(col, row).Value = ""
						Next
					Next
					If Me.par_en_remote_path Then
						Me.add_log(-1, 211, Me.cma_labels(508) + "( " + Conversions.ToString(today) + " )")
					End If
				Else
					Dim lineCount As Integer = File.ReadAllLines(text).Length
					If lineCount > 10 Then
						Me.dgv_robot1_stats.RowCount = lineCount
					Else
						Me.dgv_robot1_stats.RowCount = 11
					End If
					Dim row As Integer = 0
					Using streamReader As StreamReader = New StreamReader(text)
						streamReader.ReadLine()
						While streamReader.Peek() >= 0
							Dim array As String() = streamReader.ReadLine().Split(New Char() {";"c})
							For col As Integer = 0 To 6
								If array.Length > col Then
									Me.dgv_robot1_stats(col, row).Value = array(col)
								Else
									Me.dgv_robot1_stats(col, row).Value = ""
								End If
							Next
							row += 1
						End While
					End Using
					If row < 11 Then
						For j As Integer = row To 10
							For col As Integer = 0 To 6
								Me.dgv_robot1_stats(col, j).Value = ""
							Next
						Next
					End If
				End If
			Catch ex As System.Exception
				Interaction.MsgBox("Load_R1_stats : " + ex.Message, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x060000A8 RID: 168 RVA: 0x0000DA04 File Offset: 0x0000BC04
		Private Sub Copy_stats_R1()
			Try
				Dim now As DateTime = DateAndTime.Now
				Dim sourceFileName As String = Path.DATA_PATH + Path.PATH_STATS + "StatsRobot1_" + Me.day2file(now)
				Dim text As String = Path.PATH_STATS_REMOTE
				If Not New FileInfo(text).Exists Then
					Me.add_log(-1, 215, "Path DATA STATS REMOTE set in init.ini does not exist")
				Else
					text = text + "StatsRobot1_" + Me.day2file(now)
					text = Strings.Replace(text, ".csv", ".txt", 1, -1, CompareMethod.Binary)
					If Not New FileInfo(text).Exists Then
						File.Create(text).Close()
					Else
						MyProject.Computer.FileSystem.CopyFile(sourceFileName, text, True)
					End If
				End If
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x060000A9 RID: 169 RVA: 0x0000DAF8 File Offset: 0x0000BCF8
		Private Sub check_program_list()
			Try
				Dim today As DateTime = DateAndTime.Today
				Dim text As String = Path.PATH_PROGRAMS_REMOTE + "ProgramList.txt"
				Dim destinationFileName As String = Path.DATA_PATH + Path.PATH_PRODLIST + "ProgramList.txt"
				Dim fileInfo As FileInfo = New FileInfo(text)
				If fileInfo.Exists Then
					Dim str As String = String.Concat(New String() {"Bkp_ProgramList ", Conversions.ToString(today.Year), Conversions.ToString(today.Month), Conversions.ToString(today.Day), "_", Conversions.ToString(today.Hour), Conversions.ToString(today.Minute), ".txt"})
					Dim text2 As String = Path.DATA_PATH + Path.PATH_PRODLIST + Path.PATH_PRODLIST_BKP + str
					Me.date_progrlist_act = fileInfo.LastWriteTime
					If DateTime.Compare(Me.date_progrlist_act, Me.date_progrlist_old) <> 0 Then
						Me.date_progrlist_old = Me.date_progrlist_act
						MyProject.Computer.FileSystem.CopyFile(text, text2, True)
						If Me.check_programlist_is_empty() Then
							MyProject.Computer.FileSystem.CopyFile(text, destinationFileName, True)
							Me.UpdateProgramList()
							MyProject.Computer.FileSystem.DeleteFile(text, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin, UICancelOption.ThrowException)
						ElseIf Interaction.MsgBox(Me.cma_labels(121), MsgBoxStyle.OkCancel Or MsgBoxStyle.Critical Or MsgBoxStyle.Question, Nothing) = MsgBoxResult.Ok Then
							MyProject.Computer.FileSystem.CopyFile(text, destinationFileName, True)
							Me.UpdateProgramList()
							MyProject.Computer.FileSystem.DeleteFile(text, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin, UICancelOption.ThrowException)
						End If
					End If
					Me.date_progrlist_old = Me.date_progrlist_act
				End If
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x060000AA RID: 170 RVA: 0x0000DCEC File Offset: 0x0000BEEC
		Private Sub check_stats_robots()
			Try
				Dim today As DateTime = DateAndTime.Today
				Dim fileName As String = Path.DATA_PATH + Path.PATH_STATS + "StatsRobot1_" + Me.day2file(today)
				Dim fileInfo As FileInfo = New FileInfo(fileName)
				If Not fileInfo.Exists Then
					If Me.error_on_1 Then
						Me.add_log(-1, 213, Me.cma_labels(508) + "( " + Conversions.ToString(today) + " )")
						Me.error_on_1 = False
					End If
				Else
					Me.error_on_1 = True
					Me.date_statsR1_act = fileInfo.LastWriteTime
					If DateTime.Compare(Me.date_statsR1_act, Me.date_statsR1_old) <> 0 Then
						Me.Load_R1_stats()
						Me.Copy_stats_R1()
					End If
				End If
				Me.date_statsR1_old = Me.date_statsR1_act
			Catch ex As System.Exception
				Me.date_statsR1_old = Me.date_statsR1_act
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x060000AB RID: 171 RVA: 0x0000DDFC File Offset: 0x0000BFFC
		Private Function check_programlist_is_empty() As Boolean
			Dim result As Boolean = True
			Dim num As Integer = Me.dgv_programlist.RowCount - 1
			For i As Integer = 0 To num
				If Operators.ConditionalCompareObjectNotEqual(Me.dgv_programlist(0, i).Value, "", False) Then
					result = False
					Exit For
				End If
			Next
			Return result
		End Function

		' Token: 0x060000AC RID: 172 RVA: 0x0000DE4C File Offset: 0x0000C04C
		Private Function day2file(data As DateTime) As String
			Dim result As String
			Try
				Dim text As String = Strings.Format(data.Day, "00")
				Dim text2 As String = Strings.Format(data.Month, "00")
				Dim text3 As String = Strings.Format(data.Year, "0000")
				result = String.Concat(New String() {text3, "_", text2, "_", text, ".csv"})
			Catch ex As System.Exception
				Interaction.MsgBox("day2file() : " + ex.Message, MsgBoxStyle.Critical, Nothing)
			End Try
			Return result
		End Function

		' Token: 0x060000AD RID: 173 RVA: 0x0000DF0C File Offset: 0x0000C10C
		Private Sub tmr_psw_Tick(sender As Object, e As EventArgs)
			Me.disable_psw_cmds()
			Me.disable_super_psw_cmds()
			Me.tmr_psw.[Stop]()
			Me.chb_password.BackColor = SystemColors.Control
			Me.chb_password.Checked = False
		End Sub

		' Token: 0x060000AE RID: 174 RVA: 0x0000DF44 File Offset: 0x0000C144
		Private Sub chb_password_CheckedChanged(sender As Object, e As EventArgs)
			Dim checkBox As CheckBox = CType(sender, CheckBox)
			If checkBox.Checked Then
				Dim frmTouchKey As frmTouchKey = New frmTouchKey()
				frmTouchKey.UcTouchKey.InsertPassword = True
				frmTouchKey.ShowDialog()
				If frmTouchKey.Responce Then
					If Operators.CompareString(frmTouchKey.KeyText, "C1M2A3", False) = 0 Then
						checkBox.BackColor = Color.Lime
						Me.psw_popup = True
						Me.enable_psw_cmds()
						Me.enable_super_psw_cmds()
						Me.tmr_psw.Start()
						Return
					End If
					Interaction.MsgBox(Me.StrLabels(506), MsgBoxStyle.Exclamation, Nothing)
					Me.chb_password.Checked = False
					Return
				End If
			Else
				checkBox.BackColor = Color.Empty
				Me.disable_psw_cmds()
				Me.disable_super_psw_cmds()
			End If
		End Sub

		' Token: 0x060000AF RID: 175 RVA: 0x0000DFFC File Offset: 0x0000C1FC
		Private Sub enable_psw_cmds()
			Me.btn_par_edit.Enabled = True
			Me.btn_force.Enabled = True
			Me.GrpManualComands.Enabled = True
			Me.BtnOpenDoorIN.Enabled = True
			Me.BtnOpenDoorOUT.Enabled = True
			Me.btn_stat_edit.Enabled = True
			Me.btn_stat_insert.Enabled = True
			Me.btn_stat_delete.Enabled = True
			Me.btn_stat_clear.Enabled = True
			Me.btn_stat_refresh.Enabled = True
			Me.btn_stat_save.Enabled = True
			Me.grp_debug.Visible = True
		End Sub

		' Token: 0x060000B0 RID: 176 RVA: 0x0000E099 File Offset: 0x0000C299
		Private Sub enable_super_psw_cmds()
			Me.dgv_master.Enabled = True
			Me.btn_reset_cyc.Enabled = True
			Me.btn_reset_cyc.Visible = True
			Me.btn_reset_cyc_main.Enabled = True
		End Sub

		' Token: 0x060000B1 RID: 177 RVA: 0x0000E0CC File Offset: 0x0000C2CC
		Private Sub disable_psw_cmds()
			If Me.pvi_ok Then
				Me.force_out.Value = New Value(False)
			End If
			Me.dgv_dout.Columns(1).Visible = False
			Me.btn_par_edit.Enabled = False
			Me.dgv_master.Enabled = False
			Me.btn_force.Enabled = False
			Me.btn_reset_cyc.Enabled = False
			Me.btn_reset_cyc.Visible = False
			Me.btn_reset_cyc_main.Enabled = False
			Me.GrpManualComands.Enabled = False
			Me.BtnOpenDoorIN.Enabled = False
			Me.BtnOpenDoorOUT.Enabled = False
			Me.dgv_dout_IMA.[ReadOnly] = True
			Me.dgv_din_IMA.[ReadOnly] = True
			Me.btn_stat_edit.Enabled = False
			Me.btn_stat_insert.Enabled = False
			Me.btn_stat_delete.Enabled = False
			Me.btn_stat_clear.Enabled = False
			Me.btn_stat_refresh.Enabled = False
			Me.btn_stat_save.Enabled = False
			Me.grp_debug.Visible = False
		End Sub

		' Token: 0x060000B2 RID: 178 RVA: 0x0000E1E1 File Offset: 0x0000C3E1
		Private Sub disable_super_psw_cmds()
			Me.dgv_master.Enabled = False
			Me.btn_reset_cyc.Enabled = False
			Me.btn_reset_cyc.Visible = False
			Me.btn_reset_cyc_main.Enabled = False
		End Sub

		' Token: 0x060000B3 RID: 179 RVA: 0x0000E214 File Offset: 0x0000C414
		Public Sub CaricaStringhe()
			Try
				Dim text As String = Path.DATA_PATH + "\Language\" + Me.Lng + ".txt"
				If Not New FileInfo(text).Exists Then
					Interaction.MsgBox("Language file not found. Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
				End If
				Dim streamReader As StreamReader = New StreamReader(text)
				While streamReader.Peek() > -1
					Dim text2 As String = streamReader.ReadLine()
					If Operators.CompareString(Strings.UCase(text2), Strings.UCase("End"), False) = 0 Then
						Exit While
					End If
					If Operators.CompareString(Strings.Left(text2, 1), "#", False) <> 0 AndAlso Operators.CompareString(Strings.Left(text2, 1), "", False) <> 0 Then
						Dim array As String() = Strings.Split(text2, "|", -1, CompareMethod.Binary)
						If array IsNot Nothing AndAlso array.Length > 1 Then
							array(0) = Strings.Trim(array(0))
							array(1) = Strings.Trim(array(1))
							If Versioned.IsNumeric(array(0)) AndAlso Conversions.ToDouble(array(0)) < CDbl((Me.StrLabels.Length - 2)) Then
								Me.StrLabels(Conversions.ToInteger(array(0))) = array(1)
							End If
						End If
					End If
				End While
				streamReader.Close()
				streamReader.Dispose()
				Me.AssegnaLabels(Me.StrLabels)
				Me.AssegnaMessaggi(Me.StrLabels)
				Me.EnableBtnLng()
				Me.InitDiagIO()
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x060000B4 RID: 180 RVA: 0x0000E3B0 File Offset: 0x0000C5B0
		Public Sub AssegnaLabels(ByRef StringLabel As String())
			' The following expression was wrapped in a checked-statement
			Try
				Me.LblRobot1Busy.Text = StringLabel(67)
				Me.LblRobot1prgRun.Text = StringLabel(68)
				Me.LblRobot1FouriIngombro.Text = StringLabel(69)
				Me.Lbl_EmptyList_R1.Text = StringLabel(70)
				Me.Pic_barrier_load.Tag = StringLabel(50)
				Me.Pic_barrier_unload.Tag = StringLabel(51)
				Me.Pic_confirmed_load.Tag = StringLabel(52)
				Me.Pic_confirmed_unload.Tag = StringLabel(53)
				Me.Pic_doorIN_open.Tag = StringLabel(54)
				Me.Pic_doorIN_close.Tag = StringLabel(55)
				Me.Pic_doorOUT_open.Tag = StringLabel(56)
				Me.Pic_doorOUT_close.Tag = StringLabel(57)
				Me.Pic_Piece_Load.Tag = StringLabel(58)
				Me.Pic_Piece_Paint.Tag = StringLabel(59)
				Me.Pic_Piece_Unload_1.Tag = StringLabel(60)
				Me.Pic_pres_start_load.Tag = StringLabel(61)
				Me.Pic_pres_end_load.Tag = StringLabel(62)
				Me.Pic_pres_start_paint.Tag = StringLabel(63)
				Me.Pic_pres_end_paint.Tag = StringLabel(64)
				Me.Pic_pres_start_unload.Tag = StringLabel(65)
				Me.Pic_pres_end_unload.Tag = StringLabel(66)
				Me.PicRobot1Busy.Tag = StringLabel(67)
				Me.PicRobot1PrgRun.Tag = StringLabel(68)
				Me.PicRobot1FouriIngombro.Tag = StringLabel(69)
				Me.PicRobot1EmptyList.Tag = StringLabel(70)
				Me.Pic_pres_safe_unload.Tag = StringLabel(71)
				Me.Pic_Oven_doorIN_open.Tag = StringLabel(73)
				Me.Pic_Oven_doorIN_close.Tag = StringLabel(74)
				Me.Pic_pres_start_oven.Tag = StringLabel(75)
				Me.Pic_pres_end_oven.Tag = StringLabel(76)
				Me.TabControl.TabPages(0).Text = StringLabel(1)
				Me.TabControl.TabPages(1).Text = StringLabel(2)
				Me.TabControl.TabPages(2).Text = StringLabel(3)
				Me.TabControl.TabPages(3).Text = StringLabel(4)
				Me.LblLinea.Text = StringLabel(30)
				Me.Lbl_Errors.Text = StringLabel(36)
				Me.Lbl_Warning.Text = StringLabel(37)
				Me.Lbl_Emergency.Text = StringLabel(38)
				Me.lbl_PLC_On.Text = "PLC OK"
				Me.lbl_Load_st_emerg.Text = StringLabel(94)
				Me.lbl_Oven_st_emerg.Text = StringLabel(95)
				Me.lbl_Paint_st_emerg.Text = StringLabel(96)
				Me.lbl_Unload_st_emerg.Text = StringLabel(97)
				Me.lbl_plant_auto_ready.Text = StringLabel(20)
				Me.lbl_confirm_button.Text = StringLabel(21)
				Me.lbl_robots_ready.Text = StringLabel(22)
				Me.lbl_barriera_load.Text = StringLabel(23)
				Me.lbl_coder_ready.Text = StringLabel(24)
				Me.lbl_unload_done.Text = StringLabel(25)
				Me.lbl_Sirtek_plant_ready.Text = StringLabel(26)
				Me.LblCaricoConfermato.Text = StringLabel(40)
				Me.LblScaricoConfermato.Text = StringLabel(41)
				Me.lbl_status_robot1_main.Text = StringLabel(46)
				Me.GrpCarico.Text = StringLabel(47)
				Me.lbl_act_batch_l.Text = StringLabel(48)
				Me.lbl_act_option_l.Text = StringLabel(49)
				Me.LblParametriGenerali.Text = StringLabel(230)
				Me.lvw_par.Columns(1).Text = StringLabel(231)
				Me.lvw_par.Columns(2).Text = StringLabel(232)
				Me.chb_password.Text = StringLabel(233)
				Me.btn_par_edit.Text = StringLabel(234)
				Me.Lbl_communicationPLC.Text = StringLabel(256)
				Me.Lbl_com_robot1_l.Text = StringLabel(231)
				Me.GroupBox1.Text = StringLabel(250)
				Me.dgv_master.Columns(0).HeaderText = StringLabel(271)
				Me.dgv_master.Columns(1).HeaderText = StringLabel(272)
				Me.dgv_master.Columns(2).HeaderText = StringLabel(273)
				Me.GroupBox4.Text = StringLabel(275)
				Me.dgv_ciclica.Columns(0).HeaderText = StringLabel(276)
				Me.btn_reset_cyc.Text = StringLabel(278)
				Me.btn_reset_cyc_main.Text = StringLabel(278)
				Me.lbl_digital_INPUT.Text = StringLabel(280)
				Me.lbl_digital_OUTPUT.Text = StringLabel(281)
				Me.lbl_IMA_INPUT.Text = StringLabel(282)
				Me.lbl_IMA_OUTPUT.Text = StringLabel(283)
				Me.lvw_alarms.Columns(0).Text = StringLabel(290)
				Me.lvw_alarms.Columns(1).Text = StringLabel(291)
				Me.lvw_alarms.Columns(2).Text = StringLabel(292)
				Me.lvw_alarms.Columns(3).Text = StringLabel(293)
				Me.dgv_programlist.Columns(0).HeaderText = StringLabel(400)
				Me.dgv_programlist.Columns(1).HeaderText = StringLabel(401)
				Me.dgv_programlist.Columns(2).HeaderText = StringLabel(402)
				Me.dgv_robot1_stats.Columns(0).HeaderText = StringLabel(400)
				Me.dgv_robot1_stats.Columns(1).HeaderText = StringLabel(401)
				Me.dgv_robot1_stats.Columns(2).HeaderText = StringLabel(402)
				Me.dgv_robot1_stats.Columns(3).HeaderText = StringLabel(403)
				Me.dgv_robot1_stats.Columns(4).HeaderText = StringLabel(404)
				Me.dgv_robot1_stats.Columns(5).HeaderText = StringLabel(405)
				Me.dgv_robot1_stats.Columns(6).HeaderText = StringLabel(406)
				Me.lbl_robot1_stats_l.Text = StringLabel(407)
				Me.btn_stat_edit.Text = StringLabel(409)
				Me.btn_stat_insert.Text = StringLabel(410)
				Me.btn_stat_delete.Text = StringLabel(411)
				Me.btn_stat_clear.Text = StringLabel(412)
				Me.btn_stat_refresh.Text = StringLabel(413)
				Me.btn_stat_save.Text = StringLabel(414)
				Dim num As Integer = 0
				Do
					Me.cma_labels(num) = StringLabel(num)
					num += 1
				Loop While num <= 700
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x060000B5 RID: 181 RVA: 0x0000EBA8 File Offset: 0x0000CDA8
		Public Sub AssegnaMessaggi(ByRef StrLabels As String())
			Try
				Dim num As Short = 500S
				Do
					If Operators.CompareString(StrLabels(CInt(num)), "", False) = 0 Then
						StrLabels(CInt(num)) = "(cod. 00" + Conversions.ToString(CInt(num)) + ")"
					Else
						StrLabels(CInt(num)) = Strings.Trim(StrLabels(CInt(num)))
					End If
					num += 1S
				Loop While num <= 700S
				Dim num2 As Integer = num2
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x060000B6 RID: 182 RVA: 0x0000EC4C File Offset: 0x0000CE4C
		Private Sub BntLng(sender As Object, e As EventArgs)
			Try
				Dim button As Button = CType(sender, Button)
				If Operators.CompareString(Strings.UCase(button.Name), Strings.UCase(Me.BtnLngIta.Name), False) = 0 Then
					Me.Lng = "ITA"
				ElseIf Operators.CompareString(Strings.UCase(button.Name), Strings.UCase(Me.BtnLngEng.Name), False) = 0 Then
					Me.Lng = "ENG"
				ElseIf Operators.CompareString(Strings.UCase(button.Name), Strings.UCase(Me.BtnLngGer.Name), False) = 0 Then
					Me.Lng = "GER"
				ElseIf Operators.CompareString(Strings.UCase(button.Name), Strings.UCase(Me.BtnLngSpa.Name), False) = 0 Then
					Me.Lng = "SPA"
				ElseIf Operators.CompareString(Strings.UCase(button.Name), Strings.UCase(Me.BtnLngFra.Name), False) = 0 Then
					Me.Lng = "FRA"
				Else
					If Operators.CompareString(Strings.UCase(button.Name), Strings.UCase(Me.BtnLngBra.Name), False) <> 0 Then
						Interaction.MsgBox("Language not found. Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
						Return
					End If
					Me.Lng = "BRA"
				End If
				Me.CaricaStringhe()
				Me.BtnColorLng()
				If Not Me.LoadingPar Then
					Me.SavePar()
				End If
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x060000B7 RID: 183 RVA: 0x0000EE18 File Offset: 0x0000D018
		Private Sub EnableBtnLng()
			' The following expression was wrapped in a checked-statement
			Try
				Dim text As String = Path.DATA_PATH + "Language\"
				If Not MyProject.Computer.FileSystem.DirectoryExists(text) Then
					Interaction.MsgBox("Language directory not found. Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.OkOnly, Nothing)
				End If
				Me.BtnLngIta.Enabled = False
				Me.BtnLngEng.Enabled = False
				Me.BtnLngGer.Enabled = False
				Me.BtnLngSpa.Enabled = False
				Me.BtnLngFra.Enabled = False
				Me.BtnLngBra.Enabled = False
				Dim files As FileInfo() = New DirectoryInfo(text).GetFiles("*.txt")
				For i As Integer = 0 To files.Length - 1
					Dim text2 As String = files(i).Name
					Dim length As Integer = Strings.Len(text2) - Strings.Len(".txt")
					text2 = Strings.Left(text2, length)
					If Operators.CompareString(Strings.UCase(text2), "ITA", False) = 0 Then
						Me.BtnLngIta.Enabled = True
					ElseIf Operators.CompareString(Strings.UCase(text2), "ENG", False) = 0 Then
						Me.BtnLngEng.Enabled = True
					ElseIf Operators.CompareString(Strings.UCase(text2), "GER", False) = 0 Then
						Me.BtnLngGer.Enabled = True
					ElseIf Operators.CompareString(Strings.UCase(text2), "SPA", False) = 0 Then
						Me.BtnLngSpa.Enabled = True
					ElseIf Operators.CompareString(Strings.UCase(text2), "FRA", False) = 0 Then
						Me.BtnLngFra.Enabled = True
					ElseIf Operators.CompareString(Strings.UCase(text2), "BRA", False) = 0 Then
						Me.BtnLngBra.Enabled = True
					End If
				Next
				Me.BtnColorLng()
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x060000B8 RID: 184 RVA: 0x0000F01C File Offset: 0x0000D21C
		Public Sub BtnColorLng()
			Try
				If Operators.CompareString(Me.Lng, "ITA", False) = 0 Then
					Me.BtnLngIta.BackColor = Color.Orange
					Me.BtnLngEng.BackColor = SystemColors.Control
					Me.BtnLngGer.BackColor = SystemColors.Control
					Me.BtnLngSpa.BackColor = SystemColors.Control
					Me.BtnLngFra.BackColor = SystemColors.Control
					Me.BtnLngBra.BackColor = SystemColors.Control
				ElseIf Operators.CompareString(Me.Lng, "ENG", False) = 0 Then
					Me.BtnLngIta.BackColor = SystemColors.Control
					Me.BtnLngEng.BackColor = Color.Orange
					Me.BtnLngGer.BackColor = SystemColors.Control
					Me.BtnLngSpa.BackColor = SystemColors.Control
					Me.BtnLngFra.BackColor = SystemColors.Control
					Me.BtnLngBra.BackColor = SystemColors.Control
				ElseIf Operators.CompareString(Me.Lng, "GER", False) = 0 Then
					Me.BtnLngIta.BackColor = SystemColors.Control
					Me.BtnLngEng.BackColor = SystemColors.Control
					Me.BtnLngGer.BackColor = Color.Orange
					Me.BtnLngSpa.BackColor = SystemColors.Control
					Me.BtnLngFra.BackColor = SystemColors.Control
					Me.BtnLngBra.BackColor = SystemColors.Control
				ElseIf Operators.CompareString(Me.Lng, "SPA", False) = 0 Then
					Me.BtnLngIta.BackColor = SystemColors.Control
					Me.BtnLngEng.BackColor = SystemColors.Control
					Me.BtnLngGer.BackColor = SystemColors.Control
					Me.BtnLngSpa.BackColor = Color.Orange
					Me.BtnLngFra.BackColor = SystemColors.Control
					Me.BtnLngBra.BackColor = SystemColors.Control
				ElseIf Operators.CompareString(Me.Lng, "FRA", False) = 0 Then
					Me.BtnLngIta.BackColor = SystemColors.Control
					Me.BtnLngEng.BackColor = SystemColors.Control
					Me.BtnLngGer.BackColor = SystemColors.Control
					Me.BtnLngSpa.BackColor = SystemColors.Control
					Me.BtnLngFra.BackColor = Color.Orange
					Me.BtnLngBra.BackColor = SystemColors.Control
				ElseIf Operators.CompareString(Me.Lng, "BRA", False) = 0 Then
					Me.BtnLngIta.BackColor = SystemColors.Control
					Me.BtnLngEng.BackColor = SystemColors.Control
					Me.BtnLngGer.BackColor = SystemColors.Control
					Me.BtnLngSpa.BackColor = SystemColors.Control
					Me.BtnLngFra.BackColor = SystemColors.Control
					Me.BtnLngBra.BackColor = Color.Orange
				End If
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x060000B9 RID: 185 RVA: 0x0000F344 File Offset: 0x0000D544
		Private Sub BtnGotoRiposo_Click(sender As Object, e As EventArgs)
			If Me.pvi_ok Then
				Me.cmd_TogglePaintDoorIN.Value = New Value(True)
			End If
		End Sub

		' Token: 0x060000BA RID: 186 RVA: 0x0000F35F File Offset: 0x0000D55F
		Private Sub BtnRobotDoors_Click(sender As Object, e As EventArgs)
			If Me.pvi_ok Then
				Me.cmd_TogglePaintDoorOUT.Value = New Value(True)
			End If
		End Sub

		' Token: 0x060000BB RID: 187 RVA: 0x0000F37C File Offset: 0x0000D57C
		Private Sub tmr_eth_Tick(sender As Object, e As EventArgs)
			Me.blink_step += 1.0
			If Me.blink_step >= 300000.0 Then
				Me.blink_step = 0.0
			End If
			Me.ConnectionLabels()
			Me.check_program_list()
			If Me.par_en_remote_path Then
				Me.check_stats_robots()
			End If
		End Sub

		' Token: 0x060000BC RID: 188 RVA: 0x0000F3DC File Offset: 0x0000D5DC
		Private Sub Vis_main_page()
			Try
				If Me.Plant.DO_AUTO_Lamp And Me.Plant.DO_POW_ON_Lamp Then
					Me.Pic_plant_auto_ready.BackColor = Color.LimeGreen
				Else
					Me.Pic_plant_auto_ready.BackColor = Color.Silver
				End If
				If Me.LoadTape_vb.DO_Confirm_Lamp Then
					Me.Pic_confirm_button.BackColor = Color.LimeGreen
				Else
					Me.Pic_confirm_button.BackColor = Color.Silver
				End If
				If (If((-If(((Me.R1_status_idx_vb = 3) > False), 1, 0)), 1, 0) And Me.R1_safe_position_vb And (If((-If(((Me.R2_status_idx_vb = 3) > False), 1, 0)), 1, 0) And Me.R2_safe_position_vb) And If((-If((Me.R1_carter_Low_vb > False), 1, 0)), 1, 0)) <> 0 Then
					Me.Pic_robots_ready.BackColor = Color.LimeGreen
				Else
					Me.Pic_robots_ready.BackColor = Color.Silver
				End If
				If Me.LoadTape_vb.DI_Barrier Then
					Me.Pic_barrier_load_ready.BackColor = Color.LimeGreen
				Else
					Me.Pic_barrier_load_ready.BackColor = Color.Silver
				End If
				If Operators.CompareString(Me.Progr_Code_vb, "", False) = 0 Or Operators.CompareString(Me.Progr_Code_vb, "Empty Code ", False) = 0 Or (Me.LoadTape_vb.DI_Presence_start And Me.LoadTape_vb.DI_Presence_end) Then
					Me.Pic_barrier_load_ready.BackColor = Color.LimeGreen
				Else
					Me.Pic_barrier_load_ready.BackColor = Color.Silver
				End If
			Catch ex As System.Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x060000BD RID: 189 RVA: 0x0000F598 File Offset: 0x0000D798
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Me.Copy_stats_R1()
		End Sub

		' Token: 0x060000BE RID: 190 RVA: 0x0000F5A0 File Offset: 0x0000D7A0
		Private Sub btn_Step_done_Click(sender As Object, e As EventArgs)
			Me.Load_prg_list()
		End Sub

		' Token: 0x060000BF RID: 191 RVA: 0x0000F5A8 File Offset: 0x0000D7A8
		Private Sub lbl_code_Oven_Click(sender As Object, e As EventArgs)
			If Not Me.psw_popup Then
				Interaction.MsgBox(Me.StrLabels(505), MsgBoxStyle.OkOnly, Nothing)
				Return
			End If
			If Interaction.MsgBox("reset_prog code?", MsgBoxStyle.OkCancel Or MsgBoxStyle.AbortRetryIgnore Or MsgBoxStyle.Critical Or MsgBoxStyle.Question, Nothing) = MsgBoxResult.Yes AndAlso Me.pvi_ok Then
				Me.OvenTape.Value("Prog_Code") = New Value("")
				Me.add_log(-1, Conversions.ToInteger("INFO"), "Oven tape code removed")
			End If
		End Sub

		' Token: 0x060000C0 RID: 192 RVA: 0x0000F620 File Offset: 0x0000D820
		Private Sub lbl_code_Paint_Click(sender As Object, e As EventArgs)
			If Not Me.psw_popup Then
				Interaction.MsgBox(Me.StrLabels(505), MsgBoxStyle.OkOnly, Nothing)
				Return
			End If
			If Interaction.MsgBox("reset_prog code?", MsgBoxStyle.OkCancel Or MsgBoxStyle.AbortRetryIgnore Or MsgBoxStyle.Critical Or MsgBoxStyle.Question, Nothing) = MsgBoxResult.Yes AndAlso Me.pvi_ok Then
				Me.PaintTape.Value("Prog_Code") = New Value("")
				Me.add_log(-1, Conversions.ToInteger("INFO"), "Paint tape code removed")
			End If
		End Sub

		' Token: 0x17000019 RID: 25
		' (get) Token: 0x060000C3 RID: 195 RVA: 0x000181E8 File Offset: 0x000163E8
		' (set) Token: 0x060000C4 RID: 196 RVA: 0x000181F0 File Offset: 0x000163F0
		Friend Overridable Property TabControl As TabControl

		' Token: 0x1700001A RID: 26
		' (get) Token: 0x060000C5 RID: 197 RVA: 0x000181F9 File Offset: 0x000163F9
		' (set) Token: 0x060000C6 RID: 198 RVA: 0x00018201 File Offset: 0x00016401
		Friend Overridable Property TabPage1 As TabPage

		' Token: 0x1700001B RID: 27
		' (get) Token: 0x060000C7 RID: 199 RVA: 0x0001820A File Offset: 0x0001640A
		' (set) Token: 0x060000C8 RID: 200 RVA: 0x00018212 File Offset: 0x00016412
		Friend Overridable Property TabPage2 As TabPage

		' Token: 0x1700001C RID: 28
		' (get) Token: 0x060000C9 RID: 201 RVA: 0x0001821B File Offset: 0x0001641B
		' (set) Token: 0x060000CA RID: 202 RVA: 0x00018223 File Offset: 0x00016423
		Friend Overridable Property TabPage3 As TabPage

		' Token: 0x1700001D RID: 29
		' (get) Token: 0x060000CB RID: 203 RVA: 0x0001822C File Offset: 0x0001642C
		' (set) Token: 0x060000CC RID: 204 RVA: 0x00018234 File Offset: 0x00016434
		Friend Overridable Property LblParametriGenerali As Label

		' Token: 0x1700001E RID: 30
		' (get) Token: 0x060000CD RID: 205 RVA: 0x0001823D File Offset: 0x0001643D
		' (set) Token: 0x060000CE RID: 206 RVA: 0x00018248 File Offset: 0x00016448
		Friend Overridable Property lvw_par As ListView
			<CompilerGenerated()>
			Get
				Return Me._lvw_par
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ListView)
				Dim value2 As EventHandler = AddressOf Me.lvw_par_SelectedIndexChanged
				Dim lvw_par As ListView = Me._lvw_par
				If lvw_par IsNot Nothing Then
					RemoveHandler lvw_par.SelectedIndexChanged, value2
				End If
				Me._lvw_par = value
				lvw_par = Me._lvw_par
				If lvw_par IsNot Nothing Then
					AddHandler lvw_par.SelectedIndexChanged, value2
				End If
			End Set
		End Property

		' Token: 0x1700001F RID: 31
		' (get) Token: 0x060000CF RID: 207 RVA: 0x0001828B File Offset: 0x0001648B
		' (set) Token: 0x060000D0 RID: 208 RVA: 0x00018293 File Offset: 0x00016493
		Friend Overridable Property ColumnHeader4 As ColumnHeader

		' Token: 0x17000020 RID: 32
		' (get) Token: 0x060000D1 RID: 209 RVA: 0x0001829C File Offset: 0x0001649C
		' (set) Token: 0x060000D2 RID: 210 RVA: 0x000182A4 File Offset: 0x000164A4
		Friend Overridable Property ColumnHeader5 As ColumnHeader

		' Token: 0x17000021 RID: 33
		' (get) Token: 0x060000D3 RID: 211 RVA: 0x000182AD File Offset: 0x000164AD
		' (set) Token: 0x060000D4 RID: 212 RVA: 0x000182B5 File Offset: 0x000164B5
		Friend Overridable Property ColumnHeader6 As ColumnHeader

		' Token: 0x17000022 RID: 34
		' (get) Token: 0x060000D5 RID: 213 RVA: 0x000182BE File Offset: 0x000164BE
		' (set) Token: 0x060000D6 RID: 214 RVA: 0x000182C8 File Offset: 0x000164C8
		Friend Overridable Property btn_par_edit As Button
			<CompilerGenerated()>
			Get
				Return Me._btn_par_edit
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As EventHandler = AddressOf Me.btn_par_edit_Click
				Dim btn_par_edit As Button = Me._btn_par_edit
				If btn_par_edit IsNot Nothing Then
					RemoveHandler btn_par_edit.Click, value2
				End If
				Me._btn_par_edit = value
				btn_par_edit = Me._btn_par_edit
				If btn_par_edit IsNot Nothing Then
					AddHandler btn_par_edit.Click, value2
				End If
			End Set
		End Property

		' Token: 0x17000023 RID: 35
		' (get) Token: 0x060000D7 RID: 215 RVA: 0x0001830B File Offset: 0x0001650B
		' (set) Token: 0x060000D8 RID: 216 RVA: 0x00018313 File Offset: 0x00016513
		Friend Overridable Property Lbl_AUTO_Plant As Label

		' Token: 0x17000024 RID: 36
		' (get) Token: 0x060000D9 RID: 217 RVA: 0x0001831C File Offset: 0x0001651C
		' (set) Token: 0x060000DA RID: 218 RVA: 0x00018324 File Offset: 0x00016524
		Friend Overridable Property il_led As ImageList

		' Token: 0x17000025 RID: 37
		' (get) Token: 0x060000DB RID: 219 RVA: 0x0001832D File Offset: 0x0001652D
		' (set) Token: 0x060000DC RID: 220 RVA: 0x00018335 File Offset: 0x00016535
		Friend Overridable Property lvw_alarms As ListView

		' Token: 0x17000026 RID: 38
		' (get) Token: 0x060000DD RID: 221 RVA: 0x0001833E File Offset: 0x0001653E
		' (set) Token: 0x060000DE RID: 222 RVA: 0x00018346 File Offset: 0x00016546
		Friend Overridable Property ColumnHeader8 As ColumnHeader

		' Token: 0x17000027 RID: 39
		' (get) Token: 0x060000DF RID: 223 RVA: 0x0001834F File Offset: 0x0001654F
		' (set) Token: 0x060000E0 RID: 224 RVA: 0x00018357 File Offset: 0x00016557
		Friend Overridable Property ColumnHeader9 As ColumnHeader

		' Token: 0x17000028 RID: 40
		' (get) Token: 0x060000E1 RID: 225 RVA: 0x00018360 File Offset: 0x00016560
		' (set) Token: 0x060000E2 RID: 226 RVA: 0x00018368 File Offset: 0x00016568
		Friend Overridable Property ColumnHeader10 As ColumnHeader

		' Token: 0x17000029 RID: 41
		' (get) Token: 0x060000E3 RID: 227 RVA: 0x00018371 File Offset: 0x00016571
		' (set) Token: 0x060000E4 RID: 228 RVA: 0x00018379 File Offset: 0x00016579
		Friend Overridable Property ColumnHeader11 As ColumnHeader

		' Token: 0x1700002A RID: 42
		' (get) Token: 0x060000E5 RID: 229 RVA: 0x00018382 File Offset: 0x00016582
		' (set) Token: 0x060000E6 RID: 230 RVA: 0x0001838C File Offset: 0x0001658C
		Friend Overridable Property dgv_ax As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgv_ax
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim value2 As DataGridViewCellEventHandler = AddressOf Me.dgvPrjDwgs_CellMouseEnter
				Dim dgv_ax As DataGridView = Me._dgv_ax
				If dgv_ax IsNot Nothing Then
					RemoveHandler dgv_ax.CellClick, value2
				End If
				Me._dgv_ax = value
				dgv_ax = Me._dgv_ax
				If dgv_ax IsNot Nothing Then
					AddHandler dgv_ax.CellClick, value2
				End If
			End Set
		End Property

		' Token: 0x1700002B RID: 43
		' (get) Token: 0x060000E7 RID: 231 RVA: 0x000183CF File Offset: 0x000165CF
		' (set) Token: 0x060000E8 RID: 232 RVA: 0x000183D7 File Offset: 0x000165D7
		Friend Overridable Property LblLinea As Label

		' Token: 0x1700002C RID: 44
		' (get) Token: 0x060000E9 RID: 233 RVA: 0x000183E0 File Offset: 0x000165E0
		' (set) Token: 0x060000EA RID: 234 RVA: 0x000183E8 File Offset: 0x000165E8
		Friend Overridable Property il_anta As ImageList

		' Token: 0x1700002D RID: 45
		' (get) Token: 0x060000EB RID: 235 RVA: 0x000183F1 File Offset: 0x000165F1
		' (set) Token: 0x060000EC RID: 236 RVA: 0x000183F9 File Offset: 0x000165F9
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x1700002E RID: 46
		' (get) Token: 0x060000ED RID: 237 RVA: 0x00018402 File Offset: 0x00016602
		' (set) Token: 0x060000EE RID: 238 RVA: 0x0001840C File Offset: 0x0001660C
		Friend Overridable Property dgv_master As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgv_master
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim value2 As DataGridViewCellEventHandler = AddressOf Me.dgv_master_CellContentClick
				Dim dgv_master As DataGridView = Me._dgv_master
				If dgv_master IsNot Nothing Then
					RemoveHandler dgv_master.CellContentClick, value2
				End If
				Me._dgv_master = value
				dgv_master = Me._dgv_master
				If dgv_master IsNot Nothing Then
					AddHandler dgv_master.CellContentClick, value2
				End If
			End Set
		End Property

		' Token: 0x1700002F RID: 47
		' (get) Token: 0x060000EF RID: 239 RVA: 0x0001844F File Offset: 0x0001664F
		' (set) Token: 0x060000F0 RID: 240 RVA: 0x00018457 File Offset: 0x00016657
		Friend Overridable Property SerialPort1 As SerialPort

		' Token: 0x17000030 RID: 48
		' (get) Token: 0x060000F1 RID: 241 RVA: 0x00018460 File Offset: 0x00016660
		' (set) Token: 0x060000F2 RID: 242 RVA: 0x00018468 File Offset: 0x00016668
		Friend Overridable Property tmr_barcode As Timer

		' Token: 0x17000031 RID: 49
		' (get) Token: 0x060000F3 RID: 243 RVA: 0x00018471 File Offset: 0x00016671
		' (set) Token: 0x060000F4 RID: 244 RVA: 0x0001847C File Offset: 0x0001667C
		Friend Overridable Property tmr_start As Timer
			<CompilerGenerated()>
			Get
				Return Me._tmr_start
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Timer)
				Dim value2 As EventHandler = AddressOf Me.tmr_start_Tick
				Dim tmr_start As Timer = Me._tmr_start
				If tmr_start IsNot Nothing Then
					RemoveHandler tmr_start.Tick, value2
				End If
				Me._tmr_start = value
				tmr_start = Me._tmr_start
				If tmr_start IsNot Nothing Then
					AddHandler tmr_start.Tick, value2
				End If
			End Set
		End Property

		' Token: 0x17000032 RID: 50
		' (get) Token: 0x060000F5 RID: 245 RVA: 0x000184BF File Offset: 0x000166BF
		' (set) Token: 0x060000F6 RID: 246 RVA: 0x000184C8 File Offset: 0x000166C8
		Friend Overridable Property tmr_eth As Timer
			<CompilerGenerated()>
			Get
				Return Me._tmr_eth
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Timer)
				Dim value2 As EventHandler = AddressOf Me.tmr_eth_Tick
				Dim tmr_eth As Timer = Me._tmr_eth
				If tmr_eth IsNot Nothing Then
					RemoveHandler tmr_eth.Tick, value2
				End If
				Me._tmr_eth = value
				tmr_eth = Me._tmr_eth
				If tmr_eth IsNot Nothing Then
					AddHandler tmr_eth.Tick, value2
				End If
			End Set
		End Property

		' Token: 0x17000033 RID: 51
		' (get) Token: 0x060000F7 RID: 247 RVA: 0x0001850B File Offset: 0x0001670B
		' (set) Token: 0x060000F8 RID: 248 RVA: 0x00018514 File Offset: 0x00016714
		Friend Overridable Property chb_password As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._chb_password
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim value2 As EventHandler = AddressOf Me.chb_password_CheckedChanged
				Dim chb_password As CheckBox = Me._chb_password
				If chb_password IsNot Nothing Then
					RemoveHandler chb_password.CheckedChanged, value2
				End If
				Me._chb_password = value
				chb_password = Me._chb_password
				If chb_password IsNot Nothing Then
					AddHandler chb_password.CheckedChanged, value2
				End If
			End Set
		End Property

		' Token: 0x17000034 RID: 52
		' (get) Token: 0x060000F9 RID: 249 RVA: 0x00018557 File Offset: 0x00016757
		' (set) Token: 0x060000FA RID: 250 RVA: 0x0001855F File Offset: 0x0001675F
		Friend Overridable Property GroupBox4 As GroupBox

		' Token: 0x17000035 RID: 53
		' (get) Token: 0x060000FB RID: 251 RVA: 0x00018568 File Offset: 0x00016768
		' (set) Token: 0x060000FC RID: 252 RVA: 0x00018570 File Offset: 0x00016770
		Friend Overridable Property dgv_ciclica As DataGridView

		' Token: 0x17000036 RID: 54
		' (get) Token: 0x060000FD RID: 253 RVA: 0x00018579 File Offset: 0x00016779
		' (set) Token: 0x060000FE RID: 254 RVA: 0x00018581 File Offset: 0x00016781
		Friend Overridable Property DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn

		' Token: 0x17000037 RID: 55
		' (get) Token: 0x060000FF RID: 255 RVA: 0x0001858A File Offset: 0x0001678A
		' (set) Token: 0x06000100 RID: 256 RVA: 0x00018592 File Offset: 0x00016792
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17000038 RID: 56
		' (get) Token: 0x06000101 RID: 257 RVA: 0x0001859B File Offset: 0x0001679B
		' (set) Token: 0x06000102 RID: 258 RVA: 0x000185A3 File Offset: 0x000167A3
		Friend Overridable Property DataGridViewButtonColumn1 As DataGridViewButtonColumn

		' Token: 0x17000039 RID: 57
		' (get) Token: 0x06000103 RID: 259 RVA: 0x000185AC File Offset: 0x000167AC
		' (set) Token: 0x06000104 RID: 260 RVA: 0x000185B4 File Offset: 0x000167B4
		Friend Overridable Property SerialPortBilancia As SerialPort

		' Token: 0x1700003A RID: 58
		' (get) Token: 0x06000105 RID: 261 RVA: 0x000185BD File Offset: 0x000167BD
		' (set) Token: 0x06000106 RID: 262 RVA: 0x000185C8 File Offset: 0x000167C8
		Friend Overridable Property btn_reset_cyc As Button
			<CompilerGenerated()>
			Get
				Return Me._btn_reset_cyc
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As EventHandler = AddressOf Me.btn_reset_cyc_Click
				Dim btn_reset_cyc As Button = Me._btn_reset_cyc
				If btn_reset_cyc IsNot Nothing Then
					RemoveHandler btn_reset_cyc.Click, value2
				End If
				Me._btn_reset_cyc = value
				btn_reset_cyc = Me._btn_reset_cyc
				If btn_reset_cyc IsNot Nothing Then
					AddHandler btn_reset_cyc.Click, value2
				End If
			End Set
		End Property

		' Token: 0x1700003B RID: 59
		' (get) Token: 0x06000107 RID: 263 RVA: 0x0001860B File Offset: 0x0001680B
		' (set) Token: 0x06000108 RID: 264 RVA: 0x00018613 File Offset: 0x00016813
		Friend Overridable Property SerialPort2 As SerialPort

		' Token: 0x1700003C RID: 60
		' (get) Token: 0x06000109 RID: 265 RVA: 0x0001861C File Offset: 0x0001681C
		' (set) Token: 0x0600010A RID: 266 RVA: 0x00018624 File Offset: 0x00016824
		Friend Overridable Property PnlRobot As Panel

		' Token: 0x1700003D RID: 61
		' (get) Token: 0x0600010B RID: 267 RVA: 0x0001862D File Offset: 0x0001682D
		' (set) Token: 0x0600010C RID: 268 RVA: 0x00018635 File Offset: 0x00016835
		Friend Overridable Property GrpCarico As GroupBox

		' Token: 0x1700003E RID: 62
		' (get) Token: 0x0600010D RID: 269 RVA: 0x0001863E File Offset: 0x0001683E
		' (set) Token: 0x0600010E RID: 270 RVA: 0x00018646 File Offset: 0x00016846
		Friend Overridable Property Lbl_MotorON_Plant As Label

		' Token: 0x1700003F RID: 63
		' (get) Token: 0x0600010F RID: 271 RVA: 0x0001864F File Offset: 0x0001684F
		' (set) Token: 0x06000110 RID: 272 RVA: 0x00018657 File Offset: 0x00016857
		Friend Overridable Property LblAlarmaDes As Label

		' Token: 0x17000040 RID: 64
		' (get) Token: 0x06000111 RID: 273 RVA: 0x00018660 File Offset: 0x00016860
		' (set) Token: 0x06000112 RID: 274 RVA: 0x00018668 File Offset: 0x00016868
		Friend Overridable Property lbl_PLC_On As Label

		' Token: 0x17000041 RID: 65
		' (get) Token: 0x06000113 RID: 275 RVA: 0x00018671 File Offset: 0x00016871
		' (set) Token: 0x06000114 RID: 276 RVA: 0x00018679 File Offset: 0x00016879
		Friend Overridable Property GrpLng As GroupBox

		' Token: 0x17000042 RID: 66
		' (get) Token: 0x06000115 RID: 277 RVA: 0x00018682 File Offset: 0x00016882
		' (set) Token: 0x06000116 RID: 278 RVA: 0x0001868A File Offset: 0x0001688A
		Friend Overridable Property BtnLngBra As Button

		' Token: 0x17000043 RID: 67
		' (get) Token: 0x06000117 RID: 279 RVA: 0x00018693 File Offset: 0x00016893
		' (set) Token: 0x06000118 RID: 280 RVA: 0x0001869B File Offset: 0x0001689B
		Friend Overridable Property BtnLngSpa As Button

		' Token: 0x17000044 RID: 68
		' (get) Token: 0x06000119 RID: 281 RVA: 0x000186A4 File Offset: 0x000168A4
		' (set) Token: 0x0600011A RID: 282 RVA: 0x000186AC File Offset: 0x000168AC
		Friend Overridable Property BtnLngGer As Button

		' Token: 0x17000045 RID: 69
		' (get) Token: 0x0600011B RID: 283 RVA: 0x000186B5 File Offset: 0x000168B5
		' (set) Token: 0x0600011C RID: 284 RVA: 0x000186BD File Offset: 0x000168BD
		Friend Overridable Property BtnLngEng As Button

		' Token: 0x17000046 RID: 70
		' (get) Token: 0x0600011D RID: 285 RVA: 0x000186C6 File Offset: 0x000168C6
		' (set) Token: 0x0600011E RID: 286 RVA: 0x000186CE File Offset: 0x000168CE
		Friend Overridable Property BtnLngFra As Button

		' Token: 0x17000047 RID: 71
		' (get) Token: 0x0600011F RID: 287 RVA: 0x000186D7 File Offset: 0x000168D7
		' (set) Token: 0x06000120 RID: 288 RVA: 0x000186DF File Offset: 0x000168DF
		Friend Overridable Property BtnLngIta As Button

		' Token: 0x17000048 RID: 72
		' (get) Token: 0x06000121 RID: 289 RVA: 0x000186E8 File Offset: 0x000168E8
		' (set) Token: 0x06000122 RID: 290 RVA: 0x000186F0 File Offset: 0x000168F0
		Friend Overridable Property TmrShowDescrizione As Timer
			<CompilerGenerated()>
			Get
				Return Me._TmrShowDescrizione
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Timer)
				Dim value2 As EventHandler = AddressOf Me.TmrShowDescrizione_Tick
				Dim tmrShowDescrizione As Timer = Me._TmrShowDescrizione
				If tmrShowDescrizione IsNot Nothing Then
					RemoveHandler tmrShowDescrizione.Tick, value2
				End If
				Me._TmrShowDescrizione = value
				tmrShowDescrizione = Me._TmrShowDescrizione
				If tmrShowDescrizione IsNot Nothing Then
					AddHandler tmrShowDescrizione.Tick, value2
				End If
			End Set
		End Property

		' Token: 0x17000049 RID: 73
		' (get) Token: 0x06000123 RID: 291 RVA: 0x00018733 File Offset: 0x00016933
		' (set) Token: 0x06000124 RID: 292 RVA: 0x0001873B File Offset: 0x0001693B
		Friend Overridable Property DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn

		' Token: 0x1700004A RID: 74
		' (get) Token: 0x06000125 RID: 293 RVA: 0x00018744 File Offset: 0x00016944
		' (set) Token: 0x06000126 RID: 294 RVA: 0x0001874C File Offset: 0x0001694C
		Friend Overridable Property DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn

		' Token: 0x1700004B RID: 75
		' (get) Token: 0x06000127 RID: 295 RVA: 0x00018755 File Offset: 0x00016955
		' (set) Token: 0x06000128 RID: 296 RVA: 0x0001875D File Offset: 0x0001695D
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x1700004C RID: 76
		' (get) Token: 0x06000129 RID: 297 RVA: 0x00018766 File Offset: 0x00016966
		' (set) Token: 0x0600012A RID: 298 RVA: 0x0001876E File Offset: 0x0001696E
		Friend Overridable Property GrpManualComands As GroupBox

		' Token: 0x1700004D RID: 77
		' (get) Token: 0x0600012B RID: 299 RVA: 0x00018777 File Offset: 0x00016977
		' (set) Token: 0x0600012C RID: 300 RVA: 0x00018780 File Offset: 0x00016980
		Friend Overridable Property TmrChekbox As Timer
			<CompilerGenerated()>
			Get
				Return Me._TmrChekbox
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Timer)
				Dim value2 As EventHandler = AddressOf Me.TmrChekbox_Tick
				Dim tmrChekbox As Timer = Me._TmrChekbox
				If tmrChekbox IsNot Nothing Then
					RemoveHandler tmrChekbox.Tick, value2
				End If
				Me._TmrChekbox = value
				tmrChekbox = Me._TmrChekbox
				If tmrChekbox IsNot Nothing Then
					AddHandler tmrChekbox.Tick, value2
				End If
			End Set
		End Property

		' Token: 0x1700004E RID: 78
		' (get) Token: 0x0600012D RID: 301 RVA: 0x000187C3 File Offset: 0x000169C3
		' (set) Token: 0x0600012E RID: 302 RVA: 0x000187CB File Offset: 0x000169CB
		Friend Overridable Property PictureBox2 As PictureBox

		' Token: 0x1700004F RID: 79
		' (get) Token: 0x0600012F RID: 303 RVA: 0x000187D4 File Offset: 0x000169D4
		' (set) Token: 0x06000130 RID: 304 RVA: 0x000187DC File Offset: 0x000169DC
		Friend Overridable Property Pic_pres_end_unload As PictureBox

		' Token: 0x17000050 RID: 80
		' (get) Token: 0x06000131 RID: 305 RVA: 0x000187E5 File Offset: 0x000169E5
		' (set) Token: 0x06000132 RID: 306 RVA: 0x000187ED File Offset: 0x000169ED
		Friend Overridable Property Pic_barrier_unload As PictureBox

		' Token: 0x17000051 RID: 81
		' (get) Token: 0x06000133 RID: 307 RVA: 0x000187F6 File Offset: 0x000169F6
		' (set) Token: 0x06000134 RID: 308 RVA: 0x000187FE File Offset: 0x000169FE
		Friend Overridable Property Pic_confirmed_unload As PictureBox

		' Token: 0x17000052 RID: 82
		' (get) Token: 0x06000135 RID: 309 RVA: 0x00018807 File Offset: 0x00016A07
		' (set) Token: 0x06000136 RID: 310 RVA: 0x0001880F File Offset: 0x00016A0F
		Friend Overridable Property Pic_pres_end_load As PictureBox

		' Token: 0x17000053 RID: 83
		' (get) Token: 0x06000137 RID: 311 RVA: 0x00018818 File Offset: 0x00016A18
		' (set) Token: 0x06000138 RID: 312 RVA: 0x00018820 File Offset: 0x00016A20
		Friend Overridable Property Pic_barrier_load As PictureBox

		' Token: 0x17000054 RID: 84
		' (get) Token: 0x06000139 RID: 313 RVA: 0x00018829 File Offset: 0x00016A29
		' (set) Token: 0x0600013A RID: 314 RVA: 0x00018831 File Offset: 0x00016A31
		Friend Overridable Property Pic_confirmed_load As PictureBox

		' Token: 0x17000055 RID: 85
		' (get) Token: 0x0600013B RID: 315 RVA: 0x0001883A File Offset: 0x00016A3A
		' (set) Token: 0x0600013C RID: 316 RVA: 0x00018842 File Offset: 0x00016A42
		Friend Overridable Property Pic_pres_start_paint As PictureBox

		' Token: 0x17000056 RID: 86
		' (get) Token: 0x0600013D RID: 317 RVA: 0x0001884B File Offset: 0x00016A4B
		' (set) Token: 0x0600013E RID: 318 RVA: 0x00018853 File Offset: 0x00016A53
		Friend Overridable Property Pic_doorIN_open As PictureBox

		' Token: 0x17000057 RID: 87
		' (get) Token: 0x0600013F RID: 319 RVA: 0x0001885C File Offset: 0x00016A5C
		' (set) Token: 0x06000140 RID: 320 RVA: 0x00018864 File Offset: 0x00016A64
		Friend Overridable Property Pic_pres_end_paint As PictureBox

		' Token: 0x17000058 RID: 88
		' (get) Token: 0x06000141 RID: 321 RVA: 0x0001886D File Offset: 0x00016A6D
		' (set) Token: 0x06000142 RID: 322 RVA: 0x00018875 File Offset: 0x00016A75
		Friend Overridable Property Pic_doorOUT_open As PictureBox

		' Token: 0x17000059 RID: 89
		' (get) Token: 0x06000143 RID: 323 RVA: 0x0001887E File Offset: 0x00016A7E
		' (set) Token: 0x06000144 RID: 324 RVA: 0x00018886 File Offset: 0x00016A86
		Friend Overridable Property Pic_doorOUT_close As PictureBox

		' Token: 0x1700005A RID: 90
		' (get) Token: 0x06000145 RID: 325 RVA: 0x0001888F File Offset: 0x00016A8F
		' (set) Token: 0x06000146 RID: 326 RVA: 0x00018897 File Offset: 0x00016A97
		Friend Overridable Property Pic_doorIN_close As PictureBox

		' Token: 0x1700005B RID: 91
		' (get) Token: 0x06000147 RID: 327 RVA: 0x000188A0 File Offset: 0x00016AA0
		' (set) Token: 0x06000148 RID: 328 RVA: 0x000188A8 File Offset: 0x00016AA8
		Friend Overridable Property Pic_pres_start_unload As PictureBox

		' Token: 0x1700005C RID: 92
		' (get) Token: 0x06000149 RID: 329 RVA: 0x000188B1 File Offset: 0x00016AB1
		' (set) Token: 0x0600014A RID: 330 RVA: 0x000188B9 File Offset: 0x00016AB9
		Friend Overridable Property Pic_pres_start_load As PictureBox

		' Token: 0x1700005D RID: 93
		' (get) Token: 0x0600014B RID: 331 RVA: 0x000188C2 File Offset: 0x00016AC2
		' (set) Token: 0x0600014C RID: 332 RVA: 0x000188CC File Offset: 0x00016ACC
		Friend Overridable Property LblDescrizione As Label
			<CompilerGenerated()>
			Get
				Return Me._LblDescrizione
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Dim value2 As EventHandler = AddressOf Me.LblDescrizione_Click
				Dim lblDescrizione As Label = Me._LblDescrizione
				If lblDescrizione IsNot Nothing Then
					RemoveHandler lblDescrizione.Click, value2
				End If
				Me._LblDescrizione = value
				lblDescrizione = Me._LblDescrizione
				If lblDescrizione IsNot Nothing Then
					AddHandler lblDescrizione.Click, value2
				End If
			End Set
		End Property

		' Token: 0x1700005E RID: 94
		' (get) Token: 0x0600014D RID: 333 RVA: 0x0001890F File Offset: 0x00016B0F
		' (set) Token: 0x0600014E RID: 334 RVA: 0x00018917 File Offset: 0x00016B17
		Friend Overridable Property Pic_Piece_Load As PictureBox

		' Token: 0x1700005F RID: 95
		' (get) Token: 0x0600014F RID: 335 RVA: 0x00018920 File Offset: 0x00016B20
		' (set) Token: 0x06000150 RID: 336 RVA: 0x00018928 File Offset: 0x00016B28
		Friend Overridable Property Pic_Piece_Paint As PictureBox

		' Token: 0x17000060 RID: 96
		' (get) Token: 0x06000151 RID: 337 RVA: 0x00018931 File Offset: 0x00016B31
		' (set) Token: 0x06000152 RID: 338 RVA: 0x00018939 File Offset: 0x00016B39
		Friend Overridable Property Pic_Piece_Unload_1 As PictureBox

		' Token: 0x17000061 RID: 97
		' (get) Token: 0x06000153 RID: 339 RVA: 0x00018942 File Offset: 0x00016B42
		' (set) Token: 0x06000154 RID: 340 RVA: 0x0001894A File Offset: 0x00016B4A
		Friend Overridable Property LblScaricoConfermato As Label

		' Token: 0x17000062 RID: 98
		' (get) Token: 0x06000155 RID: 341 RVA: 0x00018953 File Offset: 0x00016B53
		' (set) Token: 0x06000156 RID: 342 RVA: 0x0001895B File Offset: 0x00016B5B
		Friend Overridable Property LblCaricoConfermato As Label

		' Token: 0x17000063 RID: 99
		' (get) Token: 0x06000157 RID: 343 RVA: 0x00018964 File Offset: 0x00016B64
		' (set) Token: 0x06000158 RID: 344 RVA: 0x0001896C File Offset: 0x00016B6C
		Friend Overridable Property cmb_act_code As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmb_act_code
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim value2 As EventHandler = AddressOf Me.cmb_act_code_Click
				Dim value3 As EventHandler = AddressOf Me.cmb_act_code_SelectedIndexChanged
				Dim cmb_act_code As ComboBox = Me._cmb_act_code
				If cmb_act_code IsNot Nothing Then
					RemoveHandler cmb_act_code.Click, value2
					RemoveHandler cmb_act_code.SelectedIndexChanged, value3
				End If
				Me._cmb_act_code = value
				cmb_act_code = Me._cmb_act_code
				If cmb_act_code IsNot Nothing Then
					AddHandler cmb_act_code.Click, value2
					AddHandler cmb_act_code.SelectedIndexChanged, value3
				End If
			End Set
		End Property

		' Token: 0x17000064 RID: 100
		' (get) Token: 0x06000159 RID: 345 RVA: 0x000189CA File Offset: 0x00016BCA
		' (set) Token: 0x0600015A RID: 346 RVA: 0x000189D2 File Offset: 0x00016BD2
		Friend Overridable Property PicRobot1FouriIngombro As PictureBox

		' Token: 0x17000065 RID: 101
		' (get) Token: 0x0600015B RID: 347 RVA: 0x000189DB File Offset: 0x00016BDB
		' (set) Token: 0x0600015C RID: 348 RVA: 0x000189E3 File Offset: 0x00016BE3
		Friend Overridable Property LblRobot1FouriIngombro As Label

		' Token: 0x17000066 RID: 102
		' (get) Token: 0x0600015D RID: 349 RVA: 0x000189EC File Offset: 0x00016BEC
		' (set) Token: 0x0600015E RID: 350 RVA: 0x000189F4 File Offset: 0x00016BF4
		Friend Overridable Property lbl_status_robot1_main As Label

		' Token: 0x17000067 RID: 103
		' (get) Token: 0x0600015F RID: 351 RVA: 0x000189FD File Offset: 0x00016BFD
		' (set) Token: 0x06000160 RID: 352 RVA: 0x00018A05 File Offset: 0x00016C05
		Friend Overridable Property PicRobot1PrgRun As PictureBox

		' Token: 0x17000068 RID: 104
		' (get) Token: 0x06000161 RID: 353 RVA: 0x00018A0E File Offset: 0x00016C0E
		' (set) Token: 0x06000162 RID: 354 RVA: 0x00018A16 File Offset: 0x00016C16
		Friend Overridable Property PicRobot1Busy As PictureBox

		' Token: 0x17000069 RID: 105
		' (get) Token: 0x06000163 RID: 355 RVA: 0x00018A1F File Offset: 0x00016C1F
		' (set) Token: 0x06000164 RID: 356 RVA: 0x00018A27 File Offset: 0x00016C27
		Friend Overridable Property LblRobot1prgRun As Label

		' Token: 0x1700006A RID: 106
		' (get) Token: 0x06000165 RID: 357 RVA: 0x00018A30 File Offset: 0x00016C30
		' (set) Token: 0x06000166 RID: 358 RVA: 0x00018A38 File Offset: 0x00016C38
		Friend Overridable Property LblRobot1Busy As Label

		' Token: 0x1700006B RID: 107
		' (get) Token: 0x06000167 RID: 359 RVA: 0x00018A41 File Offset: 0x00016C41
		' (set) Token: 0x06000168 RID: 360 RVA: 0x00018A49 File Offset: 0x00016C49
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x1700006C RID: 108
		' (get) Token: 0x06000169 RID: 361 RVA: 0x00018A52 File Offset: 0x00016C52
		' (set) Token: 0x0600016A RID: 362 RVA: 0x00018A5A File Offset: 0x00016C5A
		Friend Overridable Property Label18 As Label

		' Token: 0x1700006D RID: 109
		' (get) Token: 0x0600016B RID: 363 RVA: 0x00018A63 File Offset: 0x00016C63
		' (set) Token: 0x0600016C RID: 364 RVA: 0x00018A6B File Offset: 0x00016C6B
		Friend Overridable Property Lbl_com_robot1_l As Label

		' Token: 0x1700006E RID: 110
		' (get) Token: 0x0600016D RID: 365 RVA: 0x00018A74 File Offset: 0x00016C74
		' (set) Token: 0x0600016E RID: 366 RVA: 0x00018A7C File Offset: 0x00016C7C
		Friend Overridable Property lbl_com_robot1 As Label

		' Token: 0x1700006F RID: 111
		' (get) Token: 0x0600016F RID: 367 RVA: 0x00018A85 File Offset: 0x00016C85
		' (set) Token: 0x06000170 RID: 368 RVA: 0x00018A8D File Offset: 0x00016C8D
		Friend Overridable Property lbl_status_robot1 As Label

		' Token: 0x17000070 RID: 112
		' (get) Token: 0x06000171 RID: 369 RVA: 0x00018A96 File Offset: 0x00016C96
		' (set) Token: 0x06000172 RID: 370 RVA: 0x00018AA0 File Offset: 0x00016CA0
		Friend Overridable Property BtnOpenDoorOUT As Button
			<CompilerGenerated()>
			Get
				Return Me._BtnOpenDoorOUT
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As EventHandler = AddressOf Me.BtnRobotDoors_Click
				Dim btnOpenDoorOUT As Button = Me._BtnOpenDoorOUT
				If btnOpenDoorOUT IsNot Nothing Then
					RemoveHandler btnOpenDoorOUT.Click, value2
				End If
				Me._BtnOpenDoorOUT = value
				btnOpenDoorOUT = Me._BtnOpenDoorOUT
				If btnOpenDoorOUT IsNot Nothing Then
					AddHandler btnOpenDoorOUT.Click, value2
				End If
			End Set
		End Property

		' Token: 0x17000071 RID: 113
		' (get) Token: 0x06000173 RID: 371 RVA: 0x00018AE3 File Offset: 0x00016CE3
		' (set) Token: 0x06000174 RID: 372 RVA: 0x00018AEC File Offset: 0x00016CEC
		Friend Overridable Property BtnOpenDoorIN As Button
			<CompilerGenerated()>
			Get
				Return Me._BtnOpenDoorIN
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As EventHandler = AddressOf Me.BtnGotoRiposo_Click
				Dim btnOpenDoorIN As Button = Me._BtnOpenDoorIN
				If btnOpenDoorIN IsNot Nothing Then
					RemoveHandler btnOpenDoorIN.Click, value2
				End If
				Me._BtnOpenDoorIN = value
				btnOpenDoorIN = Me._BtnOpenDoorIN
				If btnOpenDoorIN IsNot Nothing Then
					AddHandler btnOpenDoorIN.Click, value2
				End If
			End Set
		End Property

		' Token: 0x17000072 RID: 114
		' (get) Token: 0x06000175 RID: 373 RVA: 0x00018B2F File Offset: 0x00016D2F
		' (set) Token: 0x06000176 RID: 374 RVA: 0x00018B38 File Offset: 0x00016D38
		Friend Overridable Property lbl_code_Paint As Label
			<CompilerGenerated()>
			Get
				Return Me._lbl_code_Paint
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Dim value2 As EventHandler = AddressOf Me.lbl_code_Paint_Click
				Dim lbl_code_Paint As Label = Me._lbl_code_Paint
				If lbl_code_Paint IsNot Nothing Then
					RemoveHandler lbl_code_Paint.DoubleClick, value2
				End If
				Me._lbl_code_Paint = value
				lbl_code_Paint = Me._lbl_code_Paint
				If lbl_code_Paint IsNot Nothing Then
					AddHandler lbl_code_Paint.DoubleClick, value2
				End If
			End Set
		End Property

		' Token: 0x17000073 RID: 115
		' (get) Token: 0x06000177 RID: 375 RVA: 0x00018B7B File Offset: 0x00016D7B
		' (set) Token: 0x06000178 RID: 376 RVA: 0x00018B83 File Offset: 0x00016D83
		Friend Overridable Property lbl_code_Load As Label

		' Token: 0x17000074 RID: 116
		' (get) Token: 0x06000179 RID: 377 RVA: 0x00018B8C File Offset: 0x00016D8C
		' (set) Token: 0x0600017A RID: 378 RVA: 0x00018B94 File Offset: 0x00016D94
		Friend Overridable Property Pic_coder_ready As PictureBox

		' Token: 0x17000075 RID: 117
		' (get) Token: 0x0600017B RID: 379 RVA: 0x00018B9D File Offset: 0x00016D9D
		' (set) Token: 0x0600017C RID: 380 RVA: 0x00018BA5 File Offset: 0x00016DA5
		Friend Overridable Property lbl_coder_ready As Label

		' Token: 0x17000076 RID: 118
		' (get) Token: 0x0600017D RID: 381 RVA: 0x00018BAE File Offset: 0x00016DAE
		' (set) Token: 0x0600017E RID: 382 RVA: 0x00018BB6 File Offset: 0x00016DB6
		Friend Overridable Property Pic_barrier_load_ready As PictureBox

		' Token: 0x17000077 RID: 119
		' (get) Token: 0x0600017F RID: 383 RVA: 0x00018BBF File Offset: 0x00016DBF
		' (set) Token: 0x06000180 RID: 384 RVA: 0x00018BC7 File Offset: 0x00016DC7
		Friend Overridable Property lbl_barriera_load As Label

		' Token: 0x17000078 RID: 120
		' (get) Token: 0x06000181 RID: 385 RVA: 0x00018BD0 File Offset: 0x00016DD0
		' (set) Token: 0x06000182 RID: 386 RVA: 0x00018BD8 File Offset: 0x00016DD8
		Friend Overridable Property Pic_robots_ready As PictureBox

		' Token: 0x17000079 RID: 121
		' (get) Token: 0x06000183 RID: 387 RVA: 0x00018BE1 File Offset: 0x00016DE1
		' (set) Token: 0x06000184 RID: 388 RVA: 0x00018BE9 File Offset: 0x00016DE9
		Friend Overridable Property lbl_robots_ready As Label

		' Token: 0x1700007A RID: 122
		' (get) Token: 0x06000185 RID: 389 RVA: 0x00018BF2 File Offset: 0x00016DF2
		' (set) Token: 0x06000186 RID: 390 RVA: 0x00018BFA File Offset: 0x00016DFA
		Friend Overridable Property Pic_confirm_button As PictureBox

		' Token: 0x1700007B RID: 123
		' (get) Token: 0x06000187 RID: 391 RVA: 0x00018C03 File Offset: 0x00016E03
		' (set) Token: 0x06000188 RID: 392 RVA: 0x00018C0B File Offset: 0x00016E0B
		Friend Overridable Property Pic_plant_auto_ready As PictureBox

		' Token: 0x1700007C RID: 124
		' (get) Token: 0x06000189 RID: 393 RVA: 0x00018C14 File Offset: 0x00016E14
		' (set) Token: 0x0600018A RID: 394 RVA: 0x00018C1C File Offset: 0x00016E1C
		Friend Overridable Property lbl_confirm_button As Label

		' Token: 0x1700007D RID: 125
		' (get) Token: 0x0600018B RID: 395 RVA: 0x00018C25 File Offset: 0x00016E25
		' (set) Token: 0x0600018C RID: 396 RVA: 0x00018C2D File Offset: 0x00016E2D
		Friend Overridable Property lbl_plant_auto_ready As Label

		' Token: 0x1700007E RID: 126
		' (get) Token: 0x0600018D RID: 397 RVA: 0x00018C36 File Offset: 0x00016E36
		' (set) Token: 0x0600018E RID: 398 RVA: 0x00018C3E File Offset: 0x00016E3E
		Friend Overridable Property Lbl_EmptyList_R1 As Label

		' Token: 0x1700007F RID: 127
		' (get) Token: 0x0600018F RID: 399 RVA: 0x00018C47 File Offset: 0x00016E47
		' (set) Token: 0x06000190 RID: 400 RVA: 0x00018C4F File Offset: 0x00016E4F
		Friend Overridable Property PicRobot1EmptyList As PictureBox

		' Token: 0x17000080 RID: 128
		' (get) Token: 0x06000191 RID: 401 RVA: 0x00018C58 File Offset: 0x00016E58
		' (set) Token: 0x06000192 RID: 402 RVA: 0x00018C60 File Offset: 0x00016E60
		Friend Overridable Property Lbl_Warning_cyc As Label

		' Token: 0x17000081 RID: 129
		' (get) Token: 0x06000193 RID: 403 RVA: 0x00018C69 File Offset: 0x00016E69
		' (set) Token: 0x06000194 RID: 404 RVA: 0x00018C71 File Offset: 0x00016E71
		Friend Overridable Property GroupBox6 As GroupBox

		' Token: 0x17000082 RID: 130
		' (get) Token: 0x06000195 RID: 405 RVA: 0x00018C7A File Offset: 0x00016E7A
		' (set) Token: 0x06000196 RID: 406 RVA: 0x00018C82 File Offset: 0x00016E82
		Friend Overridable Property GroupBox5 As GroupBox

		' Token: 0x17000083 RID: 131
		' (get) Token: 0x06000197 RID: 407 RVA: 0x00018C8B File Offset: 0x00016E8B
		' (set) Token: 0x06000198 RID: 408 RVA: 0x00018C93 File Offset: 0x00016E93
		Friend Overridable Property Lbl_Warning As Label

		' Token: 0x17000084 RID: 132
		' (get) Token: 0x06000199 RID: 409 RVA: 0x00018C9C File Offset: 0x00016E9C
		' (set) Token: 0x0600019A RID: 410 RVA: 0x00018CA4 File Offset: 0x00016EA4
		Friend Overridable Property Lbl_Errors As Label

		' Token: 0x17000085 RID: 133
		' (get) Token: 0x0600019B RID: 411 RVA: 0x00018CAD File Offset: 0x00016EAD
		' (set) Token: 0x0600019C RID: 412 RVA: 0x00018CB5 File Offset: 0x00016EB5
		Friend Overridable Property lbl_Load_st_emerg As Label

		' Token: 0x17000086 RID: 134
		' (get) Token: 0x0600019D RID: 413 RVA: 0x00018CBE File Offset: 0x00016EBE
		' (set) Token: 0x0600019E RID: 414 RVA: 0x00018CC6 File Offset: 0x00016EC6
		Friend Overridable Property lbl_Unload_st_emerg As Label

		' Token: 0x17000087 RID: 135
		' (get) Token: 0x0600019F RID: 415 RVA: 0x00018CCF File Offset: 0x00016ECF
		' (set) Token: 0x060001A0 RID: 416 RVA: 0x00018CD7 File Offset: 0x00016ED7
		Friend Overridable Property Lbl_Emergency As Label

		' Token: 0x17000088 RID: 136
		' (get) Token: 0x060001A1 RID: 417 RVA: 0x00018CE0 File Offset: 0x00016EE0
		' (set) Token: 0x060001A2 RID: 418 RVA: 0x00018CE8 File Offset: 0x00016EE8
		Friend Overridable Property lbl_Paint_st_emerg As Label

		' Token: 0x17000089 RID: 137
		' (get) Token: 0x060001A3 RID: 419 RVA: 0x00018CF1 File Offset: 0x00016EF1
		' (set) Token: 0x060001A4 RID: 420 RVA: 0x00018CF9 File Offset: 0x00016EF9
		Friend Overridable Property Pic_unload_done As PictureBox

		' Token: 0x1700008A RID: 138
		' (get) Token: 0x060001A5 RID: 421 RVA: 0x00018D02 File Offset: 0x00016F02
		' (set) Token: 0x060001A6 RID: 422 RVA: 0x00018D0A File Offset: 0x00016F0A
		Friend Overridable Property lbl_unload_done As Label

		' Token: 0x1700008B RID: 139
		' (get) Token: 0x060001A7 RID: 423 RVA: 0x00018D13 File Offset: 0x00016F13
		' (set) Token: 0x060001A8 RID: 424 RVA: 0x00018D1C File Offset: 0x00016F1C
		Friend Overridable Property lbl_reset_warning As Button
			<CompilerGenerated()>
			Get
				Return Me._lbl_reset_warning
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As EventHandler = AddressOf Me.lbl_reset_warning_Click
				Dim lbl_reset_warning As Button = Me._lbl_reset_warning
				If lbl_reset_warning IsNot Nothing Then
					RemoveHandler lbl_reset_warning.Click, value2
				End If
				Me._lbl_reset_warning = value
				lbl_reset_warning = Me._lbl_reset_warning
				If lbl_reset_warning IsNot Nothing Then
					AddHandler lbl_reset_warning.Click, value2
				End If
			End Set
		End Property

		' Token: 0x1700008C RID: 140
		' (get) Token: 0x060001A9 RID: 425 RVA: 0x00018D5F File Offset: 0x00016F5F
		' (set) Token: 0x060001AA RID: 426 RVA: 0x00018D67 File Offset: 0x00016F67
		Friend Overridable Property lbl_mmUnloadBelt As Label

		' Token: 0x1700008D RID: 141
		' (get) Token: 0x060001AB RID: 427 RVA: 0x00018D70 File Offset: 0x00016F70
		' (set) Token: 0x060001AC RID: 428 RVA: 0x00018D78 File Offset: 0x00016F78
		Friend Overridable Property lbl_mmPaintBelt As Label

		' Token: 0x1700008E RID: 142
		' (get) Token: 0x060001AD RID: 429 RVA: 0x00018D81 File Offset: 0x00016F81
		' (set) Token: 0x060001AE RID: 430 RVA: 0x00018D89 File Offset: 0x00016F89
		Friend Overridable Property lbl_mmLoadBelt As Label

		' Token: 0x1700008F RID: 143
		' (get) Token: 0x060001AF RID: 431 RVA: 0x00018D92 File Offset: 0x00016F92
		' (set) Token: 0x060001B0 RID: 432 RVA: 0x00018D9A File Offset: 0x00016F9A
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17000090 RID: 144
		' (get) Token: 0x060001B1 RID: 433 RVA: 0x00018DA3 File Offset: 0x00016FA3
		' (set) Token: 0x060001B2 RID: 434 RVA: 0x00018DAB File Offset: 0x00016FAB
		Friend Overridable Property cl_pos As DataGridViewTextBoxColumn

		' Token: 0x17000091 RID: 145
		' (get) Token: 0x060001B3 RID: 435 RVA: 0x00018DB4 File Offset: 0x00016FB4
		' (set) Token: 0x060001B4 RID: 436 RVA: 0x00018DBC File Offset: 0x00016FBC
		Friend Overridable Property cl_vel As DataGridViewTextBoxColumn

		' Token: 0x17000092 RID: 146
		' (get) Token: 0x060001B5 RID: 437 RVA: 0x00018DC5 File Offset: 0x00016FC5
		' (set) Token: 0x060001B6 RID: 438 RVA: 0x00018DCD File Offset: 0x00016FCD
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17000093 RID: 147
		' (get) Token: 0x060001B7 RID: 439 RVA: 0x00018DD6 File Offset: 0x00016FD6
		' (set) Token: 0x060001B8 RID: 440 RVA: 0x00018DDE File Offset: 0x00016FDE
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17000094 RID: 148
		' (get) Token: 0x060001B9 RID: 441 RVA: 0x00018DE7 File Offset: 0x00016FE7
		' (set) Token: 0x060001BA RID: 442 RVA: 0x00018DEF File Offset: 0x00016FEF
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17000095 RID: 149
		' (get) Token: 0x060001BB RID: 443 RVA: 0x00018DF8 File Offset: 0x00016FF8
		' (set) Token: 0x060001BC RID: 444 RVA: 0x00018E00 File Offset: 0x00017000
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17000096 RID: 150
		' (get) Token: 0x060001BD RID: 445 RVA: 0x00018E09 File Offset: 0x00017009
		' (set) Token: 0x060001BE RID: 446 RVA: 0x00018E11 File Offset: 0x00017011
		Friend Overridable Property MotorsManualMove As DataGridViewCheckBoxColumn

		' Token: 0x17000097 RID: 151
		' (get) Token: 0x060001BF RID: 447 RVA: 0x00018E1A File Offset: 0x0001701A
		' (set) Token: 0x060001C0 RID: 448 RVA: 0x00018E24 File Offset: 0x00017024
		Friend Overridable Property lbl_reset_errors As Button
			<CompilerGenerated()>
			Get
				Return Me._lbl_reset_errors
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As EventHandler = AddressOf Me.lbl_reset_errors_Click
				Dim lbl_reset_errors As Button = Me._lbl_reset_errors
				If lbl_reset_errors IsNot Nothing Then
					RemoveHandler lbl_reset_errors.Click, value2
				End If
				Me._lbl_reset_errors = value
				lbl_reset_errors = Me._lbl_reset_errors
				If lbl_reset_errors IsNot Nothing Then
					AddHandler lbl_reset_errors.Click, value2
				End If
			End Set
		End Property

		' Token: 0x17000098 RID: 152
		' (get) Token: 0x060001C1 RID: 449 RVA: 0x00018E67 File Offset: 0x00017067
		' (set) Token: 0x060001C2 RID: 450 RVA: 0x00018E6F File Offset: 0x0001706F
		Friend Overridable Property GroupBox8 As GroupBox

		' Token: 0x17000099 RID: 153
		' (get) Token: 0x060001C3 RID: 451 RVA: 0x00018E78 File Offset: 0x00017078
		' (set) Token: 0x060001C4 RID: 452 RVA: 0x00018E80 File Offset: 0x00017080
		Friend Overridable Property lbl_cma_loadinf As Label

		' Token: 0x1700009A RID: 154
		' (get) Token: 0x060001C5 RID: 453 RVA: 0x00018E89 File Offset: 0x00017089
		' (set) Token: 0x060001C6 RID: 454 RVA: 0x00018E91 File Offset: 0x00017091
		Friend Overridable Property Lbl_communicationPLC As Label

		' Token: 0x1700009B RID: 155
		' (get) Token: 0x060001C7 RID: 455 RVA: 0x00018E9A File Offset: 0x0001709A
		' (set) Token: 0x060001C8 RID: 456 RVA: 0x00018EA2 File Offset: 0x000170A2
		Friend Overridable Property GroupBox9 As GroupBox

		' Token: 0x1700009C RID: 156
		' (get) Token: 0x060001C9 RID: 457 RVA: 0x00018EAB File Offset: 0x000170AB
		' (set) Token: 0x060001CA RID: 458 RVA: 0x00018EB3 File Offset: 0x000170B3
		Friend Overridable Property lbl_IMA_OUTPUT As Label

		' Token: 0x1700009D RID: 157
		' (get) Token: 0x060001CB RID: 459 RVA: 0x00018EBC File Offset: 0x000170BC
		' (set) Token: 0x060001CC RID: 460 RVA: 0x00018EC4 File Offset: 0x000170C4
		Friend Overridable Property lbl_IMA_INPUT As Label

		' Token: 0x1700009E RID: 158
		' (get) Token: 0x060001CD RID: 461 RVA: 0x00018ECD File Offset: 0x000170CD
		' (set) Token: 0x060001CE RID: 462 RVA: 0x00018ED8 File Offset: 0x000170D8
		Friend Overridable Property dgv_dout_IMA As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgv_dout_IMA
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim value2 As DataGridViewCellEventHandler = AddressOf Me.dgv_dout_IMA_CellValueChanged
				Dim dgv_dout_IMA As DataGridView = Me._dgv_dout_IMA
				If dgv_dout_IMA IsNot Nothing Then
					RemoveHandler dgv_dout_IMA.CellValueChanged, value2
				End If
				Me._dgv_dout_IMA = value
				dgv_dout_IMA = Me._dgv_dout_IMA
				If dgv_dout_IMA IsNot Nothing Then
					AddHandler dgv_dout_IMA.CellValueChanged, value2
				End If
			End Set
		End Property

		' Token: 0x1700009F RID: 159
		' (get) Token: 0x060001CF RID: 463 RVA: 0x00018F1B File Offset: 0x0001711B
		' (set) Token: 0x060001D0 RID: 464 RVA: 0x00018F23 File Offset: 0x00017123
		Friend Overridable Property dgv_din_IMA As DataGridView

		' Token: 0x170000A0 RID: 160
		' (get) Token: 0x060001D1 RID: 465 RVA: 0x00018F2C File Offset: 0x0001712C
		' (set) Token: 0x060001D2 RID: 466 RVA: 0x00018F34 File Offset: 0x00017134
		Friend Overridable Property lbl_digital_OUTPUT As Label

		' Token: 0x170000A1 RID: 161
		' (get) Token: 0x060001D3 RID: 467 RVA: 0x00018F3D File Offset: 0x0001713D
		' (set) Token: 0x060001D4 RID: 468 RVA: 0x00018F45 File Offset: 0x00017145
		Friend Overridable Property lbl_digital_INPUT As Label

		' Token: 0x170000A2 RID: 162
		' (get) Token: 0x060001D5 RID: 469 RVA: 0x00018F4E File Offset: 0x0001714E
		' (set) Token: 0x060001D6 RID: 470 RVA: 0x00018F58 File Offset: 0x00017158
		Friend Overridable Property dgv_dout As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgv_dout
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim value2 As DataGridViewCellEventHandler = AddressOf Me.dgv_dout_CellContentClick
				Dim dgv_dout As DataGridView = Me._dgv_dout
				If dgv_dout IsNot Nothing Then
					RemoveHandler dgv_dout.CellContentClick, value2
				End If
				Me._dgv_dout = value
				dgv_dout = Me._dgv_dout
				If dgv_dout IsNot Nothing Then
					AddHandler dgv_dout.CellContentClick, value2
				End If
			End Set
		End Property

		' Token: 0x170000A3 RID: 163
		' (get) Token: 0x060001D7 RID: 471 RVA: 0x00018F9B File Offset: 0x0001719B
		' (set) Token: 0x060001D8 RID: 472 RVA: 0x00018FA3 File Offset: 0x000171A3
		Friend Overridable Property DataGridViewImageColumn1 As DataGridViewImageColumn

		' Token: 0x170000A4 RID: 164
		' (get) Token: 0x060001D9 RID: 473 RVA: 0x00018FAC File Offset: 0x000171AC
		' (set) Token: 0x060001DA RID: 474 RVA: 0x00018FB4 File Offset: 0x000171B4
		Friend Overridable Property Column1 As DataGridViewButtonColumn

		' Token: 0x170000A5 RID: 165
		' (get) Token: 0x060001DB RID: 475 RVA: 0x00018FBD File Offset: 0x000171BD
		' (set) Token: 0x060001DC RID: 476 RVA: 0x00018FC5 File Offset: 0x000171C5
		Friend Overridable Property DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn

		' Token: 0x170000A6 RID: 166
		' (get) Token: 0x060001DD RID: 477 RVA: 0x00018FCE File Offset: 0x000171CE
		' (set) Token: 0x060001DE RID: 478 RVA: 0x00018FD6 File Offset: 0x000171D6
		Friend Overridable Property dgv_din As DataGridView

		' Token: 0x170000A7 RID: 167
		' (get) Token: 0x060001DF RID: 479 RVA: 0x00018FDF File Offset: 0x000171DF
		' (set) Token: 0x060001E0 RID: 480 RVA: 0x00018FE7 File Offset: 0x000171E7
		Friend Overridable Property Column3 As DataGridViewImageColumn

		' Token: 0x170000A8 RID: 168
		' (get) Token: 0x060001E1 RID: 481 RVA: 0x00018FF0 File Offset: 0x000171F0
		' (set) Token: 0x060001E2 RID: 482 RVA: 0x00018FF8 File Offset: 0x000171F8
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x170000A9 RID: 169
		' (get) Token: 0x060001E3 RID: 483 RVA: 0x00019001 File Offset: 0x00017201
		' (set) Token: 0x060001E4 RID: 484 RVA: 0x0001900C File Offset: 0x0001720C
		Friend Overridable Property btn_force As Button
			<CompilerGenerated()>
			Get
				Return Me._btn_force
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As EventHandler = AddressOf Me.btn_force_Click
				Dim btn_force As Button = Me._btn_force
				If btn_force IsNot Nothing Then
					RemoveHandler btn_force.Click, value2
				End If
				Me._btn_force = value
				btn_force = Me._btn_force
				If btn_force IsNot Nothing Then
					AddHandler btn_force.Click, value2
				End If
			End Set
		End Property

		' Token: 0x170000AA RID: 170
		' (get) Token: 0x060001E5 RID: 485 RVA: 0x0001904F File Offset: 0x0001724F
		' (set) Token: 0x060001E6 RID: 486 RVA: 0x00019057 File Offset: 0x00017257
		Friend Overridable Property lbl_waiting_resume As Label

		' Token: 0x170000AB RID: 171
		' (get) Token: 0x060001E7 RID: 487 RVA: 0x00019060 File Offset: 0x00017260
		' (set) Token: 0x060001E8 RID: 488 RVA: 0x00019068 File Offset: 0x00017268
		Friend Overridable Property Pic_pres_safe_unload As PictureBox

		' Token: 0x170000AC RID: 172
		' (get) Token: 0x060001E9 RID: 489 RVA: 0x00019071 File Offset: 0x00017271
		' (set) Token: 0x060001EA RID: 490 RVA: 0x00019079 File Offset: 0x00017279
		Friend Overridable Property lbl_code_Unload_ST1 As Label

		' Token: 0x170000AD RID: 173
		' (get) Token: 0x060001EB RID: 491 RVA: 0x00019082 File Offset: 0x00017282
		' (set) Token: 0x060001EC RID: 492 RVA: 0x0001908A File Offset: 0x0001728A
		Friend Overridable Property lbl_SR20G_R1_ready As Label

		' Token: 0x170000AE RID: 174
		' (get) Token: 0x060001ED RID: 493 RVA: 0x00019093 File Offset: 0x00017293
		' (set) Token: 0x060001EE RID: 494 RVA: 0x0001909B File Offset: 0x0001729B
		Friend Overridable Property Pic_SR20G_R1_ready As PictureBox

		' Token: 0x170000AF RID: 175
		' (get) Token: 0x060001EF RID: 495 RVA: 0x000190A4 File Offset: 0x000172A4
		' (set) Token: 0x060001F0 RID: 496 RVA: 0x000190AC File Offset: 0x000172AC
		Friend Overridable Property lbl_Sirtek_plant_ready As Label

		' Token: 0x170000B0 RID: 176
		' (get) Token: 0x060001F1 RID: 497 RVA: 0x000190B5 File Offset: 0x000172B5
		' (set) Token: 0x060001F2 RID: 498 RVA: 0x000190BD File Offset: 0x000172BD
		Friend Overridable Property Pic_Sirtek_plant_ready As PictureBox

		' Token: 0x170000B1 RID: 177
		' (get) Token: 0x060001F3 RID: 499 RVA: 0x000190C6 File Offset: 0x000172C6
		' (set) Token: 0x060001F4 RID: 500 RVA: 0x000190D0 File Offset: 0x000172D0
		Friend Overridable Property tmr_psw As Timer
			<CompilerGenerated()>
			Get
				Return Me._tmr_psw
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Timer)
				Dim value2 As EventHandler = AddressOf Me.tmr_psw_Tick
				Dim tmr_psw As Timer = Me._tmr_psw
				If tmr_psw IsNot Nothing Then
					RemoveHandler tmr_psw.Tick, value2
				End If
				Me._tmr_psw = value
				tmr_psw = Me._tmr_psw
				If tmr_psw IsNot Nothing Then
					AddHandler tmr_psw.Tick, value2
				End If
			End Set
		End Property

		' Token: 0x170000B2 RID: 178
		' (get) Token: 0x060001F5 RID: 501 RVA: 0x00019113 File Offset: 0x00017313
		' (set) Token: 0x060001F6 RID: 502 RVA: 0x0001911C File Offset: 0x0001731C
		Friend Overridable Property lbl_act_code As Label
			<CompilerGenerated()>
			Get
				Return Me._lbl_act_code
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Dim value2 As EventHandler = AddressOf Me.lbl_act_code_Click
				Dim lbl_act_code As Label = Me._lbl_act_code
				If lbl_act_code IsNot Nothing Then
					RemoveHandler lbl_act_code.Click, value2
				End If
				Me._lbl_act_code = value
				lbl_act_code = Me._lbl_act_code
				If lbl_act_code IsNot Nothing Then
					AddHandler lbl_act_code.Click, value2
				End If
			End Set
		End Property

		' Token: 0x170000B3 RID: 179
		' (get) Token: 0x060001F7 RID: 503 RVA: 0x0001915F File Offset: 0x0001735F
		' (set) Token: 0x060001F8 RID: 504 RVA: 0x00019168 File Offset: 0x00017368
		Friend Overridable Property lbl_act_option As Label
			<CompilerGenerated()>
			Get
				Return Me._lbl_act_option
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Dim value2 As EventHandler = AddressOf Me.lbl_act_option_Click
				Dim lbl_act_option As Label = Me._lbl_act_option
				If lbl_act_option IsNot Nothing Then
					RemoveHandler lbl_act_option.Click, value2
				End If
				Me._lbl_act_option = value
				lbl_act_option = Me._lbl_act_option
				If lbl_act_option IsNot Nothing Then
					AddHandler lbl_act_option.Click, value2
				End If
			End Set
		End Property

		' Token: 0x170000B4 RID: 180
		' (get) Token: 0x060001F9 RID: 505 RVA: 0x000191AB File Offset: 0x000173AB
		' (set) Token: 0x060001FA RID: 506 RVA: 0x000191B4 File Offset: 0x000173B4
		Friend Overridable Property lbl_act_batch As Label
			<CompilerGenerated()>
			Get
				Return Me._lbl_act_batch
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Dim value2 As EventHandler = AddressOf Me.lbl_act_batch_Click
				Dim lbl_act_batch As Label = Me._lbl_act_batch
				If lbl_act_batch IsNot Nothing Then
					RemoveHandler lbl_act_batch.Click, value2
				End If
				Me._lbl_act_batch = value
				lbl_act_batch = Me._lbl_act_batch
				If lbl_act_batch IsNot Nothing Then
					AddHandler lbl_act_batch.Click, value2
				End If
			End Set
		End Property

		' Token: 0x170000B5 RID: 181
		' (get) Token: 0x060001FB RID: 507 RVA: 0x000191F7 File Offset: 0x000173F7
		' (set) Token: 0x060001FC RID: 508 RVA: 0x000191FF File Offset: 0x000173FF
		Friend Overridable Property lbl_act_option_l As Label

		' Token: 0x170000B6 RID: 182
		' (get) Token: 0x060001FD RID: 509 RVA: 0x00019208 File Offset: 0x00017408
		' (set) Token: 0x060001FE RID: 510 RVA: 0x00019210 File Offset: 0x00017410
		Friend Overridable Property lbl_act_batch_l As Label

		' Token: 0x170000B7 RID: 183
		' (get) Token: 0x060001FF RID: 511 RVA: 0x00019219 File Offset: 0x00017419
		' (set) Token: 0x06000200 RID: 512 RVA: 0x00019221 File Offset: 0x00017421
		Friend Overridable Property TabPage4 As TabPage

		' Token: 0x170000B8 RID: 184
		' (get) Token: 0x06000201 RID: 513 RVA: 0x0001922A File Offset: 0x0001742A
		' (set) Token: 0x06000202 RID: 514 RVA: 0x00019232 File Offset: 0x00017432
		Friend Overridable Property grp_debug As GroupBox

		' Token: 0x170000B9 RID: 185
		' (get) Token: 0x06000203 RID: 515 RVA: 0x0001923B File Offset: 0x0001743B
		' (set) Token: 0x06000204 RID: 516 RVA: 0x00019243 File Offset: 0x00017443
		Friend Overridable Property lbl_debug_03 As Label

		' Token: 0x170000BA RID: 186
		' (get) Token: 0x06000205 RID: 517 RVA: 0x0001924C File Offset: 0x0001744C
		' (set) Token: 0x06000206 RID: 518 RVA: 0x00019254 File Offset: 0x00017454
		Friend Overridable Property lbl_debug_02 As Label

		' Token: 0x170000BB RID: 187
		' (get) Token: 0x06000207 RID: 519 RVA: 0x0001925D File Offset: 0x0001745D
		' (set) Token: 0x06000208 RID: 520 RVA: 0x00019265 File Offset: 0x00017465
		Friend Overridable Property lbl_debug_01 As Label

		' Token: 0x170000BC RID: 188
		' (get) Token: 0x06000209 RID: 521 RVA: 0x0001926E File Offset: 0x0001746E
		' (set) Token: 0x0600020A RID: 522 RVA: 0x00019276 File Offset: 0x00017476
		Friend Overridable Property Label6 As Label

		' Token: 0x170000BD RID: 189
		' (get) Token: 0x0600020B RID: 523 RVA: 0x0001927F File Offset: 0x0001747F
		' (set) Token: 0x0600020C RID: 524 RVA: 0x00019287 File Offset: 0x00017487
		Friend Overridable Property Label5 As Label

		' Token: 0x170000BE RID: 190
		' (get) Token: 0x0600020D RID: 525 RVA: 0x00019290 File Offset: 0x00017490
		' (set) Token: 0x0600020E RID: 526 RVA: 0x00019298 File Offset: 0x00017498
		Friend Overridable Property Label3 As Label

		' Token: 0x170000BF RID: 191
		' (get) Token: 0x0600020F RID: 527 RVA: 0x000192A1 File Offset: 0x000174A1
		' (set) Token: 0x06000210 RID: 528 RVA: 0x000192A9 File Offset: 0x000174A9
		Friend Overridable Property Label2 As Label

		' Token: 0x170000C0 RID: 192
		' (get) Token: 0x06000211 RID: 529 RVA: 0x000192B2 File Offset: 0x000174B2
		' (set) Token: 0x06000212 RID: 530 RVA: 0x000192BA File Offset: 0x000174BA
		Friend Overridable Property Label1 As Label

		' Token: 0x170000C1 RID: 193
		' (get) Token: 0x06000213 RID: 531 RVA: 0x000192C3 File Offset: 0x000174C3
		' (set) Token: 0x06000214 RID: 532 RVA: 0x000192CB File Offset: 0x000174CB
		Friend Overridable Property mmPaint As Label

		' Token: 0x170000C2 RID: 194
		' (get) Token: 0x06000215 RID: 533 RVA: 0x000192D4 File Offset: 0x000174D4
		' (set) Token: 0x06000216 RID: 534 RVA: 0x000192DC File Offset: 0x000174DC
		Friend Overridable Property lbl_mmnastro_unload As Label

		' Token: 0x170000C3 RID: 195
		' (get) Token: 0x06000217 RID: 535 RVA: 0x000192E5 File Offset: 0x000174E5
		' (set) Token: 0x06000218 RID: 536 RVA: 0x000192ED File Offset: 0x000174ED
		Friend Overridable Property lbl_mmnastro_paint As Label

		' Token: 0x170000C4 RID: 196
		' (get) Token: 0x06000219 RID: 537 RVA: 0x000192F6 File Offset: 0x000174F6
		' (set) Token: 0x0600021A RID: 538 RVA: 0x000192FE File Offset: 0x000174FE
		Friend Overridable Property lbl_FSM_err As Label

		' Token: 0x170000C5 RID: 197
		' (get) Token: 0x0600021B RID: 539 RVA: 0x00019307 File Offset: 0x00017507
		' (set) Token: 0x0600021C RID: 540 RVA: 0x0001930F File Offset: 0x0001750F
		Friend Overridable Property Pic_pres_end_oven As PictureBox

		' Token: 0x170000C6 RID: 198
		' (get) Token: 0x0600021D RID: 541 RVA: 0x00019318 File Offset: 0x00017518
		' (set) Token: 0x0600021E RID: 542 RVA: 0x00019320 File Offset: 0x00017520
		Friend Overridable Property Pic_pres_start_oven As PictureBox

		' Token: 0x170000C7 RID: 199
		' (get) Token: 0x0600021F RID: 543 RVA: 0x00019329 File Offset: 0x00017529
		' (set) Token: 0x06000220 RID: 544 RVA: 0x00019331 File Offset: 0x00017531
		Friend Overridable Property Pic_Piece_Oven As PictureBox

		' Token: 0x170000C8 RID: 200
		' (get) Token: 0x06000221 RID: 545 RVA: 0x0001933A File Offset: 0x0001753A
		' (set) Token: 0x06000222 RID: 546 RVA: 0x00019342 File Offset: 0x00017542
		Friend Overridable Property Pic_Oven_doorIN_open As PictureBox

		' Token: 0x170000C9 RID: 201
		' (get) Token: 0x06000223 RID: 547 RVA: 0x0001934B File Offset: 0x0001754B
		' (set) Token: 0x06000224 RID: 548 RVA: 0x00019353 File Offset: 0x00017553
		Friend Overridable Property Pic_Oven_doorIN_close As PictureBox

		' Token: 0x170000CA RID: 202
		' (get) Token: 0x06000225 RID: 549 RVA: 0x0001935C File Offset: 0x0001755C
		' (set) Token: 0x06000226 RID: 550 RVA: 0x00019364 File Offset: 0x00017564
		Friend Overridable Property BtnOvenDoor As Button

		' Token: 0x170000CB RID: 203
		' (get) Token: 0x06000227 RID: 551 RVA: 0x0001936D File Offset: 0x0001756D
		' (set) Token: 0x06000228 RID: 552 RVA: 0x00019375 File Offset: 0x00017575
		Friend Overridable Property lbl_Oven_st_emerg As Label

		' Token: 0x170000CC RID: 204
		' (get) Token: 0x06000229 RID: 553 RVA: 0x0001937E File Offset: 0x0001757E
		' (set) Token: 0x0600022A RID: 554 RVA: 0x00019388 File Offset: 0x00017588
		Friend Overridable Property lbl_code_Oven As Label
			<CompilerGenerated()>
			Get
				Return Me._lbl_code_Oven
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Dim value2 As EventHandler = AddressOf Me.lbl_code_Oven_Click
				Dim lbl_code_Oven As Label = Me._lbl_code_Oven
				If lbl_code_Oven IsNot Nothing Then
					RemoveHandler lbl_code_Oven.DoubleClick, value2
				End If
				Me._lbl_code_Oven = value
				lbl_code_Oven = Me._lbl_code_Oven
				If lbl_code_Oven IsNot Nothing Then
					AddHandler lbl_code_Oven.DoubleClick, value2
				End If
			End Set
		End Property

		' Token: 0x170000CD RID: 205
		' (get) Token: 0x0600022B RID: 555 RVA: 0x000193CB File Offset: 0x000175CB
		' (set) Token: 0x0600022C RID: 556 RVA: 0x000193D3 File Offset: 0x000175D3
		Friend Overridable Property lbl_mmOvenBelt As Label

		' Token: 0x170000CE RID: 206
		' (get) Token: 0x0600022D RID: 557 RVA: 0x000193DC File Offset: 0x000175DC
		' (set) Token: 0x0600022E RID: 558 RVA: 0x000193E4 File Offset: 0x000175E4
		Friend Overridable Property GroupBox3 As GroupBox

		' Token: 0x170000CF RID: 207
		' (get) Token: 0x0600022F RID: 559 RVA: 0x000193ED File Offset: 0x000175ED
		' (set) Token: 0x06000230 RID: 560 RVA: 0x000193F5 File Offset: 0x000175F5
		Friend Overridable Property lbl_timeout_oven As Label

		' Token: 0x170000D0 RID: 208
		' (get) Token: 0x06000231 RID: 561 RVA: 0x000193FE File Offset: 0x000175FE
		' (set) Token: 0x06000232 RID: 562 RVA: 0x00019406 File Offset: 0x00017606
		Friend Overridable Property lbl_timeout_oven_set As Label

		' Token: 0x170000D1 RID: 209
		' (get) Token: 0x06000233 RID: 563 RVA: 0x0001940F File Offset: 0x0001760F
		' (set) Token: 0x06000234 RID: 564 RVA: 0x00019418 File Offset: 0x00017618
		Friend Overridable Property btn_oven_t_plus As Button
			<CompilerGenerated()>
			Get
				Return Me._btn_oven_t_plus
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As EventHandler = AddressOf Me.btn_oven_t_plus_Click
				Dim btn_oven_t_plus As Button = Me._btn_oven_t_plus
				If btn_oven_t_plus IsNot Nothing Then
					RemoveHandler btn_oven_t_plus.Click, value2
				End If
				Me._btn_oven_t_plus = value
				btn_oven_t_plus = Me._btn_oven_t_plus
				If btn_oven_t_plus IsNot Nothing Then
					AddHandler btn_oven_t_plus.Click, value2
				End If
			End Set
		End Property

		' Token: 0x170000D2 RID: 210
		' (get) Token: 0x06000235 RID: 565 RVA: 0x0001945B File Offset: 0x0001765B
		' (set) Token: 0x06000236 RID: 566 RVA: 0x00019464 File Offset: 0x00017664
		Friend Overridable Property btn_force_oven_timeout As Button
			<CompilerGenerated()>
			Get
				Return Me._btn_force_oven_timeout
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As EventHandler = AddressOf Me.btn_force_oven_timeout_Click
				Dim btn_force_oven_timeout As Button = Me._btn_force_oven_timeout
				If btn_force_oven_timeout IsNot Nothing Then
					RemoveHandler btn_force_oven_timeout.Click, value2
				End If
				Me._btn_force_oven_timeout = value
				btn_force_oven_timeout = Me._btn_force_oven_timeout
				If btn_force_oven_timeout IsNot Nothing Then
					AddHandler btn_force_oven_timeout.Click, value2
				End If
			End Set
		End Property

		' Token: 0x170000D3 RID: 211
		' (get) Token: 0x06000237 RID: 567 RVA: 0x000194A7 File Offset: 0x000176A7
		' (set) Token: 0x06000238 RID: 568 RVA: 0x000194B0 File Offset: 0x000176B0
		Friend Overridable Property btn_oven_t_min As Button
			<CompilerGenerated()>
			Get
				Return Me._btn_oven_t_min
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As EventHandler = AddressOf Me.btn_oven_t_min_Click
				Dim btn_oven_t_min As Button = Me._btn_oven_t_min
				If btn_oven_t_min IsNot Nothing Then
					RemoveHandler btn_oven_t_min.Click, value2
				End If
				Me._btn_oven_t_min = value
				btn_oven_t_min = Me._btn_oven_t_min
				If btn_oven_t_min IsNot Nothing Then
					AddHandler btn_oven_t_min.Click, value2
				End If
			End Set
		End Property

		' Token: 0x170000D4 RID: 212
		' (get) Token: 0x06000239 RID: 569 RVA: 0x000194F3 File Offset: 0x000176F3
		' (set) Token: 0x0600023A RID: 570 RVA: 0x000194FB File Offset: 0x000176FB
		Friend Overridable Property mmOven As Label

		' Token: 0x170000D5 RID: 213
		' (get) Token: 0x0600023B RID: 571 RVA: 0x00019504 File Offset: 0x00017704
		' (set) Token: 0x0600023C RID: 572 RVA: 0x0001950C File Offset: 0x0001770C
		Friend Overridable Property lbl_mmnastro_oven As Label

		' Token: 0x170000D6 RID: 214
		' (get) Token: 0x0600023D RID: 573 RVA: 0x00019515 File Offset: 0x00017715
		' (set) Token: 0x0600023E RID: 574 RVA: 0x0001951D File Offset: 0x0001771D
		Friend Overridable Property DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn

		' Token: 0x170000D7 RID: 215
		' (get) Token: 0x0600023F RID: 575 RVA: 0x00019526 File Offset: 0x00017726
		' (set) Token: 0x06000240 RID: 576 RVA: 0x0001952E File Offset: 0x0001772E
		Friend Overridable Property Value As DataGridViewTextBoxColumn

		' Token: 0x170000D8 RID: 216
		' (get) Token: 0x06000241 RID: 577 RVA: 0x00019537 File Offset: 0x00017737
		' (set) Token: 0x06000242 RID: 578 RVA: 0x0001953F File Offset: 0x0001773F
		Friend Overridable Property DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn

		' Token: 0x170000D9 RID: 217
		' (get) Token: 0x06000243 RID: 579 RVA: 0x00019548 File Offset: 0x00017748
		' (set) Token: 0x06000244 RID: 580 RVA: 0x00019550 File Offset: 0x00017750
		Friend Overridable Property DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn

		' Token: 0x170000DA RID: 218
		' (get) Token: 0x06000245 RID: 581 RVA: 0x00019559 File Offset: 0x00017759
		' (set) Token: 0x06000246 RID: 582 RVA: 0x00019561 File Offset: 0x00017761
		Friend Overridable Property Label12 As Label

		' Token: 0x170000DB RID: 219
		' (get) Token: 0x06000247 RID: 583 RVA: 0x0001956A File Offset: 0x0001776A
		' (set) Token: 0x06000248 RID: 584 RVA: 0x00019572 File Offset: 0x00017772
		Friend Overridable Property lbl_com_TCPIP_r1 As Label

		' Token: 0x170000DC RID: 220
		' (get) Token: 0x06000249 RID: 585 RVA: 0x0001957B File Offset: 0x0001777B
		' (set) Token: 0x0600024A RID: 586 RVA: 0x00019584 File Offset: 0x00017784
		Friend Overridable Property btn_Send_tcpip As Button
			<CompilerGenerated()>
			Get
				Return Me._btn_Send_tcpip
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As EventHandler = AddressOf Me.btn_Send_tcpip_Click
				Dim btn_Send_tcpip As Button = Me._btn_Send_tcpip
				If btn_Send_tcpip IsNot Nothing Then
					RemoveHandler btn_Send_tcpip.Click, value2
				End If
				Me._btn_Send_tcpip = value
				btn_Send_tcpip = Me._btn_Send_tcpip
				If btn_Send_tcpip IsNot Nothing Then
					AddHandler btn_Send_tcpip.Click, value2
				End If
			End Set
		End Property

		' Token: 0x170000DD RID: 221
		' (get) Token: 0x0600024B RID: 587 RVA: 0x000195C7 File Offset: 0x000177C7
		' (set) Token: 0x0600024C RID: 588 RVA: 0x000195D0 File Offset: 0x000177D0
		Friend Overridable Property btn_force_unload_step As Button
			<CompilerGenerated()>
			Get
				Return Me._btn_force_unload_step
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As EventHandler = AddressOf Me.btn_force_unload_step_Click
				Dim btn_force_unload_step As Button = Me._btn_force_unload_step
				If btn_force_unload_step IsNot Nothing Then
					RemoveHandler btn_force_unload_step.Click, value2
				End If
				Me._btn_force_unload_step = value
				btn_force_unload_step = Me._btn_force_unload_step
				If btn_force_unload_step IsNot Nothing Then
					AddHandler btn_force_unload_step.Click, value2
				End If
			End Set
		End Property

		' Token: 0x170000DE RID: 222
		' (get) Token: 0x0600024D RID: 589 RVA: 0x00019613 File Offset: 0x00017813
		' (set) Token: 0x0600024E RID: 590 RVA: 0x0001961C File Offset: 0x0001781C
		Friend Overridable Property tmr_blink As Timer
			<CompilerGenerated()>
			Get
				Return Me._tmr_blink
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Timer)
				Dim value2 As EventHandler = AddressOf Me.Tmr_Blink_Tick
				Dim tmr_blink As Timer = Me._tmr_blink
				If tmr_blink IsNot Nothing Then
					RemoveHandler tmr_blink.Tick, value2
				End If
				Me._tmr_blink = value
				tmr_blink = Me._tmr_blink
				If tmr_blink IsNot Nothing Then
					AddHandler tmr_blink.Tick, value2
				End If
			End Set
		End Property

		' Token: 0x170000DF RID: 223
		' (get) Token: 0x0600024F RID: 591 RVA: 0x0001965F File Offset: 0x0001785F
		' (set) Token: 0x06000250 RID: 592 RVA: 0x00019667 File Offset: 0x00017867
		Friend Overridable Property Grp_stats As GroupBox

		' Token: 0x170000E0 RID: 224
		' (get) Token: 0x06000251 RID: 593 RVA: 0x00019670 File Offset: 0x00017870
		' (set) Token: 0x06000252 RID: 594 RVA: 0x00019678 File Offset: 0x00017878
		Friend Overridable Property btn_stat_edit As Button

		' Token: 0x170000E1 RID: 225
		' (get) Token: 0x06000253 RID: 595 RVA: 0x00019681 File Offset: 0x00017881
		' (set) Token: 0x06000254 RID: 596 RVA: 0x00019689 File Offset: 0x00017889
		Friend Overridable Property btn_Step_done As Button

		' Token: 0x170000E2 RID: 226
		' (get) Token: 0x06000255 RID: 597 RVA: 0x00019692 File Offset: 0x00017892
		' (set) Token: 0x06000256 RID: 598 RVA: 0x0001969A File Offset: 0x0001789A
		Friend Overridable Property btn_stat_save As Button

		' Token: 0x170000E3 RID: 227
		' (get) Token: 0x06000257 RID: 599 RVA: 0x000196A3 File Offset: 0x000178A3
		' (set) Token: 0x06000258 RID: 600 RVA: 0x000196AB File Offset: 0x000178AB
		Friend Overridable Property Button1 As Button

		' Token: 0x170000E4 RID: 228
		' (get) Token: 0x06000259 RID: 601 RVA: 0x000196B4 File Offset: 0x000178B4
		' (set) Token: 0x0600025A RID: 602 RVA: 0x000196BC File Offset: 0x000178BC
		Friend Overridable Property btn_stat_delete As Button

		' Token: 0x170000E5 RID: 229
		' (get) Token: 0x0600025B RID: 603 RVA: 0x000196C5 File Offset: 0x000178C5
		' (set) Token: 0x0600025C RID: 604 RVA: 0x000196CD File Offset: 0x000178CD
		Friend Overridable Property dgv_robot1_stats As DataGridView

		' Token: 0x170000E6 RID: 230
		' (get) Token: 0x0600025D RID: 605 RVA: 0x000196D6 File Offset: 0x000178D6
		' (set) Token: 0x0600025E RID: 606 RVA: 0x000196DE File Offset: 0x000178DE
		Friend Overridable Property DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn

		' Token: 0x170000E7 RID: 231
		' (get) Token: 0x0600025F RID: 607 RVA: 0x000196E7 File Offset: 0x000178E7
		' (set) Token: 0x06000260 RID: 608 RVA: 0x000196EF File Offset: 0x000178EF
		Friend Overridable Property DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn

		' Token: 0x170000E8 RID: 232
		' (get) Token: 0x06000261 RID: 609 RVA: 0x000196F8 File Offset: 0x000178F8
		' (set) Token: 0x06000262 RID: 610 RVA: 0x00019700 File Offset: 0x00017900
		Friend Overridable Property DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn

		' Token: 0x170000E9 RID: 233
		' (get) Token: 0x06000263 RID: 611 RVA: 0x00019709 File Offset: 0x00017909
		' (set) Token: 0x06000264 RID: 612 RVA: 0x00019711 File Offset: 0x00017911
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x170000EA RID: 234
		' (get) Token: 0x06000265 RID: 613 RVA: 0x0001971A File Offset: 0x0001791A
		' (set) Token: 0x06000266 RID: 614 RVA: 0x00019722 File Offset: 0x00017922
		Friend Overridable Property Column15 As DataGridViewTextBoxColumn

		' Token: 0x170000EB RID: 235
		' (get) Token: 0x06000267 RID: 615 RVA: 0x0001972B File Offset: 0x0001792B
		' (set) Token: 0x06000268 RID: 616 RVA: 0x00019733 File Offset: 0x00017933
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x170000EC RID: 236
		' (get) Token: 0x06000269 RID: 617 RVA: 0x0001973C File Offset: 0x0001793C
		' (set) Token: 0x0600026A RID: 618 RVA: 0x00019744 File Offset: 0x00017944
		Friend Overridable Property Column17 As DataGridViewTextBoxColumn

		' Token: 0x170000ED RID: 237
		' (get) Token: 0x0600026B RID: 619 RVA: 0x0001974D File Offset: 0x0001794D
		' (set) Token: 0x0600026C RID: 620 RVA: 0x00019755 File Offset: 0x00017955
		Friend Overridable Property lbl_robot1_stats_l As Label

		' Token: 0x170000EE RID: 238
		' (get) Token: 0x0600026D RID: 621 RVA: 0x0001975E File Offset: 0x0001795E
		' (set) Token: 0x0600026E RID: 622 RVA: 0x00019766 File Offset: 0x00017966
		Friend Overridable Property btn_stat_clear As Button

		' Token: 0x170000EF RID: 239
		' (get) Token: 0x0600026F RID: 623 RVA: 0x0001976F File Offset: 0x0001796F
		' (set) Token: 0x06000270 RID: 624 RVA: 0x00019777 File Offset: 0x00017977
		Friend Overridable Property lbl_programlist_l As Label

		' Token: 0x170000F0 RID: 240
		' (get) Token: 0x06000271 RID: 625 RVA: 0x00019780 File Offset: 0x00017980
		' (set) Token: 0x06000272 RID: 626 RVA: 0x00019788 File Offset: 0x00017988
		Friend Overridable Property btn_stat_insert As Button

		' Token: 0x170000F1 RID: 241
		' (get) Token: 0x06000273 RID: 627 RVA: 0x00019791 File Offset: 0x00017991
		' (set) Token: 0x06000274 RID: 628 RVA: 0x00019799 File Offset: 0x00017999
		Friend Overridable Property btn_stat_refresh As Button

		' Token: 0x170000F2 RID: 242
		' (get) Token: 0x06000275 RID: 629 RVA: 0x000197A2 File Offset: 0x000179A2
		' (set) Token: 0x06000276 RID: 630 RVA: 0x000197AA File Offset: 0x000179AA
		Friend Overridable Property dgv_programlist As DataGridView

		' Token: 0x170000F3 RID: 243
		' (get) Token: 0x06000277 RID: 631 RVA: 0x000197B3 File Offset: 0x000179B3
		' (set) Token: 0x06000278 RID: 632 RVA: 0x000197BB File Offset: 0x000179BB
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x170000F4 RID: 244
		' (get) Token: 0x06000279 RID: 633 RVA: 0x000197C4 File Offset: 0x000179C4
		' (set) Token: 0x0600027A RID: 634 RVA: 0x000197CC File Offset: 0x000179CC
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x170000F5 RID: 245
		' (get) Token: 0x0600027B RID: 635 RVA: 0x000197D5 File Offset: 0x000179D5
		' (set) Token: 0x0600027C RID: 636 RVA: 0x000197DD File Offset: 0x000179DD
		Friend Overridable Property Column13 As DataGridViewTextBoxColumn

		' Token: 0x170000F6 RID: 246
		' (get) Token: 0x0600027D RID: 637 RVA: 0x000197E6 File Offset: 0x000179E6
		' (set) Token: 0x0600027E RID: 638 RVA: 0x000197F0 File Offset: 0x000179F0
		Friend Overridable Property btn_reset_cyc_main As Button
			<CompilerGenerated()>
			Get
				Return Me._btn_reset_cyc_main
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As EventHandler = AddressOf Me.btn_reset_cyc_Click
				Dim btn_reset_cyc_main As Button = Me._btn_reset_cyc_main
				If btn_reset_cyc_main IsNot Nothing Then
					RemoveHandler btn_reset_cyc_main.Click, value2
				End If
				Me._btn_reset_cyc_main = value
				btn_reset_cyc_main = Me._btn_reset_cyc_main
				If btn_reset_cyc_main IsNot Nothing Then
					AddHandler btn_reset_cyc_main.Click, value2
				End If
			End Set
		End Property

		' Token: 0x04000018 RID: 24
		Private Const N_AX As Integer = 4

		' Token: 0x04000019 RID: 25
		Private Const N_LINES As Integer = 2

		' Token: 0x0400001A RID: 26
		Private Const N_STATION As Integer = 4

		' Token: 0x0400001B RID: 27
		Private Const N_MIN_PROGRAM As Integer = 19

		' Token: 0x0400001C RID: 28
		Private Const N_MIN_STATS_ROW As Integer = 10

		' Token: 0x0400001D RID: 29
		Private Const N_FIELD_stats As Integer = 6

		' Token: 0x0400001E RID: 30
		Public Const CSV_SEP As String = ";"

		' Token: 0x0400001F RID: 31
		Private Const TERM_IDX As Integer = 0

		' Token: 0x04000020 RID: 32
		Private Const MAIN_IDX As Integer = 20

		' Token: 0x04000021 RID: 33
		Private Const PLANT_IDX As Integer = 50

		' Token: 0x04000022 RID: 34
		Private Const RB_INFO_IDX As Integer = 80

		' Token: 0x04000023 RID: 35
		Private Const WARN_IDX As Integer = 150

		' Token: 0x04000024 RID: 36
		Private Const PAR_IDX As Integer = 230

		' Token: 0x04000025 RID: 37
		Private Const DIAG_IDX As Integer = 250

		' Token: 0x04000026 RID: 38
		Private Const ALARM_IDX As Integer = 290

		' Token: 0x04000027 RID: 39
		Private Const LOG_IDX As Integer = 300

		' Token: 0x04000028 RID: 40
		Private Const STATS_IDX As Integer = 400

		' Token: 0x04000029 RID: 41
		Private Const MSG_IDX As Integer = 500

		' Token: 0x0400002A RID: 42
		Private Const RB_CONN_IDX As Integer = 530

		' Token: 0x0400002B RID: 43
		Private Const N_LABEL As Integer = 700

		' Token: 0x0400002C RID: 44
		Private Const PAR_OVEN_DOOR_IN_EN As Integer = 36

		' Token: 0x0400002D RID: 45
		Private Const PAR_OVEN_TIMEOUT As Integer = 46

		' Token: 0x0400002E RID: 46
		Private Const PAR_EN_REMOTE_PRG_LST As Integer = 53

		' Token: 0x0400002F RID: 47
		Private Const PAR_EN_SEND_STATS_SERVER As Integer = 54

		' Token: 0x04000030 RID: 48
		Public Const NO_WARN As Integer = 0

		' Token: 0x04000031 RID: 49
		Public Const PLANT_NOT_READY_MOTOR As Integer = 1

		' Token: 0x04000032 RID: 50
		Public Const RB1_NOT_READY As Integer = 2

		' Token: 0x04000033 RID: 51
		Public Const RB2_NOT_READY As Integer = 3

		' Token: 0x04000034 RID: 52
		Public Const LOAD_ST_EMERG As Integer = 4

		' Token: 0x04000035 RID: 53
		Public Const UNLOAD_ST_EMERG As Integer = 5

		' Token: 0x04000036 RID: 54
		Public Const BARRIER_LOAD_TIMEOUT As Integer = 6

		' Token: 0x04000037 RID: 55
		Public Const PLANT_NOT_READY_MODE As Integer = 7

		' Token: 0x04000038 RID: 56
		Public Const UNLOAD_BUSY As Integer = 8

		' Token: 0x04000039 RID: 57
		Public Const LIST_NOT_EMPTY As Integer = 9

		' Token: 0x0400003A RID: 58
		Public Const PRG_RUN As Integer = 10

		' Token: 0x0400003B RID: 59
		Public Const OVEN_AND_PAINT_BUSY As Integer = 11

		' Token: 0x0400003C RID: 60
		Public Const RB1_NOT_SAFE_POS As Integer = 12

		' Token: 0x0400003D RID: 61
		Public Const RB2_NOT_SAFE_POS As Integer = 13

		' Token: 0x0400003E RID: 62
		Public Const BARRIER_UNLOAD_TIMEOUT As Integer = 14

		' Token: 0x0400003F RID: 63
		Public Const SAFE_POS_UNLOAD_BELT As Integer = 15

		' Token: 0x04000040 RID: 64
		Public Const MANUAL_MODE As Integer = 16

		' Token: 0x04000041 RID: 65
		Public Const DOOR_OPEN As Integer = 17

		' Token: 0x04000042 RID: 66
		Public Const SIR_PLANT_KO As Integer = 18

		' Token: 0x04000043 RID: 67
		Public Const SR20G_NOT_READY As Integer = 19

		' Token: 0x04000044 RID: 68
		Public Const PAINT_ST_BUSY As Integer = 20

		' Token: 0x04000045 RID: 69
		Public Const PLANT_NOT_READY As Integer = 21

		' Token: 0x04000046 RID: 70
		Public Const CHANGE_PROD_CODE As Integer = 22

		' Token: 0x04000047 RID: 71
		Public Const BARRIER_RESET_LOAD As Integer = 23

		' Token: 0x04000048 RID: 72
		Public Const SAFE_POS_PAINT_BELT As Integer = 24

		' Token: 0x04000049 RID: 73
		Public Const LINE_EMPTY As Integer = 25

		' Token: 0x0400004A RID: 74
		Public Const EMPTY_OVEN_MODE As Integer = 26

		' Token: 0x0400004B RID: 75
		Public Const EMPTY_OVEN_PAINT_ST As Integer = 27

		' Token: 0x0400004C RID: 76
		Public Const EMPTY_OVEN_BELT_NOT_READY As Integer = 28

		' Token: 0x0400004D RID: 77
		Public Const EMPTY_PAINT_MODE As Integer = 29

		' Token: 0x0400004E RID: 78
		Public Const EMPTY_PAINT_PAINT_ST As Integer = 30

		' Token: 0x0400004F RID: 79
		Public Const EMPTY_PAINT_BELT_NOT_READY As Integer = 31

		' Token: 0x04000050 RID: 80
		Public Const OVEN_PAINT_AUTOEMPTY_RUN As Integer = 32

		' Token: 0x04000051 RID: 81
		Public Const WAITING_OVEN As Integer = 33

		' Token: 0x04000052 RID: 82
		Public Const CARTER_NOT_LOW As Integer = 34

		' Token: 0x04000053 RID: 83
		Public Const NO_PIECE_LINE As Integer = 35

		' Token: 0x04000054 RID: 84
		Public Const BELTS_AUTO_OP_ONGOING As Integer = 36

		' Token: 0x04000055 RID: 85
		Public Const FORCE_UNLOAD_OP_ONGOING As Integer = 37

		' Token: 0x04000056 RID: 86
		Public Const RB_NOT_CONNECTED As Integer = 38

		' Token: 0x04000057 RID: 87
		Private ax_pos_vb As Single()

		' Token: 0x04000058 RID: 88
		Public cnt_pieces_vb As Single()

		' Token: 0x04000059 RID: 89
		Private ax_status_vb As Integer()

		' Token: 0x0400005A RID: 90
		Private ax_status_color As Color()

		' Token: 0x0400005B RID: 91
		Private timeout_oven_vb As Double

		' Token: 0x0400005C RID: 92
		Private connection_delay As Single

		' Token: 0x0400005D RID: 93
		Private psw_popup As Boolean

		' Token: 0x0400005E RID: 94
		Private psw_popup_master As Boolean

		' Token: 0x0400005F RID: 95
		Public StatoPresence As Boolean()

		' Token: 0x04000060 RID: 96
		Public debug_var_VB As Double()

		' Token: 0x04000061 RID: 97
		Public cma_labels As String()

		' Token: 0x04000062 RID: 98
		Private LoadingPar As Boolean

		' Token: 0x04000063 RID: 99
		Private R1_status_idx_vb As Integer

		' Token: 0x04000064 RID: 100
		Private R2_status_idx_vb As Integer

		' Token: 0x04000065 RID: 101
		Private R1_n_list_vb As Integer

		' Token: 0x04000066 RID: 102
		Private R2_n_list_vb As Integer

		' Token: 0x04000067 RID: 103
		Private R1_safe_position_vb As Integer

		' Token: 0x04000068 RID: 104
		Private R1_carter_Low_vb As Boolean

		' Token: 0x04000069 RID: 105
		Private R2_safe_position_vb As Integer

		' Token: 0x0400006A RID: 106
		Private Piece_Presence_vb As Integer()

		' Token: 0x0400006B RID: 107
		Private blink_step As Double

		' Token: 0x0400006C RID: 108
		Private Progr_Code_vb As String

		' Token: 0x0400006D RID: 109
		Private Terminal_ErrCode_vb As Integer

		' Token: 0x0400006E RID: 110
		Private clk_oven_VB As Integer

		' Token: 0x0400006F RID: 111
		Private clk_paint_VB As Integer

		' Token: 0x04000070 RID: 112
		Private flag_force_unload_vb As Integer

		' Token: 0x04000071 RID: 113
		Private cmd_str_oven_t_vb As Boolean

		' Token: 0x04000072 RID: 114
		Private par_en_remote_programlist As Boolean

		' Token: 0x04000073 RID: 115
		Private par_en_remote_path As Boolean

		' Token: 0x04000074 RID: 116
		Private par_en_oven_door As Boolean

		' Token: 0x04000075 RID: 117
		Private Plant As FormPrincipale.StGenerali

		' Token: 0x04000076 RID: 118
		Private LoadTape_vb As FormPrincipale.St_Tape

		' Token: 0x04000077 RID: 119
		Private OvenTape_vb As FormPrincipale.St_Tape

		' Token: 0x04000078 RID: 120
		Private PaintTape_vb As FormPrincipale.St_Tape

		' Token: 0x04000079 RID: 121
		Private UnloadTape_vb As FormPrincipale.St_Tape

		' Token: 0x0400007A RID: 122
		Private Lng As String

		' Token: 0x0400007B RID: 123
		Public service As Service

		' Token: 0x0400007C RID: 124
		Public cpu As Cpu

		' Token: 0x0400007D RID: 125
		Private cpu_address As String

		' Token: 0x0400007E RID: 126
		Private source_station As String

		' Token: 0x0400007F RID: 127
		Private destination_station As String

		' Token: 0x04000080 RID: 128
		Private Const TOT_MOD As Integer = 6

		' Token: 0x04000081 RID: 129
		Private Const TOT_LOAD As Integer = 40

		' Token: 0x04000082 RID: 130
		Private connect_counter As Integer

		' Token: 0x04000083 RID: 131
		Private var_inst_counter As Integer

		' Token: 0x04000084 RID: 132
		Private var_con_counter As Integer

		' Token: 0x04000085 RID: 133
		Private task_inst_counter As Integer

		' Token: 0x04000086 RID: 134
		Private task_con_counter As Integer

		' Token: 0x04000087 RID: 135
		Private mod_con_counter As Integer

		' Token: 0x04000088 RID: 136
		Private pvi_ok As Boolean

		' Token: 0x04000089 RID: 137
		Private pvi_error As Boolean

		' Token: 0x0400008A RID: 138
		Public ax_pos As Variable

		' Token: 0x0400008B RID: 139
		Public ax_status As Variable

		' Token: 0x0400008C RID: 140
		Public MainStepDone As Variable

		' Token: 0x0400008D RID: 141
		Public presence As Variable

		' Token: 0x0400008E RID: 142
		Public debug_var As Variable

		' Token: 0x0400008F RID: 143
		Public par_VB As Variable

		' Token: 0x04000090 RID: 144
		Public man_ax As Variable

		' Token: 0x04000091 RID: 145
		Public DIn As Variable

		' Token: 0x04000092 RID: 146
		Public DOut As Variable

		' Token: 0x04000093 RID: 147
		Public FDOut As Variable

		' Token: 0x04000094 RID: 148
		Public force_out As Variable

		' Token: 0x04000095 RID: 149
		Public axis_status As Variable

		' Token: 0x04000096 RID: 150
		Public vis_error_list As Variable

		' Token: 0x04000097 RID: 151
		Public vis_error As Variable

		' Token: 0x04000098 RID: 152
		Public cmd_master As Variable

		' Token: 0x04000099 RID: 153
		Public stato_ciclica As Variable

		' Token: 0x0400009A RID: 154
		Public reset_auto As Variable

		' Token: 0x0400009B RID: 155
		Public waiting_resume As Variable

		' Token: 0x0400009C RID: 156
		Public IMA_R1_in As Variable

		' Token: 0x0400009D RID: 157
		Public IMA_R2_in As Variable

		' Token: 0x0400009E RID: 158
		Public IMA_IN_vb As Variable

		' Token: 0x0400009F RID: 159
		Public IMA_OUT_vb As Variable

		' Token: 0x040000A0 RID: 160
		Public cmd_TogglePaintDoorIN As Variable

		' Token: 0x040000A1 RID: 161
		Public cmd_TogglePaintDoorOUT As Variable

		' Token: 0x040000A2 RID: 162
		Public DI_Force_Unload As Variable

		' Token: 0x040000A3 RID: 163
		Public flag_force_unload As Variable

		' Token: 0x040000A4 RID: 164
		Private Prog_Code As Variable

		' Token: 0x040000A5 RID: 165
		Private Terminal_ErrCode As Variable

		' Token: 0x040000A6 RID: 166
		Private reset_error_vb As Variable

		' Token: 0x040000A7 RID: 167
		Private LoadTape As Variable

		' Token: 0x040000A8 RID: 168
		Private OvenTape As Variable

		' Token: 0x040000A9 RID: 169
		Private PaintTape As Variable

		' Token: 0x040000AA RID: 170
		Private UnloadTape As Variable

		' Token: 0x040000AB RID: 171
		Public abs_encoder As FormPrincipale.master_abs_enc()

		' Token: 0x040000AC RID: 172
		Public abs_enc As Variable

		' Token: 0x040000AD RID: 173
		Public mmNastro As Variable

		' Token: 0x040000AE RID: 174
		Public cmd_Oven_auto_step As Variable

		' Token: 0x040000AF RID: 175
		Public clk_oven As Variable

		' Token: 0x040000B0 RID: 176
		Public clk_paint As Variable

		' Token: 0x040000B1 RID: 177
		Public cmd_str_oven_t As Variable

		' Token: 0x040000B2 RID: 178
		Public oven_time_end As Variable

		' Token: 0x040000B3 RID: 179
		Private cpu_restart_request As Boolean

		' Token: 0x040000B4 RID: 180
		Private cont As Integer

		' Token: 0x040000B5 RID: 181
		Private DO_Unload_Confirm_Lamp_old As Integer

		' Token: 0x040000B6 RID: 182
		Private MainStepDone_vb_old As Boolean

		' Token: 0x040000B7 RID: 183
		Private di_string As String()

		' Token: 0x040000B8 RID: 184
		Private do_string As String()

		' Token: 0x040000B9 RID: 185
		Private vis_stato_ciclica As Integer()

		' Token: 0x040000BA RID: 186
		Private master_data As Integer()

		' Token: 0x040000BB RID: 187
		Private idx_IMA_R1 As Integer

		' Token: 0x040000BC RID: 188
		Private idx_IMA_R2 As Integer

		' Token: 0x040000BD RID: 189
		Private idx_DIG_IN As Integer

		' Token: 0x040000BE RID: 190
		Private idx_DIG_OUT As Integer

		' Token: 0x040000BF RID: 191
		Private ServerR1 As Socket

		' Token: 0x040000C0 RID: 192
		Private ServerR2 As Socket

		' Token: 0x040000C1 RID: 193
		Private ClientR1 As Socket

		' Token: 0x040000C2 RID: 194
		Private ClientR2 As Socket

		' Token: 0x040000C3 RID: 195
		Private R1_Connected As Integer

		' Token: 0x040000C4 RID: 196
		Private R2_Connected As Integer

		' Token: 0x040000C5 RID: 197
		Private R1_Connected_old As Integer

		' Token: 0x040000C6 RID: 198
		Private R1_rec_string As String

		' Token: 0x040000C7 RID: 199
		Private R2_rec_string As String

		' Token: 0x040000C8 RID: 200
		Private ServerPortR1 As Integer

		' Token: 0x040000C9 RID: 201
		Private ServerPortR2 As Integer

		' Token: 0x040000CA RID: 202
		Private string_complete As Long

		' Token: 0x040000CB RID: 203
		Private check_string_complete As Boolean

		' Token: 0x040000CC RID: 204
		Private send_active As Boolean()

		' Token: 0x040000CD RID: 205
		Private check_active As Boolean()

		' Token: 0x040000CE RID: 206
		Private send_string As String()

		' Token: 0x040000CF RID: 207
		Private check_string As String()

		' Token: 0x040000D0 RID: 208
		Private send_code As String()

		' Token: 0x040000D1 RID: 209
		Private send_res As String()

		' Token: 0x040000D2 RID: 210
		Private tmr_send As Integer()

		' Token: 0x040000D3 RID: 211
		Private IpServer As String

		' Token: 0x040000D4 RID: 212
		Private robot_program As String()

		' Token: 0x040000D5 RID: 213
		Private split_string As String()

		' Token: 0x040000D6 RID: 214
		Private new_date As String

		' Token: 0x040000D7 RID: 215
		Private act_date As String

		' Token: 0x040000D8 RID: 216
		Private DO_Load_Confirm_Lamp_OLD As Boolean

		' Token: 0x040000D9 RID: 217
		Private DI_Load_Confirm_Btn_OLD As Boolean

		' Token: 0x040000DA RID: 218
		Private DO_AUTO_Lamp_OLD As Boolean

		' Token: 0x040000DB RID: 219
		Private DI_Empty_Line_OLD As Boolean

		' Token: 0x040000DC RID: 220
		Private progr_code_tmp As String

		' Token: 0x040000DD RID: 221
		Private date_progrlist_act As DateTime

		' Token: 0x040000DE RID: 222
		Private date_progrlist_old As DateTime

		' Token: 0x040000DF RID: 223
		Private date_statsR1_act As DateTime

		' Token: 0x040000E0 RID: 224
		Private date_statsR1_old As DateTime

		' Token: 0x040000E1 RID: 225
		Private error_on_1 As Boolean

		' Token: 0x040000E2 RID: 226
		Private StrLabels As String()

		' Token: 0x040000E3 RID: 227
		Private init_prog_ok As Boolean

		' Token: 0x02000017 RID: 23
		Public Structure St_Tape
			' Token: 0x0400024E RID: 590
			Public DI_DoorIN_open As Boolean

			' Token: 0x0400024F RID: 591
			Public DI_DoorIN_close As Boolean

			' Token: 0x04000250 RID: 592
			Public DI_DoorOUT_open As Boolean

			' Token: 0x04000251 RID: 593
			Public DI_DoorOUT_close As Boolean

			' Token: 0x04000252 RID: 594
			Public DI_Presence_start As Boolean

			' Token: 0x04000253 RID: 595
			Public DI_Presence_end As Boolean

			' Token: 0x04000254 RID: 596
			Public DI_Emerg_Btn As Boolean

			' Token: 0x04000255 RID: 597
			Public DI_Confirm_Btn As Boolean

			' Token: 0x04000256 RID: 598
			Public DI_Barrier As Boolean

			' Token: 0x04000257 RID: 599
			Public DO_DoorIN_open As Boolean

			' Token: 0x04000258 RID: 600
			Public DO_DoorIN_close As Boolean

			' Token: 0x04000259 RID: 601
			Public DO_DoorOUT_open As Boolean

			' Token: 0x0400025A RID: 602
			Public DO_DoorOUT_close As Boolean

			' Token: 0x0400025B RID: 603
			Public DO_DoorIN_Open_Lamp As Boolean

			' Token: 0x0400025C RID: 604
			Public DO_DoorOUT_Open_Lamp As Boolean

			' Token: 0x0400025D RID: 605
			Public DO_Doors_Locked As Boolean

			' Token: 0x0400025E RID: 606
			Public DO_Confirm_Lamp As Boolean

			' Token: 0x0400025F RID: 607
			Public Prog_Code As String
		End Structure

		' Token: 0x02000018 RID: 24
		Public Structure StGenerali
			' Token: 0x04000260 RID: 608
			Public DO_AUTO_Lamp As Boolean

			' Token: 0x04000261 RID: 609
			Public DO_POW_ON_Lamp As Boolean

			' Token: 0x04000262 RID: 610
			Public DO_LED_ALLARMI As Boolean

			' Token: 0x04000263 RID: 611
			Public DI_EMERGENZA_Generale As Boolean

			' Token: 0x04000264 RID: 612
			Public DI_BarrieraCarico As Boolean

			' Token: 0x04000265 RID: 613
			Public DI_BarrieraScarico As Boolean

			' Token: 0x04000266 RID: 614
			Public DI_Automatico As Boolean

			' Token: 0x04000267 RID: 615
			Public InScarico As Boolean
		End Structure

		' Token: 0x02000019 RID: 25
		Public Structure master_abs_enc
			' Token: 0x04000268 RID: 616
			Public master_ok As Boolean

			' Token: 0x04000269 RID: 617
			Public offset As Integer

			' Token: 0x0400026A RID: 618
			Public n_overflow As Integer

			' Token: 0x0400026B RID: 619
			Public n_mod_overflow As Integer

			' Token: 0x0400026C RID: 620
			Public actual_pos As Integer

			' Token: 0x0400026D RID: 621
			Public rest As Single
		End Structure

		' Token: 0x0200001A RID: 26
		Public Class StateObject
			' Token: 0x0600038F RID: 911 RVA: 0x000205F6 File Offset: 0x0001E7F6
			Public Sub New()
				Me.workSocket = Nothing
				Me.BufferSize = 100000
				Me.buffer = New Byte(99999) {}
				Me.sb = New StringBuilder()
			End Sub

			' Token: 0x0400026E RID: 622
			Public workSocket As Socket

			' Token: 0x0400026F RID: 623
			Public BufferSize As Integer

			' Token: 0x04000270 RID: 624
			Public buffer As Byte()

			' Token: 0x04000271 RID: 625
			Public sb As StringBuilder
		End Class

		Private _lvw_par As ListView
		Private _btn_par_edit As Button
		Private _dgv_ax As DataGridView
		Private _dgv_master As DataGridView
		Private _tmr_start As Timer
		Private _tmr_eth As Timer
		Private _chb_password As CheckBox
		Private _btn_reset_cyc As Button
		Private _TmrShowDescrizione As Timer
		Private _TmrChekbox As Timer
		Private _LblDescrizione As Label
		Private _cmb_act_code As ComboBox
		Private _BtnOpenDoorOUT As Button
		Private _BtnOpenDoorIN As Button
		Private _lbl_code_Paint As Label
		Private _lbl_reset_warning As Button
		Private _lbl_reset_errors As Button
		Private _dgv_dout_IMA As DataGridView
		Private _dgv_dout As DataGridView
		Private _btn_force As Button
		Private _tmr_psw As Timer
		Private _lbl_act_code As Label
		Private _lbl_act_option As Label
		Private _lbl_act_batch As Label
		Private _lbl_code_Oven As Label
		Private _btn_oven_t_plus As Button
		Private _btn_force_oven_timeout As Button
		Private _btn_oven_t_min As Button
		Private _btn_Send_tcpip As Button
		Private _btn_force_unload_step As Button
		Private _tmr_blink As Timer
		Private _btn_reset_cyc_main As Button
	End Class
End Namespace
