using Autofac;
using EventsLibrary.Service;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EventsApplication.Startup))]
namespace EventsApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
        
    }
}
