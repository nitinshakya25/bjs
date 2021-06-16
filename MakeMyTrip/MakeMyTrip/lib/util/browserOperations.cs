/*
 * Created by Ranorex
 * User: nitinshak
 * Date: 6/13/2021
 * Time: 6:35 PM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

using WinForms = System.Windows.Forms;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace MakeMyTrip.lib.util
{
    /// <summary>
    /// Description of browserOperations.
    /// </summary>
    [TestModule("E34F0B1E-D454-418C-A01F-D6556B52C417", ModuleType.UserCode, 1)]
    public class browserOperations : ITestModule
    {
    	MakeMyTrip.MakeMyTripRepository repo = MakeMyTrip.MakeMyTripRepository.Instance;
		
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public browserOperations()
        {
            // Do not delete - a parameterless constructor is required!
        }

        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
        }
        
        
        string _varURL = "";
        [TestVariable("2385c09c-f273-48a9-a8e0-295244971b48")]
        public string varURL
        {
        	get { return _varURL; }
        	set { _varURL = value; }
        }
        
        bool _isSessionToBeKilled = false;
        [TestVariable("18f76d60-5956-4d04-9c3d-a0fa354f1836")]
        public bool isSessionToBeKilled
        {
        	get { return _isSessionToBeKilled; }
        	set { _isSessionToBeKilled = value; }
        }
        
        
        string _varBrowserName = "";
        [TestVariable("0de53e49-9a96-465e-b80a-733fd694a8f7")]
        public string varBrowserName
        {
        	get { return _varBrowserName; }
        	set { _varBrowserName = value; }
        }
        
        public void LaunchURL()
		{
			try
			{
				// Check that current browser sessions to be killed or not
				if (isSessionToBeKilled)
				{
					KillSessions(varBrowserName);
				}
				
				// Launch the Purchase manager application
				Process process = new Process();
				process.StartInfo.FileName = varBrowserName;
				process.StartInfo.Arguments = varURL; 	// + ~" --new-window --window-size=640,480";
				process.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;								
				process.Start();
				
				Report.Info("Launched URL :" + varURL);
				repo.MMT.HomeButtonInfo.WaitForExists(30000);
				process.Dispose();
				process.Close();
			}
			
			catch (Exception ex)
			{
				Report.Failure( "Exception is found in the class = '" + GetType().Name + "' & the method = '" + System.Reflection.MethodBase.GetCurrentMethod().Name + "'.");
				Report.Error( "Exception is found with Staktrace - " + ex.StackTrace);
				Report.Error( "Exception is found with message - " + ex.Message );
			}
		}
        
        public void KillSessions(string browserName = null)
		{
			string s = null;
			try
			{
				Process[] AllProcesses = Process.GetProcesses();
				foreach (var process in AllProcesses)
				{
					s  = process.ProcessName.ToLower();
					if (browserName != null)
					{
						if (s == browserName )
						{
							process.Kill();
							process.WaitForExit();
						}
					}
					else if (s == "iexplore" || s == "iexplorer" || s == "firefox" || s == "chrome" )
					{
						process.Kill();
					}
				}
			}
			
			catch (Exception ex)
			{
				Report.Error( "Exception is found with message - " + ex.Message);
			}
		}        
    }
}
