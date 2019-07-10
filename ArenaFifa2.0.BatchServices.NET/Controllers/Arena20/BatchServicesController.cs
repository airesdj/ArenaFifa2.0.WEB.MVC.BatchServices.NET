using System;
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

        // GET: BatchServices/GenerateRenewal
        [UserModerator]
        public ActionResult GenerateRenewal(FormCollection formHTML)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            GenerateRenewalViewModel modelReturnJSON = new GenerateRenewalViewModel();
            GenerateRenewalViewModel modelReturnView = new GenerateRenewalViewModel();

            string actionForm = "summary";

            if (formHTML["actionForm"] != null)
                actionForm = formHTML["actionForm"].ToLower();

            setViewBagVariables();

            try
            {
                if (TempData["FullModel"] != null) { modelReturnView = (GenerateRenewalViewModel)TempData["FullModel"]; }
                modelReturnJSON.inRenewalWithWorldCup = Convert.ToInt16(ConfigurationManager.AppSettings["renewal.h2h.worldcup"].ToString());
                modelReturnJSON.inRenewalWithEuro = Convert.ToInt16(ConfigurationManager.AppSettings["renewal.h2h.uefaeuro"].ToString());

                if (actionForm=="summary")
                {
                    modelReturnJSON.actionUser = "summary";
                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("GenerateRenewal", modelReturnJSON).Result;
                    modelReturnJSON = response.Content.ReadAsAsync<GenerateRenewalViewModel>().Result;

                }
                else if (actionForm == "prepare-database-before")
                {
                    modelReturnJSON = modelReturnView;
                    modelReturnJSON.actionUser = "prepareDatabaseBefore";
                    modelReturnJSON.dataBaseName = GlobalVariables.DATABASE_NAME_STAGING;
                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("GenerateRenewal", modelReturnJSON).Result;
                    modelReturnJSON = response.Content.ReadAsAsync<GenerateRenewalViewModel>().Result;
                }
                else if (actionForm == "generate-renewal")
                {
                    modelReturnJSON = modelReturnView;
                    modelReturnJSON.actionUser = "generateRenewal";
                    modelReturnJSON.dataBaseName = GlobalVariables.DATABASE_NAME_STAGING;
                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("GenerateRenewal", modelReturnJSON).Result;
                    modelReturnJSON = response.Content.ReadAsAsync<GenerateRenewalViewModel>().Result;
                }
                else if (actionForm == "cancel-renewal")
                {
                    modelReturnJSON = modelReturnView;
                    modelReturnJSON.actionUser = "cancelRenewal";
                    modelReturnJSON.dataBaseName = GlobalVariables.DATABASE_NAME_STAGING;
                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("GenerateRenewal", modelReturnJSON).Result;
                    modelReturnJSON = response.Content.ReadAsAsync<GenerateRenewalViewModel>().Result;
                }
                else if (actionForm == "create-spooler")
                {
                    modelReturnJSON = modelReturnView;
                    modelReturnJSON.actionUser = "createSpooler";
                    modelReturnJSON.dataBaseName = GlobalVariables.DATABASE_NAME_STAGING;
                    modelReturnJSON.userActionID = Convert.ToInt32(Session["user.id"]);
                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("GenerateRenewal", modelReturnJSON).Result;
                    modelReturnJSON = response.Content.ReadAsAsync<GenerateRenewalViewModel>().Result;
                }
                else if (actionForm == "cancel-spooler")
                {
                    modelReturnJSON = modelReturnView;
                    modelReturnJSON.actionUser = "cancelSpooler";
                    modelReturnJSON.dataBaseName = GlobalVariables.DATABASE_NAME_STAGING;
                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("GenerateRenewal", modelReturnJSON).Result;
                    modelReturnJSON = response.Content.ReadAsAsync<GenerateRenewalViewModel>().Result;
                }
                else
                {
                    modelReturnJSON.returnMessage = "GenerateRenewalSuccessfully";
                    modelReturnJSON.actionUser = actionForm.ToUpper();
                    response.StatusCode = HttpStatusCode.Created;
                }

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "GenerateRenewalSuccessfully")
                        {
                            if (actionForm == "prepare-database-before") {
                                TempData["actionSuccessfully"] = "Staging Database was prepared successfully";
                            }
                            else if (actionForm == "generate-renewal")
                            {
                                TempData["actionSuccessfully"] = "The renewals were generated successfully";
                            }
                            else if (actionForm == "cancel-renewal")
                            {
                                TempData["actionSuccessfully"] = "All renewal processes were cancelled successfully";
                            }
                            else if (actionForm == "cancel-spooler")
                            {
                                TempData["actionSuccessfully"] = "The email spooler for renewal was cancelled successfully";
                            }
                            else if (actionForm == "create-spooler")
                            {
                                TempData["actionSuccessfully"] = "The email spooler for renewal was created successfully";
                            }
                        }
                        else
                        {
                            TempData["returnMessage"] = "Some error occurred when the system was trying to show the view: Generate Renewal - Summary. (" + modelReturnJSON.returnMessage + ")";
                        }
                        return View(modelReturnJSON);

                    default:
                        TempData["returnMessage"] = "Some error occurred when the system was trying to show the view: Generate Renewal - Summary. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(modelReturnView);
                }
            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Internal error - when the system was trying to show the view: Generate Renewal - Summary. (" + ex.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(modelReturnView);
            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                modelReturnView = null;
            }
        }

    }
}