using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CloudSuite.Modules.Application.ViewModels
{
    public class SubscriptionViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("N�mero da Assinatura")]
        [Required(ErrorMessage = "O campo Numero da Assinatura deve ser preenchido.")]
        public string? SubscriptionNumber { get; set; }

        [DisplayName("Data de cria��o da Assinatura")]
        [Required(ErrorMessage = "O campo Data de Cria��o deve ser preenchido.")]
        public DateTime? CreateDate { get; set; }

        [DisplayName("Data da �ltima Atualiza��o da Assinatura")]
        [Required(ErrorMessage = "O campo Data da �ltima Atualiza��o deve ser preenchido.")]
        public DateTime? LastUpdateDate { get; set; }

        [DisplayName("Data de Vencimento da Assinatura")]
        [Required(ErrorMessage = "O campo Data de Vencimento deve ser preenchido.")]
        public DateTime? ExpireDate { get; set; }

        [DisplayName("Status Da Assinatura")]
        [Required(ErrorMessage = "O campo Status Da Assinatura deve ser preenchido.")]
        public bool? Active { get; set; }

    }
}