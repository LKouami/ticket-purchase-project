﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BasetpEntities : DbContext
    {
        public BasetpEntities()
            : base("name=BasetpEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Bus> Buses { get; set; }
        public virtual DbSet<Operation> Operations { get; set; }
        public virtual DbSet<Route> Routes { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<Treatment> Treatments { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
    }
}
