using System;
using System.Reflection;

namespace Jive.net.Api.Serialization
{
	public class EntityPropertyMap
	{
		private readonly object _source;
		private readonly PropertyInfo _property;
		private string _name;
		public string Property { get { return _name ?? _property.Name; } set { _name = value; } }

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
 			return _property.GetValue(_source);
 		}
	}
}