using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jive.Linq.Serialization;

namespace Jive.Linq.Test
{
	public class AnnotationTestClass
	{
		private string Private { get { return "Private"; } }
		private string _required = "Required";
		public virtual string Required
		{
			get { return _required; }
			set { _required = value; }
		}
		private string _optional = "Optional";
		[JiveApiOptional]
		public virtual string Optional { get { return _optional ; }
			set { _optional = value; }
		}

		[JiveApiReadOnly]
		public virtual string ReadOnly { get { return "ReadOnly"; } }
	}
}