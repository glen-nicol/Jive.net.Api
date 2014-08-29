using System;
using System.Collections.Generic;

namespace Jive.Linq.Models
{
	public abstract class JiveContent : IJiveContent
	{
		public virtual string ApiId { get { return ContentId; } }
		public virtual string ContentId { get; private set; }
		public string Id { get; private set; }
		public virtual IEnumerable<IJiveResource> Resources { get; private set; }
		public Uri ApiPath { get { return new Uri("/contents"); } }
		public abstract JiveContentType Type {  get;  }
		public virtual JiveBody Body { get; set; }
		private string _subject;
		public virtual string Subject
		{
			get { return _subject; }
			set
			{
			if (string.IsNullOrEmpty(value))
			{
				throw new ArgumentNullException("Subject");
			}
			_subject = value;
		} }
	}
}