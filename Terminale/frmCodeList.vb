Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace Terminale
	' Token: 0x02000008 RID: 8
	Public Partial Class frmCodeList
		Inherits Form

		' Token: 0x0600001B RID: 27 RVA: 0x0000230B File Offset: 0x0000050B
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frm_CodeList
			Me.InitializeComponent()
		End Sub

		' Token: 0x17000012 RID: 18
		' (get) Token: 0x0600001E RID: 30 RVA: 0x00002736 File Offset: 0x00000936
		' (set) Token: 0x0600001F RID: 31 RVA: 0x00002740 File Offset: 0x00000940
		Friend Overridable Property btn_code_list_ok As Button
			<CompilerGenerated()>
			Get
				Return Me._btn_code_list_ok
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As EventHandler = AddressOf Me.btn_code_list_ok_Click
				Dim btn_code_list_ok As Button = Me._btn_code_list_ok
				If btn_code_list_ok IsNot Nothing Then
					RemoveHandler btn_code_list_ok.Click, value2
				End If
				Me._btn_code_list_ok = value
				btn_code_list_ok = Me._btn_code_list_ok
				If btn_code_list_ok IsNot Nothing Then
					AddHandler btn_code_list_ok.Click, value2
				End If
			End Set
		End Property

		' Token: 0x17000013 RID: 19
		' (get) Token: 0x06000020 RID: 32 RVA: 0x00002783 File Offset: 0x00000983
		' (set) Token: 0x06000021 RID: 33 RVA: 0x0000278C File Offset: 0x0000098C
		Friend Overridable Property btn_code_list_cancel As Button
			<CompilerGenerated()>
			Get
				Return Me._btn_code_list_cancel
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As EventHandler = AddressOf Me.btn_code_list_cancel_Click
				Dim btn_code_list_cancel As Button = Me._btn_code_list_cancel
				If btn_code_list_cancel IsNot Nothing Then
					RemoveHandler btn_code_list_cancel.Click, value2
				End If
				Me._btn_code_list_cancel = value
				btn_code_list_cancel = Me._btn_code_list_cancel
				If btn_code_list_cancel IsNot Nothing Then
					AddHandler btn_code_list_cancel.Click, value2
				End If
			End Set
		End Property

		' Token: 0x17000014 RID: 20
		' (get) Token: 0x06000022 RID: 34 RVA: 0x000027CF File Offset: 0x000009CF
		' (set) Token: 0x06000023 RID: 35 RVA: 0x000027D8 File Offset: 0x000009D8
		Friend Overridable Property dgv_code_prg_list As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgv_code_prg_list
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim value2 As DataGridViewCellEventHandler = AddressOf Me.dgv_code_prg_list_CellContentClick
				Dim dgv_code_prg_list As DataGridView = Me._dgv_code_prg_list
				If dgv_code_prg_list IsNot Nothing Then
					RemoveHandler dgv_code_prg_list.CellClick, value2
				End If
				Me._dgv_code_prg_list = value
				dgv_code_prg_list = Me._dgv_code_prg_list
				If dgv_code_prg_list IsNot Nothing Then
					AddHandler dgv_code_prg_list.CellClick, value2
				End If
			End Set
		End Property

		' Token: 0x17000015 RID: 21
		' (get) Token: 0x06000024 RID: 36 RVA: 0x0000281B File Offset: 0x00000A1B
		' (set) Token: 0x06000025 RID: 37 RVA: 0x00002824 File Offset: 0x00000A24
		Friend Overridable Property lbl_code_selected As Label
			<CompilerGenerated()>
			Get
				Return Me._lbl_code_selected
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Dim value2 As EventHandler = AddressOf Me.lbl_code_selected_Click
				Dim lbl_code_selected As Label = Me._lbl_code_selected
				If lbl_code_selected IsNot Nothing Then
					RemoveHandler lbl_code_selected.Click, value2
				End If
				Me._lbl_code_selected = value
				lbl_code_selected = Me._lbl_code_selected
				If lbl_code_selected IsNot Nothing Then
					AddHandler lbl_code_selected.Click, value2
				End If
			End Set
		End Property

		' Token: 0x17000016 RID: 22
		' (get) Token: 0x06000026 RID: 38 RVA: 0x00002867 File Offset: 0x00000A67
		' (set) Token: 0x06000027 RID: 39 RVA: 0x0000286F File Offset: 0x00000A6F
		Friend Overridable Property DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn

		' Token: 0x17000017 RID: 23
		' (get) Token: 0x06000028 RID: 40 RVA: 0x00002878 File Offset: 0x00000A78
		' (set) Token: 0x06000029 RID: 41 RVA: 0x00002880 File Offset: 0x00000A80
		Friend Overridable Property Batch As DataGridViewTextBoxColumn

		' Token: 0x17000018 RID: 24
		' (get) Token: 0x0600002A RID: 42 RVA: 0x00002889 File Offset: 0x00000A89
		' (set) Token: 0x0600002B RID: 43 RVA: 0x00002891 File Offset: 0x00000A91
		Friend Overridable Property Opt As DataGridViewTextBoxColumn

		' Token: 0x0600002C RID: 44 RVA: 0x0000289A File Offset: 0x00000A9A
		Private Sub frm_CodeList(sender As Object, e As EventArgs)
			MyBase.TopMost = True
			Me.LoadCodeList()
		End Sub

		' Token: 0x0600002D RID: 45 RVA: 0x000028A9 File Offset: 0x00000AA9
		Private Sub btn_code_list_ok_Click(sender As Object, e As EventArgs)
			Me.code = Me.lbl_code_selected.Text
			Me.WriteOK = True
			MyBase.Close()
		End Sub

		' Token: 0x0600002E RID: 46 RVA: 0x000028C9 File Offset: 0x00000AC9
		Private Sub btn_code_list_cancel_Click(sender As Object, e As EventArgs)
			Me.WriteOK = False
			MyBase.Close()
		End Sub

		' Token: 0x0600002F RID: 47 RVA: 0x000028D8 File Offset: 0x00000AD8
		Private Sub LoadCodeList()
			' The following expression was wrapped in a checked-statement
			Try
				If New FileInfo(Path.DATA_PATH + Path.PATH_PRODLIST + "ProgramList.txt").Exists Then
					Dim streamReader As StreamReader = New StreamReader(Path.DATA_PATH + Path.PATH_PRODLIST + "ProgramList.txt")
					Dim num As Integer = 1
					Dim num2 As Integer = File.ReadAllLines(Path.DATA_PATH + Path.PATH_PRODLIST + "ProgramList.txt").Length
					If num2 > 10 Then
						Me.dgv_code_prg_list.RowCount = num2 + 1
					Else
						Me.dgv_code_prg_list.RowCount = 12
					End If
					Me.dgv_code_prg_list(0, 0).Value = "EMPTY CODE"
					Me.dgv_code_prg_list(1, 0).Value = ""
					Me.dgv_code_prg_list(2, 0).Value = ""
					While streamReader.Peek() >= 0
						Dim array As String() = Strings.Split(streamReader.ReadLine(), "|", -1, CompareMethod.Binary)
						Me.dgv_code_prg_list(0, num).Value = array(0)
						Me.dgv_code_prg_list(1, num).Value = array(1)
						Me.dgv_code_prg_list(2, num).Value = array(2)
						num += 1
					End While
					If num <= 11 Then
						For i As Integer = num To 10
							Me.dgv_code_prg_list(0, i).Value = ""
							Me.dgv_code_prg_list(1, i).Value = ""
							Me.dgv_code_prg_list(2, i).Value = ""
						Next
					End If
					streamReader.Close()
				End If
			Catch ex As Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x06000030 RID: 48 RVA: 0x00002AC0 File Offset: 0x00000CC0
		Private Sub lbl_code_selected_Click(sender As Object, e As EventArgs)
			Dim frmTouchKey As frmTouchKey = New frmTouchKey()
			frmTouchKey.ShowDialog()
			If frmTouchKey.Responce Then
				Me.lbl_code_selected.Text = frmTouchKey.KeyText
			End If
			Me.code_batch = ""
			Me.code_opt = ""
		End Sub

		' Token: 0x06000031 RID: 49 RVA: 0x00002B0C File Offset: 0x00000D0C
		Private Sub dgv_code_prg_list_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
			Try
				If Me.dgv_code_prg_list(0, Me.dgv_code_prg_list.CurrentCell.RowIndex).Value IsNot Nothing Then
					Me.lbl_code_selected.Text = Me.dgv_code_prg_list(0, Me.dgv_code_prg_list.CurrentCell.RowIndex).Value.ToString()
					Me.code_batch = Me.dgv_code_prg_list(1, Me.dgv_code_prg_list.CurrentCell.RowIndex).Value.ToString()
					Me.code_opt = Me.dgv_code_prg_list(2, Me.dgv_code_prg_list.CurrentCell.RowIndex).Value.ToString()
				End If
			Catch ex As Exception
				Interaction.MsgBox(Information.Err().Description + " Function: " + MethodBase.GetCurrentMethod().Name, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x04000013 RID: 19
		Private Const N_MIN_PROGRAM As Integer = 10

		' Token: 0x04000014 RID: 20
		Public code As String

		' Token: 0x04000015 RID: 21
		Public code_batch As String

		' Token: 0x04000016 RID: 22
		Public code_opt As String

		' Token: 0x04000017 RID: 23
		Public WriteOK As Boolean

		Private _btn_code_list_ok As Button
		Private _btn_code_list_cancel As Button
		Private _dgv_code_prg_list As DataGridView
		Private _lbl_code_selected As Label
	End Class
End Namespace
