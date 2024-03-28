using CloudSuite.Modules.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Infrastructure.Mapping.EFCore
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
