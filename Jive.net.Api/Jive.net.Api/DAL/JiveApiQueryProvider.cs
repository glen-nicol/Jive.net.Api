using System;
using System.Linq.Expressions;
using System.Text;
using Jive.Linq.DAL;
using Jive.Linq.Models;

namespace Jive.Linq.DAL
{
	public class JiveApiQueryProvider : QueryProvider
	{
		private readonly string _jiveObjectApiSearchPrefix;

		public JiveApiQueryProvider(string searchPrefix)
		{
			if (searchPrefix == null)
			{
				throw new ArgumentNullException("searchPrefix");
			}
			_jiveObjectApiSearchPrefix = searchPrefix;
		}

		public override string GetQueryText(Expression expression)
		{
			return Translate(expression);
		}

		public override object Execute(Expression expression)
		{
			return GetQueryText(expression);
		}

		private string Translate(Expression expression)
		{
			var sb = new StringBuilder("/search/");
			sb.Append(_jiveObjectApiSearchPrefix);
			sb.Append("?");
			sb.Append(new JiveApiQueryTranslator().Translate(expression));
			return sb.ToString();
		}
	}

	public class JiveContext
	{
		public Query<IJiveContent> Content { get; private set; }

		public JiveContext(JiveApiQueryProvider provider)
		{
			Content = new Query<IJiveContent>(provider);
		}

	}
}