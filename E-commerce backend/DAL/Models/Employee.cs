using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required,StringLength(30)]
        public string Name { get; set; }
        [Required,StringLength(30)]
        public string Email { get; set; }
        [Required,StringLength(30)] 
        public string Address { get; set; }
        [Required,StringLength(20)]
        public string Password { get; set; }
        [Required]
        public string Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
