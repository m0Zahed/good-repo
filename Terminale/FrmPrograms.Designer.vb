Namespace Terminale
	' Token: 0x0200000B RID: 11
	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
	Public Partial Class FrmPrograms
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600028D RID: 653 RVA: 0x00019CA4 File Offset: 0x00017EA4
		<Global.System.Diagnostics.DebuggerNonUserCode()>
		Protected Overrides Sub Dispose(disposing As Boolean)
			Try
				If disposing AndAlso Me.components IsNot Nothing Then
					Me.components.Dispose()
				End If
			Finally
				MyBase.Dispose(disposing)
			End Try
		End Sub

		' Token: 0x0600028E RID: 654 RVA: 0x00019CE4 File Offset: 0x00017EE4
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Dim componentResourceManager As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.Terminale.FrmPrograms))
			Me.LsbPrograms = New Global.System.Windows.Forms.ListBox()
			Me.btnCancel = New Global.System.Windows.Forms.Button()
			Me.btnOk = New Global.System.Windows.Forms.Button()
			MyBase.SuspendLayout()
			Me.LsbPrograms.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.LsbPrograms.FormattingEnabled = True
			Me.LsbPrograms.ItemHeight = 20
			Me.LsbPrograms.Location = New Global.System.Drawing.Point(9, 12)
			Me.LsbPrograms.Name = "LsbPrograms"
			Me.LsbPrograms.Size = New Global.System.Drawing.Size(225, 524)
			Me.LsbPrograms.TabIndex = 1
			Me.btnCancel.Image = CType(componentResourceManager.GetObject("btnCancel.Image"), Global.System.Drawing.Image)
			Me.btnCancel.Location = New Global.System.Drawing.Point(142, 554)
			Me.btnCancel.Name = "btnCancel"
			Me.btnCancel.Size = New Global.System.Drawing.Size(92, 48)
			Me.btnCancel.TabIndex = 3
			Me.btnCancel.UseVisualStyleBackColor = True
			Me.btnOk.Image = CType(componentResourceManager.GetObject("btnOk.Image"), Global.System.Drawing.Image)
			Me.btnOk.Location = New Global.System.Drawing.Point(8, 554)
			Me.btnOk.Name = "btnOk"
			Me.btnOk.Size = New Global.System.Drawing.Size(92, 48)
			Me.btnOk.TabIndex = 2
			Me.btnOk.UseVisualStyleBackColor = True
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(244, 612)
			MyBase.ControlBox = False
			MyBase.Controls.Add(Me.btnCancel)
			MyBase.Controls.Add(Me.btnOk)
			MyBase.Controls.Add(Me.LsbPrograms)
			MyBase.Name = "FrmPrograms"
			MyBase.SizeGripStyle = Global.System.Windows.Forms.SizeGripStyle.Hide
			MyBase.StartPosition = Global.System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "Programs"
			MyBase.TopMost = True
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x040001C9 RID: 457
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
