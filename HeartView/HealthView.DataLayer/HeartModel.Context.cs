﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using HealthView.Models;

namespace HealthView.DataLayer
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class IP_DatabaseEntities : DbContext
    {
        public IP_DatabaseEntities()
            : base("name=IP_DatabaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ActivitatePacienti> ActivitatePacienti { get; set; }
        public virtual DbSet<Doctori> Doctori { get; set; }
        public virtual DbSet<Identitate> Identitate { get; set; }
        public virtual DbSet<Pacienti> Pacienti { get; set; }
        public virtual DbSet<Recomandari> Recomandari { get; set; }
    }
}
