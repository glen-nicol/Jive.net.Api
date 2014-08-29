using System;
using Jive.Linq.Serialization;

namespace Jive.Linq.Models
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