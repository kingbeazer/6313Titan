using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_6313Titan.Startup))]
namespace _6313Titan
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
