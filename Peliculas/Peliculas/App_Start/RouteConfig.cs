using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Peliculas
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "norte america",
                url: "countries/{pais}",
                defaults: new { controller = "countries", action = "NorthAmerica" },
                constraints: new { pais = "(us|ca|mx)" }
            );

            routes.MapRoute(
               name: "europa",
               url: "countries/{pais}",
               defaults: new { controller = "countries", action = "Europa" },
               constraints: new { pais = "(uk|de|es|fr|it)" }
           );
            routes.MapRoute(
               name: "otros",
               url: "countries/{pais}",
               defaults: new { controller = "countries", action = "otros" }

           );
            /*routes.MapRoute(
              name: "error",
              url: "home/error/{Error}",
              defaults: new { controller = "countries", action = "otros" }

          );*/
            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "home", action = "index", id = UrlParameter.Optional }
            );
        }
    }
}