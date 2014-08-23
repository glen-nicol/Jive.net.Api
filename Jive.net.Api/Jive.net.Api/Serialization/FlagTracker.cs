using System.Collections.Generic;
using System.Reflection;

namespace Jive.net.Api.Serialization
{
	class FlagTracker : ITrackChanges
	{
		private readonly IDictionary<string, MethodInfo> _changes;

		public FlagTracker()
		{
			_changes = new Dictionary<string, MethodInfo>();
		}

		public void MarkMemberChanged(MethodInfo method)
		{
			throw new System.NotImplementedException();
		}

		public IEnumerable<MethodInfo> Changes()
		{
			return _changes.Values;
		}
	}
}