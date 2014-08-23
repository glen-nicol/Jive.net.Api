﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Jive.net.Api.Serialization
{
	public class JiveAnnotationAnalyzer<T> : IPropertyAnalyzer<T>
	{
		public IEnumerable<EntityPropertyMap> RequiredProperties(T entity)
		{
			return entity.GetType().GetProperties()
				.Where( p =>
					{
						var optional = IsVirtual(p);
						var readOnly = ReadOnly(p);
						return !optional && !readOnly;
					})
				.Select(p => new EntityPropertyMap(entity, p));
		}

		public IEnumerable<EntityPropertyMap> OptionalProperties(T entity)
		{
			return entity.GetType().GetProperties()
				.Where(p =>
					{
						var optional = IsVirtual(p);
						var readOnly = ReadOnly(p);
						return optional && !readOnly;
					})
				.Select(p => new EntityPropertyMap(entity, p));
		}

		private static bool ReadOnly(PropertyInfo p)
		{
			return p.GetCustomAttributes(typeof(JiveApiReadOnly), true).Any();
		}

		private static bool IsVirtual(PropertyInfo p)
		{
			return p.GetGetMethod().IsVirtual;
		}
	}
}