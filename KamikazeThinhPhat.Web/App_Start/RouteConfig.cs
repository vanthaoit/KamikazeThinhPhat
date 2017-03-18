using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace KamikazeThinhPhat.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.IgnoreRoute("{*botdetect}", new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });

            routes.MapRoute(
                name: "About Index",
                url: "about-index.html",
                defaults: new { controller = "About", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "KamikazeThinhPhat.Web.Controllers" }

            );

            routes.MapRoute(
                name: "Default Index",
                url: "default-index.html",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional,alias = "vai-net-ve-thinh-phat" },
                namespaces: new string[] { "KamikazeThinhPhat.Web.Controllers" }

            );

            routes.MapRoute(
                name: "About vai net ve thinh phat",
                url: "about.index-vai-net-ve-thinh-phat.html",
                defaults: new { controller = "About", action = "Index", id = UrlParameter.Optional,alias="vai-net-ve-thinh-phat" },
                namespaces: new string[] { "KamikazeThinhPhat.Web.Controllers" }

            );


            routes.MapRoute(
                name: "About Detail",
                url: "about.index-co-cau-to-chuc.html",
                defaults: new { controller = "About", action = "Diagram", id = UrlParameter.Optional,alias ="co-cau-to-chuc" },
                namespaces: new string[] { "KamikazeThinhPhat.Web.Controllers" }

            );


            routes.MapRoute(
                name: "Portfolio Index",
                url: "portfolio-index.html",
                defaults: new { controller = "Portfolio", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "KamikazeThinhPhat.Web.Controllers" }

            );

            routes.MapRoute(
                name: "Portfolio child",
                url: "portfolio.index-{alias}-{id}.html",
                defaults: new { controller = "Portfolio", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "KamikazeThinhPhat.Web.Controllers" }

            );


            routes.MapRoute(
                name: "Portfolio Detail",
                url: "portfolio.detail-{alias}-{id}.html",
                defaults: new { controller = "Portfolio", action = "Detail", id = UrlParameter.Optional },
                namespaces: new string[] { "KamikazeThinhPhat.Web.Controllers" }

            );


            routes.MapRoute(
                name: "Ledger Index",
                url: "ledger-index.html",
                defaults: new { controller = "Ledger", action = "Default", id = UrlParameter.Optional },
                namespaces: new string[] { "KamikazeThinhPhat.Web.Controllers" }

            );

            routes.MapRoute(
                name: "Ledger Index Sub",
                url: "ledger-index-{id}.html",
                defaults: new { controller = "Ledger", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "KamikazeThinhPhat.Web.Controllers" }

            );

            routes.MapRoute(
                name: "Partner Index",
                url: "partner-index.html",
                defaults: new { controller = "Partner", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "KamikazeThinhPhat.Web.Controllers" }

            );

            routes.MapRoute(
                name: "Partner Detail",
                url: "partner.detail-{alias}-{id}.html",
                defaults: new { controller = "Partner", action = "Detail", id = UrlParameter.Optional },
                namespaces: new string[] { "KamikazeThinhPhat.Web.Controllers" }

            );

            routes.MapRoute(
              name: "Contact Index",
              url: "contact-index.html",
              defaults: new { controller = "Contact", action = "Index", id = UrlParameter.Optional },
              namespaces: new string[] { "KamikazeThinhPhat.Web.Controllers" }

          );


            routes.MapRoute(
              name: "Back Default",
              url: "default.html",
              defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
              namespaces: new string[] { "KamikazeThinhPhat.Web.Controllers" }
          );

            
            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           );

        }
    }
}
