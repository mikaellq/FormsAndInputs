using System;
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
                name: "Add",
                url: "ViewModel/Add/{id}",
                defaults: new { controller = "ViewModel", action = "Add", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Delete",
                url: "ViewModel/Delete/{id}",
                defaults: new { controller = "ViewModel", action = "Delete", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ViewModel",
                url: "ViewModel/{id}",
                defaults: new { controller = "ViewModel", action = "Index", id = UrlParameter.Optional }
            );

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
