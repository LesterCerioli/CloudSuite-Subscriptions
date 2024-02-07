using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudSuite.Modules.Commons.Valueobjects;

namespace CloudSuite.Modules.Application.ViewModels
{
    public class ContactViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Contact Name")]
        [Required(ErrorMessage = "The Name field must be filled in.")]
        public string? Name { get; set; }

        [DisplayName("Contact Email")]
        [Required(ErrorMessage = "The Social Email field must be filled in.")]
        public string? Email { get; set; }

        [DisplayName("Contact Number")]
        [Required(ErrorMessage = "The Contact Number field must be filled in.")]
        public string? Telephone { get; set; }

        [DisplayName("Contact Description")]
        public string BodyMessage { get; set; }
    }
}
