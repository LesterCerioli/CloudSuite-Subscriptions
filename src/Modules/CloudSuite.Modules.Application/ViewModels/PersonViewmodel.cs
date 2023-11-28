using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CloudSuite.Modules.Application.ViewModels
{
    public class PersonViewmodel
    {
        [Key]
        public Guid Id { get; private set; }

        [DisplayName("Nome")]
        [MaxLength(100)]
        [Required(ErrorMessage = "O nome deve ser informado.")]
        public string? Name { get; set; }

        [DisplayName("Idade")]
        [MaxLength(3)]
        [Required(ErrorMessage = "A idade deve ser informado.")]
        public string? Age { get; set; }
    }
}