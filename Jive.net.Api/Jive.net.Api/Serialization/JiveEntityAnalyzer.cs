using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Jive.net.Api.Serialization
{
	public class JiveEntityAnalyzer<T> : IEntityPropertyAnalyzer<T>
	{
		public IPropertyAnalyzer _analyzer;

		public JiveEntityAnalyzer(IPropertyAnalyzer analyzer)
		{
			if (analyzer == null)
			{
				throw new ArgumentNullException("analyzer");
			}
			_analyzer = analyzer;
		}

		public IEnumerable<EntityPropertyMap> RequiredProperties(T entity)
		{
			return _analyzer.RequiredProperties(entity.GetType())
				.Select(p => new EntityPropertyMap(entity, p.GetGetMethod()));
		}

		public IEnumerable<EntityPropertyMap> OptionalProperties(T entity)
		{
			return _analyzer.OptionalProperties(entity.GetType())
				.Select(p => new EntityPropertyMap(entity, p.GetGetMethod()));
		}
	}
}
