using System;
using System.Collections.Generic;
using System.IO;
using Jive.Linq.Proxy;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Jive.Linq.Serialization
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
			var dict = new Dictionary<string, object>();
			foreach (var member in _memberProvider.MembersToSerialize(entity))
			{
				dict[member.Property] =  member.Value();
			}
			return JsonConvert.SerializeObject(dict);
		}
	}
}