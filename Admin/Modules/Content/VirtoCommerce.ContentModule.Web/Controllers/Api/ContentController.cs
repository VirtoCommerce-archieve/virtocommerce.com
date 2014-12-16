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
    }
}
