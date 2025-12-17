Imports System
Imports System.CodeDom.Compiler
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Globalization
Imports System.Resources
Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace Terminale.My.Resources
	''' <summary>
	'''   Classe di risorse fortemente tipizzata per la ricerca di stringhe localizzate e così via.
	''' </summary>
	' Token: 0x02000005 RID: 5
	<GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")>
	<DebuggerNonUserCode()>
	<CompilerGenerated()>
	<HideModuleName()>
	Friend Module Resources
		''' <summary>
		'''   Restituisce l'istanza di ResourceManager nella cache utilizzata da questa classe.
		''' </summary>
		' Token: 0x17000006 RID: 6
		' (get) Token: 0x0600000B RID: 11 RVA: 0x00002116 File Offset: 0x00000316
		<EditorBrowsable(EditorBrowsableState.Advanced)>
		Friend ReadOnly Property ResourceManager As ResourceManager
			Get
				If Object.ReferenceEquals(Resources.resourceMan, Nothing) Then
					Resources.resourceMan = New ResourceManager("Terminale.Resources", GetType(Resources).Assembly)
				End If
				Return Resources.resourceMan
			End Get
		End Property

		''' <summary>
		'''   Esegue l'override della proprietà CurrentUICulture del thread corrente per tutte le
		'''   ricerche di risorse eseguite utilizzando questa classe di risorse fortemente tipizzata.
		''' </summary>
		' Token: 0x17000007 RID: 7
		' (get) Token: 0x0600000C RID: 12 RVA: 0x00002148 File Offset: 0x00000348
		' (set) Token: 0x0600000D RID: 13 RVA: 0x0000214F File Offset: 0x0000034F
		<EditorBrowsable(EditorBrowsableState.Advanced)>
		Friend Property Culture As CultureInfo
			Get
				Return Resources.resourceCulture
			End Get
			Set(value As CultureInfo)
				Resources.resourceCulture = value
			End Set
		End Property

		''' <summary>
		'''   Cerca una risorsa localizzata di tipo System.Drawing.Bitmap.
		''' </summary>
		' Token: 0x17000008 RID: 8
		' (get) Token: 0x0600000E RID: 14 RVA: 0x00002157 File Offset: 0x00000357
		Friend ReadOnly Property _13458_Layout_Spruzzatura_Vasche_Piscine_Piccole As Bitmap
			Get
				Return CType(RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("13458 Layout Spruzzatura Vasche Piscine Piccole", Resources.resourceCulture)), Bitmap)
			End Get
		End Property

		''' <summary>
		'''   Cerca una risorsa localizzata di tipo System.Drawing.Bitmap.
		''' </summary>
		' Token: 0x17000009 RID: 9
		' (get) Token: 0x0600000F RID: 15 RVA: 0x00002177 File Offset: 0x00000377
		Friend ReadOnly Property _6100_2 As Bitmap
			Get
				Return CType(RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("6100_2", Resources.resourceCulture)), Bitmap)
			End Get
		End Property

		''' <summary>
		'''   Cerca una risorsa localizzata di tipo System.Drawing.Bitmap.
		''' </summary>
		' Token: 0x1700000A RID: 10
		' (get) Token: 0x06000010 RID: 16 RVA: 0x00002197 File Offset: 0x00000397
		Friend ReadOnly Property Sin1 As Bitmap
			Get
				Return CType(RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Sin1", Resources.resourceCulture)), Bitmap)
			End Get
		End Property

		''' <summary>
		'''   Cerca una risorsa localizzata di tipo System.Drawing.Bitmap.
		''' </summary>
		' Token: 0x1700000B RID: 11
		' (get) Token: 0x06000011 RID: 17 RVA: 0x000021B7 File Offset: 0x000003B7
		Friend ReadOnly Property Sin2 As Bitmap
			Get
				Return CType(RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Sin2", Resources.resourceCulture)), Bitmap)
			End Get
		End Property

		''' <summary>
		'''   Cerca una risorsa localizzata di tipo System.Drawing.Bitmap.
		''' </summary>
		' Token: 0x1700000C RID: 12
		' (get) Token: 0x06000012 RID: 18 RVA: 0x000021D7 File Offset: 0x000003D7
		Friend ReadOnly Property sin3 As Bitmap
			Get
				Return CType(RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("sin3", Resources.resourceCulture)), Bitmap)
			End Get
		End Property

		''' <summary>
		'''   Cerca una risorsa localizzata di tipo System.Drawing.Bitmap.
		''' </summary>
		' Token: 0x1700000D RID: 13
		' (get) Token: 0x06000013 RID: 19 RVA: 0x000021F7 File Offset: 0x000003F7
		Friend ReadOnly Property sin4 As Bitmap
			Get
				Return CType(RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("sin4", Resources.resourceCulture)), Bitmap)
			End Get
		End Property

		''' <summary>
		'''   Cerca una risorsa localizzata di tipo System.Drawing.Bitmap.
		''' </summary>
		' Token: 0x1700000E RID: 14
		' (get) Token: 0x06000014 RID: 20 RVA: 0x00002217 File Offset: 0x00000417
		Friend ReadOnly Property Tasca1 As Bitmap
			Get
				Return CType(RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Tasca1", Resources.resourceCulture)), Bitmap)
			End Get
		End Property

		''' <summary>
		'''   Cerca una risorsa localizzata di tipo System.Drawing.Bitmap.
		''' </summary>
		' Token: 0x1700000F RID: 15
		' (get) Token: 0x06000015 RID: 21 RVA: 0x00002237 File Offset: 0x00000437
		Friend ReadOnly Property Tasca2 As Bitmap
			Get
				Return CType(RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("Tasca2", Resources.resourceCulture)), Bitmap)
			End Get
		End Property

		' Token: 0x04000006 RID: 6
		Private resourceMan As ResourceManager

		' Token: 0x04000007 RID: 7
		Private resourceCulture As CultureInfo
	End Module
End Namespace
