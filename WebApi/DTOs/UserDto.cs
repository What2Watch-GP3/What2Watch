﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Email  { get; set; }
        public string Password { get; set; }
    }
}
