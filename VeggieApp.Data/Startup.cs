using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VeggieApp.Data.Startup))]
namespace VeggieApp.Data
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
