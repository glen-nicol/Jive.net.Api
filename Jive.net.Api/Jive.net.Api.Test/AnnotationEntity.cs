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
		private string Private { get { return "Private"; } }
		public string Required { get { return "Required"; } }

		public virtual string Optional { get { return "Optional"; } }

		[JiveApiReadOnly]
		public virtual string ReadOnly { get { return "ReadOnly"; } }
	}
}