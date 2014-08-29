using Castle.DynamicProxy;
using Jive.Linq.Serialization;

namespace Jive.Linq.Proxy
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