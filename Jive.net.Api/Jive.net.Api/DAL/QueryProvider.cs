using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Jive.net.DAL
{
	//http://blogs.msdn.com/b/mattwar/archive/2007/07/30/linq-building-an-iqueryable-provider-part-i.aspx
	public abstract class QueryProvider : IQueryProvider
	{
		protected QueryProvider()
		{
		}

		IQueryable<S> IQueryProvider.CreateQuery<S>(Expression expression)
		{
			return new Query<S>(this, expression);
		}

		IQueryable IQueryProvider.CreateQuery(Expression expression)
		{
			var elementType = TypeSystem.GetElementType(expression.Type);
			try
			{
				return (IQueryable)Activator.CreateInstance(typeof(Query<>).MakeGenericType(elementType), new object[] { this, expression });
			}
			catch (TargetInvocationException tie)
			{
				throw tie.InnerException;
			}
		}

		S IQueryProvider.Execute<S>(Expression expression)
		{
			return (S)Execute(expression);
		}

		public abstract string GetQueryText(Expression expression);
		public abstract object Execute(Expression expression);
	}
}