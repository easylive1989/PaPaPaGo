﻿using System.Web.Mvc;
using System.Web.Routing;

namespace PapapaGo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Report",
                url: "Report",
                defaults: new { controller = "Bid", action = "SoldOutReport", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Bid",
                url: "Bid",
                defaults: new { controller = "Bid", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}