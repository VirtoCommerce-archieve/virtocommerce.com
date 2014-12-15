using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace VirtoCommerce.Publishing.Engines
{
    using System.IO;

    using DotLiquid;

    public class LiquidTemplateEngine : ITemplateEngine
    {
        private string _sourceFolder = "";
        public LiquidTemplateEngine(string sourceFolder)
        {
            _sourceFolder = sourceFolder;
        }

        public bool CanProcess(string inputType, string outputType)
        {
            return true;
        }

        public string Process(string contents, IDictionary<string, dynamic> attributes)
        {
            var data = CreatePageData(contents, attributes);
            var template = Template.Parse(contents);
            Template.FileSystem = new Includes(_sourceFolder);
            var output = template.Render(data);
            return output;

        }

        Hash CreatePageData(string contents, IDictionary<string, dynamic> attributes)
        {
            var y = Hash.FromDictionary(attributes);

            /*
            if (y.ContainsKey("title"))
            {
                if (string.IsNullOrWhiteSpace(y["title"].ToString()))
                {
                    y["title"] = Context.Title;
                }
            }
            else
            {
                y.Add("title", Context.Title);
            }
             * */

            var x = Hash.FromAnonymousObject(new
            {
                //site = contextDrop.ToHash(),
                wtftime = Hash.FromAnonymousObject(new { date = DateTime.Now }),
                page = y,
                content = contents
            });

            return x;
        }

        internal class Includes : DotLiquid.FileSystems.IFileSystem
        {
            public string Root { get; set; }

            public Includes(string root)
            {
                Root = root;
            }

            public string ReadTemplateFile(DotLiquid.Context context, string templateName)
            {
                var include = Path.Combine(Root, "Includes", templateName);
                if (File.Exists(include))
                    return File.ReadAllText(include);
                return string.Empty;
            }
        }

        /*
        public class FormToken : DotLiquid.Tag
        {
            public override void Render(Context context, TextWriter result)
            {
                var httpContextWrapper = new HttpContextWrapper(HttpContext.Current);
                MvcHandler mvcHandler = httpContextWrapper.CurrentHandler as MvcHandler;
                mvcHandler.RequestContext
                result.Write(new HtmlHelper(new ViewContext()).AntiForgeryToken().ToString());
            }
        }
         * */
    }
}
