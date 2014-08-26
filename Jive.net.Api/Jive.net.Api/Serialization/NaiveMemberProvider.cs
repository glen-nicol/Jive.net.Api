using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jive.net.Proxy;

namespace Jive.net.Serialization
{
	public class NaiveMemberProvider<T> : IEntityMemberProvider<T>
	{
		private readonly IEntityPropertyAnalyzer<T> _analyzer;

		public NaiveMemberProvider(IEntityPropertyAnalyzer<T> analyzer)
		{
			if (analyzer == null)
			{
				throw new ArgumentNullException("analyzer");
			}
			_analyzer = analyzer;
		} 

		public IEnumerable<EntityPropertyMap> MembersToSerialize(T entity)
		{
			return _analyzer.RequiredProperties(entity).Union(_analyzer.OptionalProperties(entity).Where(o => o.Value() != null));
		}
	}
}
