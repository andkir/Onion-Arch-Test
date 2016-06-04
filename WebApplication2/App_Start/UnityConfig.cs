using Microsoft.Practices.Unity;
using System.Web.Http;
using System.Web.Mvc;
using BusinessLogic;
using Core.Interfaces;
using Infrastructure;
using Unity.Mvc5;

//using Unity.WebApi;

namespace WebApplication2
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<ISportComplexRepository, SportComplexRepository>();
            container.RegisterType<ISportTypeRepository, SportTypeRepository>();
            container.RegisterType<ISportListOutput, SportListOutputHtml>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}