using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ArenaFifa20.BatchServices.NET
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Application["fifa.codImgCurrent"] = "Fifa19";

            // Add /MyVeryOwn/ folder to the default location scheme for STANDARD Views
            var razorEngine = ViewEngines.Engines.OfType<RazorViewEngine>().FirstOrDefault();
            razorEngine.ViewLocationFormats =
                razorEngine.ViewLocationFormats.Concat(new string[] {
            "~/Arena20/Views/Shared/{0}.cshtml",
            "~/Arena20/Views/{1}/{0}.cshtml",
            "~/Arena20/Views/{0}.cshtml"
                    // add other folders here (if any)
                }).ToArray();

            // Add /MyVeryOwnPartialFolder/ folder to the default location scheme for PARTIAL Views
            razorEngine.PartialViewLocationFormats =
                razorEngine.PartialViewLocationFormats.Concat(new string[] {
            "~/Arena20/Views/Shared/{0}.cshtml",
            "~/Arena20/Views/{1}/{0}.cshtml",
            "~/Arena20/Views/{0}.cshtml"
                    // add other folders here (if any)
                }).ToArray();
        }

        protected void Session_Start()
        {
            InitializeSessionVariales();
        }

        private void InitializeSessionVariales()
        {
            Session["session.active"] = false;

            Session["user.id"] = String.Empty;
            Session["user.name"] = String.Empty;
            Session["user.isModerator"] = false;
            Session["user.pathAvatar"] = String.Empty;
            Session["user.dtLastAccess"] = String.Empty;
            Session["user.psnID"] = String.Empty;
            Session["user.dsEmail"] = String.Empty;
            Session["user.currentTeam"] = String.Empty;
            Session["user.totalTitlesWon"] = "0";

            Session["app.totalVices"] = "0";
            Session["user.teamNameH2H"] = String.Empty;
            Session["user.teamNameFUT"] = String.Empty;
            Session["user.teamNamePRO"] = String.Empty;
        }
    }
}
