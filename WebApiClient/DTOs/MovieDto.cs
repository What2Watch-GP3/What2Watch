﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiClient.DTOs
{
    public class MovieDto
    {

        public int Id { get; set; }
        public string Title { get; set; }

        public int Duration { get; set; }
    }
}
