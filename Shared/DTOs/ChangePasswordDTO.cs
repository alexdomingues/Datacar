using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datacar.Shared.DTOs
{
    public class ChangePasswordDTO
    {
        [Required]
        public string CurrentPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
        [Required]
        [Compare("NewPassword",ErrorMessage ="A password não é igual à nova password")]
        public string ConfirmationPassword { get; set; }

        public string UserId { get; set; }
    }
}
