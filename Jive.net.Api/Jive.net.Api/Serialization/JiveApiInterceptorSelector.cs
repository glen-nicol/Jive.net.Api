using System;
using System.Collections.Generic;
using System.Reflection;
using Castle.DynamicProxy;
using System.Linq;

namespace Jive.net.Api.Serialization
{
	public class JiveApiInterceptorSelector : IInterceptorSelector
	{
		private HashSet<string> _getters;
		private HashSet<string> _setters;

		private void PopulateMaps(Type t)
		{
			if (_getters != null && _setters != null) return;
			var properties = _analyzer.OptionalProperties(t).ToArray();
			_setters = new HashSet<string>(properties.Where(p => p.GetSetMethod() != null).Select(p=>p.GetSetMethod().Name));
			_getters = new HashSet<string>(properties.Where(p => p.GetGetMethod() != null).Select(p=>p.GetGetMethod().Name));
		}

		private readonly ITrackChanges _tracker;
		private readonly OptionalSetterInterceptor _setterInterceptor;
		private readonly IPropertyAnalyzer _analyzer; 

		public JiveApiInterceptorSelector(ITrackChanges tracker, IPropertyAnalyzer analyzer)
		{
			if (tracker == null)
			{
				throw new ArgumentNullException("tracker");
			}
			if (analyzer == null)
			{
				throw new ArgumentNullException("analyzer");
			}
			_tracker = tracker;
			_analyzer = analyzer;
			_setterInterceptor = new OptionalSetterInterceptor(_tracker);
		}

		public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
		{
			PopulateMaps(type);
			return _setters.Contains(method.Name) ?
				new IInterceptor[] {_setterInterceptor}.Union(interceptors).ToArray() : interceptors;
		}
	}


}