using System.ComponentModel.DataAnnotations;
using NetDevPack.Domain;

namespace CloudSuite.Modules.Domain.Models
{
    public class Person : Entity, IAggregateRoot
    {
        
        public Person(string name, string age)
        {
            Name = name;
            Age = age;
        }
        
        [Required(ErrorMessage = "O nome deve ser informado.")]
        [MaxLength(100)]
        public string? Name { get; private set; }

        [Required(ErrorMessage = "A idade deve ser informado.")]
        [MaxLength(3)]
        public string? Age { get; private set; }
        
    }
}