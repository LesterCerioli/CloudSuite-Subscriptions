using CloudSuite.Modules.Commons.Valueobjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.ViewModels
{
    public class UserViewModel
    {
        [Key]
        public Guid Id { get; private set; }

        [Required(ErrorMessage = "O usuário deve ser informado.")]
        [StringLength(255)]
        [DisplayName("Username")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "A senha deve ser informada.")]
        [StringLength(20)]
        [DisplayName("Password")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "O PERFIL deve ser informado.")]
        [StringLength(20)]
        [DisplayName("Password")]
        public string? Profile { get; private set; }

        [Required(ErrorMessage = "O CPF deve ser informado.")]
        [DisplayName("Cpf")]
        public Cpf Cpf { get; private set; }
    }
}
