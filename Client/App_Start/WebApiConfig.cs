using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Client
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //private Timer t1;
            config.EnableCors();
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
