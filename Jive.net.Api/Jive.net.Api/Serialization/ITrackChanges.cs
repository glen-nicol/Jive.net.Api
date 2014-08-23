using System.Collections.Generic;
using System.Reflection;

namespace Jive.net.Api.Serialization
{
	public interface ITrackChanges
	{
		void MarkMemberChanged(MethodInfo method);
		IEnumerable<MethodInfo> Changes();
	}
}