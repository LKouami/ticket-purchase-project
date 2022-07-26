using reservationTicket.Models.Db;
using reservationTicket.Models.EntityManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace reservationTicket.Security
{
    //Class qui gère les autorisations en se basant sur les roles assignés
    // suffix Roles
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        private readonly string[] userAssignedRoles;
        //constructeur 
        public AuthorizeRolesAttribute(params string[] roles)
        {
            this.userAssignedRoles = roles;
        }
        
        //Methode qui verifie si un utilisateur est autorisé à acceder à un controleur.
        //Renvoi true s'il est autorisé et false si non
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;
            using (BasetpEntities db = new BasetpEntities())
            {
                UserManager usm = new UserManager();
                foreach(var role in userAssignedRoles)
                {
                    authorize = usm.IsUserInRole(httpContext.User.Identity.Name, role);
                    if(authorize)
                    {
                        //le return arrête tous les process
                        return authorize;
                    }
                }
                return authorize;
            }
        }
        //Methode qui gère les requêtes non autorisées
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult("~/Home/UnAuthorized/");
        }
    }
}