Imports System
Imports System.CodeDom.Compiler
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Diagnostics
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.ApplicationServices
Imports Microsoft.VisualBasic.CompilerServices

Namespace Terminale.My
	' Token: 0x02000004 RID: 4
	<HideModuleName()>
	<GeneratedCode("MyTemplate", "11.0.0.0")>
	Friend Module MyProject
		' Token: 0x17000001 RID: 1
		' (get) Token: 0x06000006 RID: 6 RVA: 0x000020DA File Offset: 0x000002DA
		<HelpKeyword("My.Computer")>
		Friend ReadOnly Property Computer As MyComputer
			<DebuggerHidden()>
			Get
				Return MyProject.m_ComputerObjectProvider.GetInstance
			End Get
		End Property

		' Token: 0x17000002 RID: 2
		' (get) Token: 0x06000007 RID: 7 RVA: 0x000020E6 File Offset: 0x000002E6
		<HelpKeyword("My.Application")>
		Friend ReadOnly Property Application As MyApplication
			<DebuggerHidden()>
			Get
				Return MyProject.m_AppObjectProvider.GetInstance
			End Get
		End Property

		' Token: 0x17000003 RID: 3
		' (get) Token: 0x06000008 RID: 8 RVA: 0x000020F2 File Offset: 0x000002F2
		<HelpKeyword("My.User")>
		Friend ReadOnly Property User As User
			<DebuggerHidden()>
			Get
				Return MyProject.m_UserObjectProvider.GetInstance
			End Get
		End Property

		' Token: 0x17000004 RID: 4
		' (get) Token: 0x06000009 RID: 9 RVA: 0x000020FE File Offset: 0x000002FE
		<HelpKeyword("My.Forms")>
		Friend ReadOnly Property Forms As MyProject.MyForms
			<DebuggerHidden()>
			Get
				Return MyProject.m_MyFormsObjectProvider.GetInstance
			End Get
		End Property

		' Token: 0x17000005 RID: 5
		' (get) Token: 0x0600000A RID: 10 RVA: 0x0000210A File Offset: 0x0000030A
		<HelpKeyword("My.WebServices")>
		Friend ReadOnly Property WebServices As MyProject.MyWebServices
			<DebuggerHidden()>
			Get
				Return MyProject.m_MyWebServicesObjectProvider.GetInstance
			End Get
		End Property

		' Token: 0x04000001 RID: 1
		Private m_ComputerObjectProvider As MyProject.ThreadSafeObjectProvider(Of MyComputer) = New MyProject.ThreadSafeObjectProvider(Of MyComputer)()

		' Token: 0x04000002 RID: 2
		Private m_AppObjectProvider As MyProject.ThreadSafeObjectProvider(Of MyApplication) = New MyProject.ThreadSafeObjectProvider(Of MyApplication)()

		' Token: 0x04000003 RID: 3
		Private m_UserObjectProvider As MyProject.ThreadSafeObjectProvider(Of User) = New MyProject.ThreadSafeObjectProvider(Of User)()

		' Token: 0x04000004 RID: 4
		Private m_MyFormsObjectProvider As MyProject.ThreadSafeObjectProvider(Of MyProject.MyForms) = New MyProject.ThreadSafeObjectProvider(Of MyProject.MyForms)()

		' Token: 0x04000005 RID: 5
		Private m_MyWebServicesObjectProvider As MyProject.ThreadSafeObjectProvider(Of MyProject.MyWebServices) = New MyProject.ThreadSafeObjectProvider(Of MyProject.MyWebServices)()

		' Token: 0x02000014 RID: 20
		<EditorBrowsable(EditorBrowsableState.Never)>
		Friend NotInheritable Class MyForms
			' Token: 0x06000371 RID: 881 RVA: 0x000202AC File Offset: 0x0001E4AC
			<DebuggerHidden()>
			Private Shared Function Create__Instance__(Of T As{Form, New})(Instance As T) As T
				If Instance Is Nothing OrElse Instance.IsDisposed Then
					If MyProject.MyForms.m_FormBeingCreated IsNot Nothing Then
						If MyProject.MyForms.m_FormBeingCreated.ContainsKey(GetType(T)) Then
							Throw New InvalidOperationException(Utils.GetResourceString("WinForms_RecursiveFormCreate", New String(-1) {}))
						End If
					Else
						MyProject.MyForms.m_FormBeingCreated = New Hashtable()
					End If
					MyProject.MyForms.m_FormBeingCreated.Add(GetType(T), Nothing)
					Try
						Return Activator.CreateInstance(Of T)()
					Catch ex As TargetInvocationException When ex.InnerException IsNot Nothing
						Throw New InvalidOperationException(Utils.GetResourceString("WinForms_SeeInnerException", New String() { ex.InnerException.Message }), ex.InnerException)
					Finally
						MyProject.MyForms.m_FormBeingCreated.Remove(GetType(T))
					End Try
				End If
				Return Instance
			End Function

			' Token: 0x06000372 RID: 882 RVA: 0x000203B0 File Offset: 0x0001E5B0
			<DebuggerHidden()>
			Private Sub Dispose__Instance__(Of T As Form)(ByRef instance As T)
				instance.Dispose()
				instance = Nothing
			End Sub

			' Token: 0x06000373 RID: 883 RVA: 0x0001C1E5 File Offset: 0x0001A3E5
			<DebuggerHidden()>
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public Sub New()
			End Sub

			' Token: 0x06000374 RID: 884 RVA: 0x000203C5 File Offset: 0x0001E5C5
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public Overrides Function Equals(o As Object) As Boolean
				Return MyBase.Equals(RuntimeHelpers.GetObjectValue(o))
			End Function

			' Token: 0x06000375 RID: 885 RVA: 0x000203D3 File Offset: 0x0001E5D3
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public Overrides Function GetHashCode() As Integer
				Return MyBase.GetHashCode()
			End Function

			' Token: 0x06000376 RID: 886 RVA: 0x000203DB File Offset: 0x0001E5DB
			<EditorBrowsable(EditorBrowsableState.Never)>
			Friend Function [GetType]() As Type
				Return GetType(MyProject.MyForms)
			End Function

			' Token: 0x06000377 RID: 887 RVA: 0x000203E7 File Offset: 0x0001E5E7
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public Overrides Function ToString() As String
				Return MyBase.ToString()
			End Function

			' Token: 0x17000153 RID: 339
			' (get) Token: 0x06000378 RID: 888 RVA: 0x000203EF File Offset: 0x0001E5EF
			' (set) Token: 0x0600037F RID: 895 RVA: 0x0002049E File Offset: 0x0001E69E
			Public Property FormPrincipale As FormPrincipale
				Get
					Me.m_FormPrincipale = MyProject.MyForms.Create__Instance__(Of FormPrincipale)(Me.m_FormPrincipale)
					Return Me.m_FormPrincipale
				End Get
				Set(value As FormPrincipale)
					If value IsNot Me.m_FormPrincipale Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of FormPrincipale)(Me.m_FormPrincipale)
					End If
				End Set
			End Property

			' Token: 0x17000154 RID: 340
			' (get) Token: 0x06000379 RID: 889 RVA: 0x00020408 File Offset: 0x0001E608
			' (set) Token: 0x06000380 RID: 896 RVA: 0x000204C3 File Offset: 0x0001E6C3
			Public Property frmCodeList As frmCodeList
				Get
					Me.m_frmCodeList = MyProject.MyForms.Create__Instance__(Of frmCodeList)(Me.m_frmCodeList)
					Return Me.m_frmCodeList
				End Get
				Set(value As frmCodeList)
					If value IsNot Me.m_frmCodeList Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmCodeList)(Me.m_frmCodeList)
					End If
				End Set
			End Property

			' Token: 0x17000155 RID: 341
			' (get) Token: 0x0600037A RID: 890 RVA: 0x00020421 File Offset: 0x0001E621
			' (set) Token: 0x06000381 RID: 897 RVA: 0x000204E8 File Offset: 0x0001E6E8
			Public Property frmEditCode As frmEditCode
				Get
					Me.m_frmEditCode = MyProject.MyForms.Create__Instance__(Of frmEditCode)(Me.m_frmEditCode)
					Return Me.m_frmEditCode
				End Get
				Set(value As frmEditCode)
					If value IsNot Me.m_frmEditCode Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmEditCode)(Me.m_frmEditCode)
					End If
				End Set
			End Property

			' Token: 0x17000156 RID: 342
			' (get) Token: 0x0600037B RID: 891 RVA: 0x0002043A File Offset: 0x0001E63A
			' (set) Token: 0x06000382 RID: 898 RVA: 0x0002050D File Offset: 0x0001E70D
			Public Property frmList As frmList
				Get
					Me.m_frmList = MyProject.MyForms.Create__Instance__(Of frmList)(Me.m_frmList)
					Return Me.m_frmList
				End Get
				Set(value As frmList)
					If value IsNot Me.m_frmList Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmList)(Me.m_frmList)
					End If
				End Set
			End Property

			' Token: 0x17000157 RID: 343
			' (get) Token: 0x0600037C RID: 892 RVA: 0x00020453 File Offset: 0x0001E653
			' (set) Token: 0x06000383 RID: 899 RVA: 0x00020532 File Offset: 0x0001E732
			Public Property FrmPrograms As FrmPrograms
				Get
					Me.m_FrmPrograms = MyProject.MyForms.Create__Instance__(Of FrmPrograms)(Me.m_FrmPrograms)
					Return Me.m_FrmPrograms
				End Get
				Set(value As FrmPrograms)
					If value IsNot Me.m_FrmPrograms Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of FrmPrograms)(Me.m_FrmPrograms)
					End If
				End Set
			End Property

			' Token: 0x17000158 RID: 344
			' (get) Token: 0x0600037D RID: 893 RVA: 0x0002046C File Offset: 0x0001E66C
			' (set) Token: 0x06000384 RID: 900 RVA: 0x00020557 File Offset: 0x0001E757
			Public Property frmTouchKey As frmTouchKey
				Get
					Me.m_frmTouchKey = MyProject.MyForms.Create__Instance__(Of frmTouchKey)(Me.m_frmTouchKey)
					Return Me.m_frmTouchKey
				End Get
				Set(value As frmTouchKey)
					If value IsNot Me.m_frmTouchKey Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmTouchKey)(Me.m_frmTouchKey)
					End If
				End Set
			End Property

			' Token: 0x17000159 RID: 345
			' (get) Token: 0x0600037E RID: 894 RVA: 0x00020485 File Offset: 0x0001E685
			' (set) Token: 0x06000385 RID: 901 RVA: 0x0002057C File Offset: 0x0001E77C
			Public Property frmTouchNum As frmTouchNum
				Get
					Me.m_frmTouchNum = MyProject.MyForms.Create__Instance__(Of frmTouchNum)(Me.m_frmTouchNum)
					Return Me.m_frmTouchNum
				End Get
				Set(value As frmTouchNum)
					If value IsNot Me.m_frmTouchNum Then
						If value IsNot Nothing Then
							Throw New ArgumentException("Property can only be set to Nothing")
						End If
						Me.Dispose__Instance__(Of frmTouchNum)(Me.m_frmTouchNum)
					End If
				End Set
			End Property

			' Token: 0x04000245 RID: 581
			<ThreadStatic()>
			Private Shared m_FormBeingCreated As Hashtable

			' Token: 0x04000246 RID: 582
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_FormPrincipale As FormPrincipale

			' Token: 0x04000247 RID: 583
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmCodeList As frmCodeList

			' Token: 0x04000248 RID: 584
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmEditCode As frmEditCode

			' Token: 0x04000249 RID: 585
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmList As frmList

			' Token: 0x0400024A RID: 586
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_FrmPrograms As FrmPrograms

			' Token: 0x0400024B RID: 587
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmTouchKey As frmTouchKey

			' Token: 0x0400024C RID: 588
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public m_frmTouchNum As frmTouchNum
		End Class

		' Token: 0x02000015 RID: 21
		<EditorBrowsable(EditorBrowsableState.Never)>
		<MyGroupCollection("System.Web.Services.Protocols.SoapHttpClientProtocol", "Create__Instance__", "Dispose__Instance__", "")>
		Friend NotInheritable Class MyWebServices
			' Token: 0x06000386 RID: 902 RVA: 0x000203C5 File Offset: 0x0001E5C5
			<EditorBrowsable(EditorBrowsableState.Never)>
			<DebuggerHidden()>
			Public Overrides Function Equals(o As Object) As Boolean
				Return MyBase.Equals(RuntimeHelpers.GetObjectValue(o))
			End Function

			' Token: 0x06000387 RID: 903 RVA: 0x000203D3 File Offset: 0x0001E5D3
			<EditorBrowsable(EditorBrowsableState.Never)>
			<DebuggerHidden()>
			Public Overrides Function GetHashCode() As Integer
				Return MyBase.GetHashCode()
			End Function

			' Token: 0x06000388 RID: 904 RVA: 0x000205A1 File Offset: 0x0001E7A1
			<EditorBrowsable(EditorBrowsableState.Never)>
			<DebuggerHidden()>
			Friend Function [GetType]() As Type
				Return GetType(MyProject.MyWebServices)
			End Function

			' Token: 0x06000389 RID: 905 RVA: 0x000203E7 File Offset: 0x0001E5E7
			<EditorBrowsable(EditorBrowsableState.Never)>
			<DebuggerHidden()>
			Public Overrides Function ToString() As String
				Return MyBase.ToString()
			End Function

			' Token: 0x0600038A RID: 906 RVA: 0x000205B0 File Offset: 0x0001E7B0
			<DebuggerHidden()>
			Private Shared Function Create__Instance__(Of T As New)(instance As T) As T
				Dim result As T
				If instance Is Nothing Then
					result = Activator.CreateInstance(Of T)()
				Else
					result = instance
				End If
				Return result
			End Function

			' Token: 0x0600038B RID: 907 RVA: 0x000205D0 File Offset: 0x0001E7D0
			<DebuggerHidden()>
			Private Sub Dispose__Instance__(Of T)(ByRef instance As T)
				instance = Nothing
			End Sub

			' Token: 0x0600038C RID: 908 RVA: 0x0001C1E5 File Offset: 0x0001A3E5
			<DebuggerHidden()>
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public Sub New()
			End Sub
		End Class

		' Token: 0x02000016 RID: 22
		<EditorBrowsable(EditorBrowsableState.Never)>
		<ComVisible(False)>
		Friend NotInheritable Class ThreadSafeObjectProvider(Of T As New)
			' Token: 0x1700015A RID: 346
			' (get) Token: 0x0600038D RID: 909 RVA: 0x000205D9 File Offset: 0x0001E7D9
			Friend ReadOnly Property GetInstance As T
				<DebuggerHidden()>
				Get
					If MyProject.ThreadSafeObjectProvider(Of T).m_ThreadStaticValue Is Nothing Then
						MyProject.ThreadSafeObjectProvider(Of T).m_ThreadStaticValue = Activator.CreateInstance(Of T)()
					End If
					Return MyProject.ThreadSafeObjectProvider(Of T).m_ThreadStaticValue
				End Get
			End Property

			' Token: 0x0600038E RID: 910 RVA: 0x0001C1E5 File Offset: 0x0001A3E5
			<DebuggerHidden()>
			<EditorBrowsable(EditorBrowsableState.Never)>
			Public Sub New()
			End Sub

			' Token: 0x0400024D RID: 589
			<CompilerGenerated()>
			<ThreadStatic()>
			Private Shared m_ThreadStaticValue As T
		End Class
	End Module
End Namespace
