using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebExamination.Startup))]
namespace WebExamination
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
