using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CoronaVirusSolution2._0
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.Add(
        "StaticRoute", new Route("static/{file}", new FileRouteHandler())
          );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "login", id = UrlParameter.Optional }
            );

            //routes.MapRoute(
            //name: "My_Own_Research",
            //url: "My_Own_Research/login",
            //defaults: new { controller = "My_Own_Research", action = "login", id = UrlParameter.Optional, desc = UrlParameter.Optional, catid = UrlParameter.Optional }
            //);
        }
    }

    public class FileRouteHandler : IRouteHandler
    {

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            String fileName = (String)requestContext.RouteData.Values["file"];
            // Contrived example of mapping.
            String routedPath = String.Format("/images/{0}", fileName);
            HttpContext.Current.Server.Transfer(routedPath);
            return null; // Never reached.
        }
    }
}
