using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Cart
    {
        public int Id {  get; set; }
        [ForeignKey("Customer")]
        public int CusId { get; set; }
        [ForeignKey("Product")]
        public int PId { get; set; }
        [Required]
        public int Qty { get; set; }
        public DateTime CreatedAt {  get; set; }
        public DateTime? UpdatedAt { get; set;}

        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}
