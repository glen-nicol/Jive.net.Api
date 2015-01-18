using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Jive.Linq.DAL;

namespace Jive.Linq.Api.Test
{
	public class MemoryRequester: IHttpRequester
	{
		private readonly CancellationTokenSource _cts = new CancellationTokenSource();
		private readonly IDictionary<string, string> _entities = new Dictionary<string, string>();
		private int _counter = 1;

		public HttpResponseMessage Send(HttpRequestMessage req)
		{
			var task = SetupSendAsync(req, _cts.Token);
			task.RunSynchronously();
			try
			{
				return task.Result;
			}
			catch (AggregateException ae)
			{
				throw ae.InnerException;
			}
		}

		public Task<HttpResponseMessage> SendAsync(HttpRequestMessage req)
		{
			throw new NotImplementedException();
		}

		public Task<HttpResponseMessage> SendAsync(HttpRequestMessage req, CancellationToken token)
		{
			var task = SetupSendAsync(req, token);
			task.Start();
			return task;
		}

		private Task<HttpResponseMessage> SetupSendAsync(HttpRequestMessage req, CancellationToken token)
		{
			return new Task<HttpResponseMessage>(() => ServeRequest(req), token);
		}

		private HttpResponseMessage ServeRequest(HttpRequestMessage req)
		{
			var uri = req.RequestUri.ToString();
			if (req.Method == HttpMethod.Get)
			{
				try
				{
					var data = _entities[uri];
					return new HttpResponseMessage
						{
							StatusCode = HttpStatusCode.OK,
							Content = new StringContent(data)
						};
				}
				catch (KeyNotFoundException)
				{
					return new HttpResponseMessage
						{
							StatusCode = HttpStatusCode.NotFound
						};
				}
			}else if (req.Method == HttpMethod.Post)
			{
				var data = req.Content.ReadAsStringAsync().Result;
				data = "{'id':" + _counter + "," + data.Substring(1);
				_entities[uri +"/"+ _counter++] = data;
				return new HttpResponseMessage
					{
						StatusCode = HttpStatusCode.OK,
						Content = new StringContent(data)
					};
			}else if (req.Method == HttpMethod.Put)
			{
				var data = req.Content.ReadAsStringAsync().Result;
					if (!_entities.ContainsKey(uri))
					{
						return new HttpResponseMessage
						{
							StatusCode = HttpStatusCode.NotFound
						};
					}

					_entities[uri] = data;
					return new HttpResponseMessage
						{
							StatusCode = HttpStatusCode.NoContent,
							Content = new StringContent(data)
						};

			}else if (req.Method == HttpMethod.Delete)
			{
				_entities.Remove(uri);
				return new HttpResponseMessage
					{
						StatusCode = HttpStatusCode.NoContent
					};
			}
			else
			{
				throw new NotSupportedException(string.Format("{0} is not supported on the memory requester.", req.Method));
			}
		}
	}
}