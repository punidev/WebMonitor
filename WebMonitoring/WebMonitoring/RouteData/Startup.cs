using System.Web.Http;
using Owin;

namespace WebMonitoring.RouteData
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{action}/{id}", 
                new {id = RouteParameter.Optional});

            appBuilder.UseWebApi(config);
        }
    }
}
