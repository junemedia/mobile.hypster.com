using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace hypster
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //--------------------------------------------------------------------------------------------
            routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            //--------------------------------------------------------------------------------------------





            // LISTEN
            //--------------------------------------------------------------------------------------------
            routes.MapRoute(
                name: "ProfileDefault",
                url: "listen/{genre}",
                defaults: new { controller = "listen", action = "index", genre = "" }
            );
            //--------------------------------------------------------------------------------------------





            //--------------------------------------------------------------------------------------------
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            //--------------------------------------------------------------------------------------------




            routes.IgnoreRoute("{resource}.ashx/{*pathInfo}");
            

        }
    }
}