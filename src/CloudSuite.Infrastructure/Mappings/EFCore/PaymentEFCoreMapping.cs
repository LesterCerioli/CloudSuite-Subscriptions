using CloudSuite.Subscriptions.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CloudSuite.Infrastructure.Mappings.EFCore
{
    public class PaymentEFCoreMapping : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(h => h.Id);

			builder.Property(h => h.Number)
				.HasMaxLength(255); // Adjust as needed
									// Other configurations...

			// Configuration of Value Objects
			builder.OwnsOne(p => p.Cnpj)
							.Property(p => p.CnpjNumber).HasColumnName("CnpjNumber");

			builder.OwnsOne(p => p.Email, email =>
			{
				email.Property(e => e.Address).HasColumnName("EmailAddress");
			});
        }
    }
}