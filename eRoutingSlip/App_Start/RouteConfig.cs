using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Routing.Constraints;
using System.Web.Routing;

namespace eRoutingSlip
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
             "SetPrevNext",
             "RoutingSlip/SetPrevNext/{id}",
             new { controller = "RoutingSlip", action = "SetPrevNext" });

            routes.MapRoute(
             "AddName",
             "LinkedListSignatureNode/CreateSignature/{id}",
             new { controller = "LinkedListSignatureNode", action = "CreateSignature" });

            //routes.MapRoute(
            //"ViewNodes",
            // "LinkedListSignatureNode/Details/{id}",
            // new { controller = "LinkedListSignatureNode", action = "Details" });


            routes.MapRoute(
                "newnode",
                "{controller}/{action}/{id}/{n}",
                new
                {
                    controller = "LinkedListSignatureNode",
                    action = "NewNode"

                });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
