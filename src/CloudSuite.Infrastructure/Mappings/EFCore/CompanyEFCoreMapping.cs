using CloudSuite.Subscriptions.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CloudSuite.Infrastructure.Mappings.EFCore
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