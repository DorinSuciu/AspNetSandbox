﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetSandbox.DTOs
{
    public class CreateBookDto
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string Language { get; set; }
    }
}
