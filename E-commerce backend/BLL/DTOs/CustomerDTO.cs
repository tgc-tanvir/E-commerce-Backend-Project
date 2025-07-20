using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        [Required, StringLength(20)]
        public string Name { get; set; }
        public string Email { get; set; }
        [Required, StringLength(20)]
        public string Password { get; set; }
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
    }
}
