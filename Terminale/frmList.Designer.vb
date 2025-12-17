Namespace Terminale
	' Token: 0x0200000A RID: 10
	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
	Public Partial Class frmList
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06000280 RID: 640 RVA: 0x00019854 File Offset: 0x00017A54
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

		' Token: 0x06000281 RID: 641 RVA: 0x00019894 File Offset: 0x00017A94
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.lb_auto = New Global.System.Windows.Forms.ListBox()
			Me.btn_ok = New Global.System.Windows.Forms.Button()
			Me.btn_cancel = New Global.System.Windows.Forms.Button()
			MyBase.SuspendLayout()
			Me.lb_auto.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 14.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lb_auto.FormattingEnabled = True
			Me.lb_auto.ItemHeight = 24
			Me.lb_auto.Location = New Global.System.Drawing.Point(12, 12)
			Me.lb_auto.Name = "lb_auto"
			Me.lb_auto.Size = New Global.System.Drawing.Size(246, 364)
			Me.lb_auto.Sorted = True
			Me.lb_auto.TabIndex = 59
			Me.btn_ok.Location = New Global.System.Drawing.Point(12, 382)
			Me.btn_ok.Name = "btn_ok"
			Me.btn_ok.Size = New Global.System.Drawing.Size(120, 42)
			Me.btn_ok.TabIndex = 60
			Me.btn_ok.Text = "Ok"
			Me.btn_ok.UseVisualStyleBackColor = True
			Me.btn_cancel.Location = New Global.System.Drawing.Point(138, 382)
			Me.btn_cancel.Name = "btn_cancel"
			Me.btn_cancel.Size = New Global.System.Drawing.Size(120, 42)
			Me.btn_cancel.TabIndex = 61
			Me.btn_cancel.Text = "Annulla"
			Me.btn_cancel.UseVisualStyleBackColor = True
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(267, 431)
			MyBase.Controls.Add(Me.btn_cancel)
			MyBase.Controls.Add(Me.btn_ok)
			MyBase.Controls.Add(Me.lb_auto)
			MyBase.FormBorderStyle = Global.System.Windows.Forms.FormBorderStyle.FixedToolWindow
			MyBase.Name = "frmList"
			Me.Text = "frmSelCode"
			MyBase.TopMost = True
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x040001C3 RID: 451
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
