using Jive.net.Api.Serialization;
using Newtonsoft.Json;
using NUnit.Framework;
using Newtonsoft.Json.Linq;

namespace Jive.net.Api.Test
{
	public class JsonSerializerTests
	{
		 [Test]
		 public void ConvertsObjectToJson()
		 {
			 var o = new {title = "a"};
			 var serializer = new JsonSerializer<dynamic>(new NaiveMemberProvider<dynamic>(new JiveAnnotationAnalyzer<dynamic>()));
			 var json = serializer.StringSerialize(o);
			 var result = JObject.Parse(json);
			 Assert.AreEqual("a",result["title"].ToObject<string>());
		 }
	}
}