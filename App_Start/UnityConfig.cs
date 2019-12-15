using Greenslate.Repositories.Implementations;
using Greenslate.Repositories.Interfaces;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace Greenslate
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IUsersRepository, UsersRepository>();
            container.RegisterType<IProjectsRepository, ProjectsRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}