using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SirahnFinalProject.Startup))]
namespace SirahnFinalProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
