/*
 * Created by Ranorex
 * User: nitinshak
 * Date: 6/10/2021
 * Time: 6:36 PM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace MakeMyTrip.lib.util
{
	/// <summary>
	/// Description of utility.
	/// </summary>
	[TestModule("DF48CD02-D786-4358-8C4B-875D937DE797", ModuleType.UserCode, 1)]
	public class utility : ITestModule
	{
		/// <summary>
		/// Constructs a new instance.
		/// </summary>
		public utility()
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
		
		/// <summary>
		/// Paste the text in already clicked element
		/// </summary>
		/// <param name="element">Element in which value is to be pasted</param>
		/// <param name="text">Text is to be pasted in the element</param>
		/// <param name="eleTextFieldName">Field name of element of which value is to be modified, it would result in pasting the text in it</param>
		/// <param name="pressEnterKey">True : If 'Enter' key is to be pressed after pasting text else 'False'</param>
		public void PasteText(Element element, string text, string eleTextFieldName = "innertext", bool pressEnterKey = false)
		{
			try
			{
				Report.Info("Variables", "element :" + element +
				            "\r\n text :" + text +
				            "\r\n eleTextFieldName :" + eleTextFieldName +
				            "\r\n pressEnterKey :" + pressEnterKey );
				
				// Set the element value
				element.SetAttributeValue(eleTextFieldName,text);
				Report.Success("Text: '" + text + "' has been set for the field: '" + eleTextFieldName +"'.");
				
				// Check if 'Enter' key is to be pressed
				if (pressEnterKey)
				{
					Report.Screenshot();
					Keyboard.Press("{Return}");
					Report.Info("'Enter' key is pressed");
				}
			}
			
			catch (Exception ex )
			{
				Report.Failure( "Exception is found in the class = '" + GetType().Name + "' & the method = '" + System.Reflection.MethodBase.GetCurrentMethod().Name + "'.");
				Report.Failure( "Exception is found with Staktrace - " + ex.StackTrace);
				Report.Failure( "Exception is found with message - " + ex.Message );
			}
		}
	}
}
