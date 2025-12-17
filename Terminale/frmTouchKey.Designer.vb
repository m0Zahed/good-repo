Namespace Terminale
	' Token: 0x0200000D RID: 13
	Public Partial Class frmTouchKey
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x060002CC RID: 716 RVA: 0x0001B4D7 File Offset: 0x000196D7
		Protected Overrides Sub Dispose(disposing As Boolean)
			If disposing AndAlso Me.components IsNot Nothing Then
				Me.components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		' Token: 0x060002D3 RID: 723 RVA: 0x0001B5A0 File Offset: 0x000197A0
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.Terminale.frmTouchKey))
			Me.btnCancel = New Global.System.Windows.Forms.Button()
			Me.btnOk = New Global.System.Windows.Forms.Button()
			Me.UcTouchKey = New Global.Terminale.ucTouchKey()
			MyBase.SuspendLayout()
			Me.btnCancel.Image = CType(componentResourceManager.GetObject("btnCancel.Image"), Global.System.Drawing.Image)
			Me.btnCancel.Location = New Global.System.Drawing.Point(329, 258)
			Me.btnCancel.Name = "btnCancel"
			Me.btnCancel.Size = New Global.System.Drawing.Size(291, 48)
			Me.btnCancel.TabIndex = 2
			Me.btnCancel.TabStop = False
			Me.btnOk.Image = CType(componentResourceManager.GetObject("btnOk.Image"), Global.System.Drawing.Image)
			Me.btnOk.Location = New Global.System.Drawing.Point(7, 258)
			Me.btnOk.Name = "btnOk"
			Me.btnOk.Size = New Global.System.Drawing.Size(294, 48)
			Me.btnOk.TabIndex = 1
			Me.btnOk.TabStop = False
			Me.UcTouchKey.KeyMode = 0
			Me.UcTouchKey.KeyText = ""
			Me.UcTouchKey.Location = New Global.System.Drawing.Point(8, 1)
			Me.UcTouchKey.Name = "UcTouchKey"
			Me.UcTouchKey.Size = New Global.System.Drawing.Size(619, 258)
			Me.UcTouchKey.TabIndex = 3
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.None
			MyBase.ClientSize = New Global.System.Drawing.Size(632, 312)
			MyBase.ControlBox = False
			MyBase.Controls.Add(Me.UcTouchKey)
			MyBase.Controls.Add(Me.btnOk)
			MyBase.Controls.Add(Me.btnCancel)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedToolWindow
			MyBase.KeyPreview = True
			MyBase.Name = "frmTouchKey"
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "TouchKeyboard"
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x040001EC RID: 492
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
