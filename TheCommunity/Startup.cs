using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheCommunity.Startup))]
namespace TheCommunity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
