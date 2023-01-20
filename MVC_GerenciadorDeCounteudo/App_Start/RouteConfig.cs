using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC_GerenciadorDeCounteudo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "paginas",
                "paginas",
                new { controller = "Paginas", action = "Index" }

                );

            routes.MapRoute(
                "paginas_cadastro",
                "paginas/cadastro",
                new { controller = "Paginas", action = "Cadastro" }

                );

            routes.MapRoute(
                "paginas_editar",
                "paginas/{id}/editar",
                new { controller = "Paginas", action = "Editar", id = 0 }

                );

            routes.MapRoute(
                "paginas_alterar",
                "paginas/{id}/alterar",
                new { controller = "Paginas", action = "Alterar", id = 0 }

                );

            routes.MapRoute(
                "paginas_previsao",
                "paginas/{id}/previsao",
                new { controller = "Paginas", action = "Previsao", id = 0 }

                );

            routes.MapRoute(
                "paginas_deletar",
                "paginas/{id}/deletar",
                new { controller = "Paginas", action = "Deletar", id = 0 }

                );

            routes.MapRoute(
                "paginas_criar",
                "paginas/criar",
                new { controller = "Paginas", action = "Criar" }

                );

            routes.MapRoute(
                "contato",
                "contato",
                new { controller = "Home", action = "Contact" }

                );

            routes.MapRoute(
                "sobre",
                "sobre",
                new { controller = "Home", action = "About" }

                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
