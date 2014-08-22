using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jive.net.Api.Serialization
{
	public class JiveAnnotationAnalyzer<T> : IPropertyAnalyzer<T>
	{
		public IEnumerable<EntityPropertyMap> RequiredProperties(T entity)
		{
			return entity.GetType().GetProperties()
				.Where( p =>
					{
						var optional = p.GetCustomAttributes(typeof(JiveApiOptional), true).Any();
						var readOnly = p.GetCustomAttributes(typeof(JiveApiReadOnly), true).Any();
						return !optional && !readOnly;
					})
				.Select(p => new EntityPropertyMap(entity, p));
		}

		public IEnumerable<EntityPropertyMap> OptionalProperties(T entity)
		{
			return entity.GetType().GetProperties()
				.Where(p =>
				{
					var optional = p.GetCustomAttributes(typeof(JiveApiOptional), true).Any();
					var readOnly = p.GetCustomAttributes(typeof(JiveApiReadOnly), true).Any();
					return optional && !readOnly;
				})
				.Select(p => new EntityPropertyMap(entity, p));
		}
	}
}
