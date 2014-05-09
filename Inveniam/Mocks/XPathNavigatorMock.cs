using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using Inveniam.Infrastructure.Extensions;

namespace Inveniam.Mocks
{
	public class XPathNavigatorMock : XPathNavigator
	{
		private string _innerXml;
		private string _name;
		public DataSourceMock _dataSource;

		public XPathNavigatorMock(DataSourceMock ds, string name = null, string innerXml = null)
		{
			this._dataSource = ds;
			this._name = name;
			this._innerXml = innerXml;
		}

		public override string BaseURI
		{
			get
			{
				return null;
			}
		}

		public override string InnerXml
		{
			get
			{
				return this._innerXml;
			}
			set
			{
				this._innerXml = value;
				UpdateDataXml();
			}
		}

		public override bool IsEmptyElement { get { return false; } }

		public override string LocalName { get { return null; } }

		public override string Name { get { return this._name; } }

		public void SetName(string name)
		{
			_name = name;
		}

		public override string NamespaceURI { get { return null; } }

		public override XmlNameTable NameTable { get { return null; } }

		public override XPathNodeType NodeType { get { return XPathNodeType.Element; } }

		public override string Prefix { get { return null; } }

		public override XPathNavigator Clone()
		{
			return null;
		}

		public override bool IsSamePosition(XPathNavigator other)
		{
			return false;
		}

		public override bool MoveTo(XPathNavigator other)
		{
			return false;
		}

		public override bool MoveToFirstAttribute()
		{
			return false;
		}

		public override bool MoveToFirstChild()
		{
			return false;
		}

		public override bool MoveToFirstNamespace(XPathNamespaceScope namespaceScope)
		{
			return false;
		}

		public override bool MoveToId(string id)
		{
			return false;
		}

		public override bool MoveToNext()
		{
			return false;
		}

		public override bool MoveToNextAttribute()
		{
			return false;
		}

		public override bool MoveToNextNamespace(XPathNamespaceScope namespaceScope)
		{
			return false;
		}

		public override bool MoveToParent()
		{
			return false;
		}

		public override bool MoveToPrevious()
		{
			return false;
		}

		public override XPathNavigator SelectSingleNode(string xpath)
		{
			var innerXml = string.Empty;

			var nodes = xpath.Split('/');
			var lastNode = nodes.LastOrDefault();

			XmlNodeList parentNode = this._dataSource.DataXml.GetElementsByTagName(lastNode);
			foreach (XmlNode childrenNode in parentNode)
			{
				innerXml = childrenNode.InnerXml;
			}

			return new XPathNavigatorMock(this._dataSource, lastNode, innerXml);
		}

		public override XPathNavigator SelectSingleNode(XPathExpression expression)
		{
			return this;
		}

		public override XPathNavigator SelectSingleNode(string xpath, IXmlNamespaceResolver resolver)
		{
			var innerXml = string.Empty;

			var nodes = xpath.Split('/');
			var lastNode = nodes.LastOrDefault();

			XmlNodeList parentNode = this._dataSource.DataXml.GetElementsByTagName(lastNode);
			foreach (XmlNode childrenNode in parentNode)
			{
				innerXml = childrenNode.InnerXml;
			}

			return new XPathNavigatorMock(this._dataSource, lastNode, innerXml);
		}

		public override string Value
		{
			get
			{
				return null;
			}
		}

		private void UpdateDataXml()
		{
			XmlNodeList parentNode = this._dataSource.DataXml.GetElementsByTagName(this.Name);
			foreach (XmlNode childrenNode in parentNode)
			{
				childrenNode.InnerXml = this._innerXml;
			}
		}
	}
}
