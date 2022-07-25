
using reservationTicket.Models.Db;
using reservationTicket.Models.ViewModel;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace reservationTicket.Models.EntityManager
{
    public class UserManager
    {
        public void AddUserAccount(UserSignupView user)
        {
            using (BasetpEntities db = new BasetpEntities())
            {
                User us = new User();
                us.name = user.name;
                us.tel = user.tel;
                us.username = user.username;
                us.password = user.password;
                db.Users.Add(us);
                db.SaveChanges();
            }

        }

        public bool IsLoginNameExist(string loginName)
        {
            using(BasetpEntities db = new BasetpEntities())
            {
                return db.Users.Where(o => o.username == loginName).Any();
            }
        }

        public string GetUserPassword(string loginName)
        {
            using (BasetpEntities db = new BasetpEntities())
            {
                var user = db.Users.Where(o => o.username.ToLower().Equals(loginName));
                if (user.Any())
                {
                    return user.FirstOrDefault().password;
                } else
                {
                    return string.Empty;
                }
            }
        }
    }

}