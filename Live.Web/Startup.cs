using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Live.Web.Startup))]
namespace Live.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
