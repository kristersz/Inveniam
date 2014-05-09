using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.InfoPath;

namespace Inveniam.Mocks
{
	public class DataConnectionCollectionMock : DataConnectionCollection
	{
		private List<DataConnectionMock> _dataConnections;

		public DataConnectionCollectionMock()
		{
			this._dataConnections = new List<DataConnectionMock>();
		}

		public void Add(DataConnectionMock ds)
		{
			this._dataConnections.Add(ds);
		}

		public void Remove(string name)
		{
			var ds = this._dataConnections.FirstOrDefault(d => d.Name == name);
			if (ds == null)
			{
				return;
			}

			this._dataConnections.Remove(ds);
		}

		public override int Count
		{
			get
			{
				return this._dataConnections.Count;
			}
		}

		public override DataConnection this[int index]
		{
			get
			{
				return this._dataConnections.ElementAt(index);
			}
		}

		public override DataConnection this[string name]
		{
			get
			{
				return this._dataConnections.FirstOrDefault(d => d.Name == name);
			}
		}

		public override IEnumerator GetEnumerator()
		{
			foreach (object ds in _dataConnections)
			{
				if (ds == null)
				{
					break;
				}

				yield return ds;
			}
		}
	}
}
