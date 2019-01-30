using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Event.Startup))]
namespace Event
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
