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
                name: "About Directorate",
                url: "about-directorate.html",
                defaults: new { controller = "About", action = "Directorate", id = UrlParameter.Optional },
                namespaces: new string[] { "KamikazeThinhPhat.Web.Controllers" }

            );

            routes.MapRoute(
                name: "About Diagram",
                url: "about-diagram.html",
                defaults: new { controller = "About", action = "Diagram", id = UrlParameter.Optional },
                namespaces: new string[] { "KamikazeThinhPhat.Web.Controllers" }

            );

            routes.MapRoute(
                name: "Ledger Index",
                url: "ledger-index.html",
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
                name: "Portfolio Index",
                url: "portfolio-index.html",
                defaults: new { controller = "Portfolio", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "KamikazeThinhPhat.Web.Controllers" }

            );

            routes.MapRoute(
                name: "Portfolio Detail",
                url: "portfolio-detail.html",
                defaults: new { controller = "Portfolio", action = "Detail", id = UrlParameter.Optional },
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
