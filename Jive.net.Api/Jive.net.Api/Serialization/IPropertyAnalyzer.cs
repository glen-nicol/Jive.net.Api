using System;
using System.Collections.Generic;
using System.Reflection;

namespace Jive.net.Serialization
{
	public interface IPropertyAnalyzer
	{
		IEnumerable<PropertyInfo> RequiredProperties(Type type);
		IEnumerable<PropertyInfo> OptionalProperties(Type type); 
	}
}