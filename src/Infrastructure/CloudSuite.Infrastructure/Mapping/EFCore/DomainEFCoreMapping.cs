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
    public class DomainEFCoreMapping : IEntityTypeConfiguration<Domain>
    {
        public void Configure(EntityTypeBuilder<Domain> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.DNS)
                .HasColumnName("DNS")
                .HasColumnType("varchar(50")
                .IsRequired();

            builder.Property(f => f.OwnerName)
                .HasColumnName("OwnerName")
                .HasColumnType("varchar(100")
                .IsRequired();

			builder.Property(f => f.CreationDate)
				.HasColumnName("CreationDate")
				.HasColumnType("date")
				.IsRequired();
		}
    }
}
