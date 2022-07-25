using reservationTicket.Models.EntityManager;
using reservationTicket.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace reservationTicket.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(UserSignupView usv)
        {
            if (ModelState.IsValid)
            {
                UserManager um = new UserManager();
                if (!um.IsLoginNameExist(usv.username))
                {
                    um.AddUserAccount(usv);
                    FormsAuthentication.SetAuthCookie(usv.name, false);
                    return RedirectToAction("Welcome", "Home");
                } else
                {
                    ModelState.AddModelError("", "Login name already taken");
                }  
            }
            return View();
        }

        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(UserLoginView ulv, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                UserManager um = new UserManager();
                string password = um.GetUserPassword(ulv.username.ToLower());
                if (string.IsNullOrEmpty(password))
                {
                    ModelState.AddModelError("", "Nom d'utilisateur ou Mot de passe Incorrect");
                }else
                {
                    if (ulv.password.Equals(password))
                    {
                        FormsAuthentication.SetAuthCookie(ulv.username, false);
                        return RedirectToAction("Welcome", "Home");
                    }else
                    {
                        ModelState.AddModelError("", "Le Mot de passe est incorrect");
                    }
                }
            }
            return View(ulv);
        }

        [Authorize]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}