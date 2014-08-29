using Jive.Linq.Test;
using Jive.Linq.Serialization;
using System.Linq;
using NUnit.Framework;

namespace Jive.Linq.Test
{
	public class EntityAnnotationAnalyzerTests
	{
		 [Test]
		 public void AllPropertiesAreRequiredUnlessVirtualReadOnlyPrivate()
		 {
			 var propertyAnalzer = new JiveEntityAnalyzer<AnnotationTestClass>(new JiveAttributeAnalyzer());
			 var anc = new AnnotationTestClass();
			 var required = propertyAnalzer.RequiredProperties(anc).Select(c => c.Property).ToList();
			 Assert.Contains("Required",required);
			 Assert.IsFalse(required.Contains("Private"), "Private Property was found in required list");
			 Assert.IsFalse(required.Contains("Optional"), "Optional Property was found in required list");
			 Assert.IsFalse(required.Contains("ReadOnly"), "ReadOnly Property was found in required list");
		 }

		[Test]
		public void OptionalOnlyGathersThoseMarkedOptionalAndNotReadOnly()
		{
			var propertyAnalzer = new JiveEntityAnalyzer<AnnotationTestClass>(new JiveAttributeAnalyzer());
			var anc = new AnnotationTestClass();
			var required = propertyAnalzer.OptionalProperties(anc).Select(c => c.Property).ToList();
			Assert.Contains("Optional", required);
			Assert.IsFalse(required.Contains("Required"), "Required Property was found in Optional list");
			Assert.IsFalse(required.Contains("ReadOnly"), "ReadOnly Property was found in Optioanl list");
		}
	}
}