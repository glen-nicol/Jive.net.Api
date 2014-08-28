using System;
using System.Collections.Generic;
using Jive.net.Serialization;

namespace Jive.net.Models
{
	public interface IJiveApiObject
	{
		[JiveApiReadOnly]
		string ApiId { get; }
		[JiveApiReadOnly]
		string Id { get; }
		IEnumerable<IJiveResource> Resources { get; }
		Uri ApiPath { get; }
	}
}