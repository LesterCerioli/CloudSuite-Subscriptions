using CloudSuite.Modules.Commons.Valueobjects;
using CustomerEntity = CloudSuite.Modules.Domain.Models.Customer;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Customers
{
    public class CreateCustomerCommand: IRequest<CreateCustomerCommand>
    {
        public Guid Id { get; private set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Cnpj { get; set; }

        public string? Email { get; set; }

        public string? BusinessOwner { get; set; }

        public DateTimeOffset? CreatedOn { get; set; }

        public CreateCustomerCommand()
        {
            Id = Guid.NewGuid();
        }

        public CustomerEntity GetEntity()
        {
            return new CustomerEntity(
                new Name(this.FirstName, this.LastName),
                new Cnpj(this.Cnpj),
                new Email(this.Email),
                this.BusinessOwner,
                this.CreatedOn
                );
        }
    }
}