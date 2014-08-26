using System;
using System.Collections.Generic;
using Jive.net.Serialization;
using System.Linq;

namespace Jive.net.Models
{
	public abstract class JiveContent : IJiveContent
	{
		public virtual string ApiId { get { return ContentId; } }
		public virtual string ContentId { get; private set; }
		public string Id { get; private set; }
		public virtual IEnumerable<IJiveResource> Resources { get; private set; }
		public string ApiPath { get { return "contents"; } }
		public abstract JiveContentType Type {  get;  }
		public virtual IJiveBody Body { get; set; }
		public virtual string Subject { get; set; }
	}

	public class Discussion : JiveContent
	{
		public override JiveContentType Type
		{
			get { return JiveContentType.Discussion; }
		}

		[JiveApiOptional]
		public virtual ICollection<string>  Categories { get; set; }
		[JiveApiOptional]
		public OnBehalfOf OnBehalfOf { get;  set; }
		[JiveApiOptional]
		public virtual ICollection<JiveOutComeType> OutcomeTypes { get; private set; }
		[JiveApiOptional]
		public Uri Parent { get; set; }
		[JiveApiOptional]
		public string Resolved { get; set; }

		[JiveApiReadOnly]
		public virtual Uri Answer { get; private set; }
		[JiveApiReadOnly]
		public virtual JivePerson Person { get; private set; }
		[JiveApiReadOnly]
		public virtual ulong FollowerCount { get; private set; }
		[JiveApiReadOnly]
		public virtual IEnumerable<Uri> Helpful { get; private set; }
		[JiveApiReadOnly]
		public virtual ulong Likes { get; private set; }
		[JiveApiReadOnly]
		public virtual IEnumerable<string> Tags { get; set; }
		[JiveApiOptional]
		public  virtual ICollection<string> Users { get;  set; }
		[JiveApiOptional]
		public virtual JiveVia Via { get; set; }
		[JiveApiOptional]
		public virtual string Visibility { get; set; }

		[JiveApiReadOnly]
		public IEnumerable<string> OutcomeTypeNames { get { return OutcomeTypes.Select(o => o.Name); } }
		[JiveApiReadOnly]
		public virtual JiveSummary ParentSummary { get; private set; }
		[JiveApiReadOnly]
		public virtual bool ParentContentVisible { get; private set; }
		[JiveApiReadOnly]
		public virtual JiveSummary ParentPlace { get; private set; }
		[JiveApiReadOnly]
		public virtual bool ParentVisible { get; private set; }
		[JiveApiReadOnly]
		public virtual DateTime Published { get; private set; }
		[JiveApiReadOnly]
		public virtual bool Question { get; private set; }
		[JiveApiReadOnly]
		public virtual ulong ReplyCount { get; private set; }
		[JiveApiReadOnly]
		public virtual int I { get; private set; }
		[JiveApiReadOnly]
		public virtual bool RestrictReplies { get; private set; }
		[JiveApiReadOnly]
		public virtual string Status { get; private set; }
		[JiveApiReadOnly]
		public virtual DateTime Updated { get; private set; }
		[JiveApiReadOnly]
		public virtual ulong ViewCount { get; private set; }
		[JiveApiReadOnly]
		public virtual bool VisibleToExternalContributors { get; private set; }


	}
}