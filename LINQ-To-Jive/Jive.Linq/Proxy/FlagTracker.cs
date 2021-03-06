﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Jive.Linq.Proxy
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

		public bool ObjectHasChanged()
		{
			return Changes().Any();
		}
	}
}