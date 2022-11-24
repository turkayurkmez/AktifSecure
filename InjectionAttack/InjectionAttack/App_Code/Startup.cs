using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InjectionAttack.Startup))]
namespace InjectionAttack
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
