using System;
using System.Collections.Generic;
using Jive.net.Serialization;

namespace Jive.net.Models
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