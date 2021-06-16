/*
 * Created by Ranorex
 * User: nitinshak
 * Date: 6/11/2021
 * Time: 5:02 PM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using WinForms = System.Windows.Forms;
using MakeMyTrip.lib.util;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Reporting;
using Ranorex.Core.Testing;

namespace MakeMyTrip.lib.mmt
{
	/// <summary>
	/// Description of homePage.
	/// </summary>
	[TestModule("1D245F86-51B9-4E04-8938-73A77E198B8E", ModuleType.UserCode, 1)]
	public class homePage : ITestModule
	{
		MakeMyTrip.MakeMyTripRepository repo = MakeMyTrip.MakeMyTripRepository.Instance;
		
		/// <summary>
		/// Constructs a new instance.
		/// </summary>
		public homePage()
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
			
			// 
			string abc = "asd";
			
		}
		
		/// <summary>
		/// Select the home button
		/// </summary>
		public void SelectHomeButton()
		{
			try
			{
				// Click on 'HomeButton' drop-down button
				TestReport.BeginTestModule("Select Home-Button", 1, ActivityExecType.RunIteration);
				repo.MMT.HomeButton.MoveTo(1500);
				repo.MMT.HomeButton.Click();
				Report.Success("MMT 'Home Page Button' button is clicked successfully.");
			}
			
			catch (Exception ex )
			{
				Report.Screenshot();
				Report.Failure( "Exception is found with message - " + ex.Message );
				Report.Failure( "Exception is found in the class = '" + GetType().Name + "' & the method = '" + System.Reflection.MethodBase.GetCurrentMethod().Name + "'.");
				Report.Failure( "Exception is found with Staktrace - " + ex.StackTrace);
			}
			
			finally
			{
				TestReport.EndTestModule();
			}
		}
		
		/// <summary>
		/// Click on the 'Flight' tab on the homepage
		/// </summary>
		public void SelectFlightTab()
		{
			try
			{
				// Click on 'HomeButton' drop-down button
				TestReport.BeginTestModule("Select Flight", 1, ActivityExecType.RunIteration);
				repo.MMT.Flight.MoveTo(1500);
				repo.MMT.Flight.Click();
				Report.Success("MMT 'Home Page Button' button is clicked successfully.");
			}
			
			catch (Exception ex )
			{
				Report.Screenshot();
				Report.Failure( "Exception is found with message - " + ex.Message );
				Report.Failure( "Exception is found in the class = '" + GetType().Name + "' & the method = '" + System.Reflection.MethodBase.GetCurrentMethod().Name + "'.");
				Report.Failure( "Exception is found with Staktrace - " + ex.StackTrace);
			}
			
			finally
			{
				TestReport.EndTestModule();
			}
		}
		
		/// <summary>
		/// Click on the 'Round Trip' radio button on the homepage
		/// </summary>
		public void SelectRoundTrip()
		{
			try
			{
				// Click on the 'Round Trip' radio button on the homepage
				TestReport.BeginTestModule("Select Round Trip", 1, ActivityExecType.RunIteration);
				repo.MMT.RoundTrip.MoveTo(1500);
				repo.MMT.RoundTrip.Click();
				Report.Success("'Round Trip' radio button on the homepage is clicked successfully.");
			}
			
			catch (Exception ex )
			{
				Report.Screenshot();
				Report.Failure( "Exception is found with message - " + ex.Message );
				Report.Failure( "Exception is found in the class = '" + GetType().Name + "' & the method = '" + System.Reflection.MethodBase.GetCurrentMethod().Name + "'.");
				Report.Failure( "Exception is found with Staktrace - " + ex.StackTrace);
			}
			
			finally
			{
				TestReport.EndTestModule();
			}
		}
		
		/// <summary>
		/// Click on the 'From' city to select starting city of the flight
		/// </summary>
		public void ClickFromCity()
		{
			try
			{
				// Click on 'From City' drop-down button
				TestReport.BeginTestModule("Select From", 1, ActivityExecType.RunIteration);
				repo.MMT.From.MoveTo(1500);
				repo.MMT.From.Click();
				Report.Success("MMT 'Home Page Button' button is clicked successfully.");
			}
			
			catch (Exception ex )
			{
				Report.Screenshot();
				Report.Failure( "Exception is found with message - " + ex.Message );
				Report.Failure( "Exception is found in the class = '" + GetType().Name + "' & the method = '" + System.Reflection.MethodBase.GetCurrentMethod().Name + "'.");
				Report.Failure( "Exception is found with Staktrace - " + ex.StackTrace);
			}
			
			finally
			{
				TestReport.EndTestModule();
			}
		}
		
		/// <summary>
		/// Fetch the list of cities from 'From' drop-down list
		/// </summary>
		public void FetchCitiesFrom()
		{
			try
			{
				// Click on 'From City' drop-down button
				TestReport.BeginTestModule("Fetch City List 'From'", 1, ActivityExecType.RunIteration);
				IList <LiTag> citiesList = repo.MMT.FromOptionList.FindDescendants<LiTag>();
				
				Report.Info("List of Cities as follows.");
				// div/div/p[1]
				foreach (var element in citiesList)
				{
					Report.Info(element.FindDescendants<PTag>()[0].InnerText);
					// OR "2nd Approach"
//					Report.Info("Adding XPATH then get \t \t : " + Element.FromPath(element.GetPath().ToString() + @"/div/div/p[1]").GetAttributeValueText("InnerText"));
				}
				
				Report.Success("City List of 'From' drop-down option.");
			}
			
			catch (Exception ex )
			{
				Report.Screenshot();
				Report.Failure( "Exception is found with message - " + ex.Message );
				Report.Failure( "Exception is found in the class = '" + GetType().Name + "' & the method = '" + System.Reflection.MethodBase.GetCurrentMethod().Name + "'.");
				Report.Failure( "Exception is found with Staktrace - " + ex.StackTrace);
			}
			
			finally
			{
				TestReport.EndTestModule();
			}
		}
		
		// From city name
		string _varFromCity = "";
		[TestVariable("ce6f62c6-ddd4-4160-a402-3ab2a7f4c2af")]
		public string varFromCity
		{
			get { return _varFromCity; }
			set { _varFromCity = value; }
		}
		
		/// <summary>
		/// Click on the 'From' city to select starting city of the flight
		/// </summary>
		/// <param name="varFromCity">'From' city is to be selected</param>
		public void SelectFromCity()
		{
			try
			{
				TestReport.BeginTestModule("Select From City", 1, ActivityExecType.RunIteration);
				Report.Info("Variables", "varFromCity :" + varFromCity );
				
				// Check that 'From' drop-down option is not expanded
				repo.R_DropDownOption = varFromCity;
				if (!repo.MMT.FromSuggestionOptionInfo.Exists(10000))
				{
					// Select on 'From' city drop-down button
					repo.MMT.From.MoveTo(1500);
					repo.MMT.From.Click();
				}
				
				// Select option for 'From' city drop-down button
				Keyboard.Press(varFromCity);
				repo.R_DropDownOption = varFromCity;
				repo.MMT.FromSuggestionOption.MoveTo(1500);
				repo.MMT.FromSuggestionOption.Click();
				Report.Success("'From' city is selected successfully.");
			}
			
			catch (Exception ex )
			{
				Report.Screenshot();
				Report.Failure( "Exception is found with message - " + ex.Message );
				Report.Failure( "Exception is found in the class = '" + GetType().Name + "' & the method = '" + System.Reflection.MethodBase.GetCurrentMethod().Name + "'.");
				Report.Failure( "Exception is found with Staktrace - " + ex.StackTrace);
			}
			
			finally
			{
				Report.Screenshot();
				TestReport.EndTestModule();
			}
		}
		
		// 'To' City is to be selected
		string _varToCity = "";
		[TestVariable("973b38ce-014e-4a93-a6eb-daabf1a1d0a5")]
		public string varToCity
		{
			get { return _varToCity; }
			set { _varToCity = value; }
		}
		
		/// <summary>
		/// Click on the 'To' city to select starting city of the flight
		/// </summary>
		/// <param name="varToCity">'To' City is to be selected</param>
		
		public void SelectToCity()
		{
			try
			{
				// Select on 'To' city drop-down button
				TestReport.BeginTestModule("Select To City", 1, ActivityExecType.RunIteration);
				repo.MMT.To.MoveTo(1500);
				repo.MMT.To.Click();
				
				// Select option for 'To' city drop-down button
				Keyboard.Press(varToCity);
				repo.R_DropDownOption = varToCity;
				repo.MMT.ToSuggestionOption.MoveTo(1500);
				repo.MMT.ToSuggestionOption.Click();
				Report.Success("'To' city is selected successfully.");
			}
			
			catch (Exception ex )
			{
				Report.Screenshot();
				Report.Failure( "Exception is found with message - " + ex.Message );
				Report.Failure( "Exception is found in the class = '" + GetType().Name + "' & the method = '" + System.Reflection.MethodBase.GetCurrentMethod().Name + "'.");
				Report.Failure( "Exception is found with Staktrace - " + ex.StackTrace);
			}
			
			finally
			{
				TestReport.EndTestModule();
			}
		}
		
		// Departure date is to be entered
		string _varDepartureDate = "";
		[TestVariable("d2fa1603-f1e8-41fe-9f43-9d8d4b2a139e")]
		public string varDepartureDate
		{
			get { return _varDepartureDate; }
			set { _varDepartureDate = value; }
		}
		
		// Return date is to be entered
		string _varReturnDate = "";
		[TestVariable("c0369ac9-11bb-4f8f-a293-ee7055fa828a")]
		public string varReturnDate
		{
			get { return _varReturnDate; }
			set { _varReturnDate = value; }
		}
		
		/// <summary>
		/// Configure date for departure and return flight
		/// </summary>
		/// <param name="varDepartureDate">Departure date is to entered in 'dd-mm-yyyy' format
		/// e.g. 1-1-2021, 11-1-2021</param>
		/// <param name="varReturnDate">Return date is to entered in 'dd-mm-yyyy' format
		/// e.g. 7-7-2021, 17-7-2021</param>
		public void SelectDepartReturnDate()
		{
			// Select on 'To' city drop-down button
			TestReport.BeginTestModule("Configure Departure/Return Date", 1, ActivityExecType.RunIteration);
			Report.Info("Variables", "varDepartureDate :" + varDepartureDate +
			            "\r\n varReturnDate :" + varReturnDate);
			
			try
			{
				// Click departure date input field
				repo.MMT.Date.DepartDate.Click();
				
				// Select 'Departure' date input field
				repo.R_Index = "0";
				SelectDay(varDepartureDate);
				Report.Success("varDepartureDate is configured -" + varDepartureDate);
				
				SelectDay(varReturnDate);
				repo.MMT.HomeButton.MoveTo();
				Report.Info( "Date/s is/are selected as : Departure date - '" + varDepartureDate + "' Return date - '" + varReturnDate + "'.");
			}
			
			catch (Exception ex )
			{
				Report.Screenshot();
				Report.Failure( "Exception is found with message - " + ex.Message );
				Report.Failure( "Exception is found in the class = '" + GetType().Name + "' & the method = '" + System.Reflection.MethodBase.GetCurrentMethod().Name + "'.");
				Report.Failure( "Exception is found with Staktrace - " + ex.StackTrace);
			}
			
			finally
			{
				Report.Screenshot();
				TestReport.EndTestModule();
			}
		}
		
		/// <summary>
		/// Select the day from date picker
		/// </summary>
		private void SelectDay(string date)
		{
			try
			{
				// Check that date belongs to current month or not
				string day = date.Split('-')[0];
				if ( int.Parse(date.Split('-')[1]) == int.Parse(System.DateTime.Now.ToString("MM")) )
				{
					repo.R_Index = "0";
				}
				else
				{
					repo.R_Index = "1";
				}
				
				// Select on 'To' city drop-down button
				repo.R_Day = day;
				Mouse.MoveTo(repo.MMT.Date.DepartReturnDate,1000);
				Mouse.Click(repo.MMT.Date.DepartReturnDate);
				Report.Info("Day '" + day + "' is selected successfully.");
			}
			
			catch (Exception ex )
			{
				Report.Screenshot();
				Report.Failure( "Exception is found with message - " + ex.Message );
				Report.Failure( "Exception is found in the class = '" + GetType().Name + "' & the method = '" + System.Reflection.MethodBase.GetCurrentMethod().Name + "'.");
				Report.Failure( "Exception is found with Staktrace - " + ex.StackTrace);
			}
		}
		
		/// <summary>
		/// Click on 'Search' button to see all available flights
		/// </summary>
		public void SearchFlight()
		{
			// Select on 'To' city drop-down button
			TestReport.BeginTestModule("Click Search", 1, ActivityExecType.RunIteration);
			
			try
			{
				// Click departure date input field
				repo.RL_Search = languageReader.GetInstance().GetString("Search");
				repo.MMT.Search.Click(1000);
				repo.MMT.SearchInfo.WaitForNotExists(30000);
				repo.MMT.SearchResult.Depart.DepartureSortInfo.WaitForExists(50000);
				Report.Success("'Search' button is clicked successfully." + varDepartureDate);
			}
			
			catch (Exception ex )
			{
				Report.Screenshot();
				Report.Failure( "Exception is found with message - " + ex.Message );
				Report.Failure( "Exception is found in the class = '" + GetType().Name + "' & the method = '" + System.Reflection.MethodBase.GetCurrentMethod().Name + "'.");
				Report.Failure( "Exception is found with Staktrace - " + ex.StackTrace);
			}
			
			finally
			{
				Report.Screenshot();
				TestReport.EndTestModule();
			}
		}
		
		// Flight type e.g. 'departure' or 'return'
		string _varFlightType = "";
		[TestVariable("766341b8-8da2-4990-8d0d-cb32a400d43a")]
		public string varFlightType
		{
			get { return _varFlightType; }
			set { _varFlightType = value; }
		}
		
		/// <summary>
		/// Sort from 'Departure' column for departuring flights
		/// </summary>
		/// <param name="varFlightType">Flight type e.g. 'departure' or 'return'</param>
		public void DepartureSort()
		{
			// Select on 'To' city drop-down button
			TestReport.BeginTestModule("Departure Sort", 1, ActivityExecType.RunIteration);
			Report.Info("Variables", "varFlightType :" + varFlightType);
			
			try
			{
				// Check that flight type is departure or not
				if (varFlightType.ToLower() == "departure")
				{
					// Click on 'Departure' column of departure flight list to sort
					repo.MMT.SearchResult.Depart.DepartureSort.MoveTo(2500);
					repo.MMT.SearchResult.Depart.DepartureSort.Click();
					repo.MMT.SearchResult.Depart.DepartureSort.MoveTo(2000);
				}
				else
				{
					// Click on 'Departure' column of return flight list to sort
					repo.MMT.SearchResult.Return.DepartureSort.MoveTo(2500);
					repo.MMT.SearchResult.Return.DepartureSort.Click();
					repo.MMT.SearchResult.Return.DepartureSort.MoveTo(2000);
				}
				
				Report.Success("'Departure' column is clicked successfully for '" + varFlightType + "' flight type.");
			}
			
			catch (Exception ex )
			{
				Report.Screenshot();
				Report.Failure( "Exception is found with message - " + ex.Message );
				Report.Failure( "Exception is found in the class = '" + GetType().Name + "' & the method = '" + System.Reflection.MethodBase.GetCurrentMethod().Name + "'.");
				Report.Failure( "Exception is found with Staktrace - " + ex.StackTrace);
			}
			
			finally
			{
				Report.Screenshot();
				TestReport.EndTestModule();
			}
		}
		
		
		/// <summary>
		/// Select first flight from 'Departure' column for departuring flights
		/// </summary>
		/// <param name="varFlightType">Flight type e.g. 'departure' or 'return'</param>
		public void SelectFirstFlight()
		{
			TestReport.BeginTestModule("Select First Flight", 1, ActivityExecType.RunIteration);
			Report.Info("Variables", "varFlightType :" + varFlightType);
			
			try
			{
				// Check that flight type is departure or not
				if (varFlightType.ToLower() == "departure")
				{
					// Click on 'Departure' column of departure flight list to sort
					repo.MMT.SearchResult.Depart.FirstFlight.Click();
					repo.MMT.SearchResult.Depart.FirstFlightInfo.WaitForExists(20000);
					repo.MMT.SearchResult.Depart.FirstFlight.MoveTo(2500);
				}
				else
				{
					// Click on 'Departure' column of return flight list to sort
					repo.MMT.SearchResult.Return.FirstFlight.MoveTo(3500);
					repo.MMT.SearchResult.Return.FirstFlight.Click();
					repo.MMT.SearchResult.Return.FirstFlightInfo.WaitForExists(20000);
					repo.MMT.SearchResult.Return.FirstFlight.MoveTo(1500);
				}
				
				Report.Success("First flight is selected from '" + varFlightType + "' flight list.");
				
//				// Click on 'Book Now' button
//				repo.MMT.SearchResult.BookNow.Click(1000);
//				Report.Success("'Book Now' button of 'Search Result' page is clicked successfully.");
//
//				// Click on 'Continue' button
//				repo.MMT.SearchResult.Continue.Click(1000);
//				Report.Success("'Continue' button of modular window page is clicked successfully.");
			}
			
			catch (Exception ex )
			{
				Report.Screenshot();
				Report.Failure( "Exception is found with message - " + ex.Message );
				Report.Failure( "Exception is found in the class = '" + GetType().Name + "' & the method = '" + System.Reflection.MethodBase.GetCurrentMethod().Name + "'.");
				Report.Failure( "Exception is found with Staktrace - " + ex.StackTrace);
			}
			
			finally
			{
				Report.Screenshot();
				TestReport.EndTestModule();
			}
		}
		
		/// <summary>
		/// Book flight by clicking 'Book Now' & 'Continue' buttons
		/// </summary>
		public void BookFlight()
		{
			TestReport.BeginTestModule("Book Flight", 1, ActivityExecType.RunIteration);
			Report.Info("Variables", "varFlightType :" + varFlightType);
			
			try
			{
				// Click on 'Book Now' button
				repo.MMT.SearchResult.BookNow.MoveTo(1000);
				repo.MMT.SearchResult.BookNow.Click();
				Report.Success("'Book Now' button of 'Search Result' page is clicked successfully.");
				
				// Click on 'Continue' button
				repo.MMT.SearchResult.Continue.MoveTo(1000);
				repo.MMT.SearchResult.Continue.Click();
				Report.Success("'Continue' button of modular window page is clicked successfully.");
			}
			
			catch (Exception ex )
			{
				Report.Screenshot();
				Report.Failure( "Exception is found with message - " + ex.Message );
				Report.Failure( "Exception is found in the class = '" + GetType().Name + "' & the method = '" + System.Reflection.MethodBase.GetCurrentMethod().Name + "'.");
				Report.Failure( "Exception is found with Staktrace - " + ex.StackTrace);
			}
			
			finally
			{
				Report.Screenshot();
				TestReport.EndTestModule();
			}
		}
		
		/// <summary>
		/// Display all details of fare of the flight/s on 'Review your booking' page
		/// </summary>
		public void DisplayFareSummary()
		{
			TestReport.BeginTestModule("Display Fare Summary", 1, ActivityExecType.RunIteration);
			
			try
			{
				// Display all details of fare of the flight/s
				repo.MMT.Review.BaseFareInfo.WaitForExists(60000);
				repo.MMT.Review.BaseFare.MoveTo();
				Report.Success("'Base Fare' of the flights is - '" + repo.MMT.Review.BaseFare.GetAttributeValue<string>("Innertext") + "' on 'Review your booking' page.");
//				repo.MMT.Review.FeeSurcharges.MoveTo();
				Report.Success("'Fee & Surcharge' of the flights is - '" + repo.MMT.Review.FeeSurcharges.GetAttributeValue<string>("Innertext") + "' on 'Review your booking' page.");
//				repo.MMT.Review.OtherServices.MoveTo();
				Report.Success("'Other Services' of the flights is - '" + repo.MMT.Review.OtherServices.GetAttributeValue<string>("Innertext") + "' on 'Review your booking' page.");
//				repo.MMT.Review.TotalAmount.MoveTo();
				Report.Success("'Total Amount' of the flights is - '" + repo.MMT.Review.TotalAmount.GetAttributeValue<string>("Innertext") + "' on 'Review your booking' page.");
			}
			
			catch (Exception ex )
			{
				Report.Screenshot();
				Report.Failure( "Exception is found with message - " + ex.Message );
				Report.Failure( "Exception is found in the class = '" + GetType().Name + "' & the method = '" + System.Reflection.MethodBase.GetCurrentMethod().Name + "'.");
				Report.Failure( "Exception is found with Staktrace - " + ex.StackTrace);
			}
			
			finally
			{
				Report.Screenshot();
				TestReport.EndTestModule();
			}
		}
		
		/// <summary>
		/// Close current tab of the browser
		/// </summary>
		public void CloseCurrentTab()
		{
			TestReport.BeginTestModule("Close Current Tab", 1, ActivityExecType.RunIteration);
			
			try
			{
				// Close current tab
				repo.MMT.Tab.CurrentTabClose.MoveTo();
				repo.MMT.Tab.CurrentTabClose.Click();
				Report.Success("Current tab is closed.");
			}
			
			catch (Exception ex )
			{
				Report.Screenshot();
				Report.Failure( "Exception is found with message - " + ex.Message );
				Report.Failure( "Exception is found in the class = '" + GetType().Name + "' & the method = '" + System.Reflection.MethodBase.GetCurrentMethod().Name + "'.");
				Report.Failure( "Exception is found with Staktrace - " + ex.StackTrace);
			}
			
			finally
			{
				Report.Screenshot();
				TestReport.EndTestModule();
			}
		}
	}
}
