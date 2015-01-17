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

	}
}