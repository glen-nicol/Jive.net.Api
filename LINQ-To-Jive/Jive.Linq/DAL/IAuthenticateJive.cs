using System;
using System.Net.Http.Headers;
using System.Security;

namespace Jive.Linq.DAL
{
	public interface IAuthenticateJive
	{

		AuthenticationHeaderValue GetAuthorizationToken();
		/// <summary>
		/// This method is called when a new Jive refresh token is acquired.
		/// Override this function to store that token and update what is returned from
		/// GetAuthorizationToken method. 
		/// </summary>
		/// <param name="token">New Refresh token data</param>
		void HandleRefreshToken(RefreshToken token);
	}
}