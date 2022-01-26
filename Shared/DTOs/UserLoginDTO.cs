using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Datacar.Client.CustomValidators;

namespace Datacar.Shared.DTOs
{
    public class UserLoginDTO
    {
        [Required]
        [EmailDomainValidator(AllowedDomain = "mail.pt")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
