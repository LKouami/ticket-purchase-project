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
    //Controleur du signup, login et signout
    public class AccountController : Controller
    {
        public ActionResult Signup()
        {
            return View();
        }
        //Methode qui permet l'enrégistrement d'un utilisateur
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
        //Methode qui permet la connexion de l'utilisateur 
        //Prend en parametre le Modele définit pour la connexion et le chemin de redirection en cas de success
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
        //Methode qui permet de se déconnecter
        [Authorize]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}