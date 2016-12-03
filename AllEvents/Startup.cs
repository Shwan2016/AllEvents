using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AllEvents.Startup))]
namespace AllEvents
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
