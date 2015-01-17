using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jive.Linq.DAL
{
	public class ApiCallCollection : ICollection<string>
	{
		private readonly ICollection<string> _restCalls = new List<string>();

		public void AddRestCall(string suffix)
		{
			_restCalls.Add(suffix);
		}

		public IEnumerator<string> GetEnumerator()
		{
			return _restCalls.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public void Add(string apiCall)
		{
			AddRestCall(apiCall);
		}

		public void Clear()
		{
			_restCalls.Clear();
		}

		public bool Contains(string item)
		{
			return _restCalls.Contains(item);
		}

		public void CopyTo(string[] array, int arrayIndex)
		{
			_restCalls.CopyTo(array,arrayIndex);
		}

		public bool Remove(string item)
		{
			return _restCalls.Remove(item);
		}

		public int Count
		{
			get { return _restCalls.Count; }
		}

		public bool IsReadOnly
		{
			get { return _restCalls.IsReadOnly; }
		}
	}
}
