using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.ContentModule.Web.Controllers.Api
{
    using System.Web.Http;
    using System.Web.Http.Description;

    using VirtoCommerce.ContentModule.Web.Model;

    [RoutePrefix("api/contents")]
    public class PublishingContentController : ApiController
    {
        // GET: api/contents/collections
        [HttpGet]
        [ResponseType(typeof(CollectionItem[]))]
        [Route("collections")]
        public IHttpActionResult GetCollections()
        {
            var retVal = new[] { new CollectionItem() { Id = "Pages" }, new CollectionItem() { Id = "Blogs" } };
            return Ok(retVal);
        }

        [HttpGet]
        [ResponseType(typeof(ContentItem[]))]
        [Route("collections/{collection}/items")]
        public IHttpActionResult GetCollectionItems(string collection)
        {
            var retVal = new[] { new ContentItem() { Id = "enterprise.md", Content = "some enterprise version", LastUpdated = DateTime.Now, Status = "Published"}, new ContentItem() { Id = "Item 2" } };
            return Ok(retVal);
        }

        [HttpGet]
        [ResponseType(typeof(ContentItem))]
        [Route("collections/{collection}/items/{itemId}")]
        public IHttpActionResult GetItem(string collection, string itemId)
        {
            var retVal = new ContentItem() { Id = "enterprise.md", Content = "some enterprise version", LastUpdated = DateTime.Now, Status = "Published" };
            return Ok(retVal);
        }
    }
}
