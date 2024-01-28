using CloudSuite.Modules.Application.Core;
using FluentValidation.Results;

namespace CloudSuite.Modules.Application.Handlers.Domains.Responses
{
    public class CheckDomainExistsByOwnerNameResponse : Response
    {
        public Guid RequestId { get; private set; }
        public bool Exists {  get; set; }

        public CheckDomainExistsByOwnerNameResponse(Guid requestId, bool exists, ValidationResult result) {
            RequestId = requestId;
            Exists = exists;
            foreach(var item in result.Errors) {
                this.AddError(item.ErrorMessage);
            }
        }

        public CheckDomainExistsByOwnerNameResponse(Guid requestId, string falhaValidacao)
        {
            RequestId = requestId;
            Exists = false;
            this.AddError(falhaValidacao);
        }
    }
}