using System.Collections.Generic;
using System.Reflection;

namespace Jive.Linq.Proxy
{
	public interface ITrackChanges
	{
		void MarkMemberChanged(PropertyInfo property);
		IEnumerable<PropertyInfo> Changes();
		bool ObjectHasChanged();
	}
}