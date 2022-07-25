using reservationTicket.Models.EntityManager;
using reservationTicket.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace reservationTicket.Controllers
{
    public class BusController : Controller
    {
        // GET: Bus
        public ActionResult Index()
        {
            return View();
        }
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