using reservationTicket.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


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
    }
}