using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace B2B
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "SalesOrder",
                url: "sales-order/{id}",
                defaults: new { controller = "SalesOrder", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Document",
                url: "search-document/{id}",
                defaults: new { controller = "Document", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "PriceTicket",
                url: "price-ticket/{id}",
                defaults: new { controller = "PriceTicket", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Price",
                url: "price-list/{id}",
                defaults: new { controller = "Price", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ProductCard",
                url: "product-card/{id}",
                defaults: new { controller = "ProductCard", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Picture",
                url: "pictures/{id}",
                defaults: new { controller = "Picture", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Help",
                url: "helps/{id}",
                defaults: new { controller = "Help", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Stock",
                url: "free-stock/{id}",
                defaults: new { controller = "Stock", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
