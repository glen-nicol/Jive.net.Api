using System;
using System.Collections.Generic;
using Jive.Linq.Serialization;
using Newtonsoft.Json;

namespace Jive.Linq.Models
{
	public interface IJiveApiObject
	{
		[JiveApiReadOnly]
		string ApiId { get; }
		[JiveApiReadOnly]
		[JsonProperty(PropertyName = "id")]
		string Id { get; }
		[JsonProperty(PropertyName = "resources")]
		IDictionary<string,JiveResource> Resources { get; }
		Uri ApiPath { get; }
	}
}