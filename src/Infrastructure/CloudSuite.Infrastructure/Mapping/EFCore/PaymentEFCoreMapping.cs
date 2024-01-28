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
    public class PaymentEFCoreMapping : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Number)
                .HasColumnName("number")
                .HasColumnType("varchar(20")
                .IsRequired();

            builder.Property(a => a.PaidDate)
                .HasColumnName("PaidDate")
                .HasColumnType("datetimeoffset")
                .IsRequired();

            builder.Property(a => a.ExpireDate)
                .HasColumnName("ExpireDate")
                .HasColumnType("datetimeoffset")
                .IsRequired();

            builder.Property(a => a.Total)
                .HasColumnName("Total")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

			builder.Property(a => a.TotalPaid)
				.HasColumnName("TotalPaid")
				.HasColumnType("decimal(18,2)")
				.IsRequired();

			builder.Property(a => a.Payer)
				.HasColumnName("Payer")
				.HasColumnType("varchar(100")
				.IsRequired();

			builder.OwnsOne(p => p.Cnpj)
							.Property(p => p.CnpjNumber).HasColumnName("CNPJNumber").HasMaxLength(11).IsRequired();

			builder.OwnsOne(p => p.Email)
							.Property(p => p.Address).HasColumnName("Address").HasMaxLength(11).IsRequired();
		}
    }
}
