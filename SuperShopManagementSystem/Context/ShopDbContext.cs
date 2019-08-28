using SuperShopManagementSystem.Models;
using SuperShopManagementSystem.Models.Operation;
using SuperShopManagementSystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SuperShopManagementSystem.Context
{
    public class ShopDbContext : IdentityDbContext<ApplicationUser>
    {
        public ShopDbContext()
            : base("ShopDbContext", throwIfV1Schema: false)
        {
        }
        public DbSet <ExpenseItem> ExpenseItems { get; set; }
        public DbSet<ExpenseCatagory> ExpenseCatagories { get; set; }
        public DbSet<ItemCategory> ItemCategories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Outlet> Outlets { get; set; }
        public DbSet<Party> Parties { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Sale> Sales { get; set; }
        public DbSet<SalesDetail> SalesDetails { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseDetail> PurchaseDetails { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseDetail> ExpenseDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Purchase>()
                .HasRequired(d => d.Outlet)
                .WithMany(w => w.Purchases)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sale>()
               .HasRequired(d => d.Outlet)
               .WithMany(w => w.Sales)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<Expense>()
                .HasRequired(d => d.Employee)
                .WithMany(w => w.Expenses)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);      
        }

        public DbSet<IncomeVm> IncomeVms { get; set; }

        public static ShopDbContext Create()
        {
            return new ShopDbContext();
        }

    }
}