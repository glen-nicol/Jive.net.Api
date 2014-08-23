﻿using Castle.DynamicProxy;

namespace Jive.net.Api.Serialization
{
	public interface IInterceptorSelectorFactory
	{
		IInterceptorSelector Create(ITrackChanges tracker, IPropertyAnalyzer analyzer);
	}

	public class OptionalSetterFactory : IInterceptorSelectorFactory
	{
		public IInterceptorSelector Create(ITrackChanges tracker, IPropertyAnalyzer analyzer)
		{
			return new JiveApiInterceptorSelector(tracker);
		}
	}
}