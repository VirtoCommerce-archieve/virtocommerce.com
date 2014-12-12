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
        private FileSystem _fileSystem;

        private Dictionary<string, object> _Config;

        private ITemplateEngine[] _templateEngines;

        public ContentPublishingService(string sourceFolder, ITemplateEngine[] templateEngines )
        {
            _context = new SiteContext() { SourceFolder = sourceFolder };
            _templateEngines = templateEngines;
            _fileSystem = new FileSystem();

            _Config = new Dictionary<string, object>();
            var configPath = Path.Combine(_context.SourceFolder, "config.yml");
            if (_fileSystem.File.Exists(configPath))
                _Config = (Dictionary<string, object>)_fileSystem.File.ReadAllText(configPath).YamlHeader(true);
        }

        public ContentItem GetContentItem(string name)
        {
            var path = Path.Combine(_context.SourceFolder, name);
            return this.CreateContentItem(path, _Config);
        }

        /// <summary>
        /// Loads all content items in the certain collection
        /// </summary>
        /// <param name="collectioName"></param>
        /// <returns></returns>
        public ContentItem[] GetCollectionContentItems(string collectioName)
        {
            var items = new List<ContentItem>();
            var collectionFolder = Path.Combine(_context.SourceFolder, collectioName);
            if (_fileSystem.Directory.Exists(collectionFolder))
            {
                items.AddRange(_fileSystem.Directory
                    .GetFiles(collectionFolder, "*.*", SearchOption.AllDirectories)
                    .Select(file => CreateContentItem(file, _Config))
                    .Where(post => post != null)
                );
            }
            return items.ToArray();
        }

        private ContentItem CreateContentItem(string path, Dictionary<string, object> config)
        {
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
            catch (Exception e)
            {
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
            try
            {
                return _fileSystem.File.ReadAllText(file);
            }
            catch (IOException)
            {
                var fileInfo = _fileSystem.FileInfo.FromFileName(file);
                var tempFile = Path.Combine(Path.GetTempPath(), fileInfo.Name);
                try
                {
                    fileInfo.CopyTo(tempFile, true);
                    return _fileSystem.File.ReadAllText(tempFile);
                }
                finally
                {
                    if (_fileSystem.File.Exists(tempFile))
                        _fileSystem.File.Delete(tempFile);
                }
            }
        }
    }
}
