using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CloudSuite.Modules.Application.ViewModels
{
    public class PersonViewmodel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "O campo Nome deve ser preenchido.")]
        public string? Name { get; set; }

        [DisplayName("Idade")]
        [Required(ErrorMessage = "O campo Idade deve ser preenchido.")]
        public string? Age { get; set; }
    }
}