Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace Terminale
	' Token: 0x0200000A RID: 10
	Public Partial Class frmList
		Inherits Form

		' Token: 0x0600027F RID: 639 RVA: 0x00019833 File Offset: 0x00017A33
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmList_Load
			Me.InitializeComponent()
		End Sub

		' Token: 0x170000F7 RID: 247
		' (get) Token: 0x06000282 RID: 642 RVA: 0x00019AAF File Offset: 0x00017CAF
		' (set) Token: 0x06000283 RID: 643 RVA: 0x00019AB7 File Offset: 0x00017CB7
		Friend Overridable Property lb_auto As ListBox

		' Token: 0x170000F8 RID: 248
		' (get) Token: 0x06000284 RID: 644 RVA: 0x00019AC0 File Offset: 0x00017CC0
		' (set) Token: 0x06000285 RID: 645 RVA: 0x00019AC8 File Offset: 0x00017CC8
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

		' Token: 0x170000F9 RID: 249
		' (get) Token: 0x06000286 RID: 646 RVA: 0x00019B0B File Offset: 0x00017D0B
		' (set) Token: 0x06000287 RID: 647 RVA: 0x00019B14 File Offset: 0x00017D14
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

		' Token: 0x06000288 RID: 648 RVA: 0x00019B57 File Offset: 0x00017D57
		Private Sub frmList_Load(sender As Object, e As EventArgs)
			Me.LoadCodeList()
		End Sub

		' Token: 0x06000289 RID: 649 RVA: 0x00019B5F File Offset: 0x00017D5F
		Private Sub btn_ok_Click(sender As Object, e As EventArgs)
			Me.code = Conversions.ToString(Me.lb_auto.SelectedItem)
			Me.responce = True
			MyBase.Close()
		End Sub

		' Token: 0x0600028A RID: 650 RVA: 0x00019B84 File Offset: 0x00017D84
		Private Sub btn_cancel_Click(sender As Object, e As EventArgs)
			Me.responce = False
			MyBase.Close()
		End Sub

		' Token: 0x0600028B RID: 651 RVA: 0x00019B94 File Offset: 0x00017D94
		Private Sub LoadCodeList()
			Try
				Me.lb_auto.Items.Clear()
				Using streamReader As StreamReader = New StreamReader(Path.DATA_PATH + "CODELIST.txt")
					While streamReader.Peek() >= 0
						Dim array As String() = Strings.Split(streamReader.ReadLine(), "|", -1, CompareMethod.Binary)
						Me.lb_auto.Items.Add(array(0))
					End While
				End Using
			Catch ex As Exception
				Interaction.MsgBox("LoadCodeList : " + ex.Message, MsgBoxStyle.Critical, Nothing)
			End Try
		End Sub

		' Token: 0x040001C7 RID: 455
		Public responce As Boolean

		' Token: 0x040001C8 RID: 456
		Public code As String

		Private _btn_ok As Button
		Private _btn_cancel As Button
	End Class
End Namespace
