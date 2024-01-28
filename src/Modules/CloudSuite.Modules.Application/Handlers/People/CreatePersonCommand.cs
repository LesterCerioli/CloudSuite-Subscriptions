using CloudSuite.Modules.Application.Handlers.People.Responses;
using CloudSuite.Modules.Commons.Valueobjects;
using MediatR;
using PersonEntity = CloudSuite.Modules.Domain.Models.Person;

namespace CloudSuite.Modules.Application.Handlers.People
{
    public class CreatePersonCommand : IRequest<CreatePersonResponse>
    {
        public Guid Id { get; private set; }

        public string? Name { get; set; }

        public CreatePersonCommand()
        {
            Id = Guid.NewGuid();
        }

        public PersonEntity GetEntity()
        {
            return new PersonEntity(
                new Name(this.Name));
        }


    }
}