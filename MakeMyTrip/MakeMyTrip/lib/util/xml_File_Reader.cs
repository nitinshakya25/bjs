using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

using Ranorex;
using Ranorex.Core.Reporting;

namespace MakeMyTrip.lib.util
{
	/// <summary>
	/// Description of xml_File_Reader.
	/// </summary>
	public class xml_File_Reader
	{
		private static xml_File_Reader xml_Reader = null;
		private Basware baswareNode = null;
		
		int validationFlag = 0;
		
		private xml_File_Reader()
		{
		}
		
		public static xml_File_Reader GetInstance()
		{
			if (xml_Reader == null) {
				xml_Reader = new xml_File_Reader();
			}
			return xml_Reader ;
		}
		
		/// <summary>
		/// Validate the XML schema
		/// </summary>
		/// <param name="xmlFilePath">XML file path</param>
		/// <param name="xsdFilePath">XSD file path</param>
		/// <returns>True: If validation is successful else false</returns>
		public bool  ValidateXMLSchema(string xmlFilePath = "", string xsdFilePath = "")
		{
			bool flag = true;
			
			try
			{        		
				// Check that file path is null
				if (xsdFilePath == "") {
					xsdFilePath = @".\..\..\..\..\ConfigFile\ConfigurationFile.xsd";
				}
				if (xmlFilePath == "") {
					xmlFilePath = @".\..\..\..\..\ConfigFile\ConfigurationFile.xml";
				}
				
				// Load the XmlSchemaSet
				XmlSchemaSet schemaSet = new XmlSchemaSet();
				schemaSet.Add("urn:basware-schema", xsdFilePath);
				
				// Set the validation settings.
				XmlReaderSettings settings = new XmlReaderSettings();
				settings.Schemas.Add(schemaSet);
				settings.ValidationType = ValidationType.Schema;
				settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
				settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation;
				settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
				settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);
				
				// Create the XmlReader object.
				XmlReader reader = XmlReader.Create(xmlFilePath, settings);
				
				// Parse the file.
				string readText = null;
				
				// Display the values of all the nodes of the XML file				
				while ( reader.Read())
				{
					readText = reader.ReadString();
					readText = readText.Trim();
					if (readText == null || readText == "") {
					}
					else
					{
						// Commented for now : It could be uncommneted for debug purpose
					//	Report.Success("Text in the file = ==   '"+ readText + "'.");
					}
				}
			}
			
			catch (Exception ex)
			{
				Report.Failure( "Exception is found in the class = '" + GetType().Name + "' & the method = '" + System.Reflection.MethodBase.GetCurrentMethod().Name + "'.");
				Report.Error( "Exception is found with Staktrace - " + ex.StackTrace);
				Report.Error( "Exception is found with message - " + ex.Message );
			}
			
			finally
			{
				if (validationFlag != 0)
				{
					flag = false;
					Report.Failure(" --- XML Validation is Un-successful.");
				}
				else
				{
			//	Report.Success("--- XML Validation is successful.");
				}				
			}
			return flag;
		}
		
		/// <summary>
		/// Display any warnings or errors 
		/// </summary>
		private static void ValidationCallBack(object sender, ValidationEventArgs args)
		{
			if (args.Severity == XmlSeverityType.Warning)
				Report.Failure("\tWarning: Matching schema not found.  No validation occurred." + args.Message);
			else
				Report.Failure("\tValidation error: " + args.Message);

			xml_File_Reader.GetInstance().validationFlag++;
		}
		
		/// <summary>
		/// Get the XML elements in class variables
		/// </summary>
		/// <param name="xmlPath">XML path</param>
		/// <returns></returns>
		public Basware GetXmlElements(string xmlPath = null)
		{
			try
			{
				if (baswareNode == null)
				{
					XmlSerializer serializer = new XmlSerializer(typeof(Basware));
					using (XmlReader reader = XmlReader.Create(@".\..\..\..\..\ConfigFile\ConfigurationFile.xml"))
					{
						baswareNode = (Basware)(serializer.Deserialize(reader));
						
						xmlNodesClass.Basware = baswareNode;
						Console.WriteLine("after reading xml file");
					}
					
					// Commented as of now : It could be uncommented for debug purpose
//					Report.Success("In 'GetXmlElements' Class :::: Login URL " + xmlNodesClass.Basware.Node[0].LoginUrl);
//					Report.Success("AdminUsername " + xmlNodesClass.Basware.Node[0].AdminUserName);
//					Report.Success("AdminPassword " + xmlNodesClass.Basware.Node[0].AdminPassword);
				}
			}
			
			catch(Exception ex)
			{
				Report.Failure( "Exception is found in the class = '" + GetType().Name + "' & the method = '" + System.Reflection.MethodBase.GetCurrentMethod().Name + "'.");
				Report.Error( "Exception is found with Staktrace - " + ex.StackTrace);
				Report.Error( "Exception is found with message - " + ex.Message );
			}
			
			return baswareNode;
		}
	}
}