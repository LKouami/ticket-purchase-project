
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

        public List<AvailableRole> GetAllRoles()
        {
            using (BasetpEntities db = new BasetpEntities())
            {
                var roles = db.Roles.Select(o => new AvailableRole
                {
                    id = o.id,
                    name = o.name
                }).ToList();
                return roles;
            }

        }

        public int GetUserId(string loginName)
        {
            using (BasetpEntities db = new BasetpEntities())
            {
                var user = db.Users.Where(o => o.username.Equals(loginName));
                if (user.Any())
                {
                    return user.FirstOrDefault().id;
                }

            }
            return 0;
        }

        public List<UserProfileView> GetAllUserProfile()
        {
            List<UserProfileView> profiles = new List<UserProfileView>();
            using (BasetpEntities db = new BasetpEntities())
            {
                UserProfileView upv;
                var users = db.Users.ToList();
                foreach(User user in db.Users)
                {
                    upv = new UserProfileView();
                    upv.userId = user.id;
                    upv.username = user.username;
                    upv.name = user.name;
                    upv.tel = user.tel;
                    upv.password = user.password;

                    var sur = db.UserRoles.Where(o => o.user_id.Equals(user.id));
                    if (sur.Any())
                    {
                        var userRole = sur.FirstOrDefault();
                        upv.roleId = userRole.role_id;
                        upv.roleName = userRole.Role.name;
                        upv.isRoleActive = userRole.status;
                    }
                    profiles.Add(upv);
                }

            }
            return profiles;
        }

        public UserDataView GetUserDataView(string loginName)
        {
            UserDataView udv = new UserDataView();
            List<UserProfileView> upv = GetAllUserProfile();
            List<AvailableRole> availableRoles = GetAllRoles();
            int? userAssignedRoleId = 0, userId = 0;
            userId = GetUserId(loginName);

            using (BasetpEntities db = new BasetpEntities())
            {
                userAssignedRoleId = db.UserRoles.Where(o => o.user_id == userId)?.FirstOrDefault().id;
            }

            udv.UserProfile = upv;
            UserRoles usr = new UserRoles();
            usr.SelectRoleId = userAssignedRoleId;
            usr.UserRoleList = availableRoles;
            udv.UserRoles = usr;

            return udv;
        }

        public void UpdateUserAccount(UserProfileView userProfileView)
        {
            using (BasetpEntities db = new BasetpEntities())
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        User user = db.Users.Find(userProfileView.userId);
                        user.username = userProfileView.username;
                        user.password = userProfileView.password;
                        user.name = userProfileView.name;
                        user.tel = userProfileView.tel;
                        user.creation_date = DateTime.Now;
                        db.SaveChanges();
                        if (userProfileView.roleId > 0)
                        {
                            var userRole = db.UserRoles.Where(o => o.user_id == userProfileView.userId);
                            UserRole ur = null;
                            if (userRole.Any())
                            {
                                ur = userRole.FirstOrDefault();
                                ur.role_id = userProfileView.roleId;
                                ur.user_id = userProfileView.userId;
                                ur.status = true;
                                ur.creation_date = DateTime.Now;
                            }else
                            {
                                ur = new UserRole();
                                ur.role_id = userProfileView.roleId;
                                ur.user_id = userProfileView.userId;
                                ur.status = true;
                                ur.creation_date = DateTime.Now;
                                db.UserRoles.Add(ur);
                                
                            }
                            db.SaveChanges();
                        }
                        dbContextTransaction.Commit();
                    }
                    catch
                    {
                        dbContextTransaction.Rollback();
                    }
                } 
            }

        }
    }

}