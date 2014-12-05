using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace VirtoCommerce.Extensions
{
	public class CssRewriteUrlTransform : IItemTransform
	{
		public CssRewriteUrlTransform()
		{

		}

		public string Process(string includedVirtualPath, string input)
		{
			return new CssRewriteUrlTransform().Process("~" + VirtualPathUtility.ToAbsolute(includedVirtualPath), input);
		}
	}
}