using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Text;
using Microsoft.Win32;

namespace ClipLog
{
	public partial class MainForm : Form
	{
		private const string APPTITLE = "ClipLog";
		private const string APPREGKEY = @"SOFTWARE\T800 Productions\" + APPTITLE;
		private const string APPREGVAL = "outputFolder";
		private const string APPREGAPPPATHS = @"Software\Microsoft\Windows\CurrentVersion\App Paths\";

		[DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
	    [return: MarshalAs(UnmanagedType.Bool)]
	    private static extern bool AddClipboardFormatListener(IntPtr hwnd);
		
	    [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
	    [return: MarshalAs(UnmanagedType.Bool)]
	    private static extern bool RemoveClipboardFormatListener(IntPtr hwnd);
		
		private const int WM_CLIPBOARDUPDATE = 0x031D;
		
		private String m_path;
		private System.IO.StreamWriter m_writer;
		private Boolean m_dirty;
		
		public MainForm()
		{
			InitializeComponent();
			
			//register app path for easy use
			try
			{
				RegistryKey rk = Registry.CurrentUser.CreateSubKey(APPREGAPPPATHS + System.IO.Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().Location));
				rk.SetValue("", System.Reflection.Assembly.GetExecutingAssembly().Location);
			}
			catch (Exception)
			{  
				//MessageBox.Show("Error: " + ex.Message);
			}
			
			//init output location
			textBoxLogFolder.Text = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
			
			//load output location setting
			try
			{
				RegistryKey rk = Registry.CurrentUser.OpenSubKey(APPREGKEY);  
				if (null != rk) { textBoxLogFolder.Text = rk.GetValue(APPREGVAL).ToString(); }
			}
			catch (Exception)
	        {  
	            //MessageBox.Show("Error: " + ex.Message);
	        }
			
			//TODO optional header and footer for each logged item
			// opt load from files or in-app setting
			// checkbox for each one and path setting for each one
			// maybe item counter (replace m_dirty) and timestamp in header/footer using string format specifiers
			
			// init file logging
			m_dirty = false;
			m_path = textBoxLogFolder.Text + "\\ClipLog - " + DateTime.Now.ToString("yyyy.MM.dd - ") + DateTime.Now.ToString("HH.mm.ss") + ".txt";
			m_writer = new StreamWriter(m_path, true, Encoding.Unicode);
			m_writer.AutoFlush = true;
			bool b = AddClipboardFormatListener(this.Handle);
			buttonPauseContinue.Text = "PAUSE";
			this.FormClosing += OnFormClosing;
		}

		protected override void WndProc(ref Message m)
		{
	        if ((m.Msg == WM_CLIPBOARDUPDATE) && String.Equals(buttonPauseContinue.Text, "PAUSE"))
	        {
				try
				{      	
		            IDataObject iData = Clipboard.GetDataObject();
		            if (iData.GetDataPresent(DataFormats.StringFormat))
		            {
		                string cliptext = iData.GetData(DataFormats.StringFormat).ToString();
		                if (null != m_writer) { m_writer.WriteLine(cliptext); }
		                m_dirty = true;
		            }         
				}
				catch
				{
				    // ignore transient clipboard errors
				}	
	        }
	        base.WndProc(ref m);
		}
		
		void ButtonSelectFolder_Click(object sender, System.EventArgs e)
		{
			FolderBrowserDialog fbr = new FolderBrowserDialog();
			fbr.ShowNewFolderButton = false;
			fbr.RootFolder = Environment.SpecialFolder.Desktop; //or MyComputer; //<<needed for SelectedPath to work
//TODO test on win7 and win10 if appending "\" helps to force scroll dialog to selected folder (doesn't work always)
			fbr.SelectedPath = textBoxLogFolder.Text + "\\";
			if (fbr.ShowDialog() == DialogResult.OK)
			{
				//message loop is running while select folder dialog is open -> log is active
			  	if (!String.Equals(fbr.SelectedPath, textBoxLogFolder.Text)) 
			  	{
	 				//update display
				    textBoxLogFolder.Text = fbr.SelectedPath;

					//save setting
					try
					{
						RegistryKey rk = Registry.CurrentUser.CreateSubKey(APPREGKEY);
						rk.SetValue(APPREGVAL, textBoxLogFolder.Text);
					}
					catch (Exception)
			        {  
			            //MessageBox.Show("Error: " + ex.Message);
			        }					
	
			  		if (m_dirty)
			  		{
			  			MessageBox.Show("New save location will be used on next run", APPTITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
			  		}
			  		else
			  		{
						//close log
						m_writer.Close();
						m_writer.Dispose();
						m_writer = null;
						
						//remove empty file
						File.Delete(m_path);
						
						//open new log
						m_dirty = false;
						m_path = textBoxLogFolder.Text + "\\ClipLog - " + DateTime.Now.ToString("yyyy.MM.dd - ") + DateTime.Now.ToString("HH.mm.ss") + ".txt";
						m_writer = new StreamWriter(m_path, true, Encoding.Unicode);
						m_writer.AutoFlush = true;
			  		}
				}
			}
		}
		
		private void OnFormClosing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			bool b = RemoveClipboardFormatListener(this.Handle);
			m_writer.Close();
			
			if (m_dirty)
			{
				if (this.checkBoxOpenLogOnExit.Checked) { Process.Start(m_path); }
			}
			else
			{
				//remove empty file
				File.Delete(m_path);			
			}
		}		
		
		void ButtonOpenFolder_Click(object sender, EventArgs e)
		{
			Process.Start(textBoxLogFolder.Text);			
		}
		
		void buttonPauseContinue_Click(object sender, EventArgs e)
		{
			if (String.Equals(buttonPauseContinue.Text, "CONTINUE")) { buttonPauseContinue.Text = "PAUSE"; }
			else { buttonPauseContinue.Text = "CONTINUE"; }
		}
	}
}
