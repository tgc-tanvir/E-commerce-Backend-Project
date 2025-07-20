using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Pname { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Qty { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ImagePath { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public Product() {
             Orders= new List<Order>();
            }

    }
}
