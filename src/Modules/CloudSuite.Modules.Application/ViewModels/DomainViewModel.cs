using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CloudSuite.Modules.Application.ViewModels
{
    public class DomainViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("DNS do domínio")]
        [Required(ErrorMessage = "O campo Dns deve ser preenchido.")]
        public string? DNS { get; set; }

        [DisplayName("Nome do Proprietario do Dominio")]
        [Required(ErrorMessage = "O campo Nome do Proprietario deve ser preenchido.")]
        public string OwnerName { get; set; }

        [DisplayName("Data de Criação do Dominio")]
        [Required(ErrorMessage = "O campo Data de Criação deve ser preenchido.")]
        public DateTimeOffset? CreationDate { get; set; }

    }
}