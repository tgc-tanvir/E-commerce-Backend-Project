﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Token
    {
        [Key]
        public int Id { get; set; }
        [Required,StringLength(30)]
        public string TKey { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public DateTime? ExpiredAt { get; set; }
        [Required]
        public string CustomerId { get; set; }
    }
}
