using System;
using System.Net;
using System.Net.Http;
using Jive.Linq.Api.Test;
using NUnit.Framework;

namespace Jive.Linq.Test
{
	public class MemoryRequesterTests
	{
		[Test]
		public void CanGet()
		{
			var r = new MemoryRequester();
			CreateEntity(r);
			var get = new HttpRequestMessage
			{
				RequestUri = new Uri("http://localhost/entities/1"),
				Method = HttpMethod.Get
			};
			var res = r.Send(get);
			Assert.AreEqual(HttpStatusCode.OK,res.StatusCode);
			Assert.Greater(res.Content.ReadAsStringAsync().Result.IndexOf("bob"),0);
		}

		[Test]
		public void ReturnsNotFoundOnGet()
		{
			var r = new MemoryRequester();
			var get = new HttpRequestMessage
				{
					RequestUri = new Uri("http://localhost/entities/1"),
					Method = HttpMethod.Get
				};
			Assert.AreEqual( HttpStatusCode.NotFound, r.Send(get).StatusCode );
		}

		[Test]
		public void ReturnsNotFoundOnPut()
		{
			var r = new MemoryRequester();
			var put = new HttpRequestMessage
			{
				RequestUri = new Uri("http://localhost/entities/1"),
				Method = HttpMethod.Put,
				Content = new StringContent("{'title': 'bob'}")
			};
			Assert.AreEqual(HttpStatusCode.NotFound, r.Send(put).StatusCode);
		}

		[Test]
		public void AddsIdOnPost()
		{
			var r = new MemoryRequester();
			CreateEntity(r);
		}

		private static void CreateEntity(MemoryRequester r)
		{
			var post = new HttpRequestMessage
				{
					RequestUri = new Uri("http://localhost/entities"),
					Method = HttpMethod.Post,
					Content = new StringContent("{'title':'bob'}")
				};
			var res = r.Send(post);
			Assert.AreEqual(res.StatusCode, HttpStatusCode.OK);
			Assert.Greater(res.Content.ReadAsStringAsync().Result.IndexOf("'id':1"), 0);
		}
	}
}