using System;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace MakeMyTrip.lib.util
{
	/// <summary>
	/// Description of xmlNodesClass.
	/// </summary>
	public class xmlNodesClass
	{
		public static Basware Basware = null;
	}
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:basware-schema", IsNullable=false)]
	public  class Basware
	{
		[XmlArray("Nodes")]
		[XmlArrayItem("Node")]
		public List<Node> Node  = new List<Node>();  	// = new Nodes();
	}
	
	public class Node
	{
		[XmlElement("TestGroup")]
		public string TestGroup {get; set; }
		
		[XmlElement("Browser")]
		public string Browser {get; set; }
		
		[XmlElement("LoginUrl")]
		public string LoginUrl {get; set; }
		
		[XmlElement("AdminUserName")]
		public string AdminUserName {get; set; }
		
		[XmlElement("AdminPassword")]
		public string AdminPassword {get; set; }
	}
}

