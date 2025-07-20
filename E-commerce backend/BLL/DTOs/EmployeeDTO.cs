using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        [Required, StringLength(30)]
        public string Name { get; set; }
        [Required, StringLength(30)]
        public string Email { get; set; }
        public string Address { get; set; }
        [Required, StringLength(20)]
        public string Password { get; set; }
        public string Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
