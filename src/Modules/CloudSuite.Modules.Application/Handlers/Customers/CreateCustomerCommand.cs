using CustomerEntity = CloudSuite.Modules.Domain.Models.Customer;
using MediatR;
using CloudSuite.Modules.Commons.Valueobjects;
using CloudSuite.Modules.Application.Handlers.Customers.Requests;
using CloudSuite.Modules.Domain.Models;

namespace CloudSuite.Modules.Application.Handlers.Customers
{
    public class CreateCustomerCommand : IRequest<CheckCustomerExistsByCnpjRequest>
    {
        public CreateCustomerCommand()
        {
            Id = Guid.NewGuid();
        }

        public CustomerEntity GetEntity()
        {
            return new CustomerEntity(
                this.Name,
                this.Cnpj,
                this.Email,
                this.BusinessOwner,
                this.CreatedOn,
                this.Company
            );
        }


        public Guid Id { get; private set; }

        public Name Name { get; set; }

        public Cnpj Cnpj { get; set; }

        public Email Email { get; set; }

        public string? BusinessOwner { get; set; }

        public DateTimeOffset? CreatedOn { get; set; }

        public Company Company { get; set; }
    }
}
