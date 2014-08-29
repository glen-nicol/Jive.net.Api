using System;
using System.Reflection;
using Castle.DynamicProxy;
using System.Linq;

namespace Jive.Linq.Proxy
{
	public class JiveApiInterceptorSelector : IInterceptorSelector
	{

		private readonly ITrackChanges _tracker;
		private readonly TrackSetterInterceptor _setterInterceptor;

		public JiveApiInterceptorSelector(ITrackChanges tracker)
		{
			if (tracker == null)
			{
				throw new ArgumentNullException("tracker");
			}
			_tracker = tracker;

			_setterInterceptor = new TrackSetterInterceptor(_tracker);
		}

		public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
		{
			

			return IsSetter(method) ?
				new IInterceptor[] {_setterInterceptor}.Union(interceptors).ToArray() : interceptors;
		}
		private bool IsSetter(MethodInfo method)
		{
			return method.IsSpecialName && method.Name.StartsWith("set_", StringComparison.Ordinal);
		}
		private bool IsGetter(MethodInfo method)
		{
			return method.IsSpecialName && method.Name.StartsWith("get_", StringComparison.Ordinal);
		}
	}


}