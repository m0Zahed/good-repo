Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace Terminale
	' Token: 0x0200000D RID: 13
	Public Partial Class frmTouchKey
		Inherits Form

		' Token: 0x060002CB RID: 715 RVA: 0x0001B488 File Offset: 0x00019688
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmTouchKey_Load
			AddHandler MyBase.KeyPress, AddressOf Me.frmTouchkey_KeyPress
			AddHandler MyBase.KeyUp, AddressOf Me.frmTouchkey_KeyUP
			Me.InitializeComponent()
		End Sub

		' Token: 0x17000111 RID: 273
		' (get) Token: 0x060002CD RID: 717 RVA: 0x0001B4F6 File Offset: 0x000196F6
		' (set) Token: 0x060002CE RID: 718 RVA: 0x0001B500 File Offset: 0x00019700
		Friend Overridable Property btnCancel As Button
			<CompilerGenerated()>
			Get
				Return Me._btnCancel
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As MouseEventHandler = AddressOf Me.btnCancel_Click
				Dim btnCancel As Button = Me._btnCancel
				If btnCancel IsNot Nothing Then
					RemoveHandler btnCancel.MouseUp, value2
				End If
				Me._btnCancel = value
				btnCancel = Me._btnCancel
				If btnCancel IsNot Nothing Then
					AddHandler btnCancel.MouseUp, value2
				End If
			End Set
		End Property

		' Token: 0x17000112 RID: 274
		' (get) Token: 0x060002CF RID: 719 RVA: 0x0001B543 File Offset: 0x00019743
		' (set) Token: 0x060002D0 RID: 720 RVA: 0x0001B54B File Offset: 0x0001974B
		Friend Overridable Property UcTouchKey As ucTouchKey

		' Token: 0x17000113 RID: 275
		' (get) Token: 0x060002D1 RID: 721 RVA: 0x0001B554 File Offset: 0x00019754
		' (set) Token: 0x060002D2 RID: 722 RVA: 0x0001B55C File Offset: 0x0001975C
		Friend Overridable Property btnOk As Button
			<CompilerGenerated()>
			Get
				Return Me._btnOk
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As MouseEventHandler = AddressOf Me.btnOk_Click
				Dim btnOk As Button = Me._btnOk
				If btnOk IsNot Nothing Then
					RemoveHandler btnOk.MouseUp, value2
				End If
				Me._btnOk = value
				btnOk = Me._btnOk
				If btnOk IsNot Nothing Then
					AddHandler btnOk.MouseUp, value2
				End If
			End Set
		End Property

		' Token: 0x060002D4 RID: 724 RVA: 0x0001B7B4 File Offset: 0x000199B4
		Private Sub frmTouchKey_Load(sender As Object, e As EventArgs)
			Me.KeyText = ""
			Me.UcTouchKey.KeyText = ""
			Me.UcTouchKey.TextForm = ""
			MyBase.TopMost = True
		End Sub

		' Token: 0x060002D5 RID: 725 RVA: 0x0001B7E8 File Offset: 0x000199E8
		Private Sub btnOk_Click(sender As Object, e As EventArgs)
			Me.KeyText = Me.UcTouchKey.TextForm
			Me.Responce = True
			MyBase.Close()
		End Sub

		' Token: 0x060002D6 RID: 726 RVA: 0x0001B808 File Offset: 0x00019A08
		Private Sub btnCancel_Click(sender As Object, e As EventArgs)
			Me.KeyText = ""
			Me.Responce = False
			MyBase.Close()
		End Sub

		' Token: 0x060002D7 RID: 727 RVA: 0x0001B824 File Offset: 0x00019A24
		Private Sub frmTouchkey_KeyPress(sender As Object, e As KeyPressEventArgs)
			Conversions.ToString(e.KeyChar)
			Dim keyChar As Char = e.KeyChar
			If(Operators.CompareString(Conversions.ToString(keyChar), "/", False) = 0 Or Operators.CompareString(Conversions.ToString(keyChar), ".", False) = 0 Or Operators.CompareString(Conversions.ToString(keyChar), "-", False) = 0 Or Operators.CompareString(Conversions.ToString(keyChar), "_", False) = 0) AndAlso Me.UcTouchKey.TextForm.Length < 50 Then
				Me.UcTouchKey.TextForm = Me.UcTouchKey.TextForm + Conversions.ToString(keyChar)
				If Me.UcTouchKey.InsertPassword Then
					Me.UcTouchKey.lbl_text.Text = Me.UcTouchKey.lbl_text.Text + "*"
					Return
				End If
				Me.UcTouchKey.lbl_text.Text = Me.UcTouchKey.TextForm
			End If
		End Sub

		' Token: 0x060002D8 RID: 728 RVA: 0x0001B924 File Offset: 0x00019B24
		Private Sub frmTouchkey_KeyUP(sender As Object, e As KeyEventArgs)
			Dim num As Integer = e.KeyValue
			If Not e.Shift Then
				If num >= 96 And num <= 105 Then
					num -= 48
				End If
				If num = 32 Or num = 46 Or (num >= 48 And num <= 57) Or (num >= 65 And num <= 90) Or num = 95 Then
					Dim str As String = Conversions.ToString(Strings.Chr(num))
					If Me.UcTouchKey.TextForm.Length < 50 Then
						Me.UcTouchKey.TextForm = Me.UcTouchKey.TextForm + str
						If Me.UcTouchKey.InsertPassword Then
							Me.UcTouchKey.lbl_text.Text = Me.UcTouchKey.lbl_text.Text + "*"
						Else
							Me.UcTouchKey.lbl_text.Text = Me.UcTouchKey.TextForm
						End If
					End If
				End If
				If e.KeyCode = Keys.Back AndAlso Me.UcTouchKey.TextForm.Length > 0 Then
					Me.UcTouchKey.TextForm = Me.UcTouchKey.TextForm.Remove(Me.UcTouchKey.TextForm.Length - 1, 1)
					Me.UcTouchKey.lbl_text.Text = Me.UcTouchKey.lbl_text.Text.Remove(Me.UcTouchKey.lbl_text.Text.Length - 1, 1)
				End If
				If e.KeyCode = Keys.[Return] Then
					Me.KeyText = Me.UcTouchKey.TextForm
					Me.Responce = True
					MyBase.Close()
				End If
				If e.KeyCode = Keys.Escape Then
					Me.KeyText = ""
					Me.Responce = False
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x040001F0 RID: 496
		Public KeyText As String

		' Token: 0x040001F1 RID: 497
		Public Responce As Boolean

		' Token: 0x040001F2 RID: 498
		Private Const MAX_LENGTH As Integer = 50

		' Token: 0x040001F3 RID: 499
		Private keyspace As Boolean

		Private _btnCancel As Button
		Private _btnOk As Button
	End Class
End Namespace
