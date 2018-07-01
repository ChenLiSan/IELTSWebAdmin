using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IELTSWebAdmin.Startup))]
namespace IELTSWebAdmin
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
