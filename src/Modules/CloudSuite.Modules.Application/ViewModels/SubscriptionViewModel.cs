using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CloudSuite.Modules.Application.ViewModels
{
    public class SubscriptionViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Número da Assinatura")]
        [Required(ErrorMessage = "O campo Numero da Assinatura deve ser preenchido.")]
        public string? SubscriptionNumber { get; set; }

        [DisplayName("Data de criação da Assinatura")]
        [Required(ErrorMessage = "O campo Data de Criação deve ser preenchido.")]
        public DateTime? CreateDate { get; set; }

        [DisplayName("Data da Última Atualização da Assinatura")]
        [Required(ErrorMessage = "O campo Data da Última Atualização deve ser preenchido.")]
        public DateTime? LastUpdateDate { get; set; }

        [DisplayName("Data de Vencimento da Assinatura")]
        [Required(ErrorMessage = "O campo Data de Vencimento deve ser preenchido.")]
        public DateTime? ExpireDate { get; set; }

        [DisplayName("Status Da Assinatura")]
        [Required(ErrorMessage = "O campo Status Da Assinatura deve ser preenchido.")]
        public bool? Active { get; set; }

    }
}