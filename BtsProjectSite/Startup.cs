using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BtsProjectSite.Startup))]
namespace BtsProjectSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
