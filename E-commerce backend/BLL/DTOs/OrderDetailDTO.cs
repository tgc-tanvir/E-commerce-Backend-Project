using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace BLL.DTOs
{
    public class OrderDetailDTO
    {
        public int Id { get; set; }
        public int OId { get; set; }
        public int PId { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
    }
}
