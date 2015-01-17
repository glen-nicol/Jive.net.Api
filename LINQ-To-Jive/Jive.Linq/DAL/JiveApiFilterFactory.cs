using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Jive.Linq.Models;

namespace Jive.Linq.DAL
{
	class JiveApiFilterFactory
	{
		private bool IsSupportedMember(string name)
		{
			switch (name)
			{
				case "Subject":
				case "Type": 
				case "Text":
					return true;
				default:
					return false;
			}
		}



		public IJiveFilter CreateFilter(FieldComparison fc)
		{
			fc.Value = Regex.Replace(fc.Value, @"([,\\\(\)])", "\\$1");
			
			if (IsSupportedMember(fc.Field))
			{
				if (fc.Field == "Type")
				{
					return new JiveFilter("type", fc.Value);
				}
				else
				{
					return new JiveFilter("search", fc.Value);
				}
				}

			throw new NotSupportedException("Cannot filter on " + fc.Field);
		}
	}
}
