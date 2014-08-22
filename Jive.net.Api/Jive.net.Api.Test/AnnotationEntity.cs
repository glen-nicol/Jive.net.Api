using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jive.net.Api.Serialization;

namespace Jive.net.Api.Test
{
	public class AnnotationTestClass
	{
		public string NotMarked { get; set; }

		[JiveApiOptional]
		public string Optional { get; set; }
	}
}