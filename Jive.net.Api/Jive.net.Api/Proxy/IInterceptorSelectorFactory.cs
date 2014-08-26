using Castle.DynamicProxy;
using Jive.net.Serialization;

namespace Jive.net.Proxy
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