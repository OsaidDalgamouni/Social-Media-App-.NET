﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO
{
    public class PhotoDTO
    {
        public decimal Id { get; set; }
        public string? Url { get; set; }
        public bool Ismain { get; set; }
        public string Publicid { get; set; }
    }
}
