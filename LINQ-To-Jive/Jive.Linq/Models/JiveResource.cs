using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Jive.Linq.Serialization;
using Newtonsoft.Json;

namespace Jive.Linq.Models
{

	[JiveApiReadOnly]
	public class JiveResource
	{
		public string Name { get; private set; }

		[JsonProperty(PropertyName = "ref")]
		public Uri Ref { get; private set; }
		
		[JsonIgnore]
		public IEnumerable<JiveResourceVerb> Allowed { get
		{
			return _Allowed.Select(v => (JiveResourceVerb)Enum.Parse(typeof(JiveResourceVerb), CultureInfo.CurrentCulture.TextInfo.ToTitleCase(v.ToLower())));
		}}

		[JsonProperty(PropertyName = "allowed")]
		private string[] _Allowed { get; set; }
	}

	public enum JiveResourceVerb
	{
		Get,
		Post,
		Put,
		Patch,
		Delete
	}
}