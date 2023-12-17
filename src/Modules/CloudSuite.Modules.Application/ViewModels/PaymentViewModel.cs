using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using CloudSuite.Modules.Commons.Valueobjects;

namespace CloudSuite.Modules.Application.ViewModels
{
    public class PaymentViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Número do Pagamento")]
        [Required(ErrorMessage = "O campo Numero deve ser preenchido.")]
        public string? Number { get; set; }

        [DisplayName("Data de Pagamento")]
        [Required(ErrorMessage = "O campo Data de Pagamento deve ser preenchido.")]
        public DateTime? PaidDate { get; set; }

        [DisplayName("Data de Vencimento do Pagamento")]
        [Required(ErrorMessage = "O campo Data de Vencimento deve ser preenchido.")]
        public DateTime? ExpireDate { get; set; }

        [DisplayName("Total do Pagamento")]
        [Required(ErrorMessage = "O campo Total deve ser preenchido.")]
        public decimal? Total { get; set; }

        [DisplayName("Total Pago")]
        [Required(ErrorMessage = "O campo Total Pago deve ser preenchido.")]
        public decimal? TotalPaid { get; set; }

        [DisplayName("Pagador")]
        [Required(ErrorMessage = "O campo Pagador deve ser preenchido.")]
        public string? Payer { get; set; }

        [DisplayName("Cnpj do pagador")]
        [Required(ErrorMessage = "O campo Cnpj deve ser preenchido.")]
        public string? Cnpj { get; set; }

        [DisplayName("Email do Pagador")]
        [Required(ErrorMessage = "O campo Email deve ser preenchido.")]
        public string? Email { get; set; }
    }
}