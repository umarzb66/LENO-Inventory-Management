//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Leno_Inventory_Management
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class lenoEntities : DbContext
    {
        public lenoEntities()
            : base("name=lenoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<bankdetailsTable> bankdetailsTables { get; set; }
        public virtual DbSet<billTable> billTables { get; set; }
        public virtual DbSet<customerTable> customerTables { get; set; }
        public virtual DbSet<loginTable> loginTables { get; set; }
        public virtual DbSet<profileTable> profileTables { get; set; }
        public virtual DbSet<purchaseTable> purchaseTables { get; set; }
        public virtual DbSet<rawmaterialsTable> rawmaterialsTables { get; set; }
        public virtual DbSet<stockoutTable> stockoutTables { get; set; }
        public virtual DbSet<stockTable> stockTables { get; set; }
        public virtual DbSet<travellerTable> travellerTables { get; set; }
        public virtual DbSet<vendorTable> vendorTables { get; set; }
        public virtual DbSet<workerTable> workerTables { get; set; }
    }
}
