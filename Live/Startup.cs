using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Live.Startup))]
namespace Live
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
