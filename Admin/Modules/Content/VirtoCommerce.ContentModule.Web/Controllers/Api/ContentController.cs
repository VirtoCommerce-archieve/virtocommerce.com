using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.ContentModule.Web.Controllers.Api
{
    using System.IO;
    using System.IO.Abstractions;
    using System.Web.Hosting;
    using System.Web.Http;
    using System.Web.Http.Description;

    using Microsoft.Practices.Unity;

    using VirtoCommerce.ContentModule.Web.Model;

    [RoutePrefix("api/contents")]
    public class PublishingContentController : ApiController
    {
        private IFileSystem _fileSystem;
        private string _folderSource;

        [InjectionConstructor]
        public PublishingContentController(IFileSystem fileSystem) : this(fileSystem, "~/App_Data/Contents")
        {
        }

        public PublishingContentController(IFileSystem fileSystem, string folderSource)
        {
            _fileSystem = fileSystem;

            if (folderSource.StartsWith("~"))
            {
                folderSource = HostingEnvironment.MapPath(folderSource);
                if (!_fileSystem.Directory.Exists(_folderSource))
                {
                    _fileSystem.Directory.CreateDirectory(folderSource);
                }
            }

            _folderSource = folderSource;
        }

        // GET: api/contents/collections
        [HttpGet]
        [ResponseType(typeof(CollectionItem[]))]
        [Route("collections")]
        public IHttpActionResult GetCollections()
        {
            var items = new List<CollectionItem>();

            if (_fileSystem.Directory.Exists(_folderSource))
            {
                items.AddRange(collection: _fileSystem.Directory
                    .GetDirectories(_folderSource, "*", searchOption: SearchOption.TopDirectoryOnly)
                    .Select(folder => new CollectionItem() { Id = GetPageTitle(folder) })
                );
            }

            return this.Ok(items.ToArray());
        }

        [HttpGet]
        [ResponseType(typeof(ContentItem[]))]
        [Route("collections/{collection}/items")]
        public IHttpActionResult GetCollectionItems(string collection)
        {
            var items = this.GetCollectionItemsInternal(collection);

            return Ok(items);
        }

        [HttpGet]
        [ResponseType(typeof(ContentItem))]
        [Route("collections/{collection}/items/{itemId}")]
        public IHttpActionResult GetItem(string collection, string itemId)
        {
            var contentItem = GetItemByName(collection, itemId);
            return Ok(contentItem);
        }

        /*
        [HttpPost]
        [ResponseType(typeof(ContentItem))]
        [Route("collections/{collection}/items/{itemId}")]
        public IHttpActionResult CreateItem(string collection, string itemId, string content)
        {
            var retVal = new ContentItem() { Id = "enterprise.md", Content = "some enterprise version", LastUpdated = DateTime.Now, Status = "Published" };
            return Ok(retVal);
        }
         * */

        [HttpPost]
        [ResponseType(typeof(ContentItem))]
        [Route("collections/{collection}/items/{itemId}")]
        public IHttpActionResult Save(string collection, string itemId, ContentItem item)
        {
            PublishFile(collection, itemId, item);
            return Ok(item);
        }

        [HttpPost]
        [ResponseType(typeof(ContentItem))]
        [Route("collections/{collection}/items/{itemId}/publish")]
        public IHttpActionResult Publish(string collection, string itemId, ContentItem item)
        {
            PublishFile(collection, itemId, item);
            return Ok(item);
        }

        private void PublishFile(string collection, string oldItemId, ContentItem item)
        {
            var origContentItem = GetItemByName(collection, oldItemId);
            _fileSystem.File.WriteAllText(origContentItem.Filename, item.Content);
        }

        private ContentItem GetItemByName(string collection, string itemId)
        {
            var items = this.GetCollectionItemsInternal(collection);
            var contentItem = items.SingleOrDefault(item => item.Id.Equals(itemId, StringComparison.OrdinalIgnoreCase));
            return contentItem;
        }

        private ContentItem[] GetCollectionItemsInternal(string collection)
        {
            var items = new List<ContentItem>();

            if (_fileSystem.Directory.Exists(_folderSource))
            {
                items.AddRange(_fileSystem.Directory
                    .GetFiles(Path.Combine(_folderSource, collection), "*.*", SearchOption.AllDirectories)
                    .Select(file => new ContentItem() { Id = GetPageTitle(file), Content = SafeReadContents(file), Filename = file })
                );
            }
            
            return items.ToArray();
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

        private string GetPageTitle(string file)
        {
            return Path.GetFileNameWithoutExtension(file);
        }

    }
}
