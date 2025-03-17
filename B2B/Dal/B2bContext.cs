using B2B.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace B2B.Dal
{
    public class B2bContext : DbContext
    {
        public B2bContext() : base("B2bContext")
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerGroup> CustomerGroups { get; set; }
        public DbSet<SalesOffice> SalesOffices { get; set; }
        public DbSet<CustomerAssignment> CustomerAssignments { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<PageCategory> PageCategories { get; set; }
        public DbSet<PageAssignment> PageAssignments { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<StorageAssignment> StorageAssignments { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Tvm1t> Mvgr1s { get; set; }
        public DbSet<Tvm2t> Mvgr2s { get; set; }
        public DbSet<Tvm3t> Mvgr3s { get; set; }
        public DbSet<Tvm4t> Mvgr4s { get; set; }
        public DbSet<Tvm5t> Mvgr5s { get; set; }
        public DbSet<MaterialPriceGroup> MaterialPriceGroups { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}