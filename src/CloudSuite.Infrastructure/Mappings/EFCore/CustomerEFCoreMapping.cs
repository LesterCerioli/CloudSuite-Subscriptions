using CloudSuite.Subscriptions.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CloudSuite.Infrastructure.Mappings.EFCore
{
    public class CustomerEFCoreMapping : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(b => b.Id);

            builder.OwnsOne(b => b.Name, name =>
            {
                name.Property(n => n.FirstName).HasColumnName("FirstName");
                name.Property(n => n.LastName).HasColumnName("LastName");
            });

			builder.OwnsOne(b => b.Cnpj, cnpj =>
			{
				cnpj.Property(b => b.CnpjNumber).HasColumnName("CnpjNumber");
			});

			builder.OwnsOne(b => b.Email, email =>
			{
				email.Property(e => e.Address).HasColumnName("EmailAddress");
			});

			builder.Property(b => b.BusinessOwner)
				.HasColumnName("BusinessOwner")
				.HasColumnType("varchar(100)"); // Defina o tamanho conforme necessário.

			builder.Property(b => b.CreatedOn)
				.HasColumnName("CreatedOn")
				.HasColumnType("datetimeoffset");

			builder.HasOne(b => b.Company)
				.WithMany()
				.HasForeignKey(b => b.Company.Id) // Assumindo que a propriedade CompanyId está na classe Company
				.IsRequired();
        }
    }
}