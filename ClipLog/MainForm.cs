using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Text;

namespace ClipLog
{
	public partial class MainForm : Form
	{
		/// <summary>
		/// Places the given window in the system-maintained clipboard format listener list.
		/// </summary>
		[DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
	    [return: MarshalAs(UnmanagedType.Bool)]
	    private static extern bool AddClipboardFormatListener(IntPtr hwnd);
		 
		/// <summary>
		/// Removes the given window from the system-maintained clipboard format listener list.
		/// </summary>
	    [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
	    [return: MarshalAs(UnmanagedType.Bool)]
	    private static extern bool RemoveClipboardFormatListener(IntPtr hwnd);
		 
		/// <summary>
		/// Sent when the contents of the clipboard have changed.
		/// </summary>
		private const int WM_CLIPBOARDUPDATE = 0x031D;
		
		private System.IO.StreamWriter m_logwriter;
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			// init file logging
			m_logwriter = new System.IO.StreamWriter("ClipLog - " + DateTime.Now.ToString("yyyy.MM.dd - ") + DateTime.Now.ToString("HH.mm.ss") + ".txt", true, Encoding.Unicode);
			this.FormClosing += OnFormClosing;
			bool b = AddClipboardFormatListener(this.Handle);
		}

		
		protected override void WndProc(ref Message m)
		{
			base.WndProc(ref m);
	 
	        if (m.Msg == WM_CLIPBOARDUPDATE)
	        {
	            IDataObject iData = Clipboard.GetDataObject();
	            if (iData.GetDataPresent(DataFormats.StringFormat))
	            {
	                string cliptext = iData.GetData(DataFormats.StringFormat).ToString();
	                m_logwriter.WriteLine(cliptext);
	                m_logwriter.Flush();
	            }
	        }			
		}

		
		private void OnFormClosing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			bool b = RemoveClipboardFormatListener(this.Handle);
			m_logwriter.Close();
		}
		
	}
}
