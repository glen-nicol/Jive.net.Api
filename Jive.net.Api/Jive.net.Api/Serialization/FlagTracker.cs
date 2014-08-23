using System.Collections.Generic;
using System.Reflection;

namespace Jive.net.Api.Serialization
{
	public class FlagTracker : ITrackChanges
	{
		private readonly IDictionary<string, MethodInfo> _changes;

		public FlagTracker()
		{
			_changes = new Dictionary<string, MethodInfo>();
		}

		public void MarkMemberChanged(MethodInfo method)
		{
			_changes[method.Name] = method;
		}

		public IEnumerable<MethodInfo> Changes()
		{
			return _changes.Values;
		}
	}
}