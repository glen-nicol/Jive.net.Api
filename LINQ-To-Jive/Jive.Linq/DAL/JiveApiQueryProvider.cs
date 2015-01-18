using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Jive.Linq.DAL;
using Jive.Linq.Models;
using Newtonsoft.Json;

namespace Jive.Linq.DAL
{
	public class JiveApiQueryProvider : QueryProvider
	{
		private readonly string _jiveObjectApiSearchPrefix;
		private readonly IHttpRequester _requester;
		public JiveApiQueryProvider(IHttpRequester requester, string searchPrefix)
		{
			if (searchPrefix == null)
			{
				throw new ArgumentNullException("searchPrefix");
			}
			if (requester == null)
			{
				throw new ArgumentNullException("requester");
			}
			_requester = requester;
			_jiveObjectApiSearchPrefix = searchPrefix;
		}

		public override string GetQueryText(Expression expression)
		{
			var calls = Translate(expression);

			return string.Join("\n",calls);
		}

		public override object Execute(Expression expression)
		{
			var calls = Translate(expression);

			var allObjects = Task.WhenAll(calls.Select(RetrieveResource)).Result;
			var finalList = new List<IJiveContent>();
			foreach (var jiveContent in allObjects)
			{
				finalList.AddRange(jiveContent);
			}
			return finalList;
		}

		private async Task<IJiveContent[]> RetrieveResource(string restCall)
		{
			var request = new HttpRequestMessage{
					RequestUri = new Uri("http://jiveon.sandbox.com/api/core/v3" + restCall),
					Method = HttpMethod.Get
				};
				var response =  await _requester.SendAsync(request);
				return JsonConvert.DeserializeObject<IJiveContent[]>(response.Content.ToString(), new JsonSerializerSettings { });
		}

		private static ApiCallCollection Translate(Expression expression)
		{
			expression = Evaluator.PartialEval(expression);
			return new JiveApiQueryTranslator().Translate(expression);
		}
	}
}