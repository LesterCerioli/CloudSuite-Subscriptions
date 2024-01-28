using System.ComponentModel.DataAnnotations;
using CloudSuite.Modules.Commons.Valueobjects;
using NetDevPack.Domain;

namespace CloudSuite.Modules.Domain.Models
{
    public class Person : Entity, IAggregateRoot
    {
        private Name name;

        public Person(Name name, string age)
        {
            Name = name;
            Age = age;
        }

        public Person() { }

        public Person(Name name)
        {
            this.name = name;
        }

        public Name Name { get; private set; }

        
        public string? Age { get; private set; }

    }
}