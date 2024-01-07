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
            builder.HasKey(x => x.Id);  
            builder.Property(x => x.Id)
                .HasColumnName("Id");

            builder.Property(x => x.FantasyName)
                .HasColumnName("FantasyName")
                .HasMaxLength(100)
                .IsRequired()
                .HasColumnType("varchar(100");


			builder.Property(x => x.SocialName)
				.HasColumnName("SocialName")
				.HasMaxLength(100)
				.IsRequired()
				.HasColumnType("varchar(100");

            builder.OwnsOne(p => p.Cnpj)
                .Property(p => p.CnpjNumber).HasColumnName("CnpjNumber").HasMaxLength(14);

            builder.Property(x => x.FundationDate)
                .HasColumnName("FundadtionDate")
                .HasColumnType("date")
                .IsRequired();



		}
    }
}
