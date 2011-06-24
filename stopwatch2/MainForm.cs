/*
 * Created by SharpDevelop.
 * User: Maxwell
 * Date: 2011.03.12.
 * Time: 23:07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Text;

//..

namespace stopwatch2
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//	
		}
		
		//ez itt egy hozzáadott sor
		void Button1Click(object sender, EventArgs e)
		{
			if (button1.Text == ">") {
				STW.Start();
				button1.Text = "||";
			}
			else if(button1.Text == "||")
			{
			    STW.Stop();
			    button1.Text = ">";
			}
			
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			STW.Reset();
			button1.Text = ">";
			time3 = STW.Elapsed;
			time2 = STW.Elapsed;
		}
		
		void Timer1Tick(object sender, EventArgs e)
		{
			time1 = STW.Elapsed;
			time2 = time1 - time3;
			label1.Text = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            time1.Hours, time1.Minutes, time1.Seconds,
            time1.Milliseconds / 10);
			//
			label2.Text = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            time2.Hours, time2.Minutes, time2.Seconds,
            time2.Milliseconds / 10);
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			textBox1.Text += label1.Text;
			textBox1.Text += String.Format("\r\n");
			time3 = STW.Elapsed;
		}
		
		void AboutToolStripMenuItemClick(object sender, EventArgs e)
		{
			MessageBox.Show("This is a Free software.\nCreated by SharpDevelop\nDeveloper: Szőke Zoltán\nContact & Feedback: maxwell.hun@gmail.com\n\nVersion: 0.2b","About");
		}
		
		void ExitToolStripMenuItemClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void Button4Click(object sender, EventArgs e)
		{
			textBox1.ResetText();
		}
		
		void SaveToolStripMenuItemClick(object sender, EventArgs e)
		{
			Stream myStream ;
			SaveFileDialog saveFileDialog1 = new SaveFileDialog();
			
			saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"  ;
			saveFileDialog1.FilterIndex = 1 ;
			saveFileDialog1.RestoreDirectory = true ;
			
			if(saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				if((myStream = saveFileDialog1.OpenFile()) != null)
				{
					// Code to write the stream goes here.
						StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.UTF8);
						sw.Write(textBox1.Text);
						sw.Close();
					// Code to write the stream goes here. (end)
					myStream.Close();
				}
			}	
		}
	}
}
