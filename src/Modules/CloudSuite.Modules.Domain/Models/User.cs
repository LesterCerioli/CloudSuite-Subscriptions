using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudSuite.Modules.Commons.Valueobjects;

namespace CloudSuite.Modules.Domain.Models
{
    public class User : Entity, IAggregateRoot
    {
        private string cpf;

        public User(string? username, string? password, string? profile, Cpf cpf)
        {
            Username = username;
            Password = password;
            Profile = profile;
            Cpf = cpf;
        }

        public User(string? username, string? password, string? profile, string cpf)
        {
            Username = username;
            Password = password;
            Profile = profile;
            this.cpf = cpf;
        }

        [Required(ErrorMessage = "O uduário deve ser informado.")]
        [StringLength(255)]
        public string? Username { get; private set; }

        [Required(ErrorMessage = "A senha deve ser informada.")]
        [StringLength(20)]
        public string? Password { get; private set; }

        
        [StringLength(20)]
        public string? Profile { get; private set; }
        
        public Cpf Cpf { get; private set; }
        
    }
}
