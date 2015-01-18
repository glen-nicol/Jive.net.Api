using System.Linq;
using Jive.Linq.Api.Test;
using Jive.Linq.DAL;
using NUnit.Framework;

namespace Jive.Linq.Test.LINQTests
{
	public class JiveContextTest
	{
		[Test]
		public void CanGetContent()
		{
			var prov = new JiveApiQueryProvider(new MemoryRequester(), "/Content");
			var ctx = new JiveContext(prov);
			var c = ctx.Content;
			Assert.IsNotNull(c);
		} 
	}
}