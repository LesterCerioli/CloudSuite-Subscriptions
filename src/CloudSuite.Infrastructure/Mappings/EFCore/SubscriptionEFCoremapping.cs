using CloudSuite.Subscriptions.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CloudSuite.Infrastructure.Mappings.EFCore
{
    public class SubscriptionEFCoremapping : IEntityTypeConfiguration<Subscription>
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