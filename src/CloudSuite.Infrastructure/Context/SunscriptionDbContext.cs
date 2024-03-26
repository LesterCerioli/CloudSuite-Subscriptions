using System.Data.Common;
using CloudSuite.Infrastructure.Mappings.EFCore;
using CloudSuite.Subscriptions.Domain.Models;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Messaging;

namespace CloudSuite.Infrastructure.Context
{
    public class SunscriptionDbContext : DbContext
    {
        public SunscriptionDbContext(DbContextOptions<SunscriptionDbContext> options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;

        }

        public DbSet<Company> Companies {get; set;}

        public DbSet<Contact> Contacts {get; set;}

        public DbSet<Customer> Customers {get; set;}

        public DbSet<DomainEntidade> Domains {get; set;}

        public DbSet<Payment> Payments {get; set;}

        public DbSet<Subscription> Subscriptions {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<Event>();

            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                    e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfiguration(new CompanyEFCoreMapping());

            modelBuilder.ApplyConfiguration(new ContactEFCoreMapping());

            modelBuilder.ApplyConfiguration(new CustomerEFCoreMapping());

            modelBuilder.ApplyConfiguration(new DomainEntidadeEFCoreMapping());

            modelBuilder.ApplyConfiguration(new PaymentEFCoreMapping());

            modelBuilder.ApplyConfiguration(new SubscriptionEFCoremapping());

            modelBuilder.Entity<Company>(c =>
            {
                c.ToTable("Companies");
            });

            modelBuilder.Entity<Contact>(c =>
            {
                c.ToTable("Contacts");
            });

            modelBuilder.Entity<Customer>(c =>
            {
                c.ToTable("Customers");
            });

            modelBuilder.Entity<DomainEntidade>(c =>
            {
                c.ToTable("Domains");
            });

            modelBuilder.Entity<Payment>(c =>
            {
                c.ToTable("Payments");
            });

            modelBuilder.Entity<Subscription>(c =>
            {
                c.ToTable("Subscriptions");
            });

            

            base.OnModelCreating(modelBuilder);


        }
        
    }
}