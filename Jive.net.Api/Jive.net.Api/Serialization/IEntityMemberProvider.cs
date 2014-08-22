using System.Collections.Generic;

namespace Jive.net.Api.Serialization
{
	public interface IEntityMemberProvider<in T>
	{
		IEnumerable<EntityPropertyMap> MembersToSerialize(T entity);
	}
}