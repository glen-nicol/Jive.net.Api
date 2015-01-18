using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Jive.Linq.DAL
{
	public class AuthenticatedRequester : IHttpRequester
	{
		private readonly IAuthenticateJive _authenticator;
		private readonly IHttpRequester _requester;

		public AuthenticatedRequester(IAuthenticateJive auth, IHttpRequester requester)
		{
			if (auth == null)
			{
				throw new ArgumentNullException("auth");
			}
			if (requester == null)
			{
				throw new ArgumentNullException("requester");
			}
			if (requester is AuthenticatedRequester)
			{
				throw new ArgumentException("That requester is already authorized.");
			}
			_authenticator = auth;
			_requester = requester;
		}

		public HttpResponseMessage Send(HttpRequestMessage req)
		{
			AuthenticateMessage(req);
			return _requester.Send(req);
		}

		public Task<HttpResponseMessage> SendAsync(HttpRequestMessage req)
		{
			AuthenticateMessage(req);
			return _requester.SendAsync(req);
		}

		public Task<HttpResponseMessage> SendAsync(HttpRequestMessage req, CancellationToken token)
		{
			AuthenticateMessage(req);
			return _requester.SendAsync(req, token);
		}

		private void AuthenticateMessage(HttpRequestMessage req)
		{
			req.Headers.Authorization = _authenticator.GetAuthorizationToken();
		}
	}
}