using ConsoleCircularTest.Model;
using ConsoleCircularTest.Model.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCircularTest
{
    public class CirculareDb:DbContext
    {


        public CirculareDb()
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //!! Instal package EntityFrameoworkCore.Proxies !

            optionsBuilder
                .UseLazyLoadingProxies() //apply this line to enable lazy loading.
                .UseSqlServer(
                   "Server=(localdb)\\mssqllocaldb;Database=circularDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new CustomerModelConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceModelConfiguration());
            modelBuilder.ApplyConfiguration(new WorkAchievementModelConfiguration());

            base.OnModelCreating(modelBuilder);
        }



        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<WorkAchievement> workAchievements { get; set; }


    }
}
