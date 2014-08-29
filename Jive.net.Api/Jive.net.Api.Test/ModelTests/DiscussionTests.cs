using System;
using Jive.Linq.Models;
using NUnit.Framework;

namespace Jive.Linq.Test.ModelTests
{
	public class DiscussionTests
	{

		[Test]
		public void ReturnDiscussionForType()
		{
			var discussion = new Discussion ();
			Assert.AreEqual("Discussion", discussion.Type.ToString());
		}

		[Test]
		public void CanSetSubject()
		{
			var discussion = new Discussion {Subject = "a"};
			Assert.AreEqual("a", discussion.Subject);
		}

		[Test]
		public void EmptySubjectThrows()
		{
			Assert.Throws<ArgumentNullException>(() =>
				{
					var d = new Discussion() {Subject = ""};
				});
		}

		[Test]
		public void CanSetBody()
		{
			const string content = "<p>Roger Moore</p>";
			var discussion = new Discussion { Body = new JiveBody{Text = content} };
			Assert.AreEqual(content, discussion.Body.Text);
		}

		[Test]
		public void BodyTypeDefaultsToHtml()
		{
			var discussion = new Discussion { Body = new JiveBody () };
			Assert.AreEqual("text/html", discussion.Body.Type);
		}

		[Test]
		public void BodyTextDefaultsToEmpty()
		{
			var discussion = new Discussion { Body = new JiveBody() };
			Assert.AreEqual("", discussion.Body.Text);
		}
	}
}