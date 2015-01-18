using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Jive.Linq.DAL
{
	public interface IHttpRequester
	{
		HttpResponseMessage Send(HttpRequestMessage req);
		Task<HttpResponseMessage> SendAsync(HttpRequestMessage req);
		Task<HttpResponseMessage> SendAsync(HttpRequestMessage req, CancellationToken token);
	}

	public class HttpRequester : IHttpRequester
	{
		public HttpResponseMessage Send(HttpRequestMessage req)
		{
			var client = new HttpClient();
			var task = client.SendAsync(req);
			task.RunSynchronously();
			return task.Result;
		}

		public Task<HttpResponseMessage> SendAsync(HttpRequestMessage req)
		{
			var client = new HttpClient();
			return client.SendAsync(req);
		}

		public Task<HttpResponseMessage> SendAsync(HttpRequestMessage req, CancellationToken token)
		{
			var client = new HttpClient();
			return client.SendAsync(req, token);
		}
	}
}