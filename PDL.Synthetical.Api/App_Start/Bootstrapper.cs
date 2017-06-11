using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using PDL.Synthetical.Infrastructure;
using PDL.Synthetical.Repositories;
using PDL.Synthetical.Services;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;

namespace PDL.Synthetical.Api
{
    public class Bootstrapper
    {
        public static void Run()
        {
            SetAutofacContainer();           
        }

        private static void SetAutofacContainer()

        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            //builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<ConnectionFactory>().As<IConnectionFactory>().InstancePerLifetimeScope();
            //builder.RegisterType<BaseConnectionFactory>().As<IBaseConnectionFactory>().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(IUserInfoRepository).Assembly)
            .Where(t => t.Name.EndsWith("Repository"))
            .AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(IUserInfoService).Assembly)
           .Where(t => t.Name.EndsWith("Service"))
           .AsImplementedInterfaces().InstancePerLifetimeScope();




            builder.RegisterFilterProvider();
            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Autofac.Integration.WebApi.AutofacWebApiDependencyResolver(container);
        }
    }
}