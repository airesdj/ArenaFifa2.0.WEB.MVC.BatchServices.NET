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
