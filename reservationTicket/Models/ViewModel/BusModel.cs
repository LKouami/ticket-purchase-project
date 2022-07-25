using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace reservationTicket.Models.ViewModel
{
    public class BusView
    {   
        [Key]
        public int id { get; set; }
        [Display(Name = "Treatment")]
        public int Tre_id { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Company name")]
        public string company_name { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Matricule")]
        public string matricule { get; set; }
    }
}