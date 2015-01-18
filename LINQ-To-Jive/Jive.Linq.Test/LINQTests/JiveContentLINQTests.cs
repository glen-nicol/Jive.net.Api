using System.Linq;
using System.Linq.Expressions;
using Jive.Linq.Api.Test;
using Jive.Linq.DAL;
using Jive.Linq.Models;
using NUnit.Framework;

namespace Jive.Linq.Test.LINQTests
{
	public class JiveContentLinqTests
	{
		 [Test]
		 public void ProducesValidRootUrl()
		 {
			 var prov = new JiveApiQueryProvider(new MemoryRequester(), "contents");
			 Assert.AreEqual("/contents?",prov.GetQueryText(null));
		 }

		[Test]
		public void ProducesFilterForSearchOnSubject()
		{
			var prov = new JiveApiQueryProvider(new MemoryRequester(), "contents");
			var ctx = new JiveContext(prov);
			var content = from c in ctx.Content
				where c.Subject == "A"
				select c;

			Assert.AreEqual("/contents?filter=search(A)", prov.GetQueryText(content.Expression));
		}

		[Test]
		public void EscapesAllSpecialCharactersInSubject()
		{
			var prov = new JiveApiQueryProvider(new MemoryRequester(), "contents");
			var ctx = new JiveContext(prov);
			var content = from c in ctx.Content
						  where c.Subject == ",()\\"
						  select c;

			Assert.AreEqual("/contents?filter=search(\\,\\(\\)\\\\)", prov.GetQueryText(content.Expression));
		}

		[Test]
		public void ProducesFilterForSearchOnContent()
		{
			var prov = new JiveApiQueryProvider(new MemoryRequester(), "contents");
			var ctx = new JiveContext(prov);
			var content = from c in ctx.Content
						  where c.Body.Text == "A"
						  select c;

			Assert.AreEqual("/contents?filter=search(A)", prov.GetQueryText(content.Expression));
		}

		[Test]
		public void ProducesFilterForSearchOnMultipleSubjects()
		{
			var prov = new JiveApiQueryProvider(new MemoryRequester(), "contents");
			var ctx = new JiveContext(prov);
			var content = from c in ctx.Content
						  where (c.Subject == "A" || c.Subject == "B")
						  select c;

			Assert.AreEqual("/contents?filter=search(A,B)", prov.GetQueryText(content.Expression));
		}

		[Test]
		public void ProducesFilterForSearchOnId()
		{
			var prov = new JiveApiQueryProvider(new MemoryRequester(), "contents");
			var ctx = new JiveContext(prov);
			var content = (from c in ctx.Content
						  where c.ContentId == "1"
						  select c);

			Assert.AreEqual("/contents/1", prov.GetQueryText(content.Expression));
		}

		[Test]
		public void ProducesFilterForSearchOnContentType()
		{
			var prov = new JiveApiQueryProvider(new MemoryRequester(), "contents");
			var ctx = new JiveContext(prov);
			var content = from c in ctx.Content
						  where (c.Type == JiveContentType.Discussion)
						  select c;

			Assert.AreEqual("/contents?filter=type(discussion)", prov.GetQueryText(content.Expression));
		}

		[Test]
		public void ProducesFilterForSearchOnMultipleContentTypes()
		{
			var prov = new JiveApiQueryProvider(new MemoryRequester(), "contents");
			var ctx = new JiveContext(prov);
			var content = from c in ctx.Content
						  where (c.Type == JiveContentType.Discussion || c.Type == JiveContentType.Document)
						  select c;

			Assert.AreEqual("/contents?filter=type(discussion,document)", prov.GetQueryText(content.Expression));
		}

		[Test]
		public void SupportsLocalStringVariable()
		{
			var prov = new JiveApiQueryProvider(new MemoryRequester(), "contents");
			var ctx = new JiveContext(prov);
			var s = "A";
			var content = from c in ctx.Content
						  where c.Subject == s
						  select c;

			Assert.AreEqual("/contents?filter=search(A)", prov.GetQueryText(content.Expression));
		}
	}
}