using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inveniam.Dummies;
using Inveniam.Mocks;
using Inveniam.Infrastructure.Helpers;
using InfoPathFakes = Microsoft.Office.InfoPath.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Inveniam.Infrastructure.Resources;

namespace Inveniam
{
	public class FormInstance<TFormCode> : IDisposable
		where TFormCode : class
	{
		private TFormCode _formCode;
		private DataSourceCollectionMock _dsCollection;
		private DataSourceMock _mainDataSource;
		private XmlNamespaceManagerDummy _namespaceManager;
		private FormStateMock _formState;
		private FormErrorCollectionMock _formErrorCollection;

		public TFormCode FormCode
		{
			get
			{
				return this._formCode;
			}
		}

		public DataSourceMock MainDataSource
		{
			get
			{
				return this._mainDataSource;
			}
		}
		public DataSourceCollectionMock DataSources
		{
			get
			{
				return this._dsCollection;
			}
		}

		public XmlNamespaceManagerDummy NamespaceManager
		{
			get
			{
				return this._namespaceManager;
			}
		}

		public FormStateMock FormState
		{
			get
			{
				return this._formState;
			}
		}

		public FormErrorCollectionMock FormErrorCollection
		{
			get
			{
				return this._formErrorCollection;
			}
		}

		public FormInstance()
		{
			this._dsCollection = new DataSourceCollectionMock();
			this._namespaceManager = new XmlNamespaceManagerDummy();
			this._formState = new FormStateMock(10);
			this._formErrorCollection = new FormErrorCollectionMock();
			this._formCode = (TFormCode)Activator.CreateInstance(typeof(TFormCode), new object[] { new RemoteArgumentArrayDummy() });

			// izveido Shims kontekstu, kas darbojas uz visu appdomain
			ShimsContext.Create();
			InfoPathFakes.ShimXmlFormHostItem.AllInstances.NamespaceManagerGet = (x) => this.NamespaceManager;
			InfoPathFakes.ShimXmlFormHostItem.AllInstances.DataSourcesGet = (x) => this._dsCollection;
			InfoPathFakes.ShimXmlFormHostItem.AllInstances.FormStateGet = (x) => this._formState;
			InfoPathFakes.ShimXmlFormHostItem.AllInstances.ErrorsGet = (x) => this._formErrorCollection;
		}

		public void AddMainDataSource<T>(T value, string methodName, string dataConnectionName)
		{
			var mainXml = XmlHelper<T>.CreateXmlFromValue(value, methodName);

			this._mainDataSource = new DataSourceMock(mainXml);
			this._mainDataSource.SetName(Names.MainDataSourceName);

			InfoPathFakes.ShimXmlFormHostItem.AllInstances.MainDataSourceGet = (x) => this._mainDataSource;
		}

		public void AddSecondaryDataSource<T>(T value, string methodName, string dataConnectionName)
		{
			var secondaryXml = XmlHelper<T>.CreateXmlFromValue(value, methodName);

			DataSourceMock secondaryDataSource = new DataSourceMock(secondaryXml);
			secondaryDataSource.SetName(dataConnectionName);

			this._dsCollection.Add(secondaryDataSource);
		}

		public void RemoveSecondaryDataSource(string name)
		{
			this._dsCollection.Remove(name);
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				ShimsContext.Create().Dispose();
			}
		}
	}
}
