Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace Terminale
	' Token: 0x0200000E RID: 14
	Public Partial Class frmTouchNum
		Inherits Form

		' Token: 0x060002D9 RID: 729 RVA: 0x0001BAF6 File Offset: 0x00019CF6
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.mybase_load
			AddHandler MyBase.KeyUp, AddressOf Me.frmTouchnum_KeyUp
			Me.InitializeComponent()
		End Sub

		' Token: 0x17000114 RID: 276
		' (get) Token: 0x060002DB RID: 731 RVA: 0x0001BB47 File Offset: 0x00019D47
		' (set) Token: 0x060002DC RID: 732 RVA: 0x0001BB50 File Offset: 0x00019D50
		Friend Overridable Property btn_ok As Button
			<CompilerGenerated()>
			Get
				Return Me._btn_ok
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btn_ok_Click
				Dim btn_ok As Button = Me._btn_ok
				If btn_ok IsNot Nothing Then
					RemoveHandler btn_ok.Click, eventHandler
				End If
				Me._btn_ok = value
				btn_ok = Me._btn_ok
				If btn_ok IsNot Nothing Then
					AddHandler btn_ok.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000115 RID: 277
		' (get) Token: 0x060002DD RID: 733 RVA: 0x0001BB93 File Offset: 0x00019D93
		' (set) Token: 0x060002DE RID: 734 RVA: 0x0001BB9C File Offset: 0x00019D9C
		Friend Overridable Property btn_cancel As Button
			<CompilerGenerated()>
			Get
				Return Me._btn_cancel
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btn_cancel_Click
				Dim btn_cancel As Button = Me._btn_cancel
				If btn_cancel IsNot Nothing Then
					RemoveHandler btn_cancel.Click, eventHandler
				End If
				Me._btn_cancel = value
				btn_cancel = Me._btn_cancel
				If btn_cancel IsNot Nothing Then
					AddHandler btn_cancel.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000116 RID: 278
		' (get) Token: 0x060002DF RID: 735 RVA: 0x0001BBDF File Offset: 0x00019DDF
		' (set) Token: 0x060002E0 RID: 736 RVA: 0x0001BBE7 File Offset: 0x00019DE7
		Friend Overridable Property UcTouchNum As ucTouchNum

		' Token: 0x060002E2 RID: 738 RVA: 0x0001BDD7 File Offset: 0x00019FD7
		Private Sub mybase_load(sender As Object, e As EventArgs)
			Me.responce = False
			Me.UcTouchNum.NumValue = ""
			MyBase.TopMost = True
		End Sub

		' Token: 0x060002E3 RID: 739 RVA: 0x0001BDF8 File Offset: 0x00019FF8
		Private Sub btn_ok_Click(sender As Object, e As EventArgs)
			Try
				If Operators.CompareString(Me.UcTouchNum.NumValue, "", False) <> 0 Then
					Me.value = Me.UcTouchNum.NumValue
					Me.responce = True
					MyBase.Close()
				End If
			Catch ex As Exception
				Interaction.MsgBox("frmTouchNum() : " + ex.Message, MsgBoxStyle.Exclamation, Nothing)
				Me.UcTouchNum.NumValue = ""
			End Try
		End Sub

		' Token: 0x060002E4 RID: 740 RVA: 0x0001BECC File Offset: 0x0001A0CC
		Private Sub btn_cancel_Click(sender As Object, e As EventArgs)
			If Operators.CompareString(Me.UcTouchNum.NumValue, "", False) = 0 Then
				Me.value = ""
				Me.responce = False
				MyBase.Close()
				Return
			End If
			Me.UcTouchNum.NumValue = ""
		End Sub

		' Token: 0x060002E5 RID: 741 RVA: 0x0001BF1C File Offset: 0x0001A11C
		Private Sub frmTouchnum_KeyUp(sender As Object, e As KeyEventArgs)
			Dim num As Integer = e.KeyValue
			If num >= 96 And num <= 105 Then
				num -= 48
			End If
			Dim str As String = Conversions.ToString(Strings.Chr(num))
			If(num >= 48 And num <= 57) Or num = 46 Then
				str = Conversions.ToString(Strings.Chr(num))
				Me.UcTouchNum.lbl_value.Text = Me.UcTouchNum.lbl_value.Text + str
				Me.UcTouchNum.NumValue = Me.UcTouchNum.lbl_value.Text
			End If
			If e.KeyCode = Keys.OemMinus Or e.KeyCode = Keys.Subtract Then
				If Me.UcTouchNum.lbl_value.Text.Length = 0 Then
					Me.UcTouchNum.lbl_value.Text = "-" + Me.UcTouchNum.lbl_value.Text
				ElseIf Operators.CompareString(Me.UcTouchNum.lbl_value.Text.Substring(0, 1), "-", False) <> 0 Then
					Me.UcTouchNum.lbl_value.Text = "-" + Me.UcTouchNum.lbl_value.Text
				Else
					Me.UcTouchNum.lbl_value.Text = Me.UcTouchNum.lbl_value.Text.Replace("-", "")
				End If
				Me.UcTouchNum.NumValue = Me.UcTouchNum.lbl_value.Text
			End If
			If(e.KeyCode = Keys.OemPeriod Or e.KeyCode = Keys.[Decimal]) AndAlso Strings.InStr(Me.UcTouchNum.lbl_value.Text, ".", CompareMethod.Binary) = 0 Then
				Me.UcTouchNum.lbl_value.Text = Me.UcTouchNum.lbl_value.Text + "."
				Me.UcTouchNum.NumValue = Me.UcTouchNum.lbl_value.Text
			End If
			If e.KeyCode = Keys.[Return] AndAlso Operators.CompareString(Me.UcTouchNum.NumValue, "", False) <> 0 Then
				Me.value = Me.UcTouchNum.NumValue
				Me.responce = True
				MyBase.Close()
			End If
			If e.KeyCode = Keys.Escape Then
				If Operators.CompareString(Me.UcTouchNum.NumValue, "", False) = 0 Then
					Me.value = ""
					Me.responce = False
					MyBase.Close()
					Return
				End If
				Me.UcTouchNum.NumValue = ""
			End If
		End Sub

		' Token: 0x040001F8 RID: 504
		Public responce As Boolean

		' Token: 0x040001F9 RID: 505
		Public value As String

		Private _btn_ok As Button
		Private _btn_cancel As Button
	End Class
End Namespace
