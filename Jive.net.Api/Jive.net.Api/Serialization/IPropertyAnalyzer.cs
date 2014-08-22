using System.Collections.Generic;

namespace Jive.net.Api.Serialization
{
	public interface IPropertyAnalyzer<in T>
	{
		IEnumerable<EntityPropertyMap> RequiredProperties(T entity);
		IEnumerable<EntityPropertyMap> OptionalProperties(T entity);
		IEnumerable<EntityPropertyMap> ExtraProperties(T entity);
	}
}