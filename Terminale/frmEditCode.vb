Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports Terminale.My.Resources

Namespace Terminale
	' Token: 0x0200000C RID: 12
	Public Partial Class frmEditCode
		Inherits Form

		' Token: 0x06000298 RID: 664 RVA: 0x0001A0C3 File Offset: 0x000182C3
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmEditCode_Load
			Me.InitializeComponent()
		End Sub

		' Token: 0x170000FD RID: 253
		' (get) Token: 0x0600029B RID: 667 RVA: 0x0001ADD4 File Offset: 0x00018FD4
		' (set) Token: 0x0600029C RID: 668 RVA: 0x0001ADDC File Offset: 0x00018FDC
		Friend Overridable Property Label6 As Label

		' Token: 0x170000FE RID: 254
		' (get) Token: 0x0600029D RID: 669 RVA: 0x0001ADE5 File Offset: 0x00018FE5
		' (set) Token: 0x0600029E RID: 670 RVA: 0x0001ADF0 File Offset: 0x00018FF0
		Friend Overridable Property lbl_code As Label
			<CompilerGenerated()>
			Get
				Return Me._lbl_code
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Dim value2 As EventHandler = AddressOf Me.lbl_code_Click
				Dim lbl_code As Label = Me._lbl_code
				If lbl_code IsNot Nothing Then
					RemoveHandler lbl_code.Click, value2
				End If
				Me._lbl_code = value
				lbl_code = Me._lbl_code
				If lbl_code IsNot Nothing Then
					AddHandler lbl_code.Click, value2
				End If
			End Set
		End Property

		' Token: 0x170000FF RID: 255
		' (get) Token: 0x0600029F RID: 671 RVA: 0x0001AE33 File Offset: 0x00019033
		' (set) Token: 0x060002A0 RID: 672 RVA: 0x0001AE3B File Offset: 0x0001903B
		Friend Overridable Property Label1 As Label

		' Token: 0x17000100 RID: 256
		' (get) Token: 0x060002A1 RID: 673 RVA: 0x0001AE44 File Offset: 0x00019044
		' (set) Token: 0x060002A2 RID: 674 RVA: 0x0001AE4C File Offset: 0x0001904C
		Friend Overridable Property lbl_H As Label
			<CompilerGenerated()>
			Get
				Return Me._lbl_H
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Dim value2 As EventHandler = AddressOf Me.lbl_HLW_Click
				Dim lbl_H As Label = Me._lbl_H
				If lbl_H IsNot Nothing Then
					RemoveHandler lbl_H.Click, value2
				End If
				Me._lbl_H = value
				lbl_H = Me._lbl_H
				If lbl_H IsNot Nothing Then
					AddHandler lbl_H.Click, value2
				End If
			End Set
		End Property

		' Token: 0x17000101 RID: 257
		' (get) Token: 0x060002A3 RID: 675 RVA: 0x0001AE8F File Offset: 0x0001908F
		' (set) Token: 0x060002A4 RID: 676 RVA: 0x0001AE97 File Offset: 0x00019097
		Friend Overridable Property Label3 As Label

		' Token: 0x17000102 RID: 258
		' (get) Token: 0x060002A5 RID: 677 RVA: 0x0001AEA0 File Offset: 0x000190A0
		' (set) Token: 0x060002A6 RID: 678 RVA: 0x0001AEA8 File Offset: 0x000190A8
		Friend Overridable Property lbl_L As Label
			<CompilerGenerated()>
			Get
				Return Me._lbl_L
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Dim value2 As EventHandler = AddressOf Me.lbl_HLW_Click
				Dim lbl_L As Label = Me._lbl_L
				If lbl_L IsNot Nothing Then
					RemoveHandler lbl_L.Click, value2
				End If
				Me._lbl_L = value
				lbl_L = Me._lbl_L
				If lbl_L IsNot Nothing Then
					AddHandler lbl_L.Click, value2
				End If
			End Set
		End Property

		' Token: 0x17000103 RID: 259
		' (get) Token: 0x060002A7 RID: 679 RVA: 0x0001AEEB File Offset: 0x000190EB
		' (set) Token: 0x060002A8 RID: 680 RVA: 0x0001AEF3 File Offset: 0x000190F3
		Friend Overridable Property Label5 As Label

		' Token: 0x17000104 RID: 260
		' (get) Token: 0x060002A9 RID: 681 RVA: 0x0001AEFC File Offset: 0x000190FC
		' (set) Token: 0x060002AA RID: 682 RVA: 0x0001AF04 File Offset: 0x00019104
		Friend Overridable Property lbl_W As Label
			<CompilerGenerated()>
			Get
				Return Me._lbl_W
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Dim value2 As EventHandler = AddressOf Me.lbl_HLW_Click
				Dim lbl_W As Label = Me._lbl_W
				If lbl_W IsNot Nothing Then
					RemoveHandler lbl_W.Click, value2
				End If
				Me._lbl_W = value
				lbl_W = Me._lbl_W
				If lbl_W IsNot Nothing Then
					AddHandler lbl_W.Click, value2
				End If
			End Set
		End Property

		' Token: 0x17000105 RID: 261
		' (get) Token: 0x060002AB RID: 683 RVA: 0x0001AF47 File Offset: 0x00019147
		' (set) Token: 0x060002AC RID: 684 RVA: 0x0001AF50 File Offset: 0x00019150
		Friend Overridable Property btn_ok As Button
			<CompilerGenerated()>
			Get
				Return Me._btn_ok
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As EventHandler = AddressOf Me.btn_ok_Click
				Dim btn_ok As Button = Me._btn_ok
				If btn_ok IsNot Nothing Then
					RemoveHandler btn_ok.Click, value2
				End If
				Me._btn_ok = value
				btn_ok = Me._btn_ok
				If btn_ok IsNot Nothing Then
					AddHandler btn_ok.Click, value2
				End If
			End Set
		End Property

		' Token: 0x17000106 RID: 262
		' (get) Token: 0x060002AD RID: 685 RVA: 0x0001AF93 File Offset: 0x00019193
		' (set) Token: 0x060002AE RID: 686 RVA: 0x0001AF9C File Offset: 0x0001919C
		Friend Overridable Property btn_cancel As Button
			<CompilerGenerated()>
			Get
				Return Me._btn_cancel
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As EventHandler = AddressOf Me.btn_cancel_Click
				Dim btn_cancel As Button = Me._btn_cancel
				If btn_cancel IsNot Nothing Then
					RemoveHandler btn_cancel.Click, value2
				End If
				Me._btn_cancel = value
				btn_cancel = Me._btn_cancel
				If btn_cancel IsNot Nothing Then
					AddHandler btn_cancel.Click, value2
				End If
			End Set
		End Property

		' Token: 0x17000107 RID: 263
		' (get) Token: 0x060002AF RID: 687 RVA: 0x0001AFDF File Offset: 0x000191DF
		' (set) Token: 0x060002B0 RID: 688 RVA: 0x0001AFE7 File Offset: 0x000191E7
		Friend Overridable Property Label2 As Label

		' Token: 0x17000108 RID: 264
		' (get) Token: 0x060002B1 RID: 689 RVA: 0x0001AFF0 File Offset: 0x000191F0
		' (set) Token: 0x060002B2 RID: 690 RVA: 0x0001AFF8 File Offset: 0x000191F8
		Friend Overridable Property rbt_1 As RadioButton
			<CompilerGenerated()>
			Get
				Return Me._rbt_1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As RadioButton)
				Dim value2 As EventHandler = AddressOf Me.rbt_CheckedChanged
				Dim rbt_ As RadioButton = Me._rbt_1
				If rbt_ IsNot Nothing Then
					RemoveHandler rbt_.CheckedChanged, value2
				End If
				Me._rbt_1 = value
				rbt_ = Me._rbt_1
				If rbt_ IsNot Nothing Then
					AddHandler rbt_.CheckedChanged, value2
				End If
			End Set
		End Property

		' Token: 0x17000109 RID: 265
		' (get) Token: 0x060002B3 RID: 691 RVA: 0x0001B03B File Offset: 0x0001923B
		' (set) Token: 0x060002B4 RID: 692 RVA: 0x0001B044 File Offset: 0x00019244
		Friend Overridable Property rbt_2 As RadioButton
			<CompilerGenerated()>
			Get
				Return Me._rbt_2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As RadioButton)
				Dim value2 As EventHandler = AddressOf Me.rbt_CheckedChanged
				Dim rbt_ As RadioButton = Me._rbt_2
				If rbt_ IsNot Nothing Then
					RemoveHandler rbt_.CheckedChanged, value2
				End If
				Me._rbt_2 = value
				rbt_ = Me._rbt_2
				If rbt_ IsNot Nothing Then
					AddHandler rbt_.CheckedChanged, value2
				End If
			End Set
		End Property

		' Token: 0x1700010A RID: 266
		' (get) Token: 0x060002B5 RID: 693 RVA: 0x0001B087 File Offset: 0x00019287
		' (set) Token: 0x060002B6 RID: 694 RVA: 0x0001B08F File Offset: 0x0001928F
		Friend Overridable Property Label4 As Label

		' Token: 0x1700010B RID: 267
		' (get) Token: 0x060002B7 RID: 695 RVA: 0x0001B098 File Offset: 0x00019298
		' (set) Token: 0x060002B8 RID: 696 RVA: 0x0001B0A0 File Offset: 0x000192A0
		Friend Overridable Property pnl_orien_0 As Panel

		' Token: 0x1700010C RID: 268
		' (get) Token: 0x060002B9 RID: 697 RVA: 0x0001B0A9 File Offset: 0x000192A9
		' (set) Token: 0x060002BA RID: 698 RVA: 0x0001B0B4 File Offset: 0x000192B4
		Friend Overridable Property pb_orien_0 As PictureBox
			<CompilerGenerated()>
			Get
				Return Me._pb_orien_0
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As PictureBox)
				Dim value2 As EventHandler = AddressOf Me.pb_orien_0_Click
				Dim pb_orien_ As PictureBox = Me._pb_orien_0
				If pb_orien_ IsNot Nothing Then
					RemoveHandler pb_orien_.Click, value2
				End If
				Me._pb_orien_0 = value
				pb_orien_ = Me._pb_orien_0
				If pb_orien_ IsNot Nothing Then
					AddHandler pb_orien_.Click, value2
				End If
			End Set
		End Property

		' Token: 0x1700010D RID: 269
		' (get) Token: 0x060002BB RID: 699 RVA: 0x0001B0F7 File Offset: 0x000192F7
		' (set) Token: 0x060002BC RID: 700 RVA: 0x0001B0FF File Offset: 0x000192FF
		Friend Overridable Property pnl_orien_1 As Panel

		' Token: 0x1700010E RID: 270
		' (get) Token: 0x060002BD RID: 701 RVA: 0x0001B108 File Offset: 0x00019308
		' (set) Token: 0x060002BE RID: 702 RVA: 0x0001B110 File Offset: 0x00019310
		Friend Overridable Property pb_orien_1 As PictureBox
			<CompilerGenerated()>
			Get
				Return Me._pb_orien_1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As PictureBox)
				Dim value2 As EventHandler = AddressOf Me.pb_orien_1_Click
				Dim pb_orien_ As PictureBox = Me._pb_orien_1
				If pb_orien_ IsNot Nothing Then
					RemoveHandler pb_orien_.Click, value2
				End If
				Me._pb_orien_1 = value
				pb_orien_ = Me._pb_orien_1
				If pb_orien_ IsNot Nothing Then
					AddHandler pb_orien_.Click, value2
				End If
			End Set
		End Property

		' Token: 0x1700010F RID: 271
		' (get) Token: 0x060002BF RID: 703 RVA: 0x0001B153 File Offset: 0x00019353
		' (set) Token: 0x060002C0 RID: 704 RVA: 0x0001B15C File Offset: 0x0001935C
		Friend Overridable Property lbl_T As Label
			<CompilerGenerated()>
			Get
				Return Me._lbl_T
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Dim value2 As EventHandler = AddressOf Me.lbl_HLW_Click
				Dim lbl_T As Label = Me._lbl_T
				If lbl_T IsNot Nothing Then
					RemoveHandler lbl_T.Click, value2
				End If
				Me._lbl_T = value
				lbl_T = Me._lbl_T
				If lbl_T IsNot Nothing Then
					AddHandler lbl_T.Click, value2
				End If
			End Set
		End Property

		' Token: 0x17000110 RID: 272
		' (get) Token: 0x060002C1 RID: 705 RVA: 0x0001B19F File Offset: 0x0001939F
		' (set) Token: 0x060002C2 RID: 706 RVA: 0x0001B1A7 File Offset: 0x000193A7
		Friend Overridable Property Label8 As Label

		' Token: 0x060002C3 RID: 707 RVA: 0x0001B1B0 File Offset: 0x000193B0
		Private Sub frmEditCode_Load(sender As Object, e As EventArgs)
			Me.lbl_code.Text = Me.code
			Me.lbl_H.Text = Conversions.ToString(Me.H)
			Me.lbl_W.Text = Conversions.ToString(Me.W)
			Me.lbl_L.Text = Conversions.ToString(Me.L)
			Me.lbl_T.Text = Conversions.ToString(Me.T)
			If Me.N <= 1 Then
				Me.rbt_1.Checked = True
			Else
				Me.rbt_2.Checked = True
			End If
			If Me.O = 0 Then
				Me.pnl_orien_0.BackColor = Color.Lime
				Me.pnl_orien_1.BackColor = Color.Empty
				Return
			End If
			Me.pnl_orien_0.BackColor = Color.Empty
			Me.pnl_orien_1.BackColor = Color.Lime
		End Sub

		' Token: 0x060002C4 RID: 708 RVA: 0x0001B294 File Offset: 0x00019494
		Private Sub btn_ok_Click(sender As Object, e As EventArgs)
			Me.code = Me.lbl_code.Text
			Me.H = Conversions.ToSingle(Me.lbl_H.Text)
			Me.W = Conversions.ToSingle(Me.lbl_W.Text)
			Me.L = Conversions.ToSingle(Me.lbl_L.Text)
			Me.T = Conversions.ToSingle(Me.lbl_T.Text)
			If Me.rbt_1.Checked Then
				Me.N = 1
			Else
				Me.N = 2
			End If
			If Me.pnl_orien_0.BackColor = Color.Lime Then
				Me.O = 0
			Else
				Me.O = 1
			End If
			Me.res = True
			If Me.O = 0 And Me.H > 1200F Then
				Interaction.MsgBox("Max Value H = 1200", MsgBoxStyle.OkOnly, Nothing)
				Return
			End If
			MyBase.Close()
		End Sub

		' Token: 0x060002C5 RID: 709 RVA: 0x0001B382 File Offset: 0x00019582
		Private Sub btn_cancel_Click(sender As Object, e As EventArgs)
			Me.res = False
			MyBase.Close()
		End Sub

		' Token: 0x060002C6 RID: 710 RVA: 0x0001B394 File Offset: 0x00019594
		Private Sub lbl_code_Click(sender As Object, e As EventArgs)
			Dim frmTouchKey As frmTouchKey = New frmTouchKey()
			frmTouchKey.ShowDialog()
			If frmTouchKey.Responce Then
				Me.lbl_code.Text = frmTouchKey.KeyText
			End If
		End Sub

		' Token: 0x060002C7 RID: 711 RVA: 0x0001B3C8 File Offset: 0x000195C8
		Private Sub lbl_HLW_Click(sender As Object, e As EventArgs)
			Dim label As Label = CType(sender, Label)
			Dim frmTouchNum As frmTouchNum = New frmTouchNum()
			frmTouchNum.ShowDialog()
			If frmTouchNum.responce Then
				label.Text = frmTouchNum.value
			End If
		End Sub

		' Token: 0x060002C8 RID: 712 RVA: 0x0001B400 File Offset: 0x00019600
		Private Sub rbt_CheckedChanged(sender As Object, e As EventArgs)
			Dim radioButton As RadioButton = CType(sender, RadioButton)
			If radioButton.Checked Then
				radioButton.BackColor = Color.Lime
				Return
			End If
			radioButton.BackColor = Color.Empty
		End Sub

		' Token: 0x060002C9 RID: 713 RVA: 0x0001B433 File Offset: 0x00019633
		Private Sub pb_orien_0_Click(sender As Object, e As EventArgs)
			Me.pnl_orien_0.BackColor = Color.Lime
			Me.pnl_orien_1.BackColor = Color.Empty
			Me.O = 0
		End Sub

		' Token: 0x060002CA RID: 714 RVA: 0x0001B45C File Offset: 0x0001965C
		Private Sub pb_orien_1_Click(sender As Object, e As EventArgs)
			Me.pnl_orien_0.BackColor = Color.Empty
			Me.pnl_orien_1.BackColor = Color.Lime
			Me.O = 1
		End Sub

		' Token: 0x040001E4 RID: 484
		Public res As Boolean

		' Token: 0x040001E5 RID: 485
		Public code As String

		' Token: 0x040001E6 RID: 486
		Public H As Single

		' Token: 0x040001E7 RID: 487
		Public W As Single

		' Token: 0x040001E8 RID: 488
		Public L As Single

		' Token: 0x040001E9 RID: 489
		Public T As Single

		' Token: 0x040001EA RID: 490
		Public N As Integer

		' Token: 0x040001EB RID: 491
		Public O As Integer

		Private _lbl_code As Label
		Private _lbl_H As Label
		Private _lbl_L As Label
		Private _lbl_W As Label
		Private _lbl_T As Label
		Private _btn_ok As Button
		Private _btn_cancel As Button
		Private _rbt_1 As RadioButton
		Private _rbt_2 As RadioButton
		Private _pb_orien_0 As PictureBox
		Private _pb_orien_1 As PictureBox
	End Class
End Namespace
