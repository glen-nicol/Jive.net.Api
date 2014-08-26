using System;
using Jive.net.Serialization;

namespace Jive.net.Models
{
	[JiveApiReadOnly]
	public class JiveSummary
	{
		public Uri Answer { get; private set; }
		public Uri Html { get; private set; }
		public string Id { get; private set; }
		public string Name { get; private set; }
		public bool Question { get; private set; }
		public string Resolved { get; private set; }
		public JiveContentType Type { get; private set; }
		public Uri Uri { get; private set; }
	}
}