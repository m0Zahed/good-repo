Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

Namespace Terminale
	' Token: 0x02000011 RID: 17
	Public Class ucTouchKey
		Inherits UserControl

		' Token: 0x060002E8 RID: 744 RVA: 0x0001C1ED File Offset: 0x0001A3ED
		Public Sub New()
			Me.InsertPassword = False
			Me.TextForm = ""
			Me.InitializeComponent()
		End Sub

		' Token: 0x060002E9 RID: 745 RVA: 0x0001C20D File Offset: 0x0001A40D
		Protected Overrides Sub Dispose(disposing As Boolean)
			If disposing AndAlso Me.components IsNot Nothing Then
				Me.components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		' Token: 0x17000117 RID: 279
		' (get) Token: 0x060002EA RID: 746 RVA: 0x0001C22C File Offset: 0x0001A42C
		' (set) Token: 0x060002EB RID: 747 RVA: 0x0001C234 File Offset: 0x0001A434
		Friend Overridable Property lbl_text As Label

		' Token: 0x17000118 RID: 280
		' (get) Token: 0x060002EC RID: 748 RVA: 0x0001C23D File Offset: 0x0001A43D
		' (set) Token: 0x060002ED RID: 749 RVA: 0x0001C248 File Offset: 0x0001A448
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

		' Token: 0x17000119 RID: 281
		' (get) Token: 0x060002EE RID: 750 RVA: 0x0001C2A6 File Offset: 0x0001A4A6
		' (set) Token: 0x060002EF RID: 751 RVA: 0x0001C2B0 File Offset: 0x0001A4B0
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

		' Token: 0x1700011A RID: 282
		' (get) Token: 0x060002F0 RID: 752 RVA: 0x0001C30E File Offset: 0x0001A50E
		' (set) Token: 0x060002F1 RID: 753 RVA: 0x0001C318 File Offset: 0x0001A518
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

		' Token: 0x1700011B RID: 283
		' (get) Token: 0x060002F2 RID: 754 RVA: 0x0001C376 File Offset: 0x0001A576
		' (set) Token: 0x060002F3 RID: 755 RVA: 0x0001C380 File Offset: 0x0001A580
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

		' Token: 0x1700011C RID: 284
		' (get) Token: 0x060002F4 RID: 756 RVA: 0x0001C3DE File Offset: 0x0001A5DE
		' (set) Token: 0x060002F5 RID: 757 RVA: 0x0001C3E8 File Offset: 0x0001A5E8
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

		' Token: 0x1700011D RID: 285
		' (get) Token: 0x060002F6 RID: 758 RVA: 0x0001C446 File Offset: 0x0001A646
		' (set) Token: 0x060002F7 RID: 759 RVA: 0x0001C450 File Offset: 0x0001A650
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

		' Token: 0x1700011E RID: 286
		' (get) Token: 0x060002F8 RID: 760 RVA: 0x0001C4AE File Offset: 0x0001A6AE
		' (set) Token: 0x060002F9 RID: 761 RVA: 0x0001C4B8 File Offset: 0x0001A6B8
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

		' Token: 0x1700011F RID: 287
		' (get) Token: 0x060002FA RID: 762 RVA: 0x0001C516 File Offset: 0x0001A716
		' (set) Token: 0x060002FB RID: 763 RVA: 0x0001C520 File Offset: 0x0001A720
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

		' Token: 0x17000120 RID: 288
		' (get) Token: 0x060002FC RID: 764 RVA: 0x0001C57E File Offset: 0x0001A77E
		' (set) Token: 0x060002FD RID: 765 RVA: 0x0001C588 File Offset: 0x0001A788
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

		' Token: 0x17000121 RID: 289
		' (get) Token: 0x060002FE RID: 766 RVA: 0x0001C5E6 File Offset: 0x0001A7E6
		' (set) Token: 0x060002FF RID: 767 RVA: 0x0001C5F0 File Offset: 0x0001A7F0
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

		' Token: 0x17000122 RID: 290
		' (get) Token: 0x06000300 RID: 768 RVA: 0x0001C64E File Offset: 0x0001A84E
		' (set) Token: 0x06000301 RID: 769 RVA: 0x0001C658 File Offset: 0x0001A858
		Friend Overridable Property Q As Button
			<CompilerGenerated()>
			Get
				Return Me._Q
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As MouseEventHandler = AddressOf Me.KeyTouchDown
				Dim value3 As MouseEventHandler = AddressOf Me.KeyTouchUp
				Dim q As Button = Me._Q
				If q IsNot Nothing Then
					RemoveHandler q.MouseDown, value2
					RemoveHandler q.MouseUp, value3
				End If
				Me._Q = value
				q = Me._Q
				If q IsNot Nothing Then
					AddHandler q.MouseDown, value2
					AddHandler q.MouseUp, value3
				End If
			End Set
		End Property

		' Token: 0x17000123 RID: 291
		' (get) Token: 0x06000302 RID: 770 RVA: 0x0001C6B6 File Offset: 0x0001A8B6
		' (set) Token: 0x06000303 RID: 771 RVA: 0x0001C6C0 File Offset: 0x0001A8C0
		Friend Overridable Property A As Button
			<CompilerGenerated()>
			Get
				Return Me._A
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As MouseEventHandler = AddressOf Me.KeyTouchDown
				Dim value3 As MouseEventHandler = AddressOf Me.KeyTouchUp
				Dim a As Button = Me._A
				If a IsNot Nothing Then
					RemoveHandler a.MouseDown, value2
					RemoveHandler a.MouseUp, value3
				End If
				Me._A = value
				a = Me._A
				If a IsNot Nothing Then
					AddHandler a.MouseDown, value2
					AddHandler a.MouseUp, value3
				End If
			End Set
		End Property

		' Token: 0x17000124 RID: 292
		' (get) Token: 0x06000304 RID: 772 RVA: 0x0001C71E File Offset: 0x0001A91E
		' (set) Token: 0x06000305 RID: 773 RVA: 0x0001C728 File Offset: 0x0001A928
		Friend Overridable Property P As Button
			<CompilerGenerated()>
			Get
				Return Me._P
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As MouseEventHandler = AddressOf Me.KeyTouchDown
				Dim value3 As MouseEventHandler = AddressOf Me.KeyTouchUp
				Dim p As Button = Me._P
				If p IsNot Nothing Then
					RemoveHandler p.MouseDown, value2
					RemoveHandler p.MouseUp, value3
				End If
				Me._P = value
				p = Me._P
				If p IsNot Nothing Then
					AddHandler p.MouseDown, value2
					AddHandler p.MouseUp, value3
				End If
			End Set
		End Property

		' Token: 0x17000125 RID: 293
		' (get) Token: 0x06000306 RID: 774 RVA: 0x0001C786 File Offset: 0x0001A986
		' (set) Token: 0x06000307 RID: 775 RVA: 0x0001C790 File Offset: 0x0001A990
		Friend Overridable Property O As Button
			<CompilerGenerated()>
			Get
				Return Me._O
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As MouseEventHandler = AddressOf Me.KeyTouchDown
				Dim value3 As MouseEventHandler = AddressOf Me.KeyTouchUp
				Dim o As Button = Me._O
				If o IsNot Nothing Then
					RemoveHandler o.MouseDown, value2
					RemoveHandler o.MouseUp, value3
				End If
				Me._O = value
				o = Me._O
				If o IsNot Nothing Then
					AddHandler o.MouseDown, value2
					AddHandler o.MouseUp, value3
				End If
			End Set
		End Property

		' Token: 0x17000126 RID: 294
		' (get) Token: 0x06000308 RID: 776 RVA: 0x0001C7EE File Offset: 0x0001A9EE
		' (set) Token: 0x06000309 RID: 777 RVA: 0x0001C7F8 File Offset: 0x0001A9F8
		Friend Overridable Property I As Button
			<CompilerGenerated()>
			Get
				Return Me._I
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As MouseEventHandler = AddressOf Me.KeyTouchDown
				Dim value3 As MouseEventHandler = AddressOf Me.KeyTouchUp
				Dim i As Button = Me._I
				If i IsNot Nothing Then
					RemoveHandler i.MouseDown, value2
					RemoveHandler i.MouseUp, value3
				End If
				Me._I = value
				i = Me._I
				If i IsNot Nothing Then
					AddHandler i.MouseDown, value2
					AddHandler i.MouseUp, value3
				End If
			End Set
		End Property

		' Token: 0x17000127 RID: 295
		' (get) Token: 0x0600030A RID: 778 RVA: 0x0001C856 File Offset: 0x0001AA56
		' (set) Token: 0x0600030B RID: 779 RVA: 0x0001C860 File Offset: 0x0001AA60
		Friend Overridable Property U As Button
			<CompilerGenerated()>
			Get
				Return Me._U
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As MouseEventHandler = AddressOf Me.KeyTouchDown
				Dim value3 As MouseEventHandler = AddressOf Me.KeyTouchUp
				Dim u As Button = Me._U
				If u IsNot Nothing Then
					RemoveHandler u.MouseDown, value2
					RemoveHandler u.MouseUp, value3
				End If
				Me._U = value
				u = Me._U
				If u IsNot Nothing Then
					AddHandler u.MouseDown, value2
					AddHandler u.MouseUp, value3
				End If
			End Set
		End Property

		' Token: 0x17000128 RID: 296
		' (get) Token: 0x0600030C RID: 780 RVA: 0x0001C8BE File Offset: 0x0001AABE
		' (set) Token: 0x0600030D RID: 781 RVA: 0x0001C8C8 File Offset: 0x0001AAC8
		Friend Overridable Property Y As Button
			<CompilerGenerated()>
			Get
				Return Me._Y
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As MouseEventHandler = AddressOf Me.KeyTouchDown
				Dim value3 As MouseEventHandler = AddressOf Me.KeyTouchUp
				Dim y As Button = Me._Y
				If y IsNot Nothing Then
					RemoveHandler y.MouseDown, value2
					RemoveHandler y.MouseUp, value3
				End If
				Me._Y = value
				y = Me._Y
				If y IsNot Nothing Then
					AddHandler y.MouseDown, value2
					AddHandler y.MouseUp, value3
				End If
			End Set
		End Property

		' Token: 0x17000129 RID: 297
		' (get) Token: 0x0600030E RID: 782 RVA: 0x0001C926 File Offset: 0x0001AB26
		' (set) Token: 0x0600030F RID: 783 RVA: 0x0001C930 File Offset: 0x0001AB30
		Friend Overridable Property T As Button
			<CompilerGenerated()>
			Get
				Return Me._T
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As MouseEventHandler = AddressOf Me.KeyTouchDown
				Dim value3 As MouseEventHandler = AddressOf Me.KeyTouchUp
				Dim t As Button = Me._T
				If t IsNot Nothing Then
					RemoveHandler t.MouseDown, value2
					RemoveHandler t.MouseUp, value3
				End If
				Me._T = value
				t = Me._T
				If t IsNot Nothing Then
					AddHandler t.MouseDown, value2
					AddHandler t.MouseUp, value3
				End If
			End Set
		End Property

		' Token: 0x1700012A RID: 298
		' (get) Token: 0x06000310 RID: 784 RVA: 0x0001C98E File Offset: 0x0001AB8E
		' (set) Token: 0x06000311 RID: 785 RVA: 0x0001C998 File Offset: 0x0001AB98
		Friend Overridable Property R As Button
			<CompilerGenerated()>
			Get
				Return Me._R
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As MouseEventHandler = AddressOf Me.KeyTouchDown
				Dim value3 As MouseEventHandler = AddressOf Me.KeyTouchUp
				Dim r As Button = Me._R
				If r IsNot Nothing Then
					RemoveHandler r.MouseDown, value2
					RemoveHandler r.MouseUp, value3
				End If
				Me._R = value
				r = Me._R
				If r IsNot Nothing Then
					AddHandler r.MouseDown, value2
					AddHandler r.MouseUp, value3
				End If
			End Set
		End Property

		' Token: 0x1700012B RID: 299
		' (get) Token: 0x06000312 RID: 786 RVA: 0x0001C9F6 File Offset: 0x0001ABF6
		' (set) Token: 0x06000313 RID: 787 RVA: 0x0001CA00 File Offset: 0x0001AC00
		Friend Overridable Property E As Button
			<CompilerGenerated()>
			Get
				Return Me._E
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As MouseEventHandler = AddressOf Me.KeyTouchDown
				Dim value3 As MouseEventHandler = AddressOf Me.KeyTouchUp
				Dim e As Button = Me._E
				If e IsNot Nothing Then
					RemoveHandler e.MouseDown, value2
					RemoveHandler e.MouseUp, value3
				End If
				Me._E = value
				e = Me._E
				If e IsNot Nothing Then
					AddHandler e.MouseDown, value2
					AddHandler e.MouseUp, value3
				End If
			End Set
		End Property

		' Token: 0x1700012C RID: 300
		' (get) Token: 0x06000314 RID: 788 RVA: 0x0001CA5E File Offset: 0x0001AC5E
		' (set) Token: 0x06000315 RID: 789 RVA: 0x0001CA68 File Offset: 0x0001AC68
		Friend Overridable Property W As Button
			<CompilerGenerated()>
			Get
				Return Me._W
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As MouseEventHandler = AddressOf Me.KeyTouchDown
				Dim value3 As MouseEventHandler = AddressOf Me.KeyTouchUp
				Dim w As Button = Me._W
				If w IsNot Nothing Then
					RemoveHandler w.MouseDown, value2
					RemoveHandler w.MouseUp, value3
				End If
				Me._W = value
				w = Me._W
				If w IsNot Nothing Then
					AddHandler w.MouseDown, value2
					AddHandler w.MouseUp, value3
				End If
			End Set
		End Property

		' Token: 0x1700012D RID: 301
		' (get) Token: 0x06000316 RID: 790 RVA: 0x0001CAC6 File Offset: 0x0001ACC6
		' (set) Token: 0x06000317 RID: 791 RVA: 0x0001CAD0 File Offset: 0x0001ACD0
		Friend Overridable Property K As Button
			<CompilerGenerated()>
			Get
				Return Me._K
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As MouseEventHandler = AddressOf Me.KeyTouchDown
				Dim value3 As MouseEventHandler = AddressOf Me.KeyTouchUp
				Dim k As Button = Me._K
				If k IsNot Nothing Then
					RemoveHandler k.MouseDown, value2
					RemoveHandler k.MouseUp, value3
				End If
				Me._K = value
				k = Me._K
				If k IsNot Nothing Then
					AddHandler k.MouseDown, value2
					AddHandler k.MouseUp, value3
				End If
			End Set
		End Property

		' Token: 0x1700012E RID: 302
		' (get) Token: 0x06000318 RID: 792 RVA: 0x0001CB2E File Offset: 0x0001AD2E
		' (set) Token: 0x06000319 RID: 793 RVA: 0x0001CB38 File Offset: 0x0001AD38
		Friend Overridable Property L As Button
			<CompilerGenerated()>
			Get
				Return Me._L
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As MouseEventHandler = AddressOf Me.KeyTouchDown
				Dim value3 As MouseEventHandler = AddressOf Me.KeyTouchUp
				Dim l As Button = Me._L
				If l IsNot Nothing Then
					RemoveHandler l.MouseDown, value2
					RemoveHandler l.MouseUp, value3
				End If
				Me._L = value
				l = Me._L
				If l IsNot Nothing Then
					AddHandler l.MouseDown, value2
					AddHandler l.MouseUp, value3
				End If
			End Set
		End Property

		' Token: 0x1700012F RID: 303
		' (get) Token: 0x0600031A RID: 794 RVA: 0x0001CB96 File Offset: 0x0001AD96
		' (set) Token: 0x0600031B RID: 795 RVA: 0x0001CBA0 File Offset: 0x0001ADA0
		Friend Overridable Property J As Button
			<CompilerGenerated()>
			Get
				Return Me._J
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As MouseEventHandler = AddressOf Me.KeyTouchDown
				Dim value3 As MouseEventHandler = AddressOf Me.KeyTouchUp
				Dim j As Button = Me._J
				If j IsNot Nothing Then
					RemoveHandler j.MouseDown, value2
					RemoveHandler j.MouseUp, value3
				End If
				Me._J = value
				j = Me._J
				If j IsNot Nothing Then
					AddHandler j.MouseDown, value2
					AddHandler j.MouseUp, value3
				End If
			End Set
		End Property

		' Token: 0x17000130 RID: 304
		' (get) Token: 0x0600031C RID: 796 RVA: 0x0001CBFE File Offset: 0x0001ADFE
		' (set) Token: 0x0600031D RID: 797 RVA: 0x0001CC08 File Offset: 0x0001AE08
		Friend Overridable Property H As Button
			<CompilerGenerated()>
			Get
				Return Me._H
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As MouseEventHandler = AddressOf Me.KeyTouchDown
				Dim value3 As MouseEventHandler = AddressOf Me.KeyTouchUp
				Dim h As Button = Me._H
				If h IsNot Nothing Then
					RemoveHandler h.MouseDown, value2
					RemoveHandler h.MouseUp, value3
				End If
				Me._H = value
				h = Me._H
				If h IsNot Nothing Then
					AddHandler h.MouseDown, value2
					AddHandler h.MouseUp, value3
				End If
			End Set
		End Property

		' Token: 0x17000131 RID: 305
		' (get) Token: 0x0600031E RID: 798 RVA: 0x0001CC66 File Offset: 0x0001AE66
		' (set) Token: 0x0600031F RID: 799 RVA: 0x0001CC70 File Offset: 0x0001AE70
		Friend Overridable Property G As Button
			<CompilerGenerated()>
			Get
				Return Me._G
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As MouseEventHandler = AddressOf Me.KeyTouchDown
				Dim value3 As MouseEventHandler = AddressOf Me.KeyTouchUp
				Dim g As Button = Me._G
				If g IsNot Nothing Then
					RemoveHandler g.MouseDown, value2
					RemoveHandler g.MouseUp, value3
				End If
				Me._G = value
				g = Me._G
				If g IsNot Nothing Then
					AddHandler g.MouseDown, value2
					AddHandler g.MouseUp, value3
				End If
			End Set
		End Property

		' Token: 0x17000132 RID: 306
		' (get) Token: 0x06000320 RID: 800 RVA: 0x0001CCCE File Offset: 0x0001AECE
		' (set) Token: 0x06000321 RID: 801 RVA: 0x0001CCD8 File Offset: 0x0001AED8
		Friend Overridable Property F As Button
			<CompilerGenerated()>
			Get
				Return Me._F
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As MouseEventHandler = AddressOf Me.KeyTouchDown
				Dim value3 As MouseEventHandler = AddressOf Me.KeyTouchUp
				Dim f As Button = Me._F
				If f IsNot Nothing Then
					RemoveHandler f.MouseDown, value2
					RemoveHandler f.MouseUp, value3
				End If
				Me._F = value
				f = Me._F
				If f IsNot Nothing Then
					AddHandler f.MouseDown, value2
					AddHandler f.MouseUp, value3
				End If
			End Set
		End Property

		' Token: 0x17000133 RID: 307
		' (get) Token: 0x06000322 RID: 802 RVA: 0x0001CD36 File Offset: 0x0001AF36
		' (set) Token: 0x06000323 RID: 803 RVA: 0x0001CD40 File Offset: 0x0001AF40
		Friend Overridable Property D As Button
			<CompilerGenerated()>
			Get
				Return Me._D
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As MouseEventHandler = AddressOf Me.KeyTouchDown
				Dim value3 As MouseEventHandler = AddressOf Me.KeyTouchUp
				Dim d As Button = Me._D
				If d IsNot Nothing Then
					RemoveHandler d.MouseDown, value2
					RemoveHandler d.MouseUp, value3
				End If
				Me._D = value
				d = Me._D
				If d IsNot Nothing Then
					AddHandler d.MouseDown, value2
					AddHandler d.MouseUp, value3
				End If
			End Set
		End Property

		' Token: 0x17000134 RID: 308
		' (get) Token: 0x06000324 RID: 804 RVA: 0x0001CD9E File Offset: 0x0001AF9E
		' (set) Token: 0x06000325 RID: 805 RVA: 0x0001CDA8 File Offset: 0x0001AFA8
		Friend Overridable Property S As Button
			<CompilerGenerated()>
			Get
				Return Me._S
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As MouseEventHandler = AddressOf Me.KeyTouchDown
				Dim value3 As MouseEventHandler = AddressOf Me.KeyTouchUp
				Dim s As Button = Me._S
				If s IsNot Nothing Then
					RemoveHandler s.MouseDown, value2
					RemoveHandler s.MouseUp, value3
				End If
				Me._S = value
				s = Me._S
				If s IsNot Nothing Then
					AddHandler s.MouseDown, value2
					AddHandler s.MouseUp, value3
				End If
			End Set
		End Property

		' Token: 0x17000135 RID: 309
		' (get) Token: 0x06000326 RID: 806 RVA: 0x0001CE06 File Offset: 0x0001B006
		' (set) Token: 0x06000327 RID: 807 RVA: 0x0001CE10 File Offset: 0x0001B010
		Friend Overridable Property C As Button
			<CompilerGenerated()>
			Get
				Return Me._C
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As MouseEventHandler = AddressOf Me.KeyTouchDown
				Dim value3 As MouseEventHandler = AddressOf Me.KeyTouchUp
				Dim c As Button = Me._C
				If c IsNot Nothing Then
					RemoveHandler c.MouseDown, value2
					RemoveHandler c.MouseUp, value3
				End If
				Me._C = value
				c = Me._C
				If c IsNot Nothing Then
					AddHandler c.MouseDown, value2
					AddHandler c.MouseUp, value3
				End If
			End Set
		End Property

		' Token: 0x17000136 RID: 310
		' (get) Token: 0x06000328 RID: 808 RVA: 0x0001CE6E File Offset: 0x0001B06E
		' (set) Token: 0x06000329 RID: 809 RVA: 0x0001CE78 File Offset: 0x0001B078
		Friend Overridable Property V As Button
			<CompilerGenerated()>
			Get
				Return Me._V
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As MouseEventHandler = AddressOf Me.KeyTouchDown
				Dim value3 As MouseEventHandler = AddressOf Me.KeyTouchUp
				Dim v As Button = Me._V
				If v IsNot Nothing Then
					RemoveHandler v.MouseDown, value2
					RemoveHandler v.MouseUp, value3
				End If
				Me._V = value
				v = Me._V
				If v IsNot Nothing Then
					AddHandler v.MouseDown, value2
					AddHandler v.MouseUp, value3
				End If
			End Set
		End Property

		' Token: 0x17000137 RID: 311
		' (get) Token: 0x0600032A RID: 810 RVA: 0x0001CED6 File Offset: 0x0001B0D6
		' (set) Token: 0x0600032B RID: 811 RVA: 0x0001CEE0 File Offset: 0x0001B0E0
		Friend Overridable Property B As Button
			<CompilerGenerated()>
			Get
				Return Me._B
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As MouseEventHandler = AddressOf Me.KeyTouchDown
				Dim value3 As MouseEventHandler = AddressOf Me.KeyTouchUp
				Dim b As Button = Me._B
				If b IsNot Nothing Then
					RemoveHandler b.MouseDown, value2
					RemoveHandler b.MouseUp, value3
				End If
				Me._B = value
				b = Me._B
				If b IsNot Nothing Then
					AddHandler b.MouseDown, value2
					AddHandler b.MouseUp, value3
				End If
			End Set
		End Property

		' Token: 0x17000138 RID: 312
		' (get) Token: 0x0600032C RID: 812 RVA: 0x0001CF3E File Offset: 0x0001B13E
		' (set) Token: 0x0600032D RID: 813 RVA: 0x0001CF48 File Offset: 0x0001B148
		Friend Overridable Property N As Button
			<CompilerGenerated()>
			Get
				Return Me._N
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As MouseEventHandler = AddressOf Me.KeyTouchDown
				Dim value3 As MouseEventHandler = AddressOf Me.KeyTouchUp
				Dim n As Button = Me._N
				If n IsNot Nothing Then
					RemoveHandler n.MouseDown, value2
					RemoveHandler n.MouseUp, value3
				End If
				Me._N = value
				n = Me._N
				If n IsNot Nothing Then
					AddHandler n.MouseDown, value2
					AddHandler n.MouseUp, value3
				End If
			End Set
		End Property

		' Token: 0x17000139 RID: 313
		' (get) Token: 0x0600032E RID: 814 RVA: 0x0001CFA6 File Offset: 0x0001B1A6
		' (set) Token: 0x0600032F RID: 815 RVA: 0x0001CFB0 File Offset: 0x0001B1B0
		Friend Overridable Property M As Button
			<CompilerGenerated()>
			Get
				Return Me._M
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As MouseEventHandler = AddressOf Me.KeyTouchDown
				Dim value3 As MouseEventHandler = AddressOf Me.KeyTouchUp
				Dim m As Button = Me._M
				If m IsNot Nothing Then
					RemoveHandler m.MouseDown, value2
					RemoveHandler m.MouseUp, value3
				End If
				Me._M = value
				m = Me._M
				If m IsNot Nothing Then
					AddHandler m.MouseDown, value2
					AddHandler m.MouseUp, value3
				End If
			End Set
		End Property

		' Token: 0x1700013A RID: 314
		' (get) Token: 0x06000330 RID: 816 RVA: 0x0001D00E File Offset: 0x0001B20E
		' (set) Token: 0x06000331 RID: 817 RVA: 0x0001D018 File Offset: 0x0001B218
		Friend Overridable Property X As Button
			<CompilerGenerated()>
			Get
				Return Me._X
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As MouseEventHandler = AddressOf Me.KeyTouchDown
				Dim value3 As MouseEventHandler = AddressOf Me.KeyTouchUp
				Dim x As Button = Me._X
				If x IsNot Nothing Then
					RemoveHandler x.MouseDown, value2
					RemoveHandler x.MouseUp, value3
				End If
				Me._X = value
				x = Me._X
				If x IsNot Nothing Then
					AddHandler x.MouseDown, value2
					AddHandler x.MouseUp, value3
				End If
			End Set
		End Property

		' Token: 0x1700013B RID: 315
		' (get) Token: 0x06000332 RID: 818 RVA: 0x0001D076 File Offset: 0x0001B276
		' (set) Token: 0x06000333 RID: 819 RVA: 0x0001D080 File Offset: 0x0001B280
		Friend Overridable Property space As Button
			<CompilerGenerated()>
			Get
				Return Me._space
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As MouseEventHandler = AddressOf Me.space_TouchDown
				Dim value3 As MouseEventHandler = AddressOf Me.space_TouchUp
				Dim space As Button = Me._space
				If space IsNot Nothing Then
					RemoveHandler space.MouseDown, value2
					RemoveHandler space.MouseUp, value3
				End If
				Me._space = value
				space = Me._space
				If space IsNot Nothing Then
					AddHandler space.MouseDown, value2
					AddHandler space.MouseUp, value3
				End If
			End Set
		End Property

		' Token: 0x1700013C RID: 316
		' (get) Token: 0x06000334 RID: 820 RVA: 0x0001D0DE File Offset: 0x0001B2DE
		' (set) Token: 0x06000335 RID: 821 RVA: 0x0001D0E8 File Offset: 0x0001B2E8
		Friend Overridable Property Z As Button
			<CompilerGenerated()>
			Get
				Return Me._Z
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As MouseEventHandler = AddressOf Me.KeyTouchDown
				Dim value3 As MouseEventHandler = AddressOf Me.KeyTouchUp
				Dim z As Button = Me._Z
				If z IsNot Nothing Then
					RemoveHandler z.MouseDown, value2
					RemoveHandler z.MouseUp, value3
				End If
				Me._Z = value
				z = Me._Z
				If z IsNot Nothing Then
					AddHandler z.MouseDown, value2
					AddHandler z.MouseUp, value3
				End If
			End Set
		End Property

		' Token: 0x1700013D RID: 317
		' (get) Token: 0x06000336 RID: 822 RVA: 0x0001D146 File Offset: 0x0001B346
		' (set) Token: 0x06000337 RID: 823 RVA: 0x0001D150 File Offset: 0x0001B350
		Friend Overridable Property del As Button
			<CompilerGenerated()>
			Get
				Return Me._del
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As MouseEventHandler = AddressOf Me.del_TouchDown
				Dim value3 As MouseEventHandler = AddressOf Me.del_TouchUp
				Dim del As Button = Me._del
				If del IsNot Nothing Then
					RemoveHandler del.MouseDown, value2
					RemoveHandler del.MouseUp, value3
				End If
				Me._del = value
				del = Me._del
				If del IsNot Nothing Then
					AddHandler del.MouseDown, value2
					AddHandler del.MouseUp, value3
				End If
			End Set
		End Property

		' Token: 0x1700013E RID: 318
		' (get) Token: 0x06000338 RID: 824 RVA: 0x0001D1AE File Offset: 0x0001B3AE
		' (set) Token: 0x06000339 RID: 825 RVA: 0x0001D1B8 File Offset: 0x0001B3B8
		Friend Overridable Property clear As Button
			<CompilerGenerated()>
			Get
				Return Me._clear
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As MouseEventHandler = AddressOf Me.clear_TouchDown
				Dim value3 As MouseEventHandler = AddressOf Me.clear_TouchUp
				Dim clear As Button = Me._clear
				If clear IsNot Nothing Then
					RemoveHandler clear.MouseDown, value2
					RemoveHandler clear.MouseUp, value3
				End If
				Me._clear = value
				clear = Me._clear
				If clear IsNot Nothing Then
					AddHandler clear.MouseDown, value2
					AddHandler clear.MouseUp, value3
				End If
			End Set
		End Property

		' Token: 0x1700013F RID: 319
		' (get) Token: 0x0600033A RID: 826 RVA: 0x0001D216 File Offset: 0x0001B416
		' (set) Token: 0x0600033B RID: 827 RVA: 0x0001D220 File Offset: 0x0001B420
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

		' Token: 0x17000140 RID: 320
		' (get) Token: 0x0600033C RID: 828 RVA: 0x0001D27E File Offset: 0x0001B47E
		' (set) Token: 0x0600033D RID: 829 RVA: 0x0001D288 File Offset: 0x0001B488
		Friend Overridable Property trat As Button
			<CompilerGenerated()>
			Get
				Return Me._trat
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As MouseEventHandler = AddressOf Me.KeyTouchDown
				Dim value3 As MouseEventHandler = AddressOf Me.KeyTouchUp
				Dim trat As Button = Me._trat
				If trat IsNot Nothing Then
					RemoveHandler trat.MouseDown, value2
					RemoveHandler trat.MouseUp, value3
				End If
				Me._trat = value
				trat = Me._trat
				If trat IsNot Nothing Then
					AddHandler trat.MouseDown, value2
					AddHandler trat.MouseUp, value3
				End If
			End Set
		End Property

		' Token: 0x17000141 RID: 321
		' (get) Token: 0x0600033E RID: 830 RVA: 0x0001D2E6 File Offset: 0x0001B4E6
		' (set) Token: 0x0600033F RID: 831 RVA: 0x0001D2F0 File Offset: 0x0001B4F0
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

		' Token: 0x17000142 RID: 322
		' (get) Token: 0x06000340 RID: 832 RVA: 0x0001D34E File Offset: 0x0001B54E
		' (set) Token: 0x06000341 RID: 833 RVA: 0x0001D358 File Offset: 0x0001B558
		Friend Overridable Property slash As Button
			<CompilerGenerated()>
			Get
				Return Me._slash
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim value2 As MouseEventHandler = AddressOf Me.KeyTouchDown
				Dim value3 As MouseEventHandler = AddressOf Me.KeyTouchUp
				Dim slash As Button = Me._slash
				If slash IsNot Nothing Then
					RemoveHandler slash.MouseDown, value2
					RemoveHandler slash.MouseUp, value3
				End If
				Me._slash = value
				slash = Me._slash
				If slash IsNot Nothing Then
					AddHandler slash.MouseDown, value2
					AddHandler slash.MouseUp, value3
				End If
			End Set
		End Property

		' Token: 0x06000342 RID: 834 RVA: 0x0001D3B8 File Offset: 0x0001B5B8
		<DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.N7 = New Button()
			Me.N3 = New Button()
			Me.N2 = New Button()
			Me.N1 = New Button()
			Me.N6 = New Button()
			Me.N5 = New Button()
			Me.N4 = New Button()
			Me.N9 = New Button()
			Me.N8 = New Button()
			Me.N0 = New Button()
			Me.Q = New Button()
			Me.A = New Button()
			Me.P = New Button()
			Me.O = New Button()
			Me.I = New Button()
			Me.U = New Button()
			Me.Y = New Button()
			Me.T = New Button()
			Me.R = New Button()
			Me.E = New Button()
			Me.W = New Button()
			Me.K = New Button()
			Me.L = New Button()
			Me.J = New Button()
			Me.H = New Button()
			Me.G = New Button()
			Me.F = New Button()
			Me.D = New Button()
			Me.S = New Button()
			Me.C = New Button()
			Me.V = New Button()
			Me.B = New Button()
			Me.N = New Button()
			Me.M = New Button()
			Me.X = New Button()
			Me.space = New Button()
			Me.Z = New Button()
			Me.lbl_text = New Label()
			Me.del = New Button()
			Me.clear = New Button()
			Me.point = New Button()
			Me.slash = New Button()
			Me.trat = New Button()
			Me.minus = New Button()
			MyBase.SuspendLayout()
			Me.N7.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.N7.ForeColor = Color.RoyalBlue
			Me.N7.Location = New Point(471, 157)
			Me.N7.Name = "N7"
			Me.N7.Size = New Size(45, 45)
			Me.N7.TabIndex = 19
			Me.N7.TabStop = False
			Me.N7.Text = "7"
			Me.N3.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.N3.ForeColor = Color.RoyalBlue
			Me.N3.Location = New Point(561, 67)
			Me.N3.Name = "N3"
			Me.N3.Size = New Size(45, 45)
			Me.N3.TabIndex = 20
			Me.N3.TabStop = False
			Me.N3.Text = "3"
			Me.N2.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.N2.ForeColor = Color.RoyalBlue
			Me.N2.Location = New Point(516, 67)
			Me.N2.Name = "N2"
			Me.N2.Size = New Size(45, 45)
			Me.N2.TabIndex = 21
			Me.N2.TabStop = False
			Me.N2.Text = "2"
			Me.N1.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.N1.ForeColor = Color.RoyalBlue
			Me.N1.Location = New Point(471, 67)
			Me.N1.Name = "N1"
			Me.N1.Size = New Size(45, 45)
			Me.N1.TabIndex = 22
			Me.N1.TabStop = False
			Me.N1.Text = "1"
			Me.N6.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.N6.ForeColor = Color.RoyalBlue
			Me.N6.Location = New Point(561, 112)
			Me.N6.Name = "N6"
			Me.N6.Size = New Size(45, 45)
			Me.N6.TabIndex = 23
			Me.N6.TabStop = False
			Me.N6.Text = "6"
			Me.N5.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.N5.ForeColor = Color.RoyalBlue
			Me.N5.Location = New Point(516, 112)
			Me.N5.Name = "N5"
			Me.N5.Size = New Size(45, 45)
			Me.N5.TabIndex = 24
			Me.N5.TabStop = False
			Me.N5.Text = "5"
			Me.N4.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.N4.ForeColor = Color.RoyalBlue
			Me.N4.Location = New Point(471, 112)
			Me.N4.Name = "N4"
			Me.N4.Size = New Size(45, 45)
			Me.N4.TabIndex = 25
			Me.N4.TabStop = False
			Me.N4.Text = "4"
			Me.N9.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.N9.ForeColor = Color.RoyalBlue
			Me.N9.Location = New Point(561, 157)
			Me.N9.Name = "N9"
			Me.N9.Size = New Size(45, 45)
			Me.N9.TabIndex = 26
			Me.N9.TabStop = False
			Me.N9.Text = "9"
			Me.N8.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.N8.ForeColor = Color.RoyalBlue
			Me.N8.Location = New Point(516, 157)
			Me.N8.Name = "N8"
			Me.N8.Size = New Size(45, 45)
			Me.N8.TabIndex = 27
			Me.N8.TabStop = False
			Me.N8.Text = "8"
			Me.N0.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.N0.ForeColor = Color.RoyalBlue
			Me.N0.Location = New Point(471, 202)
			Me.N0.Name = "N0"
			Me.N0.Size = New Size(90, 45)
			Me.N0.TabIndex = 28
			Me.N0.TabStop = False
			Me.N0.Text = "0"
			Me.Q.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.Q.ForeColor = Color.DarkRed
			Me.Q.Location = New Point(8, 67)
			Me.Q.Name = "Q"
			Me.Q.Size = New Size(45, 45)
			Me.Q.TabIndex = 30
			Me.Q.TabStop = False
			Me.Q.Text = "Q"
			Me.A.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.A.ForeColor = Color.DarkRed
			Me.A.Location = New Point(30, 112)
			Me.A.Name = "A"
			Me.A.Size = New Size(45, 45)
			Me.A.TabIndex = 31
			Me.A.TabStop = False
			Me.A.Text = "A"
			Me.P.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.P.ForeColor = Color.DarkRed
			Me.P.Location = New Point(413, 67)
			Me.P.Name = "P"
			Me.P.Size = New Size(45, 45)
			Me.P.TabIndex = 32
			Me.P.TabStop = False
			Me.P.Text = "P"
			Me.O.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.O.ForeColor = Color.DarkRed
			Me.O.Location = New Point(368, 67)
			Me.O.Name = "O"
			Me.O.Size = New Size(45, 45)
			Me.O.TabIndex = 33
			Me.O.TabStop = False
			Me.O.Text = "O"
			Me.I.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.I.ForeColor = Color.DarkRed
			Me.I.Location = New Point(323, 67)
			Me.I.Name = "I"
			Me.I.Size = New Size(45, 45)
			Me.I.TabIndex = 34
			Me.I.TabStop = False
			Me.I.Text = "I"
			Me.U.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.U.ForeColor = Color.DarkRed
			Me.U.Location = New Point(278, 67)
			Me.U.Name = "U"
			Me.U.Size = New Size(45, 45)
			Me.U.TabIndex = 35
			Me.U.TabStop = False
			Me.U.Text = "U"
			Me.Y.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.Y.ForeColor = Color.DarkRed
			Me.Y.Location = New Point(233, 67)
			Me.Y.Name = "Y"
			Me.Y.Size = New Size(45, 45)
			Me.Y.TabIndex = 36
			Me.Y.TabStop = False
			Me.Y.Text = "Y"
			Me.T.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.T.ForeColor = Color.DarkRed
			Me.T.Location = New Point(188, 67)
			Me.T.Name = "T"
			Me.T.Size = New Size(45, 45)
			Me.T.TabIndex = 37
			Me.T.TabStop = False
			Me.T.Text = "T"
			Me.R.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.R.ForeColor = Color.DarkRed
			Me.R.Location = New Point(143, 67)
			Me.R.Name = "R"
			Me.R.Size = New Size(45, 45)
			Me.R.TabIndex = 38
			Me.R.TabStop = False
			Me.R.Text = "R"
			Me.E.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.E.ForeColor = Color.DarkRed
			Me.E.Location = New Point(98, 67)
			Me.E.Name = "E"
			Me.E.Size = New Size(45, 45)
			Me.E.TabIndex = 39
			Me.E.TabStop = False
			Me.E.Text = "E"
			Me.W.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.W.ForeColor = Color.DarkRed
			Me.W.Location = New Point(53, 67)
			Me.W.Name = "W"
			Me.W.Size = New Size(45, 45)
			Me.W.TabIndex = 40
			Me.W.TabStop = False
			Me.W.Text = "W"
			Me.K.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.K.ForeColor = Color.DarkRed
			Me.K.Location = New Point(345, 112)
			Me.K.Name = "K"
			Me.K.Size = New Size(45, 45)
			Me.K.TabIndex = 41
			Me.K.TabStop = False
			Me.K.Text = "K"
			Me.L.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.L.ForeColor = Color.DarkRed
			Me.L.Location = New Point(390, 112)
			Me.L.Name = "L"
			Me.L.Size = New Size(45, 45)
			Me.L.TabIndex = 42
			Me.L.TabStop = False
			Me.L.Text = "L"
			Me.J.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.J.ForeColor = Color.DarkRed
			Me.J.Location = New Point(300, 112)
			Me.J.Name = "J"
			Me.J.Size = New Size(45, 45)
			Me.J.TabIndex = 43
			Me.J.TabStop = False
			Me.J.Text = "J"
			Me.H.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.H.ForeColor = Color.DarkRed
			Me.H.Location = New Point(255, 112)
			Me.H.Name = "H"
			Me.H.Size = New Size(45, 45)
			Me.H.TabIndex = 44
			Me.H.TabStop = False
			Me.H.Text = "H"
			Me.G.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.G.ForeColor = Color.DarkRed
			Me.G.Location = New Point(210, 112)
			Me.G.Name = "G"
			Me.G.Size = New Size(45, 45)
			Me.G.TabIndex = 45
			Me.G.TabStop = False
			Me.G.Text = "G"
			Me.F.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.F.ForeColor = Color.DarkRed
			Me.F.Location = New Point(165, 112)
			Me.F.Name = "F"
			Me.F.Size = New Size(45, 45)
			Me.F.TabIndex = 46
			Me.F.TabStop = False
			Me.F.Text = "F"
			Me.D.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.D.ForeColor = Color.DarkRed
			Me.D.Location = New Point(120, 112)
			Me.D.Name = "D"
			Me.D.Size = New Size(45, 45)
			Me.D.TabIndex = 47
			Me.D.TabStop = False
			Me.D.Text = "D"
			Me.S.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.S.ForeColor = Color.DarkRed
			Me.S.Location = New Point(75, 112)
			Me.S.Name = "S"
			Me.S.Size = New Size(45, 45)
			Me.S.TabIndex = 48
			Me.S.TabStop = False
			Me.S.Text = "S"
			Me.C.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.C.ForeColor = Color.DarkRed
			Me.C.Location = New Point(143, 157)
			Me.C.Name = "C"
			Me.C.Size = New Size(45, 45)
			Me.C.TabIndex = 57
			Me.C.TabStop = False
			Me.C.Text = "C"
			Me.V.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.V.ForeColor = Color.DarkRed
			Me.V.Location = New Point(188, 157)
			Me.V.Name = "V"
			Me.V.Size = New Size(45, 45)
			Me.V.TabIndex = 56
			Me.V.TabStop = False
			Me.V.Text = "V"
			Me.B.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.B.ForeColor = Color.DarkRed
			Me.B.Location = New Point(233, 157)
			Me.B.Name = "B"
			Me.B.Size = New Size(45, 45)
			Me.B.TabIndex = 55
			Me.B.TabStop = False
			Me.B.Text = "B"
			Me.N.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.N.ForeColor = Color.DarkRed
			Me.N.Location = New Point(278, 157)
			Me.N.Name = "N"
			Me.N.Size = New Size(45, 45)
			Me.N.TabIndex = 54
			Me.N.TabStop = False
			Me.N.Text = "N"
			Me.M.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.M.ForeColor = Color.DarkRed
			Me.M.Location = New Point(323, 157)
			Me.M.Name = "M"
			Me.M.Size = New Size(45, 45)
			Me.M.TabIndex = 53
			Me.M.TabStop = False
			Me.M.Text = "M"
			Me.X.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.X.ForeColor = Color.DarkRed
			Me.X.Location = New Point(98, 157)
			Me.X.Name = "X"
			Me.X.Size = New Size(45, 45)
			Me.X.TabIndex = 49
			Me.X.TabStop = False
			Me.X.Text = "X"
			Me.space.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0)
			Me.space.ForeColor = Color.Green
			Me.space.Location = New Point(98, 202)
			Me.space.Name = "space"
			Me.space.Size = New Size(270, 45)
			Me.space.TabIndex = 58
			Me.space.TabStop = False
			Me.Z.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.Z.ForeColor = Color.DarkRed
			Me.Z.Location = New Point(53, 157)
			Me.Z.Name = "Z"
			Me.Z.Size = New Size(45, 45)
			Me.Z.TabIndex = 61
			Me.Z.TabStop = False
			Me.Z.Text = "Z"
			Me.lbl_text.BackColor = Color.White
			Me.lbl_text.BorderStyle = BorderStyle.Fixed3D
			Me.lbl_text.Font = New Font("Microsoft Sans Serif", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.lbl_text.Location = New Point(8, 8)
			Me.lbl_text.Name = "lbl_text"
			Me.lbl_text.Size = New Size(598, 56)
			Me.lbl_text.TabIndex = 62
			Me.lbl_text.Text = "123456789012345678901234567890"
			Me.lbl_text.TextAlign = ContentAlignment.MiddleLeft
			Me.del.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0)
			Me.del.ForeColor = Color.Green
			Me.del.Location = New Point(368, 202)
			Me.del.Name = "del"
			Me.del.Size = New Size(90, 45)
			Me.del.TabIndex = 64
			Me.del.TabStop = False
			Me.del.Text = "DEL"
			Me.clear.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0)
			Me.clear.ForeColor = Color.Green
			Me.clear.Location = New Point(8, 202)
			Me.clear.Name = "clear"
			Me.clear.Size = New Size(90, 45)
			Me.clear.TabIndex = 65
			Me.clear.TabStop = False
			Me.clear.Text = "CLEAR"
			Me.point.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.point.Location = New Point(561, 202)
			Me.point.Name = "point"
			Me.point.Size = New Size(45, 45)
			Me.point.TabIndex = 66
			Me.point.TabStop = False
			Me.point.Text = "."
			Me.slash.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.slash.Location = New Point(8, 157)
			Me.slash.Name = "slash"
			Me.slash.Size = New Size(45, 45)
			Me.slash.TabIndex = 67
			Me.slash.TabStop = False
			Me.slash.Text = "/"
			Me.trat.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.trat.Location = New Point(368, 157)
			Me.trat.Name = "trat"
			Me.trat.Size = New Size(45, 45)
			Me.trat.TabIndex = 68
			Me.trat.TabStop = False
			Me.trat.Text = "_"
			Me.minus.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
			Me.minus.Location = New Point(413, 157)
			Me.minus.Name = "minus"
			Me.minus.Size = New Size(45, 45)
			Me.minus.TabIndex = 69
			Me.minus.TabStop = False
			Me.minus.Text = "-"
			MyBase.AutoScaleMode = AutoScaleMode.None
			MyBase.Controls.Add(Me.minus)
			MyBase.Controls.Add(Me.trat)
			MyBase.Controls.Add(Me.slash)
			MyBase.Controls.Add(Me.point)
			MyBase.Controls.Add(Me.clear)
			MyBase.Controls.Add(Me.del)
			MyBase.Controls.Add(Me.lbl_text)
			MyBase.Controls.Add(Me.Z)
			MyBase.Controls.Add(Me.space)
			MyBase.Controls.Add(Me.C)
			MyBase.Controls.Add(Me.V)
			MyBase.Controls.Add(Me.B)
			MyBase.Controls.Add(Me.N)
			MyBase.Controls.Add(Me.M)
			MyBase.Controls.Add(Me.X)
			MyBase.Controls.Add(Me.S)
			MyBase.Controls.Add(Me.D)
			MyBase.Controls.Add(Me.F)
			MyBase.Controls.Add(Me.G)
			MyBase.Controls.Add(Me.H)
			MyBase.Controls.Add(Me.J)
			MyBase.Controls.Add(Me.L)
			MyBase.Controls.Add(Me.K)
			MyBase.Controls.Add(Me.W)
			MyBase.Controls.Add(Me.E)
			MyBase.Controls.Add(Me.R)
			MyBase.Controls.Add(Me.T)
			MyBase.Controls.Add(Me.Y)
			MyBase.Controls.Add(Me.U)
			MyBase.Controls.Add(Me.I)
			MyBase.Controls.Add(Me.O)
			MyBase.Controls.Add(Me.P)
			MyBase.Controls.Add(Me.A)
			MyBase.Controls.Add(Me.Q)
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
			MyBase.Name = "ucTouchKey"
			MyBase.Size = New Size(615, 257)
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x17000143 RID: 323
		' (get) Token: 0x06000343 RID: 835 RVA: 0x0001F188 File Offset: 0x0001D388
		' (set) Token: 0x06000344 RID: 836 RVA: 0x0001F19D File Offset: 0x0001D39D
		Public Property KeyText As String
			Get
				Return Me.TextForm
			End Get
			Set(value As String)
				Me.lbl_text.Text = value
				Me.TextForm = value
			End Set
		End Property

		' Token: 0x17000144 RID: 324
		' (get) Token: 0x06000345 RID: 837 RVA: 0x0001F1B4 File Offset: 0x0001D3B4
		' (set) Token: 0x06000346 RID: 838 RVA: 0x0001F1C2 File Offset: 0x0001D3C2
		Public Property KeyMode As Byte
			Get
				Dim result As Byte
				Return result
			End Get
			Set(value As Byte)
			End Set
		End Property

		' Token: 0x06000347 RID: 839 RVA: 0x0001F1C4 File Offset: 0x0001D3C4
		Private Sub KeyTouchDown(sender As Object, e As MouseEventArgs)
			Me.key = CType(sender, Button)
			Me.key.BackColor = Color.Cyan
		End Sub

		' Token: 0x06000348 RID: 840 RVA: 0x0001F1E4 File Offset: 0x0001D3E4
		Private Sub KeyTouchUp(sender As Object, e As MouseEventArgs)
			Me.key = CType(sender, Button)
			Me.key.BackColor = Color.Empty
			If Strings.Len(Me.lbl_text.Text) < 50 Then
				If Me.InsertPassword Then
					Me.lbl_text.Text = Me.lbl_text.Text + "*"
				Else
					Me.lbl_text.Text = Me.lbl_text.Text + Me.key.Text
				End If
				Me.TextForm += Me.key.Text
			End If
			Me.count += 1
		End Sub

		' Token: 0x06000349 RID: 841 RVA: 0x0001F1C4 File Offset: 0x0001D3C4
		Private Sub space_TouchDown(sender As Object, e As MouseEventArgs)
			Me.key = CType(sender, Button)
			Me.key.BackColor = Color.Cyan
		End Sub

		' Token: 0x0600034A RID: 842 RVA: 0x0001F29C File Offset: 0x0001D49C
		Private Sub space_TouchUp(sender As Object, e As MouseEventArgs)
			Me.key = CType(sender, Button)
			Me.key.BackColor = Color.Empty
			If Strings.Len(Me.lbl_text.Text) < 50 Then
				If Me.InsertPassword Then
					Me.lbl_text.Text = Me.lbl_text.Text + "*"
				Else
					Me.lbl_text.Text = Me.lbl_text.Text + " "
				End If
				Me.TextForm += " "
			End If
		End Sub

		' Token: 0x0600034B RID: 843 RVA: 0x0001F1C4 File Offset: 0x0001D3C4
		Private Sub del_TouchDown(sender As Object, e As MouseEventArgs)
			Me.key = CType(sender, Button)
			Me.key.BackColor = Color.Cyan
		End Sub

		' Token: 0x0600034C RID: 844 RVA: 0x0001F33C File Offset: 0x0001D53C
		Private Sub del_TouchUp(sender As Object, e As MouseEventArgs)
			Me.key = CType(sender, Button)
			Me.key.BackColor = Color.Empty
			If Me.lbl_text.Text.Length > 0 Then
				Me.lbl_text.Text = Me.lbl_text.Text.Remove(Me.lbl_text.Text.Length - 1, 1)
				Me.TextForm = Me.TextForm.Remove(Me.TextForm.Length - 1, 1)
			End If
		End Sub

		' Token: 0x0600034D RID: 845 RVA: 0x0001F1C4 File Offset: 0x0001D3C4
		Private Sub clear_TouchDown(sender As Object, e As MouseEventArgs)
			Me.key = CType(sender, Button)
			Me.key.BackColor = Color.Cyan
		End Sub

		' Token: 0x0600034E RID: 846 RVA: 0x0001F3C5 File Offset: 0x0001D5C5
		Private Sub clear_TouchUp(sender As Object, e As MouseEventArgs)
			Me.key = CType(sender, Button)
			Me.key.BackColor = Color.Empty
			Me.lbl_text.Text = ""
			Me.TextForm = ""
		End Sub

		' Token: 0x04000201 RID: 513
		Private components As IContainer

		' Token: 0x0400022E RID: 558
		Public Const KEY_MODE_TOT As Integer = 0

		' Token: 0x0400022F RID: 559
		Public Const KEY_MODE_ALFA As Integer = 1

		' Token: 0x04000230 RID: 560
		Public Const KEY_MODE_NUM As Integer = 2

		' Token: 0x04000231 RID: 561
		Public InsertPassword As Boolean

		' Token: 0x04000232 RID: 562
		Public TextForm As String

		' Token: 0x04000233 RID: 563
		Private Const MAX_LENGTH As Integer = 50

		' Token: 0x04000234 RID: 564
		Private key As Button

		' Token: 0x04000235 RID: 565
		Private count As Integer

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
		Private _A As Button
		Private _B As Button
		Private _C As Button
		Private _D As Button
		Private _E As Button
		Private _F As Button
		Private _G As Button
		Private _H As Button
		Private _I As Button
		Private _J As Button
		Private _K As Button
		Private _L As Button
		Private _M As Button
		Private _N As Button
		Private _O As Button
		Private _P As Button
		Private _Q As Button
		Private _R As Button
		Private _S As Button
		Private _T As Button
		Private _U As Button
		Private _V As Button
		Private _W As Button
		Private _X As Button
		Private _Y As Button
		Private _Z As Button
		Private _clear As Button
		Private _del As Button
		Private _minus As Button
		Private _point As Button
		Private _slash As Button
		Private _space As Button
		Private _trat As Button
	End Class
End Namespace
