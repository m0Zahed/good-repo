Namespace Terminale
	' Token: 0x02000008 RID: 8
	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
	Public Partial Class frmCodeList
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x0600001C RID: 28 RVA: 0x0000232C File Offset: 0x0000052C
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

		' Token: 0x0600001D RID: 29 RVA: 0x0000236C File Offset: 0x0000056C
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.btn_code_list_ok = New Global.System.Windows.Forms.Button()
			Me.btn_code_list_cancel = New Global.System.Windows.Forms.Button()
			Me.dgv_code_prg_list = New Global.System.Windows.Forms.DataGridView()
			Me.lbl_code_selected = New Global.System.Windows.Forms.Label()
			Me.DataGridViewTextBoxColumn8 = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Batch = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.Opt = New Global.System.Windows.Forms.DataGridViewTextBoxColumn()
			CType(Me.dgv_code_prg_list, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			MyBase.SuspendLayout()
			Me.btn_code_list_ok.Location = New Global.System.Drawing.Point(283, 383)
			Me.btn_code_list_ok.Name = "btn_code_list_ok"
			Me.btn_code_list_ok.Size = New Global.System.Drawing.Size(73, 36)
			Me.btn_code_list_ok.TabIndex = 0
			Me.btn_code_list_ok.Text = "OK"
			Me.btn_code_list_ok.UseVisualStyleBackColor = True
			Me.btn_code_list_cancel.Location = New Global.System.Drawing.Point(376, 383)
			Me.btn_code_list_cancel.Name = "btn_code_list_cancel"
			Me.btn_code_list_cancel.Size = New Global.System.Drawing.Size(73, 36)
			Me.btn_code_list_cancel.TabIndex = 1
			Me.btn_code_list_cancel.Text = "Cancel"
			Me.btn_code_list_cancel.UseVisualStyleBackColor = True
			Me.dgv_code_prg_list.AllowUserToAddRows = False
			Me.dgv_code_prg_list.AllowUserToDeleteRows = False
			Me.dgv_code_prg_list.AllowUserToResizeColumns = False
			Me.dgv_code_prg_list.AllowUserToResizeRows = False
			Me.dgv_code_prg_list.ColumnHeadersHeightSizeMode = Global.System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
			Me.dgv_code_prg_list.Columns.AddRange(New Global.System.Windows.Forms.DataGridViewColumn() { Me.DataGridViewTextBoxColumn8, Me.Batch, Me.Opt })
			Me.dgv_code_prg_list.Location = New Global.System.Drawing.Point(21, 24)
			Me.dgv_code_prg_list.MultiSelect = False
			Me.dgv_code_prg_list.Name = "dgv_code_prg_list"
			Me.dgv_code_prg_list.[ReadOnly] = True
			Me.dgv_code_prg_list.Size = New Global.System.Drawing.Size(428, 325)
			Me.dgv_code_prg_list.TabIndex = 82
			Me.lbl_code_selected.BackColor = Global.System.Drawing.Color.White
			Me.lbl_code_selected.BorderStyle = Global.System.Windows.Forms.BorderStyle.Fixed3D
			Me.lbl_code_selected.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.5F, Global.System.Drawing.FontStyle.Bold)
			Me.lbl_code_selected.Location = New Global.System.Drawing.Point(21, 383)
			Me.lbl_code_selected.Name = "lbl_code_selected"
			Me.lbl_code_selected.Size = New Global.System.Drawing.Size(157, 28)
			Me.lbl_code_selected.TabIndex = 323
			Me.lbl_code_selected.TextAlign = Global.System.Drawing.ContentAlignment.MiddleCenter
			Me.DataGridViewTextBoxColumn8.HeaderText = "Program name"
			Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
			Me.DataGridViewTextBoxColumn8.[ReadOnly] = True
			Me.DataGridViewTextBoxColumn8.Width = 180
			Me.Batch.HeaderText = "Batch"
			Me.Batch.Name = "Batch"
			Me.Batch.[ReadOnly] = True
			Me.Opt.HeaderText = "Opt"
			Me.Opt.Name = "Opt"
			Me.Opt.[ReadOnly] = True
			MyBase.AutoScaleDimensions = New Global.System.Drawing.SizeF(6F, 13F)
			MyBase.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			MyBase.ClientSize = New Global.System.Drawing.Size(472, 431)
			MyBase.Controls.Add(Me.lbl_code_selected)
			MyBase.Controls.Add(Me.dgv_code_prg_list)
			MyBase.Controls.Add(Me.btn_code_list_cancel)
			MyBase.Controls.Add(Me.btn_code_list_ok)
			MyBase.Name = "frmCodeList"
			Me.Text = "CodeList"
			CType(Me.dgv_code_prg_list, Global.System.ComponentModel.ISupportInitialize).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		' Token: 0x0400000B RID: 11
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
