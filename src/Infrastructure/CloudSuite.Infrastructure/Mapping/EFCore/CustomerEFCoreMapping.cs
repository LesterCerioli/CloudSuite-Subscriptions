using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudSuite.Modules.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CloudSuite.Infrastructure.Mapping.EFCore
{
    public class CustomerEFCoreMapping : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.BusinessOwner)
                .HasColumnName("BusinessOwner")
                .HasColumnType("varchar(100")
                .IsRequired();

			builder.OwnsOne(p => p.Cnpj)
							.Property(p => p.CnpjNumber).HasColumnName("CNPJNumber").HasMaxLength(11).IsRequired();

			builder.OwnsOne(p => p.Name)
							.Property(p => p.FirstName).HasColumnName("FirstName").HasMaxLength(100).IsRequired();

			builder.OwnsOne(p => p.Name)
							.Property(p => p.LastName).HasColumnName("LastName").HasMaxLength(100).IsRequired();

			builder.OwnsOne(p => p.Email)
							.Property(p => p.Address).HasColumnName("Address").HasMaxLength(100).IsRequired();

			builder.HasOne(e => e.Company)
			   .WithMany()
			   .HasForeignKey(e => e.Companies)
			   .IsRequired();
		}
    }
}
