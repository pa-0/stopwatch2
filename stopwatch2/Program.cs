﻿/*
 * Created by SharpDevelop.
 * User: Maxwell
 * Date: 2011.03.12.
 * Time: 23:07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace stopwatch2
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
		
	}
	
}
