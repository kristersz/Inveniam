using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using Inveniam.Infrastructure.Resources;
using Inveniam.Infrastructure.Xml;

namespace Inveniam.Infrastructure.Helpers
{
	public static class XmlHelper<T>
	{
		public static XmlDocument CreateXmlFromValue(T value, string methodName)
		{
			var xmlBuilder = new XmlBuilder<T>(Namespaces.dfsNamespace, Namespaces.templateNamespace, methodName, value);
			var xmlDoc = xmlBuilder.GenerateXml();

			return xmlDoc;
		}

		public static XPathDocument ConvertXmlDocumentToXPathDocument(XmlDocument xmlDoc)
		{
			return new XPathDocument(new XmlNodeReader(xmlDoc));
		}
	}
}
