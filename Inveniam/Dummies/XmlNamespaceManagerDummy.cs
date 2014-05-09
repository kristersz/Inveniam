using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Inveniam.Dummies
{
	public class XmlNamespaceManagerDummy : XmlNamespaceManager
	{
		public XmlNamespaceManagerDummy()
			: base(new XmlNameTableDummy())
		{
		}
		public override IDictionary<string, string> GetNamespacesInScope(XmlNamespaceScope scope)
		{
			return null;
		}

		public override string LookupNamespace(string prefix)
		{
			return null;
		}

		public override string LookupPrefix(string namespaceName)
		{
			return null;
		}
	}
}
