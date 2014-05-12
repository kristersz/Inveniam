using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces.Inveniam
{
	public interface IMockContainer
	{
		string Name { get; }
		void SetName(string name);
	}
}
