using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using Repositories.DomainServices;
using Repositories.Models.Domain;
using Repositories.Models.Entities;
using Repositories.Models.ViewModels;
using Repositories.Repositories;

namespace Repositories
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            Application_Bootstrapping();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
        }

        protected void Application_Bootstrapping()
        {

            AutomapperInitilialization();
            InitializeContainer();
        }

        protected void InitializeContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<ContactRepository>().As<IContactRepository>();
            builder.RegisterType<ContactService>().As<IContactService>();



           

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }

        private static void AutomapperInitilialization()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Contact, ContactEntity>();
                cfg.CreateMap<ContactEntity, Contact>();
                cfg.CreateMap<Contact, ContactViewModel>();
                cfg.CreateMap<ContactViewModel, Contact>();
                cfg.CreateMap<Contact, CreateContactViewModel>();
                cfg.CreateMap<CreateContactViewModel, Contact>();
            });
        }


        
        
    }
}
