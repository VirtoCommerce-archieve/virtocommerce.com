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

    using Octokit;

    using VirtoCommerce.ContentModule.Web.Repositories;

    public class ContentScenarios
    {
        private string FolderRoot = @"e:\Projects\Git\virtocommerce.com\Website\App_Data\Contents";
        [Fact]
        public void Can_get_collections()
        {
            var controller = new PublishingContentController(new GitHubFileRepository(new Credentials("virtocommercecom", "v1rtocommerce"), new RepositoryInfo("VirtoCommerce", "vc-content")));
            var result = controller.GetCollections().Result;
            Assert.IsType<OkNegotiatedContentResult<CollectionItem[]>>(result);
        }

        [Fact]
        public void Can_get_collection_items()
        {
            var client = new GitHubFileRepository(
                new Credentials("virtocommercecom", "v1rtocommerce"),
                new RepositoryInfo("VirtoCommerce", "vc-content"));

            var controller = new PublishingContentController(client);
            var result = controller.GetCollectionItems("sample").Result;

            Assert.IsType<OkNegotiatedContentResult<ContentItem[]>>(result);
        }


        [Fact]
        public void Can_get_collection_item()
        {
            var client = new GitHubFileRepository(
                new Credentials("virtocommercecom", "v1rtocommerce"),
                new RepositoryInfo("VirtoCommerce", "vc-content"));

            var controller = new PublishingContentController(client);
            var result = controller.GetItem("sample", "readme.md").Result;
            //readme.md
            Assert.IsType<OkNegotiatedContentResult<ContentItem>>(result);
        }
    }
}
