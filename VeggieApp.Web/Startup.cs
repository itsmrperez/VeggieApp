using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VeggieApp.Web.Startup))]
namespace VeggieApp.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
