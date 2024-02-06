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
    public class CompanyEFCoreMapping : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(a => a.Id);

			builder.OwnsOne(p => p.Cnpj)
							.Property(p => p.CnpjNumber).HasColumnName("CnpjNumber");

            builder.Property(a => a.SocialName)
                .HasColumnName("SocialName")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(a => a.FantasyName)
                .HasColumnName("FantasyName")
                .HasColumnType("varchar(100)")
				.HasMaxLength(100)
				.IsRequired();

            builder.Property(a => a.FundationDate)
                .HasColumnName("FundationDate")
				.HasColumnType("date")
				.IsRequired();
		}
    }
}
