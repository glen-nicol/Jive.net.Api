using Jive.Linq.Models;

namespace Jive.Linq.DAL
{
	public class JiveContext
	{
		public Query<IJiveContent> Content { get; private set; }

		public JiveContext(JiveApiQueryProvider provider)
		{
			Content = new Query<IJiveContent>(provider);
		}

		public JiveContext(IAuthenticateJive authenticator)
		{
			Content = new Query<IJiveContent>(new JiveApiQueryProvider(new AuthenticatedRequester(authenticator,new HttpRequester()), "/contents"));
		}

		public JiveContext(IHttpRequester requester)
		{
			
		}
	}
}