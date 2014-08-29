using System;
using Castle.DynamicProxy;
using Jive.Linq.Serialization;

namespace Jive.Linq.Proxy
{
	public interface IGenericProxy<out T>
	{
		ITrackChanges Tracker { get; }
		T Entity { get; }
	}

	public class GenericProxy<T> : IGenericProxy<T>
	{
		public ITrackChanges Tracker { get; private set; }
		public T Entity { get; private set; }

		public GenericProxy(ITrackChanges tracker, T entity)
		{
			if (tracker == null)
			{
				throw new ArgumentNullException("tracker");
			}
			if (entity == null)
			{
				throw new ArgumentNullException("entity");
			}
			Tracker = tracker;
			Entity = entity;
		}
	}

	public class GenericProxyFactory<T>
	{
		private readonly ProxyGenerator _generator = new ProxyGenerator();
		private readonly IInterceptorSelectorFactory _selectorSelectorFactory;
		private readonly ITrackerFactory _trackerFactory;

		public GenericProxyFactory(IInterceptorSelectorFactory selectorFactory, ITrackerFactory trackerFactory)
		{
			if (selectorFactory == null)
			{
				throw new ArgumentNullException("selectorFactory");
			}
			if (trackerFactory == null)
			{
				throw new ArgumentNullException("trackerFactory");
			}
			_selectorSelectorFactory = selectorFactory;
			_trackerFactory = trackerFactory;
		}

		public IGenericProxy<T> Create(T entity)
		{
			var tracker = _trackerFactory.Create();
			var analyzer = new JiveAttributeAnalyzer();
			var options = new ProxyGenerationOptions
				{
					Selector = _selectorSelectorFactory.Create(tracker, analyzer)
				};
			return new GenericProxy<T>(tracker, (T) _generator.CreateClassProxy(typeof(T),options, new IInterceptor[0]));
		}
	}

	public interface ITrackerFactory
	{
		ITrackChanges Create();
	}
}