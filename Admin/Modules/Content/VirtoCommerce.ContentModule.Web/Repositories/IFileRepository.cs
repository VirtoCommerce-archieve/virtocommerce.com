using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.ContentModule.Web.Repositories
{
    using Octokit;

    using VirtoCommerce.ContentModule.Web.Model;

    public interface IFileRepository
    {        
        Task<ResponseCollection<CollectionItem>> GetCollections();

        Task<ResponseCollection<ContentItem>> GetCollectionItems(string collection, int startIndex, int pageSize);

        Task<ContentItem> GetContentItem(string collection, string name);

        Task<ContentItem> SaveContentItem(string collection, string name, ContentItem item);

        Task DeleteContentItem(string collection, string name);
    }
}
