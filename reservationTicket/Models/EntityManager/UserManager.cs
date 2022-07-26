
using reservationTicket.Models.Db;
using reservationTicket.Models.ViewModel;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace reservationTicket.Models.EntityManager
{
    //Class qui gère toutes les actions à effectuer dans le controleur AccountControler
    public class UserManager
    {
        //Methode qui crée un nouvel utilisateur dans la base
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

        //Methode qui vérifie si le login name que l'utilisateur saisi existe déjà dans la base
        public bool IsLoginNameExist(string loginName)
        {
            using(BasetpEntities db = new BasetpEntities())
            {
                return db.Users.Where(o => o.username == loginName).Any();
            }
        }

        //Methode qui retourne le password d'un utilisateur depuis la base en se basant sur son nom 
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
        //Methode qui verifie si un utilisateur possede un role précis dans la base
        public bool IsUserInRole(string loginName, string roleName)
        {
            using (BasetpEntities db = new BasetpEntities())
            {
                User us = db.Users.Where(o => o.username.ToLower().Equals(loginName.ToLower()))?.FirstOrDefault();
                if(us != null)
                {
                    var roles = from q in db.UserRoles
                                join r in db.Roles on q.role_id equals r.id
                                where r.name.Equals(roleName) && q.user_id.Equals(us.id)
                                select r.name;
                    if(roles != null)
                    {
                        return roles.Any();
                    }

                }
                return false;
            }
            
        }
    }

}