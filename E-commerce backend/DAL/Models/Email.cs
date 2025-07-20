using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Email
    {
        [Key]
        public int Id { get; set; } 
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

    }
}
