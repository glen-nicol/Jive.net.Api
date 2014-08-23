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
		private string _optional = "Optional";
		public virtual string Optional { get { return _optional ; }
			set { _optional = value; }
		}

		[JiveApiReadOnly]
		public virtual string ReadOnly { get { return "ReadOnly"; } }
	}
}