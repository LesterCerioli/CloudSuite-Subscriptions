using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using CloudSuite.Modules.Commons.Valueobjects;
using CloudSuite.Modules.Domain.Models;

namespace CloudSuite.Modules.Application.ViewModels
{
    public class CustomerViewModel
    {
        [Key]
        public Guid Id { get; private set; }

        [DisplayName("Nomde da Empresa")]
        public Name Name { get; set; }

        [DisplayName("Cnpj da Empresa")]
        [Required(ErrorMessage = "O {0} campo deve ser preenchido.")]
        public Cnpj Cnpj { get; set; }

        [DisplayName("Email da Empresa")]
        [Required(ErrorMessage = "O {0} campo deve ser preenchido.")]
        public Email Email { get; set; }

        [DisplayName("Nome do Proprietario da Empresa")]
        [Required(ErrorMessage = "O {0} campo deve ser preenchido.")]
        public string? BusinessOwner { get; set; }

        [DisplayName("Data de criação da Empresa")]
        public DateTimeOffset? CreatedOn { get; set; }

        [DisplayName("Informações da Empresa")]
        public Company Company { get; set; }

    }
}