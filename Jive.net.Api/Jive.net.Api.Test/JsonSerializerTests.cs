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
			 var o = new AnnotationTestClass();
			 var serializer = new JsonSerializer<AnnotationTestClass>(new NaiveMemberProvider<AnnotationTestClass>(new JiveEntityAnalyzer<dynamic>(new JiveAttributeAnalyzer())));
			 var json = serializer.StringSerialize(o);
			 var result = JObject.Parse(json);
			 Assert.AreEqual("Required",result["Required"].ToObject<string>());
		 }
	}
}