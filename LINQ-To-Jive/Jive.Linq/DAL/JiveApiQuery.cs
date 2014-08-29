using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Jive.Linq.Models;

namespace Jive.Linq.DAL
{
	public abstract class JiveApiQuery<T> : IOrderedQueryable<T> where T : IJiveContent
	{

		public Expression Expression { get; private set; }
		public Type ElementType { get; private set; }
		public IQueryProvider Provider { get; private set; }

		protected  JiveApiQuery(IJiveQueryProvider provider, Expression expression)
        {
            if (provider == null)
            {
                throw new ArgumentNullException("provider");
            }

            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            if (!typeof(IQueryable<T>).IsAssignableFrom(expression.Type))
            {
                throw new ArgumentOutOfRangeException("expression");
            }

            Provider = provider;
            Expression = expression;
        }

		public IEnumerator<T> GetEnumerator()
		{
			return (Provider.Execute<IEnumerable<T>>(Expression)).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

	}
}