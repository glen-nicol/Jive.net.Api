using System;
using System.Linq.Expressions;
using System.Text;
using Jive.Linq.DAL;

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
			//var sb = new StringBuilder("/");
			//sb.Append(_jiveObjectApiSearchPrefix);
			//sb.Append("?");
			var calls = Translate(expression);

			return string.Join("\n",calls);
		}

		public override object Execute(Expression expression)
		{
			return Translate(expression);
		}

		private static ApiCallCollection Translate(Expression expression)
		{
			expression = Evaluator.PartialEval(expression);
			return new JiveApiQueryTranslator().Translate(expression);
		}
	}
}