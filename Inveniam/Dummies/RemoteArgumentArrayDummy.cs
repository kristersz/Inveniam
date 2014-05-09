using System;
using System.AddIn.Contract;
using System.AddIn.Contract.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inveniam.Dummies
{
	public class RemoteArgumentArrayDummy : IRemoteArgumentArrayContract
	{
		public int AcquireLifetimeToken()
		{
			return 0;

		}

		public int GetCount()
		{
			return 0;
		}

		public IRemoteArgumentEnumeratorContract GetEnumeratorContract()
		{
			return null;
		}

		public RemoteArgument GetItem(int index)
		{
			return new RemoteArgument();
		}

		public int GetRemoteHashCode()
		{
			return 0;
		}

		public IContract QueryContract(string contractIdentifier)
		{
			return null;
		}

		public bool RemoteEquals(IContract contract)
		{
			return true;
		}

		public string RemoteToString()
		{
			return null;
		}

		public void RevokeLifetimeToken(int token)
		{

		}

		public void SetItem(int index, RemoteArgument value)
		{

		}
	}
}
