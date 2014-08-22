using System.IO;

namespace Jive.net.Api.Serialization
{
	public class JsonSerializer<T> : ISerialize<T>
	{
		public Stream Serialize(T entity)
		{
			throw new System.NotImplementedException();
		}

		public byte[] BlockSerialize(T entity)
		{
			throw new System.NotImplementedException();
		}
	}
}