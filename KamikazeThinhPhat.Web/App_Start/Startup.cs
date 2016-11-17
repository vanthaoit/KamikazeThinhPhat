using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using KamikazeThinhPhat.Data;
using KamikazeThinhPhat.Data.Infrastructure;
using KamikazeThinhPhat.Data.Repositories;
using KamikazeThinhPhat.Model.Models;
using KamikazeThinhPhat.Service;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.DataProtection;
using Owin;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

[assembly: OwinStartup(typeof(KamikazeThinhPhat.Web.App_Start.Startup))]

namespace KamikazeThinhPhat.Web.App_Start
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigAutofac(app);
            ConfigureAuth(app);
        }

        public void ConfigAutofac(IAppBuilder app)
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            // register your web API Controllers
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // register your Data
            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerRequest();
            builder.RegisterType<DbFactory>()
                .As<IDbFactory>()
                .InstancePerRequest();
            builder.RegisterType<KamikazeThinhPhatDbContext>()
                .AsSelf()
                .InstancePerRequest();

            //Asp.net Identity

            builder.RegisterType<ApplicationUserStore>().As<IUserStore<ApplicationUser>>().InstancePerRequest();
            builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationSignInManager>().AsSelf().InstancePerRequest();
            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();
            builder.Register(c => app.GetDataProtectionProvider()).InstancePerRequest();

            // Repository
            builder.RegisterAssemblyTypes(typeof(ProductRepository).Assembly)
                .Where(x => x.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerRequest();

            // Service
            builder.RegisterAssemblyTypes(typeof(ProductService).Assembly)
                .Where(x => x.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerRequest();

            IContainer container = builder.Build();
            // override cơ chế mặc định bằng register
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver =
                new AutofacWebApiDependencyResolver(container); // set the WebApi DependencyResolver
        }
    }
}