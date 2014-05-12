using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using Interfaces.Inveniam;
using Inveniam.Dummies;
using Microsoft.Office.InfoPath;

namespace Inveniam.Mocks
{
	public class DataSourceMock : DataSource, IMockContainer
	{
		protected string _name;

		public DataSourceMock(XmlDocument xmlDoc)
		{
			this._name = string.Empty;
			this.DataXml = xmlDoc;
		}

		public XmlDocument DataXml
		{
			get;
			set;
		}

		public override string Name
		{
			get
			{
				return _name;
			}
		}

		public void SetName(string name)
		{
			_name = name;
		}

		public override DataConnection QueryConnection
		{
			get
			{
				return new DataConnectionMock();
			}
		}

		public override bool ReadOnly
		{
			get
			{
				return false;
			}
		}

		public override XPathNavigator CreateNavigator()
		{
			return new XPathNavigatorMock(this);
		}

		public override string GetNamedNodeProperty(XPathNavigator target, string name)
		{
			return null;
		}

		public override void SetNamedNodeProperty(XPathNavigator target, string name, string value)
		{
		}
	}
}
