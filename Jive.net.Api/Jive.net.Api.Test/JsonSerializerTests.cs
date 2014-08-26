using System.Linq;
using Jive.net.Proxy;
using Jive.net.Serialization;
using NSubstitute;
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
			 var req = result.GetValue("Required");
			 Assert.AreEqual("Required",req.ToString());
		 }

		[Test]
		public void SerializesRequiredAndChanged()
		{
			var tracker = new FlagTracker();
			var fakeFactory = NSubstitute.Substitute.For<ITrackerFactory>();
			fakeFactory.Create().Returns(tracker);
			var selectFactory = new OptionalSetterFactory();
			var pfactory = new GenericProxyFactory<AnnotationTestClass>(selectFactory, fakeFactory);
			var original = new AnnotationTestClass();
			var proxy = pfactory.Create(original);
			Assert.AreEqual(0, tracker.Changes().Count());
			proxy.Entity.Optional = "Changed";
			Assert.AreEqual(1, tracker.Changes().Count());
			Assert.AreEqual("Changed", proxy.Entity.Optional);

			var serializer = new JsonSerializer<AnnotationTestClass>(new ChangedPropertyProvider<AnnotationTestClass>(proxy.Tracker));
			var json = serializer.StringSerialize(proxy.Entity);
			var result =JsonConvert.DeserializeObject<AnnotationTestClass>(json,new JsonSerializerSettings{});
			//var result = JObject.Parse(json);
			Assert.AreEqual("Changed", result.Optional );

		}
	}
}