using System;
using System.Collections.Generic;
using System.Linq;
using Jive.Linq.Proxy;

namespace Jive.Linq.Serialization
{
	public interface IEntityMemberProvider<in T>
	{
		IEnumerable<EntityPropertyMap> MembersToSerialize(T entity);
	}

	public class ChangedPropertyProvider<T> : IEntityMemberProvider<T>
	{
		private readonly JiveEntityAnalyzer<T> _analyzer = new JiveEntityAnalyzer<T>(new JiveAttributeAnalyzer());
		private readonly ITrackChanges _tracker;

		public ChangedPropertyProvider(ITrackChanges tracker)
		{
			if (tracker == null)
			{
				throw new ArgumentNullException("tracker");
			}
			_tracker = tracker;
		}


		public IEnumerable<EntityPropertyMap> MembersToSerialize(T entity)
		{
			return _analyzer.RequiredProperties(entity).Union(_tracker.Changes().Select(m => new EntityPropertyMap(entity, m)));
		}
	}
}