using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AOS.Startup))]
namespace AOS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
