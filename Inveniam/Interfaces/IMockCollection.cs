using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inveniam.Interfaces
{
	public interface IMockCollection<TOriginal, TMock>
	{
		int Count { get; }
		TOriginal this[int index] { get; }
		TOriginal this[string name] { get; }
		void Add(TMock mockObject);
		void Remove(string name);
	}
}
