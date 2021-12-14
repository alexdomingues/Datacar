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
        //TODO:include driver picture
        public int Id { get; set; }
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
        //{
        //    get
        //    {
        //        if (string.IsNullOrEmpty(Comment))
        //        {
        //            return null;
        //        }
        //        if (Comment.Length > 20)
        //        {
        //            return Comment.Substring(0, 20) + "....";
        //        }
        //        else
        //        {
        //            return Comment;
        //        }
        //    }
        //}

        public string Photo { get; set; }
    }
}
