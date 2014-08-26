using System.Collections.Generic;
using System.Reflection;

namespace Jive.net.Serialization
{
	public interface ITrackChanges
	{
		void MarkMemberChanged(PropertyInfo property);
		IEnumerable<PropertyInfo> Changes();
	}
}