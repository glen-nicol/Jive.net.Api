using System;
using Castle.DynamicProxy;

namespace Jive.net.Api.Serialization
{
	public class GenericProxyFactory<T>
	{
		 private readonly ProxyGenerator _generator = new ProxyGenerator();
		private readonly IInterceptorSelectorFactory _selectorFactory;

		public GenericProxyFactory(IInterceptorSelectorFactory factory)
		{
			if (factory == null)
			{
				throw new ArgumentNullException("factory");
			}
			_selectorFactory = factory;
		}

		public T Create(T entity)
		{
			var options = new ProxyGenerationOptions
				{
					Selector = _selectorFactory.Create()
				};
			return (T)_generator.CreateInterfaceProxyWithTarget(typeof (T), entity, options);
		}
	}
}