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
        private PublishingContentController Controler
        {
            get
            {
                return
                    new PublishingContentController(
                        new GitHubFileRepository(
                            new Credentials("virtocommercecom", "v1rtocommerce"),
                            new RepositoryInfo("VirtoCommerce", "vc-content")));
            }
        }
        private string FolderRoot = @"e:\Projects\Git\virtocommerce.com\Website\App_Data\Contents";
        [Fact]
        public void Can_get_collections()
        {
            var controller = this.Controler;
            var result = controller.GetCollections().Result;
            Assert.IsType<OkNegotiatedContentResult<CollectionItem[]>>(result);
        }

        [Fact]
        public void Can_get_collection_items()
        {
            var controller = this.Controler;
            var result = controller.GetCollectionItems("sample").Result;

            Assert.IsType<OkNegotiatedContentResult<ContentItem[]>>(result);
        }


        [Fact]
        public void Can_get_collection_item()
        {
            var controller = this.Controler;
            var result = controller.GetItem("sample", "readme.md").Result;
            //readme.md
            Assert.IsType<OkNegotiatedContentResult<ContentItem>>(result);
        }

        [Fact]
        public void Can_crud_content_item()
        {
            var controller = this.Controler;

            var createResult22 = controller.Save(
                "",
                "1sample.md",
                new ContentItem() { Content = "hello world", Id = "sample.md" }).Result;

            var createResult = controller.Save(
                "test",
                "1sample.md",
                new ContentItem() { Content = "hello world", Id = "sample.md" }).Result;

            var result = controller.GetItem("test", "sample.md").Result;

            //readme.md
            Assert.IsType<OkNegotiatedContentResult<ContentItem>>(result);

            var updateResult = controller.Save(
                "test",
                "1sample.md",
                new ContentItem() { Content = "hello world NEW", Id = "1sampleNEW.md" }).Result;

            var result2 = controller.GetItem("test", "1sampleNEW.md").Result;

            //readme.md
            Assert.IsType<OkNegotiatedContentResult<ContentItem>>(result);

            var updateResult2 = controller.Save(
                "test",
                "1sampleNEW.md",
                new ContentItem() { Content = "hello world NEW", Id = "1sampleNEW2.md" }).Result;

            var result3 = controller.GetItem("test", "1sampleNEW2.md").Result;

            var deleteResult = controller.Delete("test", "1sampleNEW.md").Result;
        }

    }
}
