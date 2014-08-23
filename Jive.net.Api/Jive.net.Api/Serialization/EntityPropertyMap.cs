using System;
using System.Reflection;

namespace Jive.net.Api.Serialization
{
	public class EntityPropertyMap
	{
		private readonly object _source;
		private readonly MethodInfo _property;
		private string _name;
		public string Property { get { return _name ?? _property.Name.Substring(4); } set { _name = value; } }
		public Type Type { get { return _source.GetType(); } }

		public EntityPropertyMap(object src, MethodInfo prop)
		{
			if (src == null)
			{
				throw new ArgumentNullException("src");
			}
			if (prop == null)
			{
				throw new ArgumentNullException("prop");
			}
			_source = src;
			_property = prop;
		}

 		public object Value()
 		{
 			return _property.Invoke(_source, new object[0]);
 		}
	}
}