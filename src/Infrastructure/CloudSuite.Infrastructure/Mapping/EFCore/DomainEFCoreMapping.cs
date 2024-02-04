using CloudSuite.Modules.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Infrastructure.Mapping.EFCore
{
	public class DomainEFCoreMapping : IEntityTypeConfiguration<DomainEntidade>
	{
		public void Configure(EntityTypeBuilder<DomainEntidade> builder)
		{
			builder.HasKey(e => e.Id);

			builder.Property(e => e.DNS)
				.HasColumnName("DNS")
				.HasColumnType("varchar(255)") // Adjust the size as needed.
				.HasMaxLength(100)
				.IsRequired();

			builder.Property(e => e.OwnerName)
				.HasColumnName("OwnerName")
				.HasColumnType("varchar(100)") // Adjust the size as needed.
				.HasMaxLength(100)
				.IsRequired();

			builder.Property(e => e.CreationDate)
				.HasColumnName("CreationDate")
				.HasColumnType("datetimeoffset")
				.IsRequired();
		}
	}
}
