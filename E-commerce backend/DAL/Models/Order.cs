using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public DateTime Time { get; set; }
        [ForeignKey("Status")]
        public int StatusId { get; set; }
        [Required]
        public decimal Total { get; set; }
        [ForeignKey("Customer")]
        public int CusId { get; set; }
        public virtual Status Status { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
