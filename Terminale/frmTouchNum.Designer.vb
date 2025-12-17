Namespace Terminale
	' Token: 0x0200000E RID: 14
	Public Partial Class frmTouchNum
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x060002DA RID: 730 RVA: 0x0001BB28 File Offset: 0x00019D28
		Protected Overrides Sub Dispose(disposing As Boolean)
			If disposing AndAlso Me.components IsNot Nothing Then
				Me.components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		' Token: 0x060002E1 RID: 737 RVA: 0x0001BBF0 File Offset: 0x00019DF0
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.Terminale.frmTouchNum))
			Me.btn_ok = New Global.System.Windows.Forms.Button()
			Me.btn_cancel = New Global.System.Windows.Forms.Button()
			Me.UcTouchNum = New Global.Terminale.ucTouchNum()
			MyBase.SuspendLayout()
			Me.btn_ok.Image = CType(componentResourceManager.GetObject("btn_ok.Image"), Global.System.Drawing.Image)
			Me.btn_ok.Location = New Global.System.Drawing.Point(8, 256)
			Me.btn_ok.Name = "btn_ok"
			Me.btn_ok.Size = New Global.System.Drawing.Size(64, 40)
			Me.btn_ok.TabIndex = 1
			Me.btn_cancel.Image = CType(componentResourceManager.GetObject("btn_cancel.Image"), Global.System.Drawing.Image)
			Me.btn_cancel.Location = New Global.System.Drawing.Point(104, 256)
			Me.btn_cancel.Name = "btn_cancel"
			Me.btn_cancel.Size = New Global.System.Drawing.Size(64, 40)
			Me.btn_cancel.TabIndex = 2
			Me.UcTouchNum.Location = New Global.System.Drawing.Point(0, 0)
			Me.UcTouchNum.Name = "UcTouchNum"
			Me.UcTouchNum.NumValue = ""
			Me.UcTouchNum.Size = New Global.System.Drawing.Size(176, 248)
			Me.UcTouchNum.TabIndex = 3
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.None
			MyBase.ClientSize = New Global.System.Drawing.Size(184, 301)
			MyBase.ControlBox = False
			MyBase.Controls.Add(Me.UcTouchNum)
			MyBase.Controls.Add(Me.btn_cancel)
			MyBase.Controls.Add(Me.btn_ok)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedDialog
			MyBase.KeyPreview = True
			MyBase.Name = "frmTouchNum"
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "TouchNum"
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x040001F4 RID: 500
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
