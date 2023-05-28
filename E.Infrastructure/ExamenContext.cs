using E.ApplicationCore.Domain;
using E.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.Infrastructure
{
    public class ExamenContext:DbContext
    {
        public DbSet<Banque> Banques { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Compte> Comptes { get; set; }
        public DbSet<TransactionRetrait> TransactionRetraits { get; set; }
        public DbSet<TransactionTransfert> TransactionTransferts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                       Initial Catalog=DABNomPrenom3;
                       Integrated Security=true;MultipleActiveResultSets=true");

            base.OnConfiguring(optionsBuilder);
        
    }
        //application de fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
            
            //TPT
            modelBuilder.Entity<TransactionRetrait>()
                .ToTable("TransactionRetraits");

                 modelBuilder.Entity<TransactionTransfert>()
                .ToTable("TransactionTransferts");
        }
        // appliquer une condition sur les prop de type string
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {


            configurationBuilder.Properties<string>().HaveMaxLength(50);
        }
    }
}
