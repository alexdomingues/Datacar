using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datacar.Shared.Entities
{
    public class Cars
    {
        public int Id { get; set; }
        [Required]
        public string License { get; set; }
        [Required]
        public DateTime? LicenseDate { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public int InitialKms { get; set; }
        [Required]
        public int BuyKms { get; set; }
        [Required]
        public DateTime? ContractValidity { get; set; }   
        public int DriverId { get; set; }
        [Required]
        public string TollIdentifier { get; set; }
    }
}
