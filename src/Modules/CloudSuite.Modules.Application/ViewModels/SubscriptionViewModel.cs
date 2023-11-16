using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CloudSuite.Modules.Application.ViewModels
{
    public class SubscriptionViewModel
    {
        [Key]
        public Guid Id { get; private set; }

        [DisplayName("N�mero da Assinatura")]
        public string? SubscriptionNumber { get; private set; }

        [DisplayName("Data de cria��o da Assinatura")]
        [Required(ErrorMessage = "O {0} campo deve ser preenchido.")]
        public DateTime? CreateDate { get; private set; }

        [DisplayName("Data da �ltima Atualiza��o da Assinatura")]
        [Required(ErrorMessage = "O {0} campo deve ser preenchido.")]
        public DateTime? LastUpdateDate { get; private set; }

        [DisplayName("Data de Vencimento da Assinatura")]
        [Required(ErrorMessage = "O {0} campo deve ser preenchido.")]
        public DateTime? ExpireDate { get; private set; }

        [DisplayName("Status Da Assinatura")]
        public bool? Active { get; private set; }

    }
}