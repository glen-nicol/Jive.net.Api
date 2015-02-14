using System;
using System.Globalization;
using Newtonsoft.Json;

namespace Jive.Linq.Models
{
	public class JiveContactInfo
	{
		public ContactInfoType Type { get { return (ContactInfoType)Enum.Parse(typeof(ContactInfoType),jive_label); }}
		public ContactInfoAccociation Association { get { return (ContactInfoAccociation)Enum.Parse(typeof(ContactInfoAccociation), CultureInfo.CurrentCulture.TextInfo.ToTitleCase(_type.ToLower())); } }

		[JsonProperty(PropertyName = "primary")]
		public bool Primary { get; private set; }
		[JsonProperty(PropertyName = "value")]
		public string Value { get; private set; }
		


		[JsonProperty(PropertyName = "jive_label")]
		private string jive_label { get; set; }
		[JsonProperty(PropertyName = "type")]
		private string _type { get; set; }

	}

	public enum ContactInfoType
	{
		Email
	}

	public enum ContactInfoAccociation
	{
		Home,
		Work,
		Other
	}
}