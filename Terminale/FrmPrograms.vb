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
	' Token: 0x0200000B RID: 11
	Public Partial Class FrmPrograms
		Inherits Form

		' Token: 0x0600028C RID: 652 RVA: 0x00019C84 File Offset: 0x00017E84
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.FrmPrograms_Load
			Me.InitializeComponent()
		End Sub

		' Token: 0x170000FA RID: 250
		' (get) Token: 0x0600028F RID: 655 RVA: 0x00019F23 File Offset: 0x00018123
		' (set) Token: 0x06000290 RID: 656 RVA: 0x00019F2B File Offset: 0x0001812B
		Friend Overridable Property LsbPrograms As ListBox

		' Token: 0x170000FB RID: 251
		' (get) Token: 0x06000291 RID: 657 RVA: 0x00019F34 File Offset: 0x00018134
		' (set) Token: 0x06000292 RID: 658 RVA: 0x00019F3C File Offset: 0x0001813C
		Friend Overridable Property btnOk As Button
			<CompilerGenerated()>
			Get
				Return Me._btnOk
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As EventHandler = AddressOf Me.btnOk_Click
				Dim btnOk As Button = Me._btnOk
				If btnOk IsNot Nothing Then
					RemoveHandler btnOk.Click, value2
				End If
				Me._btnOk = value
				btnOk = Me._btnOk
				If btnOk IsNot Nothing Then
					AddHandler btnOk.Click, value2
				End If
			End Set
		End Property

		' Token: 0x170000FC RID: 252
		' (get) Token: 0x06000293 RID: 659 RVA: 0x00019F7F File Offset: 0x0001817F
		' (set) Token: 0x06000294 RID: 660 RVA: 0x00019F88 File Offset: 0x00018188
		Friend Overridable Property btnCancel As Button
			<CompilerGenerated()>
			Get
				Return Me._btnCancel
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As EventHandler = AddressOf Me.btnCancel_Click
				Dim btnCancel As Button = Me._btnCancel
				If btnCancel IsNot Nothing Then
					RemoveHandler btnCancel.Click, value2
				End If
				Me._btnCancel = value
				btnCancel = Me._btnCancel
				If btnCancel IsNot Nothing Then
					AddHandler btnCancel.Click, value2
				End If
			End Set
		End Property

		' Token: 0x06000295 RID: 661 RVA: 0x00019FCC File Offset: 0x000181CC
		Private Sub FrmPrograms_Load(sender As Object, e As EventArgs)
			Try
				Dim path_PROGRAMS As String = Path.PATH_PROGRAMS
				Dim files As FileInfo() = New DirectoryInfo(path_PROGRAMS).GetFiles()
				Me.LsbPrograms.Items.Clear()
				For Each fileInfo As FileInfo In files
					Me.LsbPrograms.Items.Add(Strings.Replace(fileInfo.Name, ".cma", "", 1, -1, CompareMethod.Binary))
				Next
				Me.Programm = ""
			Catch ex As Exception
				Interaction.MsgBox("FrmPrograms_Load() : " + Information.Err().Description, MsgBoxStyle.Critical, "CMA Robotics")
			End Try
		End Sub

		' Token: 0x06000296 RID: 662 RVA: 0x0001A084 File Offset: 0x00018284
		Private Sub btnOk_Click(sender As Object, e As EventArgs)
			Me.Programm = Conversions.ToString(Me.LsbPrograms.SelectedItem)
			Me.Responce = True
			MyBase.Close()
		End Sub

		' Token: 0x06000297 RID: 663 RVA: 0x0001A0A9 File Offset: 0x000182A9
		Private Sub btnCancel_Click(sender As Object, e As EventArgs)
			Me.Programm = ""
			Me.Responce = False
			MyBase.Close()
		End Sub

		' Token: 0x040001CD RID: 461
		Public Programm As String

		' Token: 0x040001CE RID: 462
		Public Responce As Boolean

		Private _btnOk As Button
		Private _btnCancel As Button
	End Class
End Namespace
