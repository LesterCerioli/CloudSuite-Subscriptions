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
            builder.HasKey(d => d.Id);

            builder.Property(d => d.SocialName)
                .HasColumnName("SocialName")
                .HasColumnType("varchar(100")
                .IsRequired();

            builder.Property(d => d.FantasyName)
				.HasColumnName("FantasyName")
				.HasColumnType("varchar(100")
				.IsRequired();

            builder.Property(d => d.FundationDate)
				.HasColumnName("FundationDate")
				.HasColumnType("date")
				.IsRequired();

			builder.OwnsOne(p => p.Cnpj)
							.Property(p => p.CnpjNumber).HasColumnName("CNPJNumber").HasMaxLength(11).IsRequired();

		}
	}
}
