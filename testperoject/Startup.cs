using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(testperoject.Startup))]
namespace testperoject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
