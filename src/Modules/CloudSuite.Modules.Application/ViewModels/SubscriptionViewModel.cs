using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CloudSuite.Modules.Application.ViewModels
{
    public class SubscriptionViewModel
    {
        [Key]
        public Guid Id { get; private set; }

        [DisplayName("Número da Assinatura")]
        [Required(ErrorMessage = "O campo Numero De Assinatura deve ser preenchido.")]
        public string? SubscriptionNumber { get; private set; }

        [DisplayName("Data de criação da Assinatura")]
        [Required(ErrorMessage = "O campo Data de criação deve ser preenchido.")]
        public DateTime? CreateDate { get; private set; }

        [DisplayName("Data da Última Atualização da Assinatura")]
        [Required(ErrorMessage = "O campo Ultima Atualização deve ser preenchido.")]
        public DateTime? LastUpdateDate { get; private set; }

        [DisplayName("Data de Vencimento da Assinatura")]
        [Required(ErrorMessage = "O campo Data de Vencimento deve ser preenchido.")]
        public DateTime? ExpireDate { get; private set; }

        [DisplayName("Status Da Assinatura")]
        [Required(ErrorMessage = "O campo Status da Assinatura deve ser preenchido.")]
        public bool? Active { get; private set; }

    }
}