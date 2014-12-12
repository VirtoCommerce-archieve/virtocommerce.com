using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Publishing.Model
{
    internal class RawContentItem
    {
        public string ContentType { get; set; }
        public string Content { get; set; }

        public IDictionary<string, dynamic> Settings { get; set; }
    }
}
