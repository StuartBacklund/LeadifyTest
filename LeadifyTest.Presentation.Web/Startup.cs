using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LeadifyTest.Presentation.Web.Startup))]
namespace LeadifyTest.Presentation.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
