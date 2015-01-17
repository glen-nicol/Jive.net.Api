using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Jive.Linq.Models;

namespace Jive.Linq.DAL
{
	public class FieldComparison
	{
		public string Field { get; private set; }
		public string Value { get; set; }
		public ExpressionType Comparison { get; private set; }

		FieldComparison(string f, string v, ExpressionType t)
		{
			Field = f;
			Value = v;
			Comparison = t;
		}

		public static FieldComparison Create(BinaryExpression b)
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

			return new FieldComparison(filterSide.Member.Name, value, b.NodeType);
		}

		private static object ExtractValue(Expression b)
		{
			var expression = b as ConstantExpression;
			return expression != null ? expression.Value : null;
		}
	}
}
