using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using VirtoCommerce.ContentModule.Web.Controllers.Api;
using VirtoCommerce.ContentModule.Web.Model;
using Xunit;

namespace ContentModule.Tests
{
    using System.IO.Abstractions;

    public class ContentScenarios
    {
        private string FolderRoot = @"e:\Projects\Git\virtocommerce.com\Website\App_Data\Contents";
        [Fact]
        public void Can_get_collections()
        {
            var controller = new PublishingContentController(new FileSystem(), FolderRoot);
            var result = controller.GetCollections();
            Assert.IsType<OkNegotiatedContentResult<CollectionItem[]>>(result);
        }

        [Fact]
        public void Can_get_collection_items()
        {
            var controller = new PublishingContentController(new FileSystem(), FolderRoot);
            var result = controller.GetCollectionItems("Pages");
            Assert.IsType<OkNegotiatedContentResult<ContentItem[]>>(result);
        }
    }
}
