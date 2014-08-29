using System;
using System.Collections.Generic;
using Jive.Linq.Serialization;

namespace Jive.Linq.Models
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