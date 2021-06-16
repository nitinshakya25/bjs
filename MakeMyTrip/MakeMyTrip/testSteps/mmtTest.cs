/*
 * Created by Ranorex
 * User: nitinshak
 * Date: 6/12/2021
 * Time: 1:50 PM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.IO;
using System.Windows.Forms;

using MakeMyTrip.lib.mmt;
using MakeMyTrip.lib.util;
using NUnit.Framework.Constraints;
using Ranorex;
using Ranorex.Core.Reporting;
using TechTalk.SpecFlow;

namespace MakeMyTrip.testSteps
{
	[Binding]
	public class mmtTest
	{
		utility utilityObject = new utility();
		browserOperations browserOperationsObject = new browserOperations();
		homePage homepageObject = new homePage();
		
		[Given("Prerequisites of the testcase")]
		public void PreRequisite()
		{
			try
			{
				// Validate the XML Schema
				if(xml_File_Reader.GetInstance().ValidateXMLSchema())
				{
					Report.Success("XML Validation successful.");
				}
				else
				{
					Report.Success("XML Validation \"Unsuccessful\".");
				}

				// Create report file structure to report logs
				string reportLoc = Environment.CurrentDirectory + @"\reports\" + System.DateTime.Now.ToString("yyMMdd_hhmmss");
				Directory.CreateDirectory(reportLoc);
				string reportPathName = reportLoc + @"\SmokeTestSuite" + System.DateTime.Now.ToString("yyMMdd_hhmmss") +".pdf";
				TestReport.Setup(ReportLevel.Inherit, reportPathName, true, true, Duration.FromMilliseconds(1000));
				TestReport.BeginTestSuite("Smoke Test-Suite");
				TestReport.BeginTestCaseContainer( "mmt", FeatureContext.Current.FeatureInfo.Title, ActivityExecType.Execute, 1, null);
				TestReport.BeginTestModule( "Launch URL", 1, ActivityExecType.Execute);
				
				// Language Reader
				languageReader.GetInstance();
				languageReader.varLanguage = "english";
				languageReader.GetInstance().ResourceFileAssignment();
			}
			
			catch( Exception e)
			{
				Report.Failure("Exception found with stacktrace as ---- " + e.StackTrace);
				Report.Failure("Exception found with stacktrace as ---- " + e.Message);
			}
		}
		
		[When("Launch browser for MMM_TEST")]
		public void LaunchBrowser()
		{
			// Launch the browser with proper URL
			browserOperationsObject.isSessionToBeKilled = false;
			browserOperationsObject.varBrowserName = xml_File_Reader.GetInstance().GetXmlElements().Node[0].Browser.ToLower();
			browserOperationsObject.varURL = xml_File_Reader.GetInstance().GetXmlElements().Node[0].LoginUrl;
			browserOperationsObject.LaunchURL();
		}
		
		[Then("Click on tab (.*) on homepage")]
		public void SelectTab(string tab)
		{
			homepageObject.SelectHomeButton();
			homepageObject.SelectFlightTab();
		}
		[Then("Click on from city drop down")]
		public void ClickFromDropDown()
		{
			homepageObject.ClickFromCity();
		}
		[Then("Fetch all of the cities in the drop-down")]
		public void FetchAllCities()
		{
			homepageObject.FetchCitiesFrom();
		}
		[Then("Select city (.*) from (.*) city drop down")]
		public void SelectDepartureReturnCity(string cityName, string dropDownType)
		{
			if (dropDownType.ToLower() == "from")
			{
				// Select from city
				homepageObject.varFromCity = cityName;
				homepageObject.SelectFromCity();
			}
			else if (dropDownType.ToLower() == "to")
			{
				// Select to city
				homepageObject.varToCity = cityName;
				homepageObject.SelectToCity();
			}
		}
		
		[Then("Select departure (.*) and return (.*) date")]
		public void SelectDate(string departureDate, string returnDate)
		{
			// Click on 'Round Trip' radio button
			homepageObject.SelectRoundTrip();
			
			// Select the date
			homepageObject.varDepartureDate = departureDate;
			homepageObject.varReturnDate = returnDate;
			homepageObject.SelectDepartReturnDate();
		}
		
		[Then("Click on Search button")]
		public void ClickSearch()
		{
			homepageObject.SearchFlight();
		}
		
		[Then("Sort from the departure column for (.*) flight list")]
		public void SortColumn(string flightType)
		{
			homepageObject.varFlightType = flightType;
			homepageObject.DepartureSort();
		}
		
		[Then("Select first flight from both of the options")]
		public void SelectFirstFLight()
		{
			homepageObject.varFlightType = "departure";
			homepageObject.SelectFirstFlight();
			
			homepageObject.varFlightType = "return";
			homepageObject.SelectFirstFlight();
		}
		
		[Then("Click on BookNow  and Continue button")]
		public void BookFlight()
		{
			homepageObject.BookFlight();
		}
		
		[Then("Display the fare summary")]
		public void DisplayFareSummary()
		{
			homepageObject.DisplayFareSummary();
		}
		
		[Then("Close the second tab")]
		public void CloseCurrentTab()
		{
			homepageObject.CloseCurrentTab();
		}
		
		[Then("Close the testcase")]
		public void CloseTest()
		{
			// Close testcontainer and testsuite
			TestReport.EndTestCaseContainer();
			TestReport.EndTestSuite();
		}
	}
}