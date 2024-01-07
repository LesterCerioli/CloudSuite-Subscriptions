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
    public class CustomerEFCoreMapping : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey();
			builder.Property(w => w.Id)
				.HasColumnName("Id");

            builder.OwnsOne(p => p.Name)
                .Property(p => p.FirstName).HasColumnName("FirstName").HasMaxLength(100);

            builder.OwnsOne(p => p.Name)
                .Property(p => p.LastName).HasColumnName("LastName").HasMaxLength(100);


		}
    }
}
