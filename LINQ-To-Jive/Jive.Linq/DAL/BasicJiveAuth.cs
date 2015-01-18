using System;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Text;

namespace Jive.Linq.DAL
{
	public class BasicJiveAuth : IAuthenticateJive
	{
		private readonly string _username;
		private readonly string _password;

		public BasicJiveAuth(string user, string pass)
		{
			if (user == null || pass == null)
			{
				throw new InvalidCredentialException("User and Password cannot be null.");
			}
			_username = user;
			_password = pass;
		}

		public AuthenticationHeaderValue GetAuthorizationToken()
		{
			return new AuthenticationHeaderValue("Basic",Convert.ToBase64String(Encoding.Unicode.GetBytes(_username + ":" + _password)));
		}

		public virtual void HandleRefreshToken(RefreshToken token)
		{
			throw new System.NotImplementedException();
		}
	}
}