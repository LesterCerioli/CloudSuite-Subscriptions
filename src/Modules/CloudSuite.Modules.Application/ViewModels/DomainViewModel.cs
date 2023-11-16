using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CloudSuite.Modules.Application.ViewModels
{
    public class DomainViewModel
    {
        [Key]
        public Guid Id { get; private set; }

        [DisplayName("DNS do domínio")]
        public string? DNS { get; private set; }

        [DisplayName("Nome do Proprietario do Dominio")]
        [Required(ErrorMessage = "O {0} campo deve ser preenchido.")]
        public string OwnerName { get; private set; }

        [DisplayName("Data de Criação do Dominio")]
        [Required(ErrorMessage = "O {0} campo deve ser preenchido.")]
        public DateTimeOffset? CreationDate { get; private set; }

    }
}