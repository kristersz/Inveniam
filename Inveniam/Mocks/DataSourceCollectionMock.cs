using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inveniam.Interfaces;
using Microsoft.Office.InfoPath;

namespace Inveniam.Mocks
{
	public class DataSourceCollectionMock : DataSourceCollection, IMockCollection<DataSource, DataSourceMock>
	{
		private List<DataSourceMock> _dataSources;

		public DataSourceCollectionMock()
		{
			this._dataSources = new List<DataSourceMock>();
		}

		public void Add(DataSourceMock ds)
		{
			this._dataSources.Add(ds);
		}

		public void Remove(string name)
		{
			var ds = this._dataSources.FirstOrDefault(d => d.Name == name);
			if (ds == null)
			{
				return;
			}

			this._dataSources.Remove(ds);
		}

		public override int Count
		{
			get
			{
				return this._dataSources.Count;
			}
		}

		public override DataSource this[int index]
		{
			get
			{
				return this._dataSources.ElementAt(index);
			}
		}

		public override DataSource this[string name]
		{
			get
			{
				return this._dataSources.FirstOrDefault(d => d.Name == name);
			}
		}

		public override IEnumerator GetEnumerator()
		{
			foreach (object ds in this._dataSources)
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
