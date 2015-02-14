using System;
using System.Collections.Generic;
using Jive.Linq.Serialization;
using Newtonsoft.Json;

namespace Jive.Linq.Models
{
	[JiveApiReadOnly]
	public class JiveOutComeType : IJiveApiObject
	{
		[JsonProperty(PropertyName = "communityAudience")]
		public string CommunityAudience	 { get; private set; }
		public string ConfirmContentEdit { get; private set; }
		[JsonProperty(PropertyName = "confirmExclusion")]
		public bool ConfirmExclusion { get; set; }
		[JsonProperty(PropertyName = "confirmUnmark")]
		public bool ConfirmUnmark { get; private set; }
		public IEnumerable<JiveField> Fields { get; private set; }
		[JsonProperty(PropertyName = "generalNote")]
		public bool GeneralNote { get; set; }
		public string ApiId { get { return Id; } }
		public string Id { get; private set; }
		[JsonProperty(PropertyName = "name")]
		public string Name { get; private set; }
		[JsonProperty(PropertyName = "noteRequired")]
		public bool NoteRequired { get; private set; }
		public IDictionary<string,JiveResource> Resources { get; private set; }
		public Uri ApiPath { get { return new Uri("/outcomeTypes"); } }
		[JsonProperty(PropertyName = "shareable")]
		public bool Shareable { get; private set; }
		[JsonProperty(PropertyName = "urlAllowed")]
		public bool UrlAllowed { get; private set; }

	}
}