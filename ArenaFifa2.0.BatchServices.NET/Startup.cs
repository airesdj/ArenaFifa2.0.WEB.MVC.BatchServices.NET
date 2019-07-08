using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ArenaFifa20.BatchServices.NET.Startup))]
namespace ArenaFifa20.BatchServices.NET
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}