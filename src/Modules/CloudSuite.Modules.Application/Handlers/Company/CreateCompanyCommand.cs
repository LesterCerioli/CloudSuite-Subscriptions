using CloudSuite.Modules.Application.Handlers.Company.Responses;
using CloudSuite.Modules.Commons.Valueobjects;
using MediatR;
using CompanyEntity = CloudSuite.Modules.Domain.Models.Company;

namespace CloudSuite.Modules.Application.Handlers.Company
{
    public class CreateCompanyCommand: IRequest<CreateCompanyResponse>
    {
        public Guid Id { get; private set; }
        public string? Cnpj { get; set; }
        public string? SocialName { get; set; }
        public string? FantasyName { get; set; }
        public DateTime? FundationDate {  get; set; }

        public CreateCompanyCommand()
        {
            Id = Guid.NewGuid();
        }

        public CompanyEntity GetEntity()
        {
            return new CompanyEntity(
                new Cnpj(this.Cnpj),
                this.SocialName,
                this.FantasyName
                );
        }


    }
}