using System.Web.Mvc;
using System.Web.Routing;

namespace OreoFood.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // /trace.axs/1/2/3/4
            // This is a special endpoint in ASP.NET web applications that provides tracing data.
            //  As a result, we ignore this route for security reasons.
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            // /customers/contact/1
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
