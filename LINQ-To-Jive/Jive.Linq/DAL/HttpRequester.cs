using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Jive.Linq.DAL
{
	public class HttpRequester : IHttpRequester
	{
		public virtual HttpResponseMessage Send(HttpRequestMessage req)
		{
			var client = new HttpClient();
			var task = client.SendAsync(req);
			task.RunSynchronously();
			return task.Result;
		}

		public virtual Task<HttpResponseMessage> SendAsync(HttpRequestMessage req)
		{
			var client = new HttpClient();
			return client.SendAsync(req);
		}

		public virtual Task<HttpResponseMessage> SendAsync(HttpRequestMessage req, CancellationToken token)
		{
			var client = new HttpClient();
			return client.SendAsync(req, token);
		}
	}
}