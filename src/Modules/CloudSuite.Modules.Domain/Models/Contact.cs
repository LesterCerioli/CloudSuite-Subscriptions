using CloudSuite.Modules.Commons.Valueobjects;
using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Models
{
    public class Contact : Entity, IAggregateRoot
    {
        public Contact()
        {
        }

        public Contact(string? name, string? email, string? number, string? description)
        {
            Name = name;
            Email = email;
            Number = number;
            Description = description;
        }

        public string? Name { get; private set; }

        public string? Email { get; private set; }

        public string? Number { get; private set;}

        public string? Description { get; private set; }

    }
}
