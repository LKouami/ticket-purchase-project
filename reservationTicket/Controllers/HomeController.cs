using reservationTicket.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using reservationTicket.Models.ViewModel;
using reservationTicket.Models.EntityManager;

namespace reservationTicket.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

            return View();
        }
        //controleur de la route welcome
        [Authorize]
        public ActionResult Welcome()
        {
            return View();
        }
        /*controleur de la route AdminOnly qui a un décorateur qui autorise l'accès à cette dernière uniquement si l'utilisateur 
         * connecté a pour role Admin
         */
        [AuthorizeRoles("Admin")]
        public ActionResult AdminOnly()
        {
            return View();
        }
        //controleur qui gére la route UnAuthorized qui est appelé quand l'utilisateur n'est pas autorisé à effectuer une action
        public ActionResult UnAuthorized()
        {
            return View();
        }

        [AuthorizeRoles("Admin")]
        public ActionResult ManageUserPartial(string status = "")
        {
            if (User.Identity.IsAuthenticated)
            {
                string loginName = User.Identity.Name;
                UserManager um = new UserManager();
                UserDataView udv = um.GetUserDataView(loginName);
                string message = string.Empty;
                if (status.Equals("Update"))
                {
                    message = "Update successfull";
                } else if (status.Equals("Delete"))
                {
                    message = "Delete successfull";
                }
                ViewBag.Message = message;
                return PartialView(udv);
            }

            return RedirectToAction("Index", "Home") ;
        }

        public ActionResult UpdateUserData(int userId, string loginName, string password, string name, string tel, int roleId = 0)
        {
            UserProfileView upv = new UserProfileView();
            upv.userId = userId;
            upv.username = loginName;
            upv.password = password;
            upv.name = name;
            upv.tel = tel;
            if(roleId > 0)
            {
                upv.roleId = roleId;
            }

            UserManager um = new UserManager();
            um.UpdateUserAccount(upv);
            return Json(new { success = true });
        }


    }
}