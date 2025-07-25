﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class LoginDTO
    {
        public int Id { get; set; }
        [Required, StringLength(20)]
        public string Username { get; set; }
        [Required, StringLength(20)]
        public string Password { get; set; }
        public string UserType { get; set; }
        public int UserId { get; set; }
    }
}
