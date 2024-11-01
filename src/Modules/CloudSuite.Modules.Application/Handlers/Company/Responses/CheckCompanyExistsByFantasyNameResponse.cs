using CloudSuite.Modules.Application.Core;
using FluentValidation.Results;

namespace CloudSuite.Modules.Application.Handlers.Company.Responses
{
    public class CheckCompanyExistsByFantasyNameResponse : Response
    {
        public Guid RequestId { get; private set; }
        public bool Exists { get; set; }
        public CheckCompanyExistsByFantasyNameResponse(Guid requestId, bool exists, ValidationResult result) {
            RequestId = requestId;
            Exists = exists;
            foreach (var item in result.Errors) {
                this.AddError(item.ErrorMessage);
            }
        }

        public CheckCompanyExistsByFantasyNameResponse(Guid requestId, string falhaValidacao) {
            RequestId=requestId;
            Exists = false;
            this.AddError(falhaValidacao);
        }
    }
}