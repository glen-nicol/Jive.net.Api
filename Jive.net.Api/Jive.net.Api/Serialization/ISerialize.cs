using System.IO;

namespace Jive.net.Api.Serialization
{
	public interface ISerialize<T>
	{
		Stream Serialize(T entity);
		byte[] BlockSerialize(T entity);
	}
}