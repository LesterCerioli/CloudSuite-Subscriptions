using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CloudSuite.Modules.Application.ViewModels
{
    public class DomainViewModel
    {
        [Key]
        public Guid Id { get; private set; }

        [DisplayName("DNS do dom�nio")]
        [Required(ErrorMessage = "O DNS campo deve ser preenchido.")]
        public string? DNS { get; private set; }

        [DisplayName("Nome do Proprietario do Dominio")]
        [Required(ErrorMessage = "O campo Proprietario do Dominio deve ser preenchido.")]
        public string OwnerName { get; private set; }

        [DisplayName("Data de Cria��o do Dominio")]
        [Required(ErrorMessage = "O campo Data de Cria��o deve ser preenchido.")]
        public DateTimeOffset? CreationDate { get; private set; }

    }
}