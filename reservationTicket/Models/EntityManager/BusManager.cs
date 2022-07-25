using reservationTicket.Models.Db;
using reservationTicket.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace reservationTicket.Models.EntityManager
{
    public class BusManager
    {
        public void AddBuss(BusView bus)
        {
            using (BasetpEntities db = new BasetpEntities())
            {
                Bus bs = new Bus();
                bs.Tre_id = bus.Tre_id;
                bs.company_name = bus.company_name;
                bs.matricule = bus.matricule;
                db.Buses.Add(bs);
                db.SaveChanges();
            }

        }
            public bool IsMatriculeExist(string matricule)
            {
                using (BasetpEntities db = new BasetpEntities())
            {
                return db.Buses.Where(o => o.matricule == matricule).Any();
            }
            }
    }
}