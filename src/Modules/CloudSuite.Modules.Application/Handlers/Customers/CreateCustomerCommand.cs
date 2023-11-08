using CloudSuite.Modules.Application.Handlers.Customers.Responses;
using CustomerEntity = CloudSuite.Modules.Domain.Models.Customer;
using CloudSuite.Modules.Domain.ValueObjects;
using MediatR;
using System;

namespace CloudSuite.Modules.Application.Handlers.Customers
{
    public class CreateCustomerCommand : IRequest<CreateCustomerResponse>
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

        public string? Name { get; set; }

        public Cnpj Cnpj { get; set; }

        public Email Email { get; set; }

        public string? BusinessOwner { get; set; }

        public DateTimeOffset? CreatedOn { get; set; }

        public Company Company { get; set; }
    }
}
