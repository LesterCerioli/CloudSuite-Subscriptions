using CloudSuite.Modules.Application.Handlers.People.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Handlers.People.Requests
{
    public class CheckPersonExistsByNameRequest : IRequest<CheckPersonExistsByNameResponse>
    {

        public Guid Id { get; private set; }

        public string? Name { get; set; }

        public bool? Exists { get; set; }

        public CheckPersonExistsByNameRequest(bool exists)
        {
            Id = Guid.NewGuid();
            Exists = exists;

        }


    }
}
