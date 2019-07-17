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
            ViewBag.inFormScript = "0";
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


        // GET: BatchServices/GenerateNewSeasonH2H
        [UserModerator]
        public ActionResult GenerateNewSeasonH2H()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            GenerateNewSeasonDetailsModel modelReturnJSON = new GenerateNewSeasonDetailsModel();
            GenerateNewSeasonDetailsModel modelReturnView = new GenerateNewSeasonDetailsModel();

            setViewBagVariables();
            ViewBag.inFormScript = "1";

            try
            {
                modelReturnView.actionUser = "getSeasonDetails";
                modelReturnView.modeType = "H2H";
                response = GlobalVariables.WebApiClient.PostAsJsonAsync("GenerateNewSeason", modelReturnView).Result;
                modelReturnView = response.Content.ReadAsAsync<GenerateNewSeasonDetailsModel>().Result;

                if (modelReturnView.returnMessage == "GenerateNewSeasonSuccessfully")
                {
                    modelReturnView.actionUser = "getAllChampionshipsActiveDetails";
                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("GenerateNewSeason", modelReturnView).Result;
                    modelReturnView = response.Content.ReadAsAsync<GenerateNewSeasonDetailsModel>().Result;
                }
                modelReturnJSON = modelReturnView;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        return View("GenerateNewSeason", modelReturnJSON);

                    default:
                        TempData["returnMessage"] = "Some error occurred when the system was trying to show the view: Generate New Season - Set Up Initial. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View("GenerateNewSeason", modelReturnJSON);
                }
            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Internal error - when the system was trying to show the view: Generate New Season - Set Up Initial. (" + ex.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View("GenerateNewSeason", modelReturnView);
            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                modelReturnView = null;
            }
        }


        // GET: BatchServices/GenerateNewSeasonFUT
        [UserModerator]
        public ActionResult GenerateNewSeasonFUT()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            GenerateNewSeasonDetailsModel modelReturnJSON = new GenerateNewSeasonDetailsModel();
            GenerateNewSeasonDetailsModel modelReturnView = new GenerateNewSeasonDetailsModel();

            setViewBagVariables();
            ViewBag.inFormScript = "1";

            try
            {
                modelReturnView.actionUser = "getSeasonDetails";
                modelReturnView.modeType = "FUT";
                response = GlobalVariables.WebApiClient.PostAsJsonAsync("GenerateNewSeason", modelReturnView).Result;
                modelReturnView = response.Content.ReadAsAsync<GenerateNewSeasonDetailsModel>().Result;

                if (modelReturnView.returnMessage == "GenerateNewSeasonSuccessfully")
                {
                    modelReturnView.actionUser = "getAllChampionshipsActiveDetails";
                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("GenerateNewSeason", modelReturnView).Result;
                    modelReturnView = response.Content.ReadAsAsync<GenerateNewSeasonDetailsModel>().Result;
                }
                modelReturnJSON = modelReturnView;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        return View("GenerateNewSeason", modelReturnJSON);

                    default:
                        TempData["returnMessage"] = "Some error occurred when the system was trying to show the view: Generate New Season - Set Up Initial. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View("GenerateNewSeason", modelReturnJSON);
                }
            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Internal error - when the system was trying to show the view: Generate New Season - Set Up Initial. (" + ex.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View("GenerateNewSeason", modelReturnView);
            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                modelReturnView = null;
            }
        }


        // GET: BatchServices/GenerateNewSeasonPRO
        [UserModerator]
        public ActionResult GenerateNewSeasonPRO()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            GenerateNewSeasonDetailsModel modelReturnJSON = new GenerateNewSeasonDetailsModel();
            GenerateNewSeasonDetailsModel modelReturnView = new GenerateNewSeasonDetailsModel();

            setViewBagVariables();
            ViewBag.inFormScript = "1";

            try
            {
                modelReturnView.actionUser = "getSeasonDetails";
                modelReturnView.modeType = "PRO";
                response = GlobalVariables.WebApiClient.PostAsJsonAsync("GenerateNewSeason", modelReturnView).Result;
                modelReturnView = response.Content.ReadAsAsync<GenerateNewSeasonDetailsModel>().Result;

                if (modelReturnView.returnMessage == "GenerateNewSeasonSuccessfully")
                {
                    modelReturnView.actionUser = "getAllChampionshipsActiveDetails";
                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("GenerateNewSeason", modelReturnView).Result;
                    modelReturnView = response.Content.ReadAsAsync<GenerateNewSeasonDetailsModel>().Result;
                }
                modelReturnJSON = modelReturnView;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        return View("GenerateNewSeason", modelReturnJSON);

                    default:
                        TempData["returnMessage"] = "Some error occurred when the system was trying to show the view: Generate New Season - Set Up Initial. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View("GenerateNewSeason", modelReturnJSON);
                }
            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Internal error - when the system was trying to show the view: Generate New Season - Set Up Initial. (" + ex.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View("GenerateNewSeason", modelReturnView);
            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                modelReturnView = null;
            }
        }



        // GET: BatchServices/GenerateNewSeason
        [UserModerator]
        [ValidateAntiForgeryToken]
        public ActionResult GenerateNewSeason(FormCollection formHTML)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            GenerateNewSeasonDetailsModel modelReturnJSON = new GenerateNewSeasonDetailsModel();
            GenerateNewSeasonDetailsModel modelReturnView = new GenerateNewSeasonDetailsModel();
            StandardGenerateNewSeasonChampionshipLeagueDetailsModel modelLeague = null;
            StandardGenerateNewSeasonChampionshipCupDetailsModel modelCup = null;

            string actionForm = "show-settings";

            if (formHTML["actionForm"] != null)
                actionForm = formHTML["actionForm"].ToLower();

            setViewBagVariables();
            ViewBag.inFormScript = "1";

            try
            {
                modelReturnView = (GenerateNewSeasonDetailsModel)TempData["FullModel"];
                if (actionForm == "save-details-championship-league")
                {
                    modelReturnView.drawDate = Convert.ToDateTime(formHTML["txtDrawDate"]);

                    for (int i = 0; i < modelReturnView.listChampionshipLeagueDetails.Count; i++)
                    {
                        modelLeague = modelReturnView.listChampionshipLeagueDetails[i];

                        modelLeague.startDate = Convert.ToDateTime(formHTML["txtStartDate-" + modelLeague.championshipType]);
                        modelLeague.totalTeams = Convert.ToInt16(formHTML["txtTotalTeams-" + modelLeague.championshipType]);
                        modelLeague.totalDaysToPlayStage0 = Convert.ToInt16(formHTML["txtDaysStage0-" + modelLeague.championshipType]);
                        modelLeague.totalDaysToPlayPlayoff = Convert.ToInt16(formHTML["txtDaysPlayoff-" + modelLeague.championshipType]);
                        modelLeague.totalRelegate = Convert.ToInt16(formHTML["txtRelegate-" + modelLeague.championshipType]);
                        modelLeague.totalGroups = Convert.ToInt16(formHTML["txtTotalGroups-" + modelLeague.championshipType]);

                        if (formHTML["chkChampionshipActive-" + modelLeague.championshipType] == "on") { modelLeague.hasChampionship = true; } else { modelLeague.hasChampionship = false; }
                        if (formHTML["chkChampionshipByGroup-" + modelLeague.championshipType] == "on") { modelLeague.championship_ByGroup = true; } else { modelLeague.championship_ByGroup = false; }
                        if (formHTML["chkChampionshipGroupsByPots-" + modelLeague.championshipType] == "on") { modelLeague.championship_byGroupPots = true; } else { modelLeague.championship_byGroupPots = false; }
                        if (formHTML["chkChampionshipDoubleRound-" + modelLeague.championshipType] == "on") { modelLeague.championship_DoubleRound = true; } else { modelLeague.championship_DoubleRound = false; }
                    }

                    modelReturnView.actionUser = "saveChampionshipsLeagueDetails";
                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("GenerateNewSeason", modelReturnView).Result;
                    modelReturnView = response.Content.ReadAsAsync<GenerateNewSeasonDetailsModel>().Result;

                    modelReturnJSON = modelReturnView;
                }
                else if (actionForm == "save-details-championship-cup")
                {
                    for (int i = 0; i < modelReturnView.listChampionshipCupDetails.Count; i++)
                    {
                        modelCup = modelReturnView.listChampionshipCupDetails[i];

                        modelCup.startDate = Convert.ToDateTime(formHTML["txtStartDate-" + modelCup.championshipType]);
                        modelCup.totalTeams = Convert.ToInt16(formHTML["txtTotalTeams-" + modelCup.championshipType]);
                        modelCup.totalDaysToPlayStage0 = Convert.ToInt16(formHTML["txtDaysStage0-" + modelCup.championshipType]);
                        modelCup.totalDaysToPlayPlayoff = Convert.ToInt16(formHTML["txtDaysPlayoff-" + modelCup.championshipType]);
                        modelCup.totalGroups = Convert.ToInt16(formHTML["txtTotalGroups-" + modelCup.championshipType]);
                        modelCup.totalTeamsPreCup = Convert.ToInt16(formHTML["txtTotalTeamsPreCup-" + modelCup.championshipType]);

                        if (formHTML["chkChampionshipActive-" + modelCup.championshipType] == "on") { modelCup.hasChampionship = true; } else { modelCup.hasChampionship = false; }
                        if (formHTML["chkChampionshipByGroup-" + modelCup.championshipType] == "on") { modelCup.championship_ByGroup = true; } else { modelCup.championship_ByGroup = false; }
                        if (formHTML["chkChampionshipGroupsByPots-" + modelCup.championshipType] == "on") { modelCup.championship_byGroupPots = true; } else { modelCup.championship_byGroupPots = false; }

                        if (formHTML["chkChampionshipJustSerieA-" + modelCup.championshipType] == "on") { modelCup.hasJust_SerieA = true; } else { modelCup.hasJust_SerieA = false; }
                        if (formHTML["chkChampionshipJustSerieB-" + modelCup.championshipType] == "on") { modelCup.hasJust_SerieB = true; } else { modelCup.hasJust_SerieB = false; }
                        if (formHTML["chkChampionshipJustSerieC-" + modelCup.championshipType] == "on") { modelCup.hasJust_SerieC = true; } else { modelCup.hasJust_SerieC = false; }
                        if (formHTML["chkChampionshipSerieA_B-" + modelCup.championshipType] == "on") { modelCup.has_SerieA_B = true; } else { modelCup.has_SerieA_B = false; }
                        if (formHTML["chkChampionshipSerieA_B_C-" + modelCup.championshipType] == "on") { modelCup.has_SerieA_B_C_D = true; } else { modelCup.has_SerieA_B_C_D = false; }
                        if (formHTML["chkChampionshipNationalTeams-" + modelCup.championshipType] == "on") { modelCup.has_NationalTeams = true; } else { modelCup.has_NationalTeams = false; }

                        if (formHTML["chkChampionshipDestiny-" + modelCup.championshipType] == "on") { modelCup.hasChampionshipDestiny = true; } else { modelCup.hasChampionshipDestiny = false; }
                        if (formHTML["chkChampionshipSource-" + modelCup.championshipType] == "on") { modelCup.hasChampionshipSource = true; } else { modelCup.hasChampionshipSource = false; }
                    }

                    modelReturnView.actionUser = "saveChampionshipsCupDetails";
                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("GenerateNewSeason", modelReturnView).Result;
                    modelReturnView = response.Content.ReadAsAsync<GenerateNewSeasonDetailsModel>().Result;

                    modelReturnJSON = modelReturnView;
                }
                else
                {
                    modelReturnJSON.returnMessage = "GenerateNewSeasonSuccessfully";
                    modelReturnJSON.actionUser = actionForm.ToUpper();
                    response.StatusCode = HttpStatusCode.Created;
                }

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "GenerateNewSeasonSuccessfully")
                        {
                            TempData["actionSuccessfully"] = "Set Up Initial for " + modelReturnJSON.modeType + " mode was saved successfully";
                        }
                        else
                        {
                            TempData["returnMessage"] = "Some error occurred when the system was trying to show the view: Generate New Season - Set Up Initial. (" + modelReturnJSON.returnMessage + ")";
                        }
                        return View(modelReturnJSON);

                    default:
                        TempData["returnMessage"] = "Some error occurred when the system was trying to show the view: Generate New Season - Set Up Initial. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(modelReturnJSON);
                }
            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Internal error - when the system was trying to show the view: Generate New Season - Set Up Initial. (" + ex.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(modelReturnView);
            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                modelReturnView = null;
                modelLeague = null;
                modelCup = null;
            }
        }
    }
}