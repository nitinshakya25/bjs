/*
 * Created by Ranorex
 * User: nitinshak
 * Date: 6/14/2021
 * Time: 2:38 AM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Resources;
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
	/// Description of languageReader.
	/// </summary>
	[TestModule("9B3D233B-7A1A-46EE-89E3-AF2B984AB47F", ModuleType.UserCode, 1)]
	public class languageReader : ITestModule
	{
		/// <summary>
		/// Constructs a new instance.
		/// </summary>
		public languageReader()
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
		
		private static languageReader languageReaderObject = null;
		private static ResourceManager resourceFileReader = null;
		
		// Language name
		static string _varLanguage = "";
		[TestVariable("2bbc33f3-f1bd-4096-b273-50b423499d4e")]
		public static string varLanguage
		{
			get { return _varLanguage; }
			set { _varLanguage = value; }
		}
		
		public static languageReader GetInstance()
		{
			try
			{
				if(languageReaderObject == null)
				{
					languageReaderObject = new languageReader();
				}
			}
			
			catch(Exception e)
			{
				Report.Failure("Exception found with stacktrace as ---- " + e.StackTrace);
			}
			return (languageReaderObject);
		}
		
		/// <summary>
		/// Get the text of the key in specific language
		/// </summary>
		/// <param name="keyString">Key of which text is to be found</param>
		/// <returns>Value of the key in the specific language</returns>
		public string GetString(string keyString)
		{
			string langString = "";
			try
			{
				if (resourceFileReader == null) {
					Report.Success("Resource file reader is null.");
				}
				
				// Get the text of the key
				langString = resourceFileReader.GetString(keyString);
				if (langString == null)
					Report.Failure(keyString + " key is not found in the resource file.");
			}
			
			catch(Exception ex)
			{
				Report.Failure( "Exception is found in the class = '" + GetType().Name + "' & the method = '" + System.Reflection.MethodBase.GetCurrentMethod().Name + "'.");
				Report.Error( "Exception is found with Staktrace - " + ex.StackTrace);
				Report.Error( "Exception is found with message - " + ex.Message );
			}
			return langString ;
		}
		
		/// <summary>
		/// Assign the resource assignment
		/// </summary>
		public void ResourceFileAssignment()
		{
			try
			{
				switch (languageReader.varLanguage.ToLower())
				{
					case "english":
						resourceFileReader = new ResourceManager("MakeMyTrip.lib.langFiles.English", Assembly.GetExecutingAssembly());
						break;
						
					case "french":
						resourceFileReader = new ResourceManager("MakeMyTrip.lib.langFiles.French", Assembly.GetExecutingAssembly());
						break;
						
					default:
						resourceFileReader = new ResourceManager("MakeMyTrip.lib.langFiles.English", Assembly.GetExecutingAssembly());
						break;
				}
			}
			catch(Exception ex)
			{
				Report.Failure( "Exception is found in the class = '" + GetType().Name + "' & the method = '" + System.Reflection.MethodBase.GetCurrentMethod().Name + "'.");
				Report.Error( "Exception is found with Staktrace - " + ex.StackTrace);
				Report.Error( "Exception is found with message - " + ex.Message );
			}
		}
	}
}
