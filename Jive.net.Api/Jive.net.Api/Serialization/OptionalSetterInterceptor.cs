using System;
using Castle.DynamicProxy;

namespace Jive.net.Api.Serialization
{
	public class OptionalSetterInterceptor : IInterceptor
	{
		private readonly ITrackChanges _tracker;

		public OptionalSetterInterceptor(ITrackChanges tracker)
		{
			if (tracker == null)
			{
				throw new ArgumentNullException("tracker");
			}
			_tracker = tracker;
		}

		public void Intercept(IInvocation invocation)
		{
			_tracker.MarkMemberChanged(invocation.Method);
		}
	}
}