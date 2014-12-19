using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.ContentModule.Web.Model
{
    using System.Collections.ObjectModel;

    using Newtonsoft.Json;

    public class ResponseCollection<T>
    {
        [JsonProperty("total")]
        public int TotalCount { get; set; }

        [JsonProperty("items")]
        public Collection<T> Items { get { return _items ?? (_items = new Collection<T>()); } }
        private Collection<T> _items;
    }
}
