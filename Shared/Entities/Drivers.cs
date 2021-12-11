using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datacar.Shared.Entities
{
    public class Drivers
    {
            public Guid Id { get; set; }
            [Required]
            public string Name { get; set; }
           // [Required]
            public int EmployeeNum { get; set; }
            // [Required]
            public string Job { get; set; }
            // [Required]
            public int LicenceNum { get; set; }
            // [Required]
            public string GSM { get; set; }
            // [Required]
            public string Email { get; set; }
            public string Comment { get; set; }
    }
}
