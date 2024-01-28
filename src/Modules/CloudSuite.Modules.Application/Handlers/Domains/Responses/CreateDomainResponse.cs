using CloudSuite.Modules.Application.Core;
using FluentValidation.Results;

namespace CloudSuite.Modules.Application.Handlers.Domains.Responses
{
    public class CreateDomainResponse : Response
    {
        public Guid RequestId { get; private set; }

        public CreateDomainResponse(Guid requestId, ValidationResult result)
        {
            RequestId = requestId;
            foreach (var item in result.Errors)
            {
                AddError(item.ErrorMessage);
            }
        }

        public CreateDomainResponse(Guid requestId, string falhaValidacao)
        {
            RequestId = RequestId;
            AddError(falhaValidacao);
        }
    }
}
