﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AirPlane.WebUI.Controllers.RoutingURL.Infrastructure;
namespace AirPlane.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

#if false
            // routes.Add(new Route("SayHello", new CustomRouteHandler()));
            routes.Add(new LegacyRoute(
                "~/Articles/WindowsXp", "~/old/.NET1,0_Class_Library"));
            routes.RouteExistingFiles = true;
            /*Creating and Registering a Simple Route   p364*/
            Route myRoute = new Route("{controller}/Route{action}", new MvcRouteHandler());
           
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
          //  routes.IgnoreRoute("Content/{filename}.html");

            routes.MapRoute(
               name: "Spec_Static_Segm",
               url: "ALL",
               defaults: new { controller = "Custom", action = "Index", id = UrlParameter.Optional },
               constraints: new {customConstraint = new UserAgentConstraint("Chrome") }
               );

            routes.MapRoute(
           name: "showImage",
           url: "Content/StaticContent.html",
           defaults: new { controller = "Custom", action = "showImage", id = UrlParameter.Optional }
           );

            routes.MapRoute(
            name: "Spec_Static_SegmIE",
            url: "ALL",
            defaults: new { controller = "Custom", action = "CustomVariable", id = UrlParameter.Optional },
            constraints: new { customConstraint = new UserAgentConstraint("Trident") }
            );
            /* static URL Segment  372*/
            routes.MapRoute(
             name: "Add_Segment",
             url: "Secret/{controller}/{action}/{id}",
             defaults: new { controller = "Admin", action = "Index", id = UrlParameter.Optional }
         );

            /* static URL Segment  372*/
            routes.MapRoute(
             name: "CustomDS",
             url: "DS{controller}/{action}/{id}",
             defaults: new { controller = "RouteCustom", action = "Index", id = 1 }
         );
            routes.MapRoute(
               name: "Paging",
               url: "P{page}",
               defaults: new { controller = "AirCraft", action = "List", category = (string)null }, 
               constraints: new { page = @"\d+" }
               );

           /* routes.MapRoute("CategoryOnly",
                "{category}",
                new { controller = "AirCraft", action = "List", page = 1 }
                );*/
           
            routes.MapRoute("CateforyAndPage",
            "{category}/P{page}",
            new { controller = "AirCraft", action = "List" },
            new { page = @"\d+" }
            );
            /* static URL Segment  372*/
            routes.MapRoute(
                name: "Segment2",
                url: "{controller}/X{action}/{id}",
                defaults: new { controller = "AirCraft", action = "List", id = UrlParameter.Optional }
            );
            /*Defining Default Values p.370 */
           var myMpaRoute = routes.MapRoute(
               name: "DefaultWithconstraint",
               url: "{controller}/{action}/{id}/{*catchall}",
               defaults: new { controller = "AirCraft", action = "List", id = UrlParameter.Optional },
               constraints: new { action = "^L.*", httpMethod =new HttpMethodConstraint("GET", "POST") },
               namespaces: new[] { "AirPlane.WebUI.Controllers.RoutingURL" }
           );

         routes.MapRoute(
             name: "Default",
             url: "{controller}/{action}/{id}/{*catchall}",
             defaults: new { controller = "AirCraft", action = "List", id = UrlParameter.Optional},
             namespaces: new [] {"AirPlane.WebUI.Controllers"}
     );
            /*disable searching other namespaces  
            myMpaRoute.DataTokens["UseNamespaceFallback"] = false ;*/

            /*Creating and Registering a Simple Route  p. 364*/
            //  routes.Add("myRoute",myRoute);
#endif


            routes.MapRoute(
                name: "AllCategorty",
                url: "",
                defaults: new { controller = "AirCraft", action = "List", category = (string)null, page = 1 }
                );



            routes.MapRoute(
               name: "Paging",
               url: "P{page}",
               defaults: new { controller = "AirCraft", action = "List", category = (string)null },
               constraints: new { page = @"\d+" }
               );

            routes.MapRoute(name: "CategoryOnly",
                url: "{category}",
                defaults: new { controller = "AirCraft", action = "List", page = 1 }
                );


            routes.MapRoute("CateforyAndPage",
            "{category}/P{page}",
            new { controller = "AirCraft", action = "List" },
            new { page = @"\d+" }
            );
            routes.MapRoute(
                name: "FormRoute",
                url: "People/{action}",
                defaults: new { controller = "People", action = "Indenx" },
                namespaces: new[] { "AirPlane.WebUI.Controllers.MVCGuide" }
                );
            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "AirCraft", action = "List", id = UrlParameter.Optional },
                namespaces: new[] { "AirPlane.WebUI.Controllers" }

            );
        }
    }
}