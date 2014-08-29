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
			 Assert.AreEqual("/search/contents?",prov.GetQueryText(null));
		 }

		[Test]
		public void ProducesFilterForSearch()
		{
			var prov = new JiveApiQueryProvider("contents");
			var ctx = new JiveContext(prov);
			var content = from c in ctx.Content
				where c.Subject == "A"
				select c;

			Assert.AreEqual("/search/contents?&search=(A)", prov.GetQueryText(content.Expression));
		}
	}
}