﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ProductImage
    {
        public long ImageId { get; set; }
        public long ProductId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
        public bool Verify { get; set; }
    }
}
