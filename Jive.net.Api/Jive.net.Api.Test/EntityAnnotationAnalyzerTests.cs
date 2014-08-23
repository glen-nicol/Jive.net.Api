using Jive.net.Api.Serialization;
using System.Linq;
using NUnit.Framework;

namespace Jive.net.Api.Test
{
	public class EntityAnnotationAnalyzerTests
	{
		 [Test]
		 public void AllPropertiesAreRequiredUnlessVirtualReadOnlyPrivate()
		 {
			 var propertyAnalzer = new JiveAnnotationAnalyzer<AnnotationTestClass>();
			 var anc = new AnnotationTestClass();
			 var required = propertyAnalzer.RequiredProperties(anc).Select(c => c.Property).ToList();
			 Assert.Contains("NotMarked",required);
			 Assert.IsFalse(required.Contains("Private"), "Private Property was found in required list");
			 Assert.IsFalse(required.Contains("Optional"), "Optional Property was found in required list");
			 Assert.IsFalse(required.Contains("ReadOnly"), "ReadOnly Property was found in required list");
		 }

		[Test]
		public void OptionalOnlyGathersThoseMarkedVirtualAndNotReadOnly()
		{
			var propertyAnalzer = new JiveAnnotationAnalyzer<AnnotationTestClass>();
			var anc = new AnnotationTestClass();
			var required = propertyAnalzer.OptionalProperties(anc).Select(c => c.Property).ToList();
			Assert.Contains("Optional", required);
			Assert.IsFalse(required.Contains("NotMarked"), "NotMarked Property was found in Optional list");
			Assert.IsFalse(required.Contains("ReadOnly"), "ReadOnly Property was found in Optioanl list");
		}
	}
}