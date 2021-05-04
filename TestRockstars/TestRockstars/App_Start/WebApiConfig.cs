using System.Net.Http.Formatting;
using System.Web.Http;

namespace TestRockstars
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Set the configuration to JSON
            GlobalConfiguration.Configuration.Formatters.Clear();
            GlobalConfiguration.Configuration.Formatters.Add(new JsonMediaTypeFormatter());

            // Dynamic Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}