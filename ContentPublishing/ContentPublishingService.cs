using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Publishing
{
    using System.IO;
    using System.IO.Abstractions;
    using System.Web.Configuration;

    using DotLiquid;

    using MarkdownDeep;

    using VirtoCommerce.Helpers.Models;
    using VirtoCommerce.Publishing.Extensions;
    using VirtoCommerce.Publishing.Model;

    public class ContentPublishingService
    {
        static readonly Markdown Markdown = new Markdown();

        private SiteContext _context;

        private ITemplateEngine[] _templateEngines;

        public ContentPublishingService(string sourceFolder, ITemplateEngine[] templateEngines )
        {
            _context = new SiteContext() { SourceFolder = sourceFolder };
            _templateEngines = templateEngines;
        }

        public ContentItem GetContentItem(string name)
        {
            try
            {
                var path = Path.Combine(_context.SourceFolder, name);
                // 1: Read raw contents and meta data. Determine contents format and read it into Contents property, create RawContentItem.
                var rawItem = this.CreateRawItem(path);

                // 2: Use convert engines to get html contents and create ContentItem object
                foreach (var templateEngine in _templateEngines)
                {
                    if (templateEngine.CanProcess(rawItem.ContentType, "html"))
                    {
                        var content = templateEngine.Process(rawItem.Content, rawItem.Settings);
                        var page = new ContentItem
                        {
                            Content = content
                        };

                        page.SetHeaderSettings(rawItem.Settings);
                        page.Settings = rawItem.Settings;
                        return page;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return null;
        }

        #region Step 1
        private RawContentItem CreateRawItem(string file)
        {
            try
            {
                var contents = SafeReadContents(file);
                var header = contents.YamlHeader();

                var page = new RawContentItem
                {
                    Content = RenderContent(file, contents, header)
                };

                page.Settings = header;

                return page;
            }
            catch (Exception)
            {
                throw;
                //Tracing.Info(String.Format("Failed to build post from File: {0}", file));
                //Tracing.Info(e.Message);
                //Tracing.Debug(e.ToString());
            }

            return null;
        }
        #endregion

        private string RenderContent(string file, string contents, IDictionary<string, object> header)
        {
            string html;
            try
            {
                var contentsWithoutHeader = contents.ExcludeHeader();
                html = string.Equals(Path.GetExtension(file), ".md", StringComparison.InvariantCultureIgnoreCase)
                       ? Markdown.Transform(contentsWithoutHeader)
                       : contentsWithoutHeader;

                //html = contentTransformers.Aggregate(html, (current, contentTransformer) => contentTransformer.Transform(current));
            }
            catch (Exception e)
            {
                //Tracing.Info(String.Format("Error ({0}) converting {1}", e.Message, file));
                //Tracing.Debug(e.ToString());
                html = String.Format("<p><b>Error converting markdown</b></p><pre>{0}</pre>", contents);
            }
            return html;
        }

        private string SafeReadContents(string file)
        {
            var fileSystem = new FileSystem();
            try
            {
                return fileSystem.File.ReadAllText(file);
            }
            catch (IOException)
            {
                var fileInfo = fileSystem.FileInfo.FromFileName(file);
                var tempFile = Path.Combine(Path.GetTempPath(), fileInfo.Name);
                try
                {
                    fileInfo.CopyTo(tempFile, true);
                    return fileSystem.File.ReadAllText(tempFile);
                }
                finally
                {
                    if (fileSystem.File.Exists(tempFile))
                        fileSystem.File.Delete(tempFile);
                }
            }
        }
    }
}
