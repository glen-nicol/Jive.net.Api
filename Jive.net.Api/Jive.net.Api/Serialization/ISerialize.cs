using System.IO;

namespace Jive.net.Serialization
{
	public interface ISerialize<in T>
	{
		byte[] ByteSerialize(T entity);
		string StringSerialize(T entity);
	}
}