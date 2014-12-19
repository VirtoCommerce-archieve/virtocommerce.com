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
    using VirtoCommerce.ContentModule.Web.Repositories;

    [RoutePrefix("api/contents")]
    public class PublishingContentController : ApiController
    {
        private IFileRepository _fileSystem;

        public PublishingContentController(IFileRepository fileSystem)
        {
            _fileSystem = fileSystem;
        }

        // GET: api/contents/collections
        [HttpGet]
        [ResponseType(typeof(CollectionItem[]))]
        [Route("collections")]
        public async Task<IHttpActionResult> GetCollections()
        {
            var items = new List<CollectionItem>();
            var collections = await _fileSystem.GetCollections();
            return this.Ok(collections.Items.ToArray());
        }

        [HttpGet]
        [ResponseType(typeof(ContentItem[]))]
        [Route("collections/{collection}/items")]
        public async Task<IHttpActionResult> GetCollectionItems(string collection)
        {
            var collections = await _fileSystem.GetCollectionItems(collection, 0, 100);
            return this.Ok(collections.Items.ToArray());
        }

        [HttpGet]
        [ResponseType(typeof(ContentItem))]
        [Route("collections/{collection}/items/{itemId}")]
        public async Task<IHttpActionResult> GetItem(string collection, string itemId)
        {

            var contentItem = await _fileSystem.GetContentItem(collection, itemId);
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
        public async Task<IHttpActionResult> Save(string collection, string itemId, ContentItem item)
        {
            var contentItem = await _fileSystem.SaveContentItem(collection, itemId, item);
            return Ok(contentItem);
        }

        [HttpPost]
        [ResponseType(typeof(ContentItem))]
        [Route("collections/items/{itemId}")]
        public async Task<IHttpActionResult> Save(string itemId, ContentItem item)
        {
            var contentItem = await _fileSystem.SaveContentItem(String.Empty, itemId, item);
            return Ok(contentItem);
        }

        [HttpPost]
        [ResponseType(typeof(ContentItem))]
        [Route("collections/{collection}/items/{itemId}/publish")]
        public async Task<IHttpActionResult> Publish(string collection, string itemId, ContentItem item)
        {
            var contentItem = await _fileSystem.SaveContentItem(collection, itemId, item);
            return Ok(contentItem);
        }

        [HttpDelete]
        [ResponseType(typeof(ContentItem))]
        [Route("collections/{collection}/items/{itemId}")]
        public async Task<IHttpActionResult> Delete(string collection, string itemId)
        {
            await _fileSystem.DeleteContentItem(collection, itemId);
            return Ok();
        }

        public async Task<IHttpActionResult> Delete(string collection, [FromUri] string[] ids)
        {
            //await _fileSystem.DeleteContentItem(collection, itemId);
            return Ok();
        }

        

        private void PublishFile(string collection, string oldItemId, ContentItem item)
        {
            /*
            var origContentItem = GetItemByName(collection, oldItemId);
            _fileSystem.File.WriteAllText(origContentItem.Filename, item.Content);
             * */
        }

        private ContentItem GetItemByName(string collection, string itemId)
        {
            var items = this.GetCollectionItemsInternal(collection);
            var contentItem = items.SingleOrDefault(item => item.Id.Equals(itemId, StringComparison.OrdinalIgnoreCase));
            return contentItem;
        }

        private ContentItem[] GetCollectionItemsInternal(string collection)
        {
            var collections = _fileSystem.GetCollectionItems(collection, 0, 100).Result;
            /*
            var items = new List<ContentItem>();

            if (_fileSystem.Directory.Exists(_folderSource))
            {
                items.AddRange(_fileSystem.Directory
                    .GetFiles(Path.Combine(_folderSource, collection), "*.*", SearchOption.AllDirectories)
                    .Select(file => new ContentItem() { Id = GetPageTitle(file), Content = SafeReadContents(file), Filename = file })
                );
            }
            
            return items.ToArray();
             * */
            return collections.Items.ToArray();
        }

        private string SafeReadContents(string file)
        {
            return null;
            
            /*
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
             * */
        }

        private string GetPageTitle(string file)
        {
            return Path.GetFileNameWithoutExtension(file);
        }

    }
}
