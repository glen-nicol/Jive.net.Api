using System;
using System.Collections.Generic;
using System.Reflection;

namespace Jive.net.Serialization
{
	public class FlagTracker : ITrackChanges
	{
		private readonly IDictionary<string, PropertyInfo> _changes = new Dictionary<string, PropertyInfo>();

		public void MarkMemberChanged(PropertyInfo property)
		{
			if (property == null)
			{
				throw new ArgumentNullException("property");
			}
			_changes[property.Name] = property;
		}

		public IEnumerable<PropertyInfo> Changes()
		{
			return _changes.Values;
		}
	}
}