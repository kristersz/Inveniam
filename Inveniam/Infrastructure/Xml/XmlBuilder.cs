using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Inveniam.Infrastructure.Extensions;

namespace Inveniam.Infrastructure.Xml
{
	public class XmlBuilder<T>
	{
		private string _dfsNameSpace { get; set; }
		private string _templateNameSpace { get; set; }
		private string _methodName { get; set; }
		private string _typeName { get { return typeof(T).Name; } }

		private StringBuilder _sb;
		private T _value { get; set; }


		public XmlBuilder(string dfsNameSpace, string tfsNameSpace, string methodName, T value)
		{
			this._dfsNameSpace = dfsNameSpace;
			this._templateNameSpace = tfsNameSpace;
			this._methodName = methodName;
			this._value = value;

			this._sb = new StringBuilder();
		}

		public XmlDocument GenerateXml()
		{
			XmlDocument document = new XmlDocument();

			XmlElement root = document.CreateElement("dfs", "myFields", this._dfsNameSpace);
			root.SetAttribute("xmlns:tns", this._templateNameSpace);
			document.AppendChild(root);

			// query fields
			XmlElement queryFields = document.CreateElement("dfs", "queryFields", this._dfsNameSpace);
			root.AppendChild(queryFields);

			XmlElement queryBody = document.CreateElement("tns", this._methodName, this._templateNameSpace);
			queryFields.AppendChild(queryBody);

			// data fields
			XmlElement dataFields = document.CreateElement("dfs", "dataFields", this._dfsNameSpace);
			root.AppendChild(dataFields);

			XmlElement queryResponse = document.CreateElement("tns", this._methodName + "Response", this._templateNameSpace);
			dataFields.AppendChild(queryResponse);

			XmlElement queryResult = document.CreateElement("tns", this._methodName + "Result", this._templateNameSpace);
			queryResponse.AppendChild(queryResult);

			// object values
			var serializedXml = this._value.Serialize();
			XmlDocument serializedDoc = new XmlDocument();
			serializedDoc.LoadXml(serializedXml);

			XmlNodeList objectNodes = serializedDoc.GetElementsByTagName(this._typeName);
			foreach (XmlNode objectNode in objectNodes)
			{
				if (objectNode.HasChildNodes)
				{
					foreach (XmlNode propertyNode in objectNode)
					{
						XmlNode importNode = queryResult.OwnerDocument.ImportNode(propertyNode, true);
						queryResult.AppendChild(importNode);
					}
				}
			}

			return document;
		}
	}
}
