using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.InfoPath;

namespace Inveniam.Mocks
{
	public class DataConnectionMock : DataConnection
	{
		protected string _name;

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

		public override void Execute() { }
	}
}
