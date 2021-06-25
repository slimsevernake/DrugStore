using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DrugStore.Startup))]
namespace DrugStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
