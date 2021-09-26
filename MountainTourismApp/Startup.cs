using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MountainTourismApp.Startup))]
namespace MountainTourismApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
