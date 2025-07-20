using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace BLL.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public int StatusId { get; set; }
        public decimal Total { get; set; }
        public int CusId { get; set; }
    }
}
