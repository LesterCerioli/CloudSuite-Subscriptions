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
	public class SubscriptionEFCoreMapping : IEntityTypeConfiguration<Subscription>
	{
		public void Configure(EntityTypeBuilder<Subscription> builder)
		{
			builder.HasKey(s => s.Id);
			builder.Property(s => s.SubscriptionNumber).HasMaxLength(255); // Ajuste conforme necessário
																		   // Outras configurações...

			builder.HasMany(s => s.Payments)
				   .WithOne()
				   .HasForeignKey(p => p.SubscriptionId)
				   .OnDelete(DeleteBehavior.Cascade);
		}
	}
}
