using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SportskaOpremaNemanjaTutunovic.Startup))]
namespace SportskaOpremaNemanjaTutunovic
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
