using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(eRoutingSlip.Startup))]
namespace eRoutingSlip
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
