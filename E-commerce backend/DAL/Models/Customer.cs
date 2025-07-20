using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required,StringLength(20)]
        public string Name { get; set; }
        [Required,StringLength(20)]
        public string Email { get; set; }
        [Required,StringLength(20)]
        public string Password { get; set; }
        [Required,StringLength(30)]
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? CreatedBy { get; set; }

    }
}
