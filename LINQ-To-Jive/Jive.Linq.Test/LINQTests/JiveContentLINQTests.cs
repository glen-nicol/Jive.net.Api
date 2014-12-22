using System.Linq;
using System.Linq.Expressions;
using Jive.Linq.DAL;
using Jive.Linq.Models;
using NUnit.Framework;

namespace Jive.Linq.Test.LINQTests
{
	public class JiveContentLINQTests
	{
		 [Test]
		 public void ProducesValidRootUrl()
		 {
			 var prov = new JiveApiQueryProvider("contents");
			 Assert.AreEqual("/contents?",prov.GetQueryText(null));
		 }

		[Test]
		public void ProducesFilterForSearchOnSubject()
		{
			var prov = new JiveApiQueryProvider("contents");
			var ctx = new JiveContext(prov);
			var s = "A";
			var content = from c in ctx.Content
				where c.Subject == s
				select c;

			Assert.AreEqual("/contents?filter=search(A)", prov.GetQueryText(content.Expression));
		}

		[Test]
		public void ProducesFilterForSearchOnMultipleSubjects()
		{
			var prov = new JiveApiQueryProvider("contents");
			var ctx = new JiveContext(prov);
			var content = from c in ctx.Content
						  where (c.Subject == "A" || c.Subject == "B")
						  select c;

			Assert.AreEqual("/contents?filter=search(A,B)", prov.GetQueryText(content.Expression));
		}
	}
}