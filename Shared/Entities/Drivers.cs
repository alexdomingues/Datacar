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

        public class Cars

        {
            //public Guid Id { get; set; }
            [Required]
            public string Nome { get; set; }
            
        }
    }
}
