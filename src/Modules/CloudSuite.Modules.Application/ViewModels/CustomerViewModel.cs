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

        [DisplayName("Nomde da Cliente")]
        [Required(ErrorMessage = "O campo Nome deve ser preenchido.")]
        public string? Name { get; set; }

        [DisplayName("Cnpj do Cliente")]
        [Required(ErrorMessage = "O campo Cnpj deve ser preenchido.")]
        public string? Cnpj { get; set; }

        [DisplayName("Email do Cliente")]
        [Required(ErrorMessage = "O campo Email deve ser preenchido.")]
        public string? Email { get; set; }

        [DisplayName("Nome do Proprietario")]
        [Required(ErrorMessage = "O campo Nome Proprietario deve ser preenchido.")]
        public string? BusinessOwner { get; set; }

        [DisplayName("Data de criação")]
        [Required(ErrorMessage = "O campo Data de Criação deve ser preenchido.")]
        public DateTimeOffset? CreatedOn { get; set; }

        [DisplayName("Informações da Empresa")]
        [Required(ErrorMessage = "O campo Empresa deve ser preenchido.")]
        public string? Company { get; set; }

    }
}