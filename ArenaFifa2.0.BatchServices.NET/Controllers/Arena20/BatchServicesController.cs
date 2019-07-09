using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Net.Http;
using System.Net;
using System.Configuration;
using ArenaFifa20.BatchServices.NET.Models;
using static ArenaFifa20.NET.App_Start.CheckUserModerator;

namespace ArenaFifa20.BatchServices.NET.Controllers
{
    public class BatchServicesController : Controller
    {
        private void setViewBagVariables()
        {
            ViewBag.inGentelella = "1";
            ViewBag.inBatchServices = "1";
            ViewBag.inDataTables = "0";
        }

        // GET: BatchServices/Summary
        [UserModerator]
        public ActionResult Summary()
        {
            setViewBagVariables();
            return View();
        }
    }
}