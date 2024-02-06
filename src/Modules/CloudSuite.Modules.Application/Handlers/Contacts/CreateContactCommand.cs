using CloudSuite.Modules.Application.Handlers.Contacts.Responses;
using CloudSuite.Modules.Commons.Valueobjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactEntity = CloudSuite.Modules.Domain.Models.Contact;

namespace CloudSuite.Modules.Application.Handlers.Contacts
{
	public class CreateContactCommand : IRequest<CreateContactResponse>
	{
        public Guid Id { get; private set; }

		public string? Name { get; set; }

		public string? Email { get; set; }

		public string? BodyMessage { get; set; }

		public string? Telephone { get; set; }

		public CreateContactCommand()
		{
			Id = Guid.NewGuid();
		}

		public ContactEntity GetEntity()
		{
			return new ContactEntity(
				new Commons.Valueobjects.Name(this.Name),
				new Email(this.Email),
				this.BodyMessage,
				new Telephone(this.Telephone));

		}
	}
}
