using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Jive.net.Serialization
{
	public class JiveAttributeAnalyzer : IPropertyAnalyzer
	{
		public IEnumerable<PropertyInfo> RequiredProperties(Type type)
		{
			return type.GetProperties().Where(p =>
				{
					var optional = IsVirtual(p);
					var readOnly = ReadOnly(p);
					return !optional && !readOnly;
				});
		}

		public IEnumerable<PropertyInfo> OptionalProperties(Type type)
		{
			return type.GetProperties().Where(p =>
				{
					var optional = IsVirtual(p);
					var readOnly = ReadOnly(p);
					return optional && !readOnly;
				});
		}

		private static bool ReadOnly(PropertyInfo p)
		{
			return p.GetCustomAttributes(typeof(JiveApiReadOnly), true).Any();
		}

		private static bool IsVirtual(PropertyInfo p)
		{
			return p.GetCustomAttributes(typeof(JiveApiOptional), true).Any();
		}
	}
}