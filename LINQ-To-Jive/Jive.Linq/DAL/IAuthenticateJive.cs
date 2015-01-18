using System;
using System.Security;

namespace Jive.Linq.DAL
{
	public interface IAuthenticateJive
	{
		/// <summary>
		/// Indicates that a Bearer token is to be used for authentication instead of Basic.
		/// </summary>
		bool OAuth { get; }
		/// <summary>
		/// Provides the entire string for BASIC or Oauth bearer token.
		/// Do not encode in Base64.
		/// </summary>
		/// <returns>String to be used in Authorization header after Basic or Bearer indicator.</returns>
		string GetAuthorizationToken();
		/// <summary>
		/// This method is called when a new Jive refresh token is acquired.
		/// Override this function to store that token and update what is returned from
		/// GetAuthorizationToken method. 
		/// </summary>
		/// <param name="token">New Refresh token data</param>
		void HandleRefreshToken(RefreshToken token);
	}
}