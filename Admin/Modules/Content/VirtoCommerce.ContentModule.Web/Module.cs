
namespace VirtoCommerce.ContentModule.Web
{
    using System.IO.Abstractions;

    using Microsoft.Practices.Unity;

    using Octokit;

    using VirtoCommerce.ContentModule.Web.Repositories;
    using VirtoCommerce.Framework.Web.Modularity;

    public class Module : IModule
    {
        private readonly IUnityContainer _container;
        public Module(IUnityContainer container)
        {
            _container = container;
        }

        public void Initialize()
        {
            //_container.RegisterType<IFileSystem, FileSystem>();
            _container.RegisterInstance(new Credentials("virtocommercecom", "v1rtocommerce"));
            _container.RegisterInstance(new RepositoryInfo("VirtoCommerce", "vc-content"));

            _container.RegisterType<IFileRepository, GitHubFileRepository>();

        }
    }
}
