using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Jive.net.Serialization
{
	public class JsonSerializer<T> : ISerialize<T>
	{
		private readonly IEntityMemberProvider<T> _memberProvider;
 
		public JsonSerializer(IEntityMemberProvider<T> provider)
		{
			if (provider == null)
			{
				throw new ArgumentNullException("provider");
			}
			_memberProvider = provider;
		}

		public byte[] ByteSerialize(T entity)
		{
			var json = StringSerialize(entity);
			var bytes = new byte[json.Length * sizeof(char)];
			System.Buffer.BlockCopy(json.ToCharArray(), 0, bytes, 0, bytes.Length);
			return bytes;
		}

		public string StringSerialize(T entity)
		{
			var json = new JObject();
			foreach (var member in _memberProvider.MembersToSerialize(entity))
			{
				json[member.Property] = JsonConvert.SerializeObject( member.Value());
			}
			return JsonConvert.SerializeObject(json);
		}
	}
}