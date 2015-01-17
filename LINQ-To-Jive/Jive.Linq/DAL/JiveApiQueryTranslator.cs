using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ExpressionVisitor = Jive.Linq.DAL.ExpressionVisitor;

namespace Jive.Linq.DAL
{
	//http://blogs.msdn.com/b/mattwar/archive/2007/07/31/linq-building-an-iqueryable-provider-part-ii.aspx
	internal class JiveApiQueryTranslator : ExpressionVisitor
	{

		
		private readonly JiveApiFilterFactory _factory = new JiveApiFilterFactory();
		private readonly JiveFilterCollection _filters = new JiveFilterCollection();
		private readonly ApiCallCollection _apiCalls = new ApiCallCollection();
		internal JiveApiQueryTranslator()
		{
		}

		internal ApiCallCollection Translate(Expression expression)
		{

			this.Visit(expression);
			if (_filters.Count > 0)
			{
				_apiCalls.AddRestCall("/contents?" + string.Join("&", _filters.Select(f => f.ToString())));
			}
			if (_apiCalls.Count == 0)
			{
				_apiCalls.AddRestCall("/contents?");
			}

			return  _apiCalls;
		}

		private static Expression StripQuotes(Expression e)
		{
			while (e.NodeType == ExpressionType.Quote)
			{
				e = ((UnaryExpression)e).Operand;
			}
			return e;
		}

		protected override Expression VisitMethodCall(MethodCallExpression m)
		{
			if (m.Method.DeclaringType == typeof(Queryable) && m.Method.Name == "Where")
			{
				
				this.Visit(StripQuotes(m.Arguments[1]));
				return m;
			}
			throw new NotSupportedException(string.Format("The method '{0}' is not supported", m.Method.Name));
		}

		protected override Expression VisitUnary(UnaryExpression u)
		{
			switch (u.NodeType)
			{
				case ExpressionType.Not:
				case ExpressionType.Convert:
					this.Visit(u.Operand);
					break;
				default:
					throw new NotSupportedException(string.Format("The unary operator '{0}' is not supported", u.NodeType));
			}
			return u;
		}

		protected override Expression VisitBinary(BinaryExpression b)
		{
			//sb.Append("(");
			this.Visit(b.Left);
			switch (b.NodeType)
			{
					//logical
				case ExpressionType.And:
				case ExpressionType.Or:
				case ExpressionType.OrElse:

					break;
					//comparison
				case ExpressionType.Equal:
				case ExpressionType.NotEqual:
				case ExpressionType.LessThan:
				case ExpressionType.LessThanOrEqual:
				case ExpressionType.GreaterThan:
				case ExpressionType.GreaterThanOrEqual:
					try
					{
						var fc = FieldComparison.Create(b);
						if (LookingForSpecificContent(fc))
						{
							_apiCalls.AddRestCall("/contents/" + fc.Value);
						}
						else
						{
							var filter = _factory.CreateFilter(fc);
							_filters.Add(filter);
						}


					}
					catch (Exception)
					{
						
						throw;
					}

					break;

				default:
					throw new NotSupportedException(string.Format("The binary operator '{0}' is not supported", b.NodeType));
			}
			this.Visit(b.Right);
			//sb.Append(")");
			return b;
		}

		private static bool LookingForSpecificContent(FieldComparison fc)
		{
			return fc.Field.ToUpper().EndsWith("ID");

		}

		protected override Expression VisitConstant(ConstantExpression c)
		{
			var q = c.Value as IQueryable;
			if (q != null)
			{
				// assume constant nodes w/ IQueryables are table references
				//sb.Append("SELECT * FROM ");
				//sb.Append(q.ElementType.Name);
			}
			else if (c.Value == null)
			{
				//sb.Append("NULL");
			}
			else
			{
				switch (Type.GetTypeCode(c.Value.GetType()))
				{
					case TypeCode.Boolean:
						//sb.Append(((bool)c.Value) ? 1 : 0);
						break;
					case TypeCode.String:
						//_searchKeys.Add((string)c.Value);
						break;
					case TypeCode.Object:
						throw new NotSupportedException(string.Format("The constant for '{0}' is not supported", c.Value));
					default:
						//sb.Append(c.Value);
						break;
				}
			}
			return c;
		}

		protected override Expression VisitMemberAccess(MemberExpression m)
		{
			if (m.Expression != null && (m.Expression.NodeType == ExpressionType.Parameter || m.Expression.NodeType == ExpressionType.MemberAccess))
			{
				//sb.Append(m.Member.Name);
				return m;
			}
			throw new NotSupportedException(string.Format("The member '{0}' is not supported", m.Member.Name));
		}
	}
}