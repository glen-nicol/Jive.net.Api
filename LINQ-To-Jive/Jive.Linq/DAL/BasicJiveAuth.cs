using System.Security.Authentication;

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

		public bool OAuth
		{
			get { return false; }
		}

		public virtual string GetAuthorizationToken()
		{
			return _username + ":" + _password;
		}

		public virtual void HandleRefreshToken(RefreshToken token)
		{
			throw new System.NotImplementedException();
		}
	}
}