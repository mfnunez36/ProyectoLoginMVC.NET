using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebLogin
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Listar_Perfiles",
                url: "Perfil",
                defaults: new { controller = "Perfil", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Editar_Perfil",
                url: "Perfil/Editar/{id}",
                defaults: new { controller = "Perfil", action = "Editar", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Agregar_Perfil",
                url: "Perfil/Agregar",
                defaults: new { controller = "Perfil", action = "Agregar", id = UrlParameter.Optional }
            );
        }
    }
}
