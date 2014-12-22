using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Jive.Linq.Models;

namespace Jive.Linq.DAL
{
	class JiveApiFilterFactory
	{
		private bool IsSupportedMember(string name)
		{
			switch (name)
			{
				case "Subject":
				case "Type": 
					return true;
				default:
					return false;
			}
		}

		private static object ExtractValue(Expression b)
		{
			var expression = b as ConstantExpression;
			return expression != null ? expression.Value : null;
		}

		public IJiveFilter CreateFilter(BinaryExpression b)
		{
			MemberExpression filterSide;
			string value;
			try
			{
				filterSide = (MemberExpression)(b.Left.NodeType == ExpressionType.MemberAccess ? b.Left : b.Right);
				value = ExtractValue(filterSide == b.Left ? b.Right : b.Left).ToString();
			}
			catch (InvalidCastException)
			{
				var leftSide = b.Left.NodeType == ExpressionType.Convert;
				filterSide = (MemberExpression)((UnaryExpression)(leftSide ? b.Left : b.Right)).Operand;
				var name = Enum.GetName(typeof(JiveContentType), ExtractValue(leftSide ? b.Right : b.Left));
				value = name != null ? name.ToLower() : "";
			}
			
			
			if (IsSupportedMember(filterSide.Member.Name))
			{
				if (filterSide.Member.Name == "Type")
				{
					return new JiveFilter("type", value);
				}
				else
				{
					return new JiveFilter("search", value);
				}
				}
				
			else
			{
				throw new NotSupportedException("Cannot filter on " + filterSide.Member.Name);
			}
			
		}
	}
}
