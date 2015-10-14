using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Telemetry.WebUI.Startup))]
namespace Telemetry.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
