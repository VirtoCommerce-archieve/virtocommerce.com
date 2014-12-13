using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Publishing
{
    using VirtoCommerce.Helpers.Models;

    public class SiteContext
    {
        public string SourceFolder { get; set; }

        public Dictionary<string, ContentItem[]> Collections { get; set; }

        public Dictionary<string, object> Config { get; set; }
    }
}
