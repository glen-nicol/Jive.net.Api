using System.IO;

namespace Jive.Linq.Serialization
{
	public interface ISerialize<in T>
	{
		byte[] ByteSerialize(T entity);
		string StringSerialize(T entity);
	}
}