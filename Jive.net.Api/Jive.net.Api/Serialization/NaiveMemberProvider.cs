﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jive.net.Api.Serialization
{
	public class NaiveMemberProvider<T> : IEntityMemberProvider<T>
	{
		private readonly IPropertyAnalyzer<T> _analyzer;

		public NaiveMemberProvider(IPropertyAnalyzer<T> analyzer)
		{
			if (analyzer == null)
			{
				throw new ArgumentNullException("analyzer");
			}
			_analyzer = analyzer;
		} 

		public IEnumerable<EntityPropertyMap> MembersToSerialize(T entity)
		{
			return _analyzer.RequiredProperties(entity).Union(_analyzer.OptionalProperties(entity).Where(o => o.Value() != null));
		}
	}
}
