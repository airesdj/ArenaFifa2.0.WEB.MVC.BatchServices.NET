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
    public class HomeController : Controller
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
                            Session["session.active"] = true;
                            Session["user.id"] = "385"; //"1281"; //"385";  //modelReturnJSON.id.ToString();
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

                            Session["user.current.season.menu"] = null;
                            Session["user.current.season.summary"] = null;

                            Session["user.pathAvatar"] = ConfigurationManager.AppSettings["avatar.path.default"].ToString();

                            string new_path_atavar = ConfigurationManager.AppSettings["avatar.path.coach"].ToString() + "/" +
                                                     modelReturnJSON.id.ToString() + ".jpg";

                            if (System.IO.File.Exists(HttpContext.Server.MapPath(new_path_atavar))) { Session["user.pathAvatar"] = new_path_atavar; }

                            return RedirectToLocal("/BatchServices/Summary");
                        }
                        else
                        {
                            if (modelReturnJSON.returnMessage == "loginFailed")
                            {
                                TempData["returnMessage"] = "Senha inválida! Favor tentar novamente.";
                                ModelState.AddModelError("", "Invalid login attempt.");
                            }
                            else if (modelReturnJSON.returnMessage == "UserNotFound")
                            {
                                TempData["returnMessage"] = "Usuário não cadastrado ou não está ativo. Favor tentar novamente.";
                                ModelState.AddModelError("", "User not found.");
                            }
                            else if (modelReturnJSON.returnMessage.Substring(0, 6) == "error_")
                            {
                                TempData["returnMessage"] = "Ocorreu algum erro na validação do login. Favor tentar novamente.";
                                ModelState.AddModelError("", "application error.");
                            }
                            return View(model);
                        }
                    case HttpStatusCode.NotAcceptable:
                        TempData["returnMessage"] = "Ocorreu algum erro não aceitável na validação do login. Favor tentar novamente.";
                        ModelState.AddModelError("", "application error.");
                        return View(model);
                    default:
                        TempData["returnMessage"] = "Ocorreu algum erro na validação do login. Favor tentar novamente.";
                        ModelState.AddModelError("", "application error.");
                        return View(model);
                }
            }
            catch (Exception ex)
            {
                TempData["returnMessage"] = "Erro interno - validando login do usuário: (" + ex.InnerException.Message + ")";
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
            return RedirectToLocal("Signin");
        }


        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Signin", "Home");
        }

    }
}