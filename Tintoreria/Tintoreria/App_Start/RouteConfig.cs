using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );

            foreach(Route r in routes)
            {
                if (!(r.RouteHandler is SingleCultureMvcRouteHandler))
                {
                    r.RouteHandler = new MultiCultureMvcRouteHandler();
                    r.Url = "{culture}/" + r.Url;
                    //Adding default culture
                    if (r.Defaults == null)
                        r.Defaults = new RouteValueDictionary();

                    r.Defaults.Add("culture", CulturesAvailables.es.ToString());

                    //Adding constraint for culture param
                    if (r.Constraints == null)
                        r.Constraints = new RouteValueDictionary();

                    r.Constraints.Add("culture", new CultureConstraint(
                        CulturesAvailables.es.ToString(),
                        CulturesAvailables.en.ToString()));
                }
            }
            routes.MapRoute(
                name: "SingleCulture",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "KeyValuePacienteList", action = "Index", id = UrlParameter.Optional }).RouteHandler = new SingleCultureMvcRouteHandler();
        }
    }
}
