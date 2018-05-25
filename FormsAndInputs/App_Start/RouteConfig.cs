﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FormsAndInputs
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "GuessingGame",
                url: "GuessingGame/{id}",
                defaults: new { controller = "Home", action = "GuessingGame", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "CheckTemp",
                url: "CheckTemp/{id}",
                defaults: new { controller = "Home", action = "CheckTemp", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "CheckTemp", id = UrlParameter.Optional }
            );
        }
    }
}
