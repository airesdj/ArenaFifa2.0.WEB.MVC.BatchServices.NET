using System;
using System.Web.Mvc;
using System.Net.Http;
using System.Net;
using System.Configuration;
using ArenaFifa20.BatchServices.NET.Models;
using static ArenaFifa20.NET.App_Start.CheckUserModerator;
using System.Collections.Generic;

namespace ArenaFifa20.BatchServices.NET.Controllers
{
    public class BatchServicesValidateController : Controller
    {
        private void setViewBagVariables()
        {
            ViewBag.inGentelella = "1";
            ViewBag.inBatchServices = "1";
            ViewBag.inHallOfFame = "1";
            ViewBag.inDataTables = "0";
            ViewBag.inModeratorMenu = "0";
            //ViewBag.inRenewNextSeason = ConfigurationManager.AppSettings["renewal.next.season"].ToString();
        }

        // GET: BatchServicesValidate/RenewalH2H
        [UserModerator]
        public ActionResult RenewalH2H()
        {

            HttpResponseMessage response = null;
            RenewalViewModel modelReturnJSON = null;
            RenewalViewModel hallOfFameMode = new RenewalViewModel();

            setViewBagVariables();
            ViewBag.inRenewalWorldCup = ConfigurationManager.AppSettings["renewal.h2h.worldcup"].ToString();
            ViewBag.inRenewalUefaEuro = ConfigurationManager.AppSettings["renewal.h2h.uefaeuro"].ToString();
            ViewBag.limitBanWorldCupUefaEuro = ConfigurationManager.AppSettings["renewal.total.limit.ban.worldcup"].ToString();


            try
            {
                hallOfFameMode.actionUser = "renewal";
                hallOfFameMode.seasonID = 0;
                hallOfFameMode.renewalMode = "H2H";
                hallOfFameMode.championshipIDRenewal = ConfigurationManager.AppSettings["renewal.h2h.id"].ToString();
                hallOfFameMode.championshipIDBenchRenewal = ConfigurationManager.AppSettings["renewal.h2h.id.bench"].ToString();
                if (ViewBag.inRenewalWorldCup == "1" || ViewBag.inRenewalUefaEuro == "1")
                    hallOfFameMode.championshipIDRenewalWorldCupUefaEuro = ConfigurationManager.AppSettings["renewal.h2h.id.worldcup.uefaeuro"].ToString();
                else
                    hallOfFameMode.championshipIDRenewalWorldCupUefaEuro = String.Empty;
                hallOfFameMode.totalLimitBlackList = Convert.ToInt16(ConfigurationManager.AppSettings["renewal.total.limit.blackList"].ToString());
                hallOfFameMode.totalLimitBanWorldCupUefaEuro = Convert.ToInt16(ViewBag.limitBanWorldCupUefaEuro);
                hallOfFameMode.dataBaseName = GlobalVariables.DATABASE_NAME_STAGING;
                response = GlobalVariables.WebApiClient.PostAsJsonAsync("HallOfFame", hallOfFameMode).Result;
                modelReturnJSON = response.Content.ReadAsAsync<RenewalViewModel>().Result;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "HallOfFameSuccessfully")
                        {
                            return View(modelReturnJSON);
                        }
                        else
                        {
                            //ModelState.AddModelError("", "Senha Atual inválida! Favor tentar novamente.");
                            TempData["returnMessage"] = "Some error occurred when the system was trying to show the view - H2H Renewal. (" + modelReturnJSON.returnMessage + ")";
                            return View(hallOfFameMode);
                        }
                    default:
                        TempData["returnMessage"] = "Some error occurred when the system was trying to show the view - H2H Renewal. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(hallOfFameMode);
                }

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Internal error - when the system was trying to show the view - H2H Renewal: (" + ex.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(hallOfFameMode);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                hallOfFameMode = null;
            }
        }


