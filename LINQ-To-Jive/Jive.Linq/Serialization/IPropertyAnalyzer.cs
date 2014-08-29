using System;
using System.Collections.Generic;
using System.Reflection;

namespace Jive.Linq.Serialization
{
	public interface IPropertyAnalyzer
	{
		IEnumerable<PropertyInfo> RequiredProperties(Type type);
		IEnumerable<PropertyInfo> OptionalProperties(Type type); 
	}
}