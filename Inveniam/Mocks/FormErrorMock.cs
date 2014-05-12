using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.XPath;
using Interfaces.Inveniam;
using Microsoft.Office.InfoPath;

namespace Inveniam.Mocks
{
	public class FormErrorMock : FormError, IMockContainer
	{
		private FormErrorType _formErrorType;
		private string _name;
		private XPathNavigatorMock _site;

		public FormErrorMock(XPathNavigatorMock site, string name, string message, string detailedMessage = null, int errorCode = 0, ErrorMode errorMode = ErrorMode.Modal)
		{
			this._site = site;
			this._name = name;
			this.Message = message;
			this.DetailedMessage = detailedMessage;
			this.ErrorCode = errorCode;
		}

		public override string DetailedMessage { get; set; }

		public override int ErrorCode { get; set; }

		public override FormErrorType FormErrorType
		{
			get
			{
				return this._formErrorType;
			}
		}

		public override string Message { get; set; }

		public override string Name
		{
			get
			{
				return this._name;
			}
		}

		public void SetName(string name)
		{
			_name = name;
		}

		public override XPathNavigator Site
		{
			get
			{
				return this._site;
			}
		}
	}
}
