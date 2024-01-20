using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Entities.Dtos
{
    public class CartItemDto
    {
        public long CartId { get; set; }
        public long UserId { get; set; }
        public Product Product { get; set; }
        public short Quantity { get; set; }
    }
}
