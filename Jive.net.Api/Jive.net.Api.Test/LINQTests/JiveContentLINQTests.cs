using System.Linq;
using System.Linq.Expressions;
using Jive.net.DAL;
using Jive.net.Models;
using NUnit.Framework;

namespace Jive.net.Api.Test.LINQTests
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