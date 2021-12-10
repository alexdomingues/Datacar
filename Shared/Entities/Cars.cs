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
            public Guid Id { get; set; }
            [Required]
            public string Matricula { get; set; }
            //[Required]
            //public DateTime? DataMaricula { get; set; }
            //[Required]
            //public string Modelo { get; set; }
            //[Required]
            //public string TipoVeiculo { get; set; }
            //[Required]
            //public int KmsIniciais { get; set; }
            //[Required]
            //public int KmsContratados { get; set; }
            //[Required]
            //public DateTime? ValidadeContrato { get; set; }
            //[Required]
            //public int IdCondutor { get; set; }
            //[Required]
            //public string IdentificadorViaVerde { get; set; }
            //[Required]
            //public string Url { get; set; }
    }
}
