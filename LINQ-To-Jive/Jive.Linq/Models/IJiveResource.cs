using System;
using System.Collections.Generic;
using Jive.Linq.Serialization;

namespace Jive.Linq.Models
{
	[JiveApiReadOnly]
	public interface IJiveResource
	{
		string Name { get; }
		Uri Ref { get; }
		IEnumerable<JiveResourceVerb> Allowed { get; }
	}

	public enum JiveResourceVerb
	{
		Get,
		Post,
		Update,
		Delete
	}
}