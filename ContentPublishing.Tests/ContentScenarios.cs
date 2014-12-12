using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentPublishing.Tests
{
    using System.IO;

    using VirtoCommerce.Publishing;
    using VirtoCommerce.Publishing.Engines;

    using Xunit;

    public class ContentScenarios
    {
        [Fact]
        public void Can_generate_content_item()
        {
            var service = new ContentPublishingService("data", new []{ new LiquidTemplateEngine("data"), });
            var item = service.GetContentItem("yaml-header-input.md");
        }
    }
}
