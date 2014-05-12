using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.XPath;
using Microsoft.Office.InfoPath;

namespace Inveniam.Mocks
{
	public class FormErrorCollectionMock : FormErrorCollection
	{
		private List<FormErrorMock> _formErrors;

		public FormErrorCollectionMock()
		{
			this._formErrors = new List<FormErrorMock>();
		}

		public override int Count
		{
			get
			{
				return this._formErrors.Count;
			}
		}

		public override FormError this[int index]
		{
			get
			{
				return this._formErrors.ElementAt(index);
			}
		}

		public override FormError Add(XPathNavigator context, string name, string message)
		{
			var newFormError = new FormErrorMock(context as XPathNavigatorMock, name, message);
			this._formErrors.Add(newFormError);

			return newFormError;
		}

		public override FormError Add(XPathNavigator context, string name, string message, string messageDetails)
		{
			var newFormError = new FormErrorMock(context as XPathNavigatorMock, name, message, messageDetails);
			this._formErrors.Add(newFormError);

			return newFormError;
		}

		public override FormError Add(XPathNavigator context, string name, string message, string messageDetails, int errorCode)
		{
			var newFormError = new FormErrorMock(context as XPathNavigatorMock, name, message, messageDetails, errorCode);
			this._formErrors.Add(newFormError);

			return newFormError;
		}

		public override FormError Add(XPathNavigator context, string name, string message, string messageDetails, int errorCode, ErrorMode errorMode)
		{
			var newFormError = new FormErrorMock(context as XPathNavigatorMock, name, message, messageDetails, errorCode, errorMode);
			this._formErrors.Add(newFormError);

			return newFormError;
		}

		public override void Delete(FormError formError)
		{
			var error = formError as FormErrorMock;
			if (error == null)
			{
				return;
			}

			this._formErrors.Remove(error);
		}

		public override void Delete(string name)
		{
			var error = this._formErrors.FirstOrDefault(e => e.Name == name);
			if (error == null)
			{
				return;
			}

			this._formErrors.Remove(error);
		}

		public override void DeleteAll()
		{
			this._formErrors.Clear();
		}

		public override IEnumerator GetEnumerator()
		{
			foreach (object ds in this._formErrors)
			{
				if (ds == null)
				{
					break;
				}

				yield return ds;
			}
		}

		public override FormError[] GetErrors(FormErrorType errorType)
		{
			return this._formErrors.Where(e => e.FormErrorType == errorType).ToArray();
		}

		public override FormError[] GetErrors(string name)
		{
			return this._formErrors.Where(e => e.Name == name).ToArray();
		}
	}
}
