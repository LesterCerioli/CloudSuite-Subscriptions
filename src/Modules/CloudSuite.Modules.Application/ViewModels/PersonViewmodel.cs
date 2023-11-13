using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CloudSuite.Modules.Application.ViewModels
{
    public class PersonViewmodel
    {
        [Key]
        public Guid Id { get; private set; }

        [Required(ErrorMessage = "O nome deve ser informado.")]
        [MaxLength(100)]
        [DisplayName("Nome")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "A idade deve ser informado.")]
        [MaxLength(3)]
        [DisplayName("Idade")]
        public string? Age { get; set; }
    }
}