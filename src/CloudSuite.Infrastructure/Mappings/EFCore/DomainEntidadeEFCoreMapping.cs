using CloudSuite.Subscriptions.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CloudSuite.Infrastructure.Mappings.EFCore
{
    public class DomainEntidadeEFCoreMapping : IEntityTypeConfiguration<DomainEntidade>
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