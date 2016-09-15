using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Seguradora.Presentation.Web.Startup))]
namespace Seguradora.Presentation.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
