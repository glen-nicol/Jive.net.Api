using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Jive.Linq.Models
{
	public interface IJivePerson : IJiveApiObject
	{
		string DisplayName { get; }
		[JsonProperty(PropertyName = "emails")]
		IEnumerable<JiveContactInfo> Emails { get; }

		string Familyname { get; }
		string GivenName { get; }
		string Formatted { get; }

	}
}