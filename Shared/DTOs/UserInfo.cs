using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Datacar.Shared.DTOs
{
    public class UserInfo
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        // new fields required by Datacar scope
        public string Language { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string Local { get; set; }
        public DateTime? BornDate { get; set; }
        public string MobilePhoneNumber { get; set; }
        public string Comment { get; set; }
        // Use roles
        //[Required]
        //public int AccessLevel { get; set; }
        public DateTime? ExpireDate { get; set; }
        public string PhoneNumber { get; set; }
    }
}
