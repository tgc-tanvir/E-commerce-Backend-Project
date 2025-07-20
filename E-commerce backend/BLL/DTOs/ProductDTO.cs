using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace BLL.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        [Required]
        public string Pname { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Qty { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public string ImagePath { get; set; }
    }
}
