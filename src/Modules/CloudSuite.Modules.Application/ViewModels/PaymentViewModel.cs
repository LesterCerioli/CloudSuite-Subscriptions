using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using CloudSuite.Modules.Commons.Valueobjects;

namespace CloudSuite.Modules.Application.ViewModels
{
    public class PaymentViewModel
    {
        [Key]
        public Guid Id { get; private set; }

        [DisplayName("Número do Pagamento")]
        public string? Number { get; private set; }

        [DisplayName("Data de Pagamento")]
        [Required(ErrorMessage = "O {0} campo deve ser preenchido.")]
        public DateTime? PaidDate { get; private set; }

        [DisplayName("Data de Vencimento do Pagamento")]
        [Required(ErrorMessage = "O {0} campo deve ser preenchido.")]
        public DateTime? ExpireDate { get; private set; }

        [DisplayName("Total do Pagamento")]
        [Required(ErrorMessage = "O {0} campo deve ser preenchido.")]
        public decimal? Total { get; private set; }

        [DisplayName("Total Pago")]
        public decimal? TotalPaid { get; private set; }

        [DisplayName("Pagador")]
        public string? Payer { get; private set; }

        [DisplayName("Cnpj do pagador")]
        public Cnpj Cnpj { get; private set; }

        [DisplayName("Email do Pagador")]
        public Email Email { get; private set; }
    }
}