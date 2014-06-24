using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WorkOrderSite.Startup))]
namespace WorkOrderSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
