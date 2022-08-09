using Autofac;
using Autofac.Integration.Mvc;
using EventsApplication.Models;
using EventsApplication.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace EventsApplication
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<ApplicationDbContext>().AsSelf();
            builder.RegisterType<CustomerService>().As<ICustomerService>();
            builder.RegisterType<EventService>().As<IEventService>();
            builder.RegisterType<TicketService>().As<ITicketService>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
           
        }
    }
}
