//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace reservationTicket.Models.Db
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ticket
    {
        public int id { get; set; }
        public int Tre_id { get; set; }
        public string ticket_code { get; set; }
        public Nullable<System.DateTime> creation_date { get; set; }
    
        public virtual Treatment Treatment { get; set; }
    }
}