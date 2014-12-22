using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jive.Linq.DAL
{
	public class JiveFilterCollection : ICollection<IJiveFilter>
	{
		private readonly IDictionary<string, IJiveFilter> _filters = new Dictionary<string, IJiveFilter>();

		public void Add(IJiveFilter f)
		{
			if (f.FilterType == "search" && _filters.ContainsKey(f.FilterType))
			{

				_filters[f.FilterType] = new JiveFilter(f.FilterType, _filters[f.FilterType].Value + "," + f.Value);
			}
			else
			{
				_filters[f.FilterType] = f;
			}
		}

		public void Clear()
		{
			_filters.Clear();
		}

		public bool Contains(IJiveFilter item)
		{
			return _filters[item.FilterType] != null;
		}

		public void CopyTo(IJiveFilter[] array, int arrayIndex)
		{
			throw new NotImplementedException();
		}

		public bool Remove(IJiveFilter item)
		{
			throw new NotImplementedException();
		}

		public int Count
		{
			get { return _filters.Count; }
		}

		public bool IsReadOnly
		{
			get { return false; }
		}

		public IEnumerator<IJiveFilter> GetEnumerator()
		{
			return _filters.Values.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
