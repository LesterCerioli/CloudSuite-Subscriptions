using CloudSuite.Subscriptions.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CloudSuite.Infrastructure.Mappings.EFCore
{
    public class ContactEFCoreMapping : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(a => a.Email)
                .HasColumnName("Email")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(a => a.Telephone)
                .HasColumnName("Telephone")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(a => a.BodyMessage)
                .HasColumnName("BodyMessage")
                .HasColumnType("varchar(100)");
        }
    }
}