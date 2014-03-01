using System.Web.Mvc;
using System.Web.Routing;

namespace DemoBlog
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                name: "ViewEntry",
                url: "Home/Entry/{slug}",
                defaults: new { controller = "Home", action = "ViewEntry"}
            );

            routes.MapRoute(
                name: "NewEntry",
                url: "Home/New",
                defaults: new { controller = "Home", action = "NewEntry" }
            );

            routes.MapRoute(
                name: "EditEntry",
                url: "Home/Edit/{slug}",
                defaults: new { controller = "Home", action = "EditEntry" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
