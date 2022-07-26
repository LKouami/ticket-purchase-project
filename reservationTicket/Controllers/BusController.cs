using reservationTicket.Models.EntityManager;
using reservationTicket.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace reservationTicket.Controllers
{
    //Controleur qui gère les bus
    public class BusController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        //Methode qui permet d'ajouter un bus
        [HttpPost]
        public ActionResult AddBus(BusView bsv)
        {
            if (ModelState.IsValid)
            {
                BusManager bm = new BusManager();
                if (!bm.IsMatriculeExist(bsv.matricule))
                {
                    bm.AddBuss(bsv);
                    return RedirectToAction("Welcome", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Matricule already exist");
                }
            }
            return View();
        }
    }
}