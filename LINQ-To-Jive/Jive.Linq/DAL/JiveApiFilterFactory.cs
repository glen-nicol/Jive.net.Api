using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Jive.Linq.DAL
{
	class JiveApiFilterFactory
	{
		private bool IsSupportedMember(string name)
		{
			switch (name)
			{
				case "Subject":
					return true;
				default:
					return false;
			}
		}

		private static string ExtractValue(Expression b)
		{
			var expression = b as ConstantExpression;
			return expression != null ? expression.Value.ToString() : "";
		}

		public IJiveFilter CreateFilter(BinaryExpression b)
		{
			var filterSide = (MemberExpression) (b.Left.NodeType == ExpressionType.MemberAccess ? b.Left : b.Right);
			var value =  ExtractValue(filterSide == b.Left ? b.Right : b.Left);
			if (IsSupportedMember(filterSide.Member.Name))
			{
				return new JiveFilter("search",value);
			}
			else
			{
				throw new NotSupportedException("Cannot filter on " + filterSide.Member.Name);
			}
			
		}
	}
}