        // GET: BatchServicesValidate/RenewalFUT
        [UserModerator]
        public ActionResult RenewalFUT()
        {

            HttpResponseMessage response = null;
            RenewalViewModel modelReturnJSON = null;
            RenewalViewModel hallOfFameMode = new RenewalViewModel();

            setViewBagVariables();

            try
            {
                hallOfFameMode.actionUser = "renewal";
                hallOfFameMode.seasonID = 0;
                hallOfFameMode.renewalMode = "FUT";
                hallOfFameMode.championshipIDRenewal = ConfigurationManager.AppSettings["renewal.fut.id"].ToString();
                hallOfFameMode.championshipIDBenchRenewal = ConfigurationManager.AppSettings["renewal.fut.id.bench"].ToString();
                hallOfFameMode.championshipIDRenewalWorldCupUefaEuro = String.Empty;
                hallOfFameMode.totalLimitBlackList = Convert.ToInt16(ConfigurationManager.AppSettings["renewal.total.limit.blackList"].ToString());
                hallOfFameMode.totalLimitBanWorldCupUefaEuro = 0;
                hallOfFameMode.dataBaseName = GlobalVariables.DATABASE_NAME_STAGING;
                response = GlobalVariables.WebApiClient.PostAsJsonAsync("HallOfFame", hallOfFameMode).Result;
                modelReturnJSON = response.Content.ReadAsAsync<RenewalViewModel>().Result;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "HallOfFameSuccessfully")
                        {
                            return View(modelReturnJSON);
                        }
                        else
                        {
                            //ModelState.AddModelError("", "Senha Atual inválida! Favor tentar novamente.");
                            TempData["returnMessage"] = "Some error occurred when the system was trying to show the view - FUT Renewal. (" + modelReturnJSON.returnMessage + ")";
                            return View(hallOfFameMode);
                        }
                    default:
                        TempData["returnMessage"] = "Some error occurred when the system was trying to show the view - FUT Renewal. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(hallOfFameMode);
                }

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Internal error - when the system was trying to show the view - FUT Renewal: (" + ex.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(hallOfFameMode);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                hallOfFameMode = null;
            }
        }

        // GET: BatchServicesValidate/RenewalPRO
        [UserModerator]
        public ActionResult RenewalPRO()
        {

            HttpResponseMessage response = null;
            RenewalViewModel modelReturnJSON = null;
            RenewalViewModel hallOfFameMode = new RenewalViewModel();

            setViewBagVariables();

            try
            {
                hallOfFameMode.actionUser = "renewal";
                hallOfFameMode.seasonID = 0;
                hallOfFameMode.renewalMode = "PRO";
                hallOfFameMode.championshipIDRenewal = ConfigurationManager.AppSettings["renewal.pro.id"].ToString();
                hallOfFameMode.championshipIDBenchRenewal = ConfigurationManager.AppSettings["renewal.pro.id.bench"].ToString();
                hallOfFameMode.championshipIDRenewalWorldCupUefaEuro = String.Empty;
                hallOfFameMode.totalLimitBlackList = Convert.ToInt16(ConfigurationManager.AppSettings["renewal.total.limit.blackList"].ToString());
                hallOfFameMode.totalLimitBanWorldCupUefaEuro = 0;
                hallOfFameMode.dataBaseName = GlobalVariables.DATABASE_NAME_STAGING;
                response = GlobalVariables.WebApiClient.PostAsJsonAsync("HallOfFame", hallOfFameMode).Result;
                modelReturnJSON = response.Content.ReadAsAsync<RenewalViewModel>().Result;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "HallOfFameSuccessfully")
                        {
                            return View(modelReturnJSON);
                        }
                        else
                        {
                            //ModelState.AddModelError("", "Senha Atual inválida! Favor tentar novamente.");
                            TempData["returnMessage"] = "Some error occurred when the system was trying to show the view - PRO Renewal. (" + modelReturnJSON.returnMessage + ")";
                            return View(hallOfFameMode);
                        }
                    default:
                        TempData["returnMessage"] = "Some error occurred when the system was trying to show the view - PRO Renewal. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(hallOfFameMode);
                }

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Internal error - when the system was trying to show the view - PRO Renewal: (" + ex.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(hallOfFameMode);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                hallOfFameMode = null;
            }
        }


        // GET: BatchServicesValidate/RenewalPROSquad
        [UserModerator]
        public ActionResult RenewalPROSquad(FormCollection formHTML)
        {

            HttpResponseMessage response = null;
            RenewalPROCLUBSquadViewModel modelReturnJSON = null;
            RenewalPROCLUBSquadViewModel hallOfFameMode = new RenewalPROCLUBSquadViewModel();

            setViewBagVariables();

            try
            {
                hallOfFameMode.actionUser = "renewalSquad";
                hallOfFameMode.managerID = Convert.ToInt16(formHTML["userID"]); ;
                hallOfFameMode.seasonID = Convert.ToInt16(formHTML["seasonID"]); ;
                hallOfFameMode.clubName = formHTML["clubName"]; ;
                hallOfFameMode.dataBaseName = GlobalVariables.DATABASE_NAME_STAGING;
                response = GlobalVariables.WebApiClient.PostAsJsonAsync("HallOfFame", hallOfFameMode).Result;
                modelReturnJSON = response.Content.ReadAsAsync<RenewalPROCLUBSquadViewModel>().Result;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "HallOfFameSuccessfully")
                        {
                            string pathImg = "/images/team-logo/" + modelReturnJSON.clubName + ".jpg";
                            if (System.IO.File.Exists(HttpContext.Server.MapPath(pathImg)))
                            { modelReturnJSON.pathImageClub = pathImg; }
                            else
                            { modelReturnJSON.pathImageClub = ConfigurationManager.AppSettings["path.image.default"].ToString(); }


                            return View(modelReturnJSON);
                        }
                        else
                        {
                            //ModelState.AddModelError("", "Senha Atual inválida! Favor tentar novamente.");
                            TempData["returnMessage"] = "Some error occurred when the system was trying to show the view - Squad PRO Renewal. (" + modelReturnJSON.returnMessage + ")";
                            return View(hallOfFameMode);
                        }
                    default:
                        TempData["returnMessage"] = "Some error occurred when the system was trying to show the view - Squad PRO Renewal. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(hallOfFameMode);
                }

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Internal error - when the system was trying to show the view - Squad PRO Renewal: (" + ex.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(hallOfFameMode);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                hallOfFameMode = null;
            }
        }

        // GET: BatchServicesValidate/AcceptingNewSeason
        [UserModerator]
        public ActionResult AcceptingNewSeason()
        {

            HttpResponseMessage response = null;
            AcceptingNewSeasonViewModel modelReturnJSON = new AcceptingNewSeasonViewModel();

            setViewBagVariables();
            ViewBag.inDataTables = "1";
            ViewBag.inModeratorMenu = "1";

            try
            {
                modelReturnJSON.actionUser = "getAllAccepting-staging";
                modelReturnJSON.dataBaseName = GlobalVariables.DATABASE_NAME_STAGING;
                response = GlobalVariables.WebApiClient.PostAsJsonAsync("AcceptingNewSeason", modelReturnJSON).Result;
                modelReturnJSON = response.Content.ReadAsAsync<AcceptingNewSeasonViewModel>().Result;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                        {

                            for (int i = 0; i < modelReturnJSON.listOfAccepting.Count; i++)
                            {
                                modelReturnJSON.listOfAccepting[i].championshipName = getChampionshipNameNewSeason(modelReturnJSON.listOfAccepting[i].championshipID);
                            }

                            return View(modelReturnJSON);
                        }
                        else
                        {
                            //ModelState.AddModelError("", "Senha Atual inválida! Favor tentar novamente.");
                            TempData["returnMessage"] = "Some error occurred when the system was trying to show the view - Accepting New Season Register. (" + modelReturnJSON.returnMessage + ")";
                            return View(modelReturnJSON);
                        }
                    default:
                        TempData["returnMessage"] = "Some error occurred when the system was trying to show the view - Accepting New Season Register. (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(modelReturnJSON);
                }

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Internal error - when the system was trying to show the view - Accepting New Season Register: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(modelReturnJSON);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
            }
        }

        // GET: BatchServicesValidate/AcceptingNewSeasonDetails
        [UserModerator]
        public ActionResult AcceptingNewSeasonDetails(FormCollection formHTML)
        {

            HttpResponseMessage response = new HttpResponseMessage();
            AcceptingNewSeasonViewModel modelReturnJSON = new AcceptingNewSeasonViewModel();
            AcceptingDetails modelReturnJSON2 = new AcceptingDetails();
            List<UserDetailsModel> listOfUser = new List<UserDetailsModel>();
            List<ChampionshipDetailsModel> listOChampionship = new List<ChampionshipDetailsModel>();
            ChampionshipDetailsModel championshipDetails = new ChampionshipDetailsModel();
            returnJSON_UserLoginModel userDetails = new returnJSON_UserLoginModel();
            UserDetailsModel userDetails2 = new UserDetailsModel();
            string championshipName = String.Empty;

            string actionForm = formHTML["actionForm"].ToLower();
            string primaryKey = String.Empty;
            string[] arrayPK = null;

            setViewBagVariables();

            try
            {

                if (actionForm == "save")
                {

                    modelReturnJSON.seasonID = Convert.ToUInt16(formHTML["seasonID"]);
                    modelReturnJSON.userID = Convert.ToUInt16(formHTML["cmbTecnico"]);
                    modelReturnJSON.championshipID = Convert.ToUInt16(formHTML["cmbCampeonato"]);
                    //modelReturnJSON.dataBaseName = "";
                    modelReturnJSON.actionUser = actionForm;
                    modelReturnJSON.teamName = formHTML["txtTime"];
                    modelReturnJSON.confirmation = formHTML["cmbConfirma"];
                    if (modelReturnJSON.confirmation == "-") { modelReturnJSON.confirmation = String.Empty; }
                    if (!String.IsNullOrEmpty(formHTML["txtOrdem"]))
                        modelReturnJSON.ordering = formHTML["txtOrdem"];
                    else
                        modelReturnJSON.ordering = "0";


                    modelReturnJSON.dataBaseName = GlobalVariables.DATABASE_NAME_STAGING;
                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("AcceptingNewSeason", modelReturnJSON).Result;
                    modelReturnJSON = response.Content.ReadAsAsync<AcceptingNewSeasonViewModel>().Result;
                    TempData["actionSuccessfully"] = "Registro incluído/alterado com sucesso";

                }
                else if (actionForm == "add" || actionForm == "view" || actionForm == "edit")
                {

                    modelReturnJSON.returnMessage = "ModeratorSuccessfully";
                    response.StatusCode = HttpStatusCode.Created;
                }

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "ModeratorSuccessfully")
                        {

                            if (actionForm == "save")
                            {
                                return RedirectToAction("AcceptingNewSeason", "BatchServicesValidate");
                            }
                            else
                            {
                                if (actionForm == "view" || actionForm == "edit")
                                {

                                    primaryKey = formHTML["selectedID"];
                                    arrayPK = primaryKey.Split(Convert.ToChar(";"));

                                    modelReturnJSON.seasonID = Convert.ToUInt16(arrayPK[0]);
                                    modelReturnJSON.userID = Convert.ToUInt16(arrayPK[1]);
                                    modelReturnJSON.championshipID = Convert.ToUInt16(arrayPK[2]);

                                    response = GlobalVariables.WebApiClient.GetAsync("HomeUser/" + Convert.ToString(modelReturnJSON.userID)).Result;
                                    userDetails = response.Content.ReadAsAsync<returnJSON_UserLoginModel>().Result;

                                    userDetails2 = new UserDetailsModel();
                                    userDetails2.id = userDetails.id;
                                    userDetails2.name = userDetails.name;
                                    userDetails2.psnID = userDetails.psnID;
                                    listOfUser.Add(userDetails2);

                                    modelReturnJSON.actionUser = "getAccepting-staging";
                                    modelReturnJSON.dataBaseName = GlobalVariables.DATABASE_NAME_STAGING;
                                    response = GlobalVariables.WebApiClient.PostAsJsonAsync("AcceptingNewSeason", modelReturnJSON).Result;
                                    modelReturnJSON2 = response.Content.ReadAsAsync<AcceptingDetails>().Result;

                                    championshipDetails = new ChampionshipDetailsModel();
                                    championshipDetails.id = modelReturnJSON.championshipID;
                                    championshipDetails.name = getChampionshipNameNewSeason(championshipDetails.id);
                                    listOChampionship.Add(championshipDetails);

                                    modelReturnJSON2.listOfUser = listOfUser;
                                    modelReturnJSON2.listOfChampionship = listOChampionship;
                                }
                                else if (actionForm == "add")
                                {
                                    response = GlobalVariables.WebApiClient.GetAsync("HomeUser").Result;
                                    modelReturnJSON2 = response.Content.ReadAsAsync<AcceptingDetails>().Result;
                                    modelReturnJSON2.seasonID = 0;
                                    modelReturnJSON2.userID = 0;
                                    modelReturnJSON2.championshipID = 999;
                                    modelReturnJSON2.ordering = "0";

                                    for (int i = 0; i < 15; i++)
                                    {
                                        championshipName = getChampionshipNameNewSeason(i);
                                        if (championshipName != String.Empty)
                                        {
                                            championshipDetails = new ChampionshipDetailsModel();
                                            championshipDetails.id = i;
                                            championshipDetails.name = championshipName;
                                            listOChampionship.Add(championshipDetails);
                                        }
                                    }
                                    modelReturnJSON2.DateconfirmationFormatted = DateTime.Now.Date.ToString("dd/MM/yyyy");
                                    modelReturnJSON2.listOfChampionship = listOChampionship;
                                }
                                modelReturnJSON2.actionUser = actionForm.ToUpper();
                                return View(modelReturnJSON2);
                            }
                        }
                        else
                        {
                            //ModelState.AddModelError("", "Senha Atual inválida! Favor tentar novamente.");
                            TempData["returnMessage"] = "Some error occurred when the system was trying to show the view - Accepting New Season Register Details - " + actionForm + ". (" + modelReturnJSON.returnMessage + ")";
                            return View(modelReturnJSON);
                        }
                    default:
                        TempData["returnMessage"] = "Some error occurred when the system was trying to show the view - Accepting New Season Register Details - " + actionForm + ". (" + response.StatusCode + ")";
                        ModelState.AddModelError("", "application error.");
                        return View(modelReturnJSON);
                }

            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Internal error - when the system was trying to show the view - Accepting New Season Register Details - " + actionForm + ": (" + ex.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(modelReturnJSON);

            }
            finally
            {
                response = null;
                modelReturnJSON = null;
                modelReturnJSON2 = null;
                listOChampionship = null;
                championshipDetails = null;
                listOfUser = null;
                userDetails = null;
                userDetails2 = null;
            }
        }


        private string getChampionshipNameNewSeason(int championshipID)
        {
            string strReturn = String.Empty;
            if (championshipID == 0)
                strReturn = "Banco - H2H";
            else if (championshipID == 1)
                strReturn = "Série A - H2H";
            else if (championshipID == 2)
                strReturn = "Série B - H2H";
            else if (championshipID == 3)
                strReturn = "Série C - H2H";
            else if (championshipID == 4)
                strReturn = "Série D - H2H";
            else if (championshipID == 5)
                strReturn = "Copa do Mundo - H2H";
            else if (championshipID == 7)
                strReturn = "Banco - F.U.T.";
            else if (championshipID == 8)
                strReturn = "Série A - F.U.T.";
            else if (championshipID == 9)
                strReturn = "Série B - F.U.T.";
            else if (championshipID == 13)
                strReturn = "Série A - Pro Club";
            else if (championshipID == 14)
                strReturn = "Banco - Pro Club";

            return strReturn;
        }

    }
}