using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudSuite.Infrastructure.Mapping.EFCore;
using CloudSuite.Modules.Domain.Models;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Messaging;

namespace CloudSuite.Infrastructure.Context
{
	public class SubscriptionDbContext : DbContext
	{

		public SubscriptionDbContext(DbContextOptions<SubscriptionDbContext> options)
		{
			ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;

		}

		public DbSet<Company> Companies {get; set;}

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Customer> Customers {get; set;}

		public DbSet<DomainEntidade> Domains { get; set;}

		public DbSet<Payment> Payments {get; set;}

        public DbSet<Subscription> Subscriptions { get; set;}

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

			modelBuilder.ApplyConfiguration(new PaymentEFCoreMapping());

            modelBuilder.ApplyConfiguration(new SubscriptionEFCoreMapping());

            modelBuilder.ApplyConfiguration(new DomainEFCoreMapping());

            


            modelBuilder.Entity<Company>(s =>
            {
                s.ToTable("Companiess");
            });

            modelBuilder.Entity<Contact>(s =>
            {
                s.ToTable("Contacts");
            });

            modelBuilder.Entity<Customer>(s =>
            {
                s.ToTable("Customers");
            });


            modelBuilder.Entity<DomainEntidade>(s =>
            {
                s.ToTable("Domains");
            });


            modelBuilder.Entity<Payment>(s =>
            {
                s.ToTable("Payments");
            });

            modelBuilder.Entity<Subscription>(s =>
            {
                s.ToTable("Subscriptions");
            });

			base.OnModelCreating(modelBuilder);
		}
	}
}
