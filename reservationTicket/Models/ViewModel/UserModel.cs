
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;

namespace reservationTicket.Models.ViewModel
{
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
}