using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using CloudSuite.Commons.ValueObjects;
namespace CloudSuite.Subscriptions.Application.ViewModels
{
    public class CompanyViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Cnpj da Empresa")]
        [Required(ErrorMessage = "O campo Cnpj deve ser preenchido.")]
        public string? Cnpj  { get; set; }

        [DisplayName("Nome Social da Empresa")]
        [Required(ErrorMessage = "O campo Nome Social deve ser preenchido.")]
        public string? SocialName { get; set; }

        [DisplayName("Nome Fantasia da Empresa")]
        [Required(ErrorMessage = "O campo Nome Fantasya deve ser preenchido.")]
        public string? FantasyName { get; set; }

        [DisplayName("Data de Fundação da Empresa")]
        [Required(ErrorMessage = "O campo Data de Fundação deve ser preenchido.")]
        public DateTime FundationDate { get; set; }
        
    }
}