using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Entities.Dtos
{
    public class ProductImageAdd
    {
        public long productId { get; set; }
        public IFormFile productImage { get; set; }
    }
}
