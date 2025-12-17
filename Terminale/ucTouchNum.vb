Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices

Namespace Terminale
	' Token: 0x02000012 RID: 18
	Public Class ucTouchNum
		Inherits UserControl

		' Token: 0x0600034F RID: 847 RVA: 0x0001F3FE File Offset: 0x0001D5FE
		Public Sub New()
			Me.InitializeComponent()
		End Sub

		' Token: 0x06000350 RID: 848 RVA: 0x0001F40C File Offset: 0x0001D60C
		Protected Overrides Sub Dispose(disposing As Boolean)
			If disposing AndAlso Me.components IsNot Nothing Then
				Me.components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		' Token: 0x17000145 RID: 325
		' (get) Token: 0x06000351 RID: 849 RVA: 0x0001F42B File Offset: 0x0001D62B
		' (set) Token: 0x06000352 RID: 850 RVA: 0x0001F434 File Offset: 0x0001D634
		Friend Overridable Property N0 As Button
			<CompilerGenerated()>
			Get
				Return Me._N0
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As MouseEventHandler = AddressOf Me.KeyTouchDown
				Dim value3 As MouseEventHandler = AddressOf Me.KeyTouchUp
				Dim n As Button = Me._N0
				If n IsNot Nothing Then
					RemoveHandler n.MouseDown, value2
					RemoveHandler n.MouseUp, value3
				End If
				Me._N0 = value
				n = Me._N0
				If n IsNot Nothing Then
					AddHandler n.MouseDown, value2
					AddHandler n.MouseUp, value3
				End If
			End Set
		End Property

		' Token: 0x17000146 RID: 326
		' (get) Token: 0x06000353 RID: 851 RVA: 0x0001F492 File Offset: 0x0001D692
		' (set) Token: 0x06000354 RID: 852 RVA: 0x0001F49C File Offset: 0x0001D69C
		Friend Overridable Property N8 As Button
			<CompilerGenerated()>
			Get
				Return Me._N8
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As MouseEventHandler = AddressOf Me.KeyTouchDown
				Dim value3 As MouseEventHandler = AddressOf Me.KeyTouchUp
				Dim n As Button = Me._N8
				If n IsNot Nothing Then
					RemoveHandler n.MouseDown, value2
					RemoveHandler n.MouseUp, value3
				End If
				Me._N8 = value
				n = Me._N8
				If n IsNot Nothing Then
					AddHandler n.MouseDown, value2
					AddHandler n.MouseUp, value3
				End If
			End Set
		End Property

		' Token: 0x17000147 RID: 327
		' (get) Token: 0x06000355 RID: 853 RVA: 0x0001F4FA File Offset: 0x0001D6FA
		' (set) Token: 0x06000356 RID: 854 RVA: 0x0001F504 File Offset: 0x0001D704
		Friend Overridable Property N9 As Button
			<CompilerGenerated()>
			Get
				Return Me._N9
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As MouseEventHandler = AddressOf Me.KeyTouchDown
				Dim value3 As MouseEventHandler = AddressOf Me.KeyTouchUp
				Dim n As Button = Me._N9
				If n IsNot Nothing Then
					RemoveHandler n.MouseDown, value2
					RemoveHandler n.MouseUp, value3
				End If
				Me._N9 = value
				n = Me._N9
				If n IsNot Nothing Then
					AddHandler n.MouseDown, value2
					AddHandler n.MouseUp, value3
				End If
			End Set
		End Property

		' Token: 0x17000148 RID: 328
		' (get) Token: 0x06000357 RID: 855 RVA: 0x0001F562 File Offset: 0x0001D762
		' (set) Token: 0x06000358 RID: 856 RVA: 0x0001F56C File Offset: 0x0001D76C
		Friend Overridable Property N4 As Button
			<CompilerGenerated()>
			Get
				Return Me._N4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As MouseEventHandler = AddressOf Me.KeyTouchDown
				Dim value3 As MouseEventHandler = AddressOf Me.KeyTouchUp
				Dim n As Button = Me._N4
				If n IsNot Nothing Then
					RemoveHandler n.MouseDown, value2
					RemoveHandler n.MouseUp, value3
				End If
				Me._N4 = value
				n = Me._N4
				If n IsNot Nothing Then
					AddHandler n.MouseDown, value2
					AddHandler n.MouseUp, value3
				End If
			End Set
		End Property

		' Token: 0x17000149 RID: 329
		' (get) Token: 0x06000359 RID: 857 RVA: 0x0001F5CA File Offset: 0x0001D7CA
		' (set) Token: 0x0600035A RID: 858 RVA: 0x0001F5D4 File Offset: 0x0001D7D4
		Friend Overridable Property N5 As Button
			<CompilerGenerated()>
			Get
				Return Me._N5
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As MouseEventHandler = AddressOf Me.KeyTouchDown
				Dim value3 As MouseEventHandler = AddressOf Me.KeyTouchUp
				Dim n As Button = Me._N5
				If n IsNot Nothing Then
					RemoveHandler n.MouseDown, value2
					RemoveHandler n.MouseUp, value3
				End If
				Me._N5 = value
				n = Me._N5
				If n IsNot Nothing Then
					AddHandler n.MouseDown, value2
					AddHandler n.MouseUp, value3
				End If
			End Set
		End Property

		' Token: 0x1700014A RID: 330
		' (get) Token: 0x0600035B RID: 859 RVA: 0x0001F632 File Offset: 0x0001D832
		' (set) Token: 0x0600035C RID: 860 RVA: 0x0001F63C File Offset: 0x0001D83C
		Friend Overridable Property N6 As Button
			<CompilerGenerated()>
			Get
				Return Me._N6
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As MouseEventHandler = AddressOf Me.KeyTouchDown
				Dim value3 As MouseEventHandler = AddressOf Me.KeyTouchUp
				Dim n As Button = Me._N6
				If n IsNot Nothing Then
					RemoveHandler n.MouseDown, value2
					RemoveHandler n.MouseUp, value3
				End If
				Me._N6 = value
				n = Me._N6
				If n IsNot Nothing Then
					AddHandler n.MouseDown, value2
					AddHandler n.MouseUp, value3
				End If
			End Set
		End Property

		' Token: 0x1700014B RID: 331
		' (get) Token: 0x0600035D RID: 861 RVA: 0x0001F69A File Offset: 0x0001D89A
		' (set) Token: 0x0600035E RID: 862 RVA: 0x0001F6A4 File Offset: 0x0001D8A4
		Friend Overridable Property N1 As Button
			<CompilerGenerated()>
			Get
				Return Me._N1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As MouseEventHandler = AddressOf Me.KeyTouchDown
				Dim value3 As MouseEventHandler = AddressOf Me.KeyTouchUp
				Dim n As Button = Me._N1
				If n IsNot Nothing Then
					RemoveHandler n.MouseDown, value2
					RemoveHandler n.MouseUp, value3
				End If
				Me._N1 = value
				n = Me._N1
				If n IsNot Nothing Then
					AddHandler n.MouseDown, value2
					AddHandler n.MouseUp, value3
				End If
			End Set
		End Property

		' Token: 0x1700014C RID: 332
		' (get) Token: 0x0600035F RID: 863 RVA: 0x0001F702 File Offset: 0x0001D902
		' (set) Token: 0x06000360 RID: 864 RVA: 0x0001F70C File Offset: 0x0001D90C
		Friend Overridable Property N2 As Button
			<CompilerGenerated()>
			Get
				Return Me._N2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As MouseEventHandler = AddressOf Me.KeyTouchDown
				Dim value3 As MouseEventHandler = AddressOf Me.KeyTouchUp
				Dim n As Button = Me._N2
				If n IsNot Nothing Then
					RemoveHandler n.MouseDown, value2
					RemoveHandler n.MouseUp, value3
				End If
				Me._N2 = value
				n = Me._N2
				If n IsNot Nothing Then
					AddHandler n.MouseDown, value2
					AddHandler n.MouseUp, value3
				End If
			End Set
		End Property

		' Token: 0x1700014D RID: 333
		' (get) Token: 0x06000361 RID: 865 RVA: 0x0001F76A File Offset: 0x0001D96A
		' (set) Token: 0x06000362 RID: 866 RVA: 0x0001F774 File Offset: 0x0001D974
		Friend Overridable Property N3 As Button
			<CompilerGenerated()>
			Get
				Return Me._N3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As MouseEventHandler = AddressOf Me.KeyTouchDown
				Dim value3 As MouseEventHandler = AddressOf Me.KeyTouchUp
				Dim n As Button = Me._N3
				If n IsNot Nothing Then
					RemoveHandler n.MouseDown, value2
					RemoveHandler n.MouseUp, value3
				End If
				Me._N3 = value
				n = Me._N3
				If n IsNot Nothing Then
					AddHandler n.MouseDown, value2
					AddHandler n.MouseUp, value3
				End If
			End Set
		End Property

		' Token: 0x1700014E RID: 334
		' (get) Token: 0x06000363 RID: 867 RVA: 0x0001F7D2 File Offset: 0x0001D9D2
		' (set) Token: 0x06000364 RID: 868 RVA: 0x0001F7DC File Offset: 0x0001D9DC
		Friend Overridable Property N7 As Button
			<CompilerGenerated()>
			Get
				Return Me._N7
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As MouseEventHandler = AddressOf Me.KeyTouchDown
				Dim value3 As MouseEventHandler = AddressOf Me.KeyTouchUp
				Dim n As Button = Me._N7
				If n IsNot Nothing Then
					RemoveHandler n.MouseDown, value2
					RemoveHandler n.MouseUp, value3
				End If
				Me._N7 = value
				n = Me._N7
				If n IsNot Nothing Then
					AddHandler n.MouseDown, value2
					AddHandler n.MouseUp, value3
				End If
			End Set
		End Property

		' Token: 0x1700014F RID: 335
		' (get) Token: 0x06000365 RID: 869 RVA: 0x0001F83A File Offset: 0x0001DA3A
		' (set) Token: 0x06000366 RID: 870 RVA: 0x0001F842 File Offset: 0x0001DA42
		Friend Overridable Property lbl_value As Label

		' Token: 0x17000150 RID: 336
		' (get) Token: 0x06000367 RID: 871 RVA: 0x0001F84B File Offset: 0x0001DA4B
		' (set) Token: 0x06000368 RID: 872 RVA: 0x0001F854 File Offset: 0x0001DA54
		Friend Overridable Property minus As Button
			<CompilerGenerated()>
			Get
				Return Me._minus
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As MouseEventHandler = AddressOf Me.KeyTouchDown
				Dim value3 As MouseEventHandler = AddressOf Me.KeyTouchUp
				Dim minus As Button = Me._minus
				If minus IsNot Nothing Then
					RemoveHandler minus.MouseDown, value2
					RemoveHandler minus.MouseUp, value3
				End If
				Me._minus = value
				minus = Me._minus
				If minus IsNot Nothing Then
					AddHandler minus.MouseDown, value2
					AddHandler minus.MouseUp, value3
				End If
			End Set
		End Property

		' Token: 0x17000151 RID: 337
		' (get) Token: 0x06000369 RID: 873 RVA: 0x0001F8B2 File Offset: 0x0001DAB2
		' (set) Token: 0x0600036A RID: 874 RVA: 0x0001F8BC File Offset: 0x0001DABC
		Friend Overridable Property point As Button
			<CompilerGenerated()>
			Get
				Return Me._point
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As MouseEventHandler = AddressOf Me.KeyTouchDown
				Dim value3 As MouseEventHandler = AddressOf Me.KeyTouchUp
				Dim point As Button = Me._point
				If point IsNot Nothing Then
					RemoveHandler point.MouseDown, value2
					RemoveHandler point.MouseUp, value3
				End If
				Me._point = value
				point = Me._point
				If point IsNot Nothing Then
					AddHandler point.MouseDown, value2
					AddHandler point.MouseUp, value3
				End If
			End Set
		End Property

		' Token: 0x0600036B RID: 875 RVA: 0x0001F91C File Offset: 0x0001DB1C
		<DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.N0 = New Button()
			Me.N8 = New Button()
			Me.N9 = New Button()
			Me.N4 = New Button()
			Me.N5 = New Button()
			Me.N6 = New Button()
			Me.N1 = New Button()
			Me.N2 = New Button()
			Me.N3 = New Button()
			Me.N7 = New Button()
			Me.minus = New Button()
			Me.lbl_value = New Label()
			Me.point = New Button()
			MyBase.SuspendLayout()
			Me.N0.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.N0.Location = New Point(16, 200)
			Me.N0.Name = "N0"
			Me.N0.Size = New Size(48, 48)
			Me.N0.TabIndex = 38
			Me.N0.TabStop = False
			Me.N0.Text = "0"
			Me.N8.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.N8.Location = New Point(64, 56)
			Me.N8.Name = "N8"
			Me.N8.Size = New Size(48, 48)
			Me.N8.TabIndex = 37
			Me.N8.TabStop = False
			Me.N8.Text = "8"
			Me.N9.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.N9.Location = New Point(112, 56)
			Me.N9.Name = "N9"
			Me.N9.Size = New Size(48, 48)
			Me.N9.TabIndex = 36
			Me.N9.TabStop = False
			Me.N9.Text = "9"
			Me.N4.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.N4.Location = New Point(16, 104)
			Me.N4.Name = "N4"
			Me.N4.Size = New Size(48, 48)
			Me.N4.TabIndex = 35
			Me.N4.TabStop = False
			Me.N4.Text = "4"
			Me.N5.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.N5.Location = New Point(64, 104)
			Me.N5.Name = "N5"
			Me.N5.Size = New Size(48, 48)
			Me.N5.TabIndex = 34
			Me.N5.TabStop = False
			Me.N5.Text = "5"
			Me.N6.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.N6.Location = New Point(112, 104)
			Me.N6.Name = "N6"
			Me.N6.Size = New Size(48, 48)
			Me.N6.TabIndex = 33
			Me.N6.TabStop = False
			Me.N6.Text = "6"
			Me.N1.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.N1.Location = New Point(16, 152)
			Me.N1.Name = "N1"
			Me.N1.Size = New Size(48, 48)
			Me.N1.TabIndex = 32
			Me.N1.TabStop = False
			Me.N1.Text = "1"
			Me.N2.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.N2.Location = New Point(64, 152)
			Me.N2.Name = "N2"
			Me.N2.Size = New Size(48, 48)
			Me.N2.TabIndex = 31
			Me.N2.TabStop = False
			Me.N2.Text = "2"
			Me.N3.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.N3.Location = New Point(112, 152)
			Me.N3.Name = "N3"
			Me.N3.Size = New Size(48, 48)
			Me.N3.TabIndex = 30
			Me.N3.TabStop = False
			Me.N3.Text = "3"
			Me.N7.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.N7.Location = New Point(16, 56)
			Me.N7.Name = "N7"
			Me.N7.Size = New Size(48, 48)
			Me.N7.TabIndex = 29
			Me.N7.TabStop = False
			Me.N7.Text = "7"
			Me.minus.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.minus.Location = New Point(112, 200)
			Me.minus.Name = "minus"
			Me.minus.Size = New Size(48, 48)
			Me.minus.TabIndex = 67
			Me.minus.TabStop = False
			Me.minus.Text = "-"
			Me.lbl_value.BackColor = Color.White
			Me.lbl_value.BorderStyle = BorderStyle.Fixed3D
			Me.lbl_value.Font = New Font("Microsoft Sans Serif", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.lbl_value.Location = New Point(8, 8)
			Me.lbl_value.Name = "lbl_value"
			Me.lbl_value.Size = New Size(168, 40)
			Me.lbl_value.TabIndex = 68
			Me.lbl_value.TextAlign = ContentAlignment.MiddleRight
			Me.point.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.point.Location = New Point(64, 200)
			Me.point.Name = "point"
			Me.point.Size = New Size(48, 48)
			Me.point.TabIndex = 69
			Me.point.TabStop = False
			Me.point.Text = "."
			MyBase.AutoScaleMode = AutoScaleMode.None
			MyBase.Controls.Add(Me.point)
			MyBase.Controls.Add(Me.lbl_value)
			MyBase.Controls.Add(Me.minus)
			MyBase.Controls.Add(Me.N0)
			MyBase.Controls.Add(Me.N8)
			MyBase.Controls.Add(Me.N9)
			MyBase.Controls.Add(Me.N4)
			MyBase.Controls.Add(Me.N5)
			MyBase.Controls.Add(Me.N6)
			MyBase.Controls.Add(Me.N1)
			MyBase.Controls.Add(Me.N2)
			MyBase.Controls.Add(Me.N3)
			MyBase.Controls.Add(Me.N7)
			MyBase.Name = "ucTouchNum"
			MyBase.Size = New Size(184, 256)
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x17000152 RID: 338
		' (get) Token: 0x0600036C RID: 876 RVA: 0x00020150 File Offset: 0x0001E350
		' (set) Token: 0x0600036D RID: 877 RVA: 0x0002016A File Offset: 0x0001E36A
		Public Property NumValue As String
			Get
				Return Me.lbl_value.Text
			End Get
			Set(value As String)
				Me.lbl_value.Text = value
			End Set
		End Property

		' Token: 0x0600036E RID: 878 RVA: 0x00020178 File Offset: 0x0001E378
		Private Sub KeyTouchDown(sender As Object, e As MouseEventArgs)
			Me.key = CType(sender, Button)
			Me.key.BackColor = Color.Cyan
		End Sub

		' Token: 0x0600036F RID: 879 RVA: 0x00020198 File Offset: 0x0001E398
		Private Sub KeyTouchUp(sender As Object, e As MouseEventArgs)
			Me.key = CType(sender, Button)
			Me.key.BackColor = Color.Empty
			If Me.key Is Me.minus Then
				If Me.lbl_value.Text.Length = 0 Then
					Me.lbl_value.Text = Me.key.Text + Me.lbl_value.Text
					Return
				End If
				If Operators.CompareString(Me.lbl_value.Text.Substring(0, 1), "-", False) <> 0 Then
					Me.lbl_value.Text = Me.key.Text + Me.lbl_value.Text
					Return
				End If
			Else
				Me.lbl_value.Text = Me.lbl_value.Text + Me.key.Text
			End If
		End Sub

		' Token: 0x04000236 RID: 566
		Private components As IContainer

		' Token: 0x04000244 RID: 580
		Private key As Button

		Private _N0 As Button
		Private _N1 As Button
		Private _N2 As Button
		Private _N3 As Button
		Private _N4 As Button
		Private _N5 As Button
		Private _N6 As Button
		Private _N7 As Button
		Private _N8 As Button
		Private _N9 As Button
		Private _minus As Button
		Private _point As Button
	End Class
End Namespace
