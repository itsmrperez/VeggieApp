using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using System.Web.Http;
using VeggieApp.Web.Services.Interfaces;
using VeggieApp.Web.Services;
using VeggieApp.Web.Core.Injection;

namespace VeggieApp.Web
{
    public static class UnityConfig
    {
        private static UnityContainer _container;
        public static UnityContainer GetContainer()
        {
            return _container;
        }

        public static void RegisterComponents(HttpConfiguration config)
        {
            UnityContainer container = new UnityContainer();

            container.RegisterType<IRecipeService, RecipeService>(new ContainerControlledLifetimeManager());

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            config.DependencyResolver = new UnityResolver(container);

            _container = container;
        }
    }
}