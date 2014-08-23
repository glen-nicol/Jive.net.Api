using Castle.DynamicProxy;

namespace Jive.net.Api.Serialization
{
	public interface IInterceptorSelectorFactory
	{
		IInterceptorSelector Create();
	}

	class OptionalSetterFactory : IInterceptorSelectorFactory
	{


		public IInterceptorSelector Create()
		{
			return new JiveApiInterceptorSelector(new FlagTracker(), new JiveAttributeAnalyzer());
		}
	}
}