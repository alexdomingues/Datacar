using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datacar.Shared.Entities
{
    public class DatacarUser
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string Local { get; set; }
        public string Language { get; set; }
        public DateTime? BornDate { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public string MobilePhoneNumber { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
        [Required]
        public int AccessLevel { get; set; }
        public DateTime? Validity { get; set; }
    }
}
