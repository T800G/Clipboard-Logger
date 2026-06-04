/*
 * Created by SharpDevelop.
 * User: T800
 * Date: 19.11.2023.
 * Time: 13:34
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ClipLog
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.checkBoxOpenLogOnExit = new System.Windows.Forms.CheckBox();
			this.textBoxLogFolder = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.buttonSelectFolder = new System.Windows.Forms.Button();
			this.buttonOpenFolder = new System.Windows.Forms.Button();
			this.buttonPauseContinue = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// checkBoxOpenLogOnExit
			// 
			this.checkBoxOpenLogOnExit.Checked = true;
			this.checkBoxOpenLogOnExit.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxOpenLogOnExit.Location = new System.Drawing.Point(372, 125);
			this.checkBoxOpenLogOnExit.Name = "checkBoxOpenLogOnExit";
			this.checkBoxOpenLogOnExit.Size = new System.Drawing.Size(150, 24);
			this.checkBoxOpenLogOnExit.TabIndex = 1;
			this.checkBoxOpenLogOnExit.Text = "Open log on exit";
			this.checkBoxOpenLogOnExit.UseVisualStyleBackColor = true;
			// 
			// textBoxLogFolder
			// 
			this.textBoxLogFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.textBoxLogFolder.Location = new System.Drawing.Point(12, 35);
			this.textBoxLogFolder.Name = "textBoxLogFolder";
			this.textBoxLogFolder.ReadOnly = true;
			this.textBoxLogFolder.Size = new System.Drawing.Size(510, 24);
			this.textBoxLogFolder.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(150, 24);
			this.label1.TabIndex = 3;
			this.label1.Text = "Save log to folder:";
			// 
			// buttonSelectFolder
			// 
			this.buttonSelectFolder.Location = new System.Drawing.Point(402, 65);
			this.buttonSelectFolder.Name = "buttonSelectFolder";
			this.buttonSelectFolder.Size = new System.Drawing.Size(120, 26);
			this.buttonSelectFolder.TabIndex = 0;
			this.buttonSelectFolder.Text = "Select folder...";
			this.buttonSelectFolder.UseVisualStyleBackColor = true;
			this.buttonSelectFolder.Click += new System.EventHandler(this.ButtonSelectFolder_Click);
			// 
			// buttonOpenFolder
			// 
			this.buttonOpenFolder.Location = new System.Drawing.Point(12, 65);
			this.buttonOpenFolder.Name = "buttonOpenFolder";
			this.buttonOpenFolder.Size = new System.Drawing.Size(120, 26);
			this.buttonOpenFolder.TabIndex = 4;
			this.buttonOpenFolder.Text = "Open folder";
			this.buttonOpenFolder.UseVisualStyleBackColor = true;
			this.buttonOpenFolder.Click += new System.EventHandler(this.ButtonOpenFolder_Click);
			// 
			// buttonPauseContinue
			// 
			this.buttonPauseContinue.Location = new System.Drawing.Point(13, 123);
			this.buttonPauseContinue.Name = "buttonPauseContinue";
			this.buttonPauseContinue.Size = new System.Drawing.Size(119, 26);
			this.buttonPauseContinue.TabIndex = 5;
			this.buttonPauseContinue.Text = "Pause";
			this.buttonPauseContinue.UseVisualStyleBackColor = true;
			this.buttonPauseContinue.Click += new System.EventHandler(this.buttonPauseContinue_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(534, 169);
			this.Controls.Add(this.buttonPauseContinue);
			this.Controls.Add(this.buttonOpenFolder);
			this.Controls.Add(this.buttonSelectFolder);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBoxLogFolder);
			this.Controls.Add(this.checkBoxOpenLogOnExit);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Clipboard Logger";
			this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button buttonPauseContinue;
		private System.Windows.Forms.Button buttonOpenFolder;
		private System.Windows.Forms.Button buttonSelectFolder;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxLogFolder;
		private System.Windows.Forms.CheckBox checkBoxOpenLogOnExit;		
		

	}
}
