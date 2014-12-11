using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Formatters;
using System.Web.Hosting;
using System.Web.Http;

namespace VirtoCommerce.Controllers
{
    public class ContentPublishingController : ApiController
    {
        // GET api/<controller>
        public string Get(string name)
        {
            var filesPath = HostingEnvironment.MapPath("~/App_Data/Contents");

            /*
            var extensions = new HashSet<string>(new[] { ".md", ".markdown" }, StringComparer.OrdinalIgnoreCase);
            var files = new DirectoryInfo(filesPath).EnumerateFiles("*", SearchOption.AllDirectories)
                                                         .Where(x => extensions.Contains(x.Extension));

            var pages = new DirectoryInfo(settings.Pages).EnumerateFiles("*", SearchOption.AllDirectories)
                                                         .Select(x => PagesParser.GetFileData(x, settings))
                                                         .OrderByDescending(x => x.Date)
                                                         .Where(x => x.Published != Published.Private && !(x is Post.MissingPost))
                                                         .ToList();
             * */

            return "";
            //return new string[] { "value1", "value2" };
        }
    }
}