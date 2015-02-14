using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Jive.Linq.Models
{
	public class JivePerson : IJivePerson
	{
		public string ApiId{ get { return Id; } }

		public string Id { get; private set; }

		public IDictionary<string, JiveResource> Resources { get; private set; }

		public Uri ApiPath { get { return new Uri("/people"); } }
		[JsonProperty(PropertyName = "displayName")]
		public string DisplayName { get; private set; }

		public IEnumerable<JiveContactInfo> Emails { get; private set; }

		public string Familyname
		{
			get { return _names.familyName; }
			set { _names.familyName = value; }
		}

		public string GivenName
		{
			get { return _names.givenName; }
			set { _names.givenName = value; }
		}

		public string Formatted
		{
			get { return _names.formatted; }
			set { _names.formatted = value; }
		}

		[JsonProperty(PropertyName = "name")]
		private PersonNames _names { get; set; }

		
		private class PersonNames
		{
			public string givenName { get; set; }
			public string formatted { get; set; }
			public string familyName { get; set; }
		}
	}

	
}