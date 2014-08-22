using Jive.net.Api.Serialization;
using System.Linq;
using NUnit.Framework;

namespace Jive.net.Api.Test
{
	public class EntityAnnotationAnalyzerTests
	{
		private class AnnotationTestClass
		{
			public string NotMarked { get; set; }
			[JiveApiOptional]
			public string Optional { get; set; }
		}
		 [Test]
		 public void AllPropertiesAreRequiredUnlessMarkedOptionalExtraNone()
		 {
			 var propertyAnalzer = new JiveAnnotationAnalyzer<AnnotationTestClass>();
			 var anc = new AnnotationTestClass
				 {
					 NotMarked = "Required",
					 Optional = "Optional"
				 };
			 var required = propertyAnalzer.RequiredProperties(anc).Select(c => c.Property).ToList();
			 Assert.Contains("NotMarked",required);
			 Assert.IsFalse(required.Contains("Optional"), "Optional Property was found in required list");
		 }

		[Test]
		public void OptionalOnlyGathersThoseMarkedOptional()
		{
			var propertyAnalzer = new JiveAnnotationAnalyzer<AnnotationTestClass>();
			var anc = new AnnotationTestClass
			{
				NotMarked = "Required",
				Optional = "Optional"
			};
			var required = propertyAnalzer.OptionalProperties(anc).Select(c => c.Property).ToList();
			Assert.Contains("Optional", required);
			Assert.IsFalse(required.Contains("NotMarked"), "NotMarked Property was found in Optional list");
		}
	}
}