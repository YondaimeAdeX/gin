﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace gin
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class dbArabaEntities : DbContext
    {
        public dbArabaEntities()
            : base("name=dbArabaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblArabalar> tblArabalar { get; set; }
        public virtual DbSet<tblmarkalar> tblmarkalar { get; set; }
        public virtual DbSet<tblmodeller> tblmodeller { get; set; }
    }
}
