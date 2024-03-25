using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CloudSuite.Subscriptions.Application.ViewModels
{
    public class CustomerViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Nomde da Empresa")]
        [Required(ErrorMessage = "O campo Nome deve ser preenchido.")]
        public string? Name { get; set; }

        [DisplayName("Cnpj da Empresa")]
        [Required(ErrorMessage = "O campo Cnpj deve ser preenchido.")]
        public string? Cnpj { get; set; }

        [DisplayName("Email da Empresa")]
        [Required(ErrorMessage = "O campo Email deve ser preenchido.")]
        public string? Email { get; set; }

        [DisplayName("Nome do Proprietario da Empresa")]
        [Required(ErrorMessage = "O campo deve ser preenchido.")]
        public string? BusinessOwner { get; set; }

        [DisplayName("Data de criação da Empresa")]
        [Required(ErrorMessage = "O campo Data de criação deve ser preenchido.")]
        public DateTimeOffset? CreatedOn { get; set; }
        
    }
}