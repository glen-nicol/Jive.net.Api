using System;
using System.Reflection;

namespace Jive.Linq.Serialization
{
	public class EntityPropertyMap
	{
		private readonly object _source;
		private readonly PropertyInfo _property;
		private string _name;
		public string Property { get { return _name ?? _property.Name; } set { _name = value; } }
		public Type Type { get { return _source.GetType(); } }

		public EntityPropertyMap(object src, PropertyInfo prop)
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
 			return _property.GetGetMethod().Invoke(_source, new object[0]);
 		}
	}
}