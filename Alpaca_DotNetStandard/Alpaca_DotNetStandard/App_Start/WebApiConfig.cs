using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Alpaca_DotNetStandard
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            config.Routes.MapHttpRoute(
               name: "DefaultApi",
               routeTemplate: "api/v1/telescope/{device_number}/{controller}",
               defaults: new { id = RouteParameter.Optional }
           );
        }
    }
}
