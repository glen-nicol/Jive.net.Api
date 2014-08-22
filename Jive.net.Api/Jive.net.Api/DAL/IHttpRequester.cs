using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Jive.net.Api.DAL
{
	public interface IHttpRequester
	{
		HttpResponseMessage Send(HttpRequestMessage req);
		Task<HttpResponseMessage> SendAsync(HttpRequestMessage req, CancellationToken token);
	}
}