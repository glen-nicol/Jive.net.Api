using System;

namespace Jive.Linq.DAL
{
	public interface IJiveFilter
	{
		string FilterType { get; }
		string Value { get; }
		string ToString();
	}

	class JiveFilter : IJiveFilter
	{

		public string FilterType { get; private set;}
		public string Value { get; private set; }

		public JiveFilter(string type, string val)
		{
			if(type == null)
				throw new ArgumentNullException("type");
			if(val == null)
				throw new ArgumentNullException("val");
			FilterType = type;
			Value = val;
		}

		public override string ToString()
		{
			return "filter=" + FilterType + "(" + Value + ")";
		}
	}
}