using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jive.Linq.Models;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Jive.Linq.Test.DeserializeTests
{
	[TestFixture]
	class DeserializeContentTests
	{
		[Test]
		public void CanDeserializeSingleContentObject()
		{
			using (var jsonFile = new StreamReader(new FileStream("..\\..\\TestFiles\\content.json",FileMode.Open)))
			{
				var deserializer = new JsonSerializer();
				var jcontent = deserializer.Deserialize<Discussion>(new JsonTextReader(jsonFile));
				Assert.AreEqual("19248", jcontent.Id);
				Assert.AreEqual("103925", jcontent.ContentId);
				Assert.AreEqual(14, jcontent.Resources.Count());
				Assert.AreEqual(3, jcontent.Resources["self"].Allowed.Count());
				Assert.IsInstanceOf<Discussion>(jcontent);
				Assert.AreEqual(JiveContentType.Discussion ,jcontent.Type);
				Assert.AreEqual(new DateTime(2015,1,17,11,55,45,279),jcontent.Published);
				Assert.AreEqual(new DateTime(2015,1,17,11,55,45,279),jcontent.Updated);
				Assert.AreEqual("3170", jcontent.Author.Id);
				Assert.AreEqual(21, jcontent.Author.Resources.Count());
				Assert.AreEqual("Glen Nicol", jcontent.Author.DisplayName);
				var emailInfo = jcontent.Author.Emails.First();
				Assert.AreEqual(ContactInfoType.Email, emailInfo.Type);
				Assert.AreEqual(ContactInfoAccociation.Work, emailInfo.Association);
				Assert.AreEqual("glen.nicol@jivesoftware.com", emailInfo.Value);

				Assert.AreEqual("Nicol",jcontent.Author.Familyname);
				Assert.AreEqual("Glen",jcontent.Author.GivenName);
				Assert.AreEqual("Glen Nicol",jcontent.Author.Formatted);
				Assert.AreEqual(5, jcontent.OutcomeTypes.Count);
				var firstOutcome = jcontent.OutcomeTypes.First();
				Assert.AreEqual("6", firstOutcome.Id);
				Assert.AreEqual("success", firstOutcome.Name);
				Assert.IsFalse(firstOutcome.Shareable);
				Assert.IsTrue(firstOutcome.NoteRequired);
				Assert.IsFalse(firstOutcome.UrlAllowed);
				Assert.IsTrue(firstOutcome.GeneralNote);
				Assert.IsFalse(firstOutcome.ConfirmExclusion);
				Assert.IsFalse(firstOutcome.ConfirmUnmark);

				Assert.IsEmpty(jcontent.Attachments);
			}
			
		}
	}
}
