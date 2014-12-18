
namespace VirtoCommerce.ContentModule.Web
{
    using System.IO.Abstractions;

    using Microsoft.Practices.Unity;

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
            _container.RegisterType<IFileSystem, FileSystem>();

        }
    }
}
