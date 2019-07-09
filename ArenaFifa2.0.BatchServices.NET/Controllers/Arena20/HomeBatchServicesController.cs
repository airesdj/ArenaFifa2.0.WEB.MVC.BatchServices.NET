using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Configuration;
using SYSEmail;
using System.Text;
using ArenaFifa20.BatchServices.NET.Models;

namespace ArenaFifa20.BatchServices.NET.Controllers
{
    public class HomeBatchServicesController : Controller
    {
        //
        // GET: /Home/Signin
        [AllowAnonymous]
        public ActionResult Signin(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Home/Signin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Signin(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "ModeState is invalid";
                return View(model);
            }

            HttpResponseMessage response = null;
            returnJSON_UserLoginModel modelReturnJSON = null;

            try
            {

                model.actionUser = "Signin";
                response = GlobalVariables.WebApiClient.PostAsJsonAsync("HomeUser", model).Result;
                modelReturnJSON = response.Content.ReadAsAsync<returnJSON_UserLoginModel>().Result;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        if (modelReturnJSON.returnMessage == "loginSuccessfully")
                        {
                            if (modelReturnJSON.userModerator == false)
                            {
                                TempData["returnMessage"] = "The action is cancelled! User is not a moderator.";
                                ModelState.AddModelError("", "Invalid login attempt.");
                                return View(model);
                            }
                            else
                            {
                                Session["session.active"] = true;
                                Session["user.id"] = modelReturnJSON.id.ToString();
                                Session["user.name"] = modelReturnJSON.name.ToString();
                                Session["user.psnID"] = modelReturnJSON.psnID.ToString();
                                Session["user.isModerator"] = modelReturnJSON.userModerator;
                                Session["user.dtLastAccess"] = modelReturnJSON.lastAccess.ToString();
                                Session["user.dsEmail"] = modelReturnJSON.email.ToString();
                                Session["user.currentTeam"] = modelReturnJSON.currentTeam.ToString();
                                Session["user.totalTitlesWon"] = modelReturnJSON.totalTitlesWon.ToString();
                                Session["user.totalVices"] = modelReturnJSON.totalVices.ToString();

                                Session["user.teamNameH2H"] = String.Empty;
                                Session["user.teamNameFUT"] = String.Empty;
                                Session["user.teamNamePRO"] = String.Empty;

                                Session["user.pathAvatar"] = ConfigurationManager.AppSettings["avatar.path.default"].ToString();

                                string new_path_atavar = ConfigurationManager.AppSettings["avatar.path.coach"].ToString() + "/" +
                                                         modelReturnJSON.id.ToString() + ".jpg";

                                if (System.IO.File.Exists(HttpContext.Server.MapPath(new_path_atavar))) { Session["user.pathAvatar"] = new_path_atavar; }

                                return RedirectToLocal("/Arena20/BatchServices/Summary");
                            }
                        }
                        else
                        {
                            if (modelReturnJSON.returnMessage == "loginFailed")
                            {
                                TempData["returnMessage"] = "Password invalid!! Please try again.";
                                ModelState.AddModelError("", "Invalid login attempt.");
                            }
                            else if (modelReturnJSON.returnMessage == "UserNotFound")
                            {
                                TempData["returnMessage"] = "User is not registered or is inactive. Please try again.";
                                ModelState.AddModelError("", "User not found.");
                            }
                            else if (modelReturnJSON.returnMessage.Substring(0, 6) == "error_")
                            {
                                TempData["returnMessage"] = "Some error occurred when the system was trying to validate the login. Please try again.";
                                ModelState.AddModelError("", "application error.");
                            }
                            return View(model);
                        }
                    case HttpStatusCode.NotAcceptable:
                        TempData["returnMessage"] = "Ocurred some error not acceptable when the system was trying to validate the login. Please try again.";
                        ModelState.AddModelError("", "application error.");
                        return View(model);
                    default:
                        TempData["returnMessage"] = "Ocurred some error when the system was trying to validate the login. Please try again.";
                        ModelState.AddModelError("", "application error.");
                        return View(model);
                }
            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Internal error - when the system was trying to validate the login: (" + ex.InnerException.Message + ")";
                ModelState.AddModelError("", "application error.");
                return View(model);
            }
            finally
            {
                response = null;
                modelReturnJSON = null;
            }

        }

        //
        // GET: /Home/Signout
        [AllowAnonymous]
        public ActionResult Signout(string returnUrl)
        {
            Session.Abandon();
            ViewBag.ReturnUrl = returnUrl;
            return RedirectToLocal("/Arena20/HomeBatchServices/Signin");
        }


        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Signin", "/Arena20/HomeBatchServices");
        }

    }
}