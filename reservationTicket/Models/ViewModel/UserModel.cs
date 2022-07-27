
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;

namespace reservationTicket.Models.ViewModel
{
    //Modele utilisé pour le signup
    public class UserSignupView
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Name")]
        public string name { get; set; }
        public string tel { get; set; }
        [Required (ErrorMessage = "*")]
        [Display(Name ="Login ID")]
        public string username { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Password")]
        public string password { get; set; }
        public string role { get; set; }
    }
    //Modele utilisé pour le login
    public class UserLoginView
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Login ID")]
        public string username { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Password")]
        public string password { get; set; }

    }

    public class UserProfileView
    {
        [Key]
        public int userId { get; set; }
        public int roleId { get; set; }
        public string roleName { get; set; }
        public bool? isRoleActive { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Name")]
        public string name { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Telephone")]
        public string tel { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Login ID")]
        public string username { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Password")]
        public string password { get; set; }

    }

    public class AvailableRole
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }

    }

    public class UserRoles
    {
        public int? SelectRoleId { get; set; }
        public IEnumerable<AvailableRole> UserRoleList { get; set; }
    }
    public class UserDataView
    {
        public IEnumerable<UserProfileView> UserProfile { get; set; }
        public UserRoles UserRoles { get; set; }
    }
}