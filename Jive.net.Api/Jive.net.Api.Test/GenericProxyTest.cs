using System.Linq;
using Jive.net.Serialization;
using NSubstitute;
using NUnit.Framework;
namespace Jive.net.Api.Test
{
	public class GenericProxyTest
	{

		[Test]
		public void UsingOptionalSettertriggersTracker()
		{
			var tracker = new FlagTracker();
			var fakeFactory = Substitute.For<ITrackerFactory>();
			fakeFactory.Create().Returns(tracker);
			var selectFactory = new OptionalSetterFactory();
			var pfactory = new GenericProxyFactory<AnnotationTestClass>(selectFactory, fakeFactory);
			var original = new AnnotationTestClass();
			var proxy = pfactory.Create(original);
			Assert.AreEqual(0, tracker.Changes().Count());
			proxy.Entity.Optional = "Changed";
			Assert.AreEqual(1, tracker.Changes().Count());
			Assert.AreEqual("Changed",proxy.Entity.Optional);
		}

		[Test]
		public void UsingRequiredSettertriggersTracker()
		{
			var tracker = new FlagTracker();
			var fakeFactory = Substitute.For<ITrackerFactory>();
			fakeFactory.Create().Returns(tracker);
			var selectFactory = new OptionalSetterFactory();
			var pfactory = new GenericProxyFactory<AnnotationTestClass>(selectFactory, fakeFactory);
			var original = new AnnotationTestClass();
			var proxy = pfactory.Create(original);
			Assert.AreEqual(0, tracker.Changes().Count());
			proxy.Entity.Required = "Changed";
			Assert.AreEqual(1, tracker.Changes().Count());
			Assert.AreEqual("Changed", proxy.Entity.Required);
		}
	}
}