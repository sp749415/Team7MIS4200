using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Team7MIS4200.Startup))]
namespace Team7MIS4200
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
