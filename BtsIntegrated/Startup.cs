using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BtsIntegrated.Startup))]
namespace BtsIntegrated
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
