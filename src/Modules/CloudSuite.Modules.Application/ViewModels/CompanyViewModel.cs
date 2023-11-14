using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using CloudSuite.Modules.Commons.Valueobjects;

namespace CloudSuite.Modules.Application.ViewModels
{
    public class CompanyViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Cnpj da Empresa")]
        [Required(ErrorMessage = "O {0} campo deve ser preenchido.")]
        public Cnpj Cnpj  { get; set; }

        [DisplayName("Nome Social da Empresa")]
        [Required(ErrorMessage = "O {0} campo deve ser preenchido.")]
        public string? SocialName { get; set; }

        [DisplayName("Nome Fantasia da Empresa")]
        [Required(ErrorMessage = "O {0} campo deve ser preenchido.")]
        public string? FantasyName { get; set; }

    }
}