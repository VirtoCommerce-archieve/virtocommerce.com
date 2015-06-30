using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Publishing
{
    using System.IO;
    using System.IO.Abstractions;
    using System.Web;
    using System.Web.Caching;
    using System.Web.Configuration;

    using DotLiquid;

    using MarkdownDeep;

    using VirtoCommerce.Helpers.Models;
    using VirtoCommerce.Publishing.Extensions;
    using VirtoCommerce.Publishing.Model;

    public class ContentPublishingService
    {
        static readonly Markdown Markdown = new Markdown();

        private SiteContext Context;
        private FileSystem _fileSystem;

        private Dictionary<string, object> _Config;

        private ITemplateEngine[] _templateEngines;

        public ContentPublishingService(string sourceFolder, ITemplateEngine[] templateEngines )
        {
            _templateEngines = templateEngines;
            _fileSystem = new FileSystem();

            // Now lets build the context
            Context = BuildSiteContext(sourceFolder);
        }

        public ContentItem GetContentItem(string name)
        {
            return
                Context.Collections.SelectMany(pages => pages.Value).SingleOrDefault(page => page.Url.Equals(name, StringComparison.OrdinalIgnoreCase));

            /*
            var path = Path.Combine(_context.SourceFolder, name);
            return this.CreateContentItem(path, _Config);
             * */
        }

        public ContentItem[] GetCollectionContentItems(string collectioName)
        {
            return Context.Collections.Where(col => col.Key.Equals(collectioName, StringComparison.OrdinalIgnoreCase)).Select(x => x.Value).SingleOrDefault();
        }

        /// <summary>
        /// Loads all content items in the certain collection
        /// </summary>
        /// <param name="context"></param>
        /// <param name="collectionFolder"></param>
        /// <returns></returns>
        private IEnumerable<ContentItem> GetCollectionContentItemsInternal(SiteContext context, string collectionFolder)
        {
            var extensions = new HashSet<string>(new[] { ".md", ".markdown", ".html" }, StringComparer.OrdinalIgnoreCase);
            var items = new List<ContentItem>();
            if (_fileSystem.Directory.Exists(collectionFolder))
            {
                var files = _fileSystem.DirectoryInfo.FromDirectoryName(collectionFolder).GetFiles("*", SearchOption.AllDirectories)
                    .Where(x => extensions.Contains(x.Extension));
                items.AddRange(
                    files.Select(file => CreateContentItem(context, file.FullName, _Config))
                        .Where(post => post != null));
            }
            return items;
        }

        private SiteContext BuildSiteContext(string sourceFolder)
        {
            var contextKey = "vc-no-cms";
            var value = HttpRuntime.Cache.Get(contextKey);

            if (value != null)
            {
                return value as SiteContext;
            }

            _Config = new Dictionary<string, object>();
            var configPath = Path.Combine(sourceFolder, "config.yml");
            if (_fileSystem.File.Exists(configPath))
                _Config = (Dictionary<string, object>)_fileSystem.File.ReadAllText(configPath).YamlHeader(true);

            var context = new SiteContext() { SourceFolder = sourceFolder, Config = _Config };

            var collections = new Dictionary<string, ContentItem[]>();

            // list all directories
            var collectionFolders = _fileSystem.Directory.GetDirectories(sourceFolder, "*", SearchOption.TopDirectoryOnly).Where(name => !name.EndsWith("includes", StringComparison.OrdinalIgnoreCase));

            // now for each directory get a list of content items
            foreach (var collectionFolder in collectionFolders)
            {
                var items = this.GetCollectionContentItemsInternal(context, collectionFolder).Where(item => item != null).ToArray();

                var collectionName = GetPageTitle(collectionFolder);
                collections.Add(collectionName, items);
            }

            // populate collection object
            context.Collections = collections;

            // add to cache
            var allDirectories = _fileSystem.Directory.GetDirectories(sourceFolder, "*", SearchOption.AllDirectories);
            HttpRuntime.Cache.Insert(contextKey, context, new CacheDependency(allDirectories));

            // return context
            return context;
        }

        private ContentItem CreateContentItem(SiteContext context, string path, Dictionary<string, object> config)
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
                    page.Url = rawItem.Settings.ContainsKey("permalink")
                        ? rawItem.Settings["permalink"]
                        : EvaluateLink(context, path);
                    return page;
                }
            }

            return null;
        }

        private string EvaluateLink(SiteContext context, string path)
        {
            var directory = Path.GetDirectoryName(path);
            var relativePath = directory.Replace(context.SourceFolder, string.Empty);
            var fileExtension = Path.GetExtension(path);

            var htmlExtensions = new[] { ".markdown", ".mdown", ".mkdn", ".mkd", ".md", ".textile" };

            if (htmlExtensions.Contains(fileExtension, StringComparer.InvariantCultureIgnoreCase))
                fileExtension = "";

            var link = relativePath.Replace('\\', '/').TrimStart('/') + "/" + GetPageTitle(path) + fileExtension;
            if (!link.StartsWith("/"))
                link = "/" + link;
            return link;
        }

        private string GetPageTitle(string file)
        {
            return Path.GetFileNameWithoutExtension(file);
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
