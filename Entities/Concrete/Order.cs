using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Order
    {
        public long OrderId { get; set; }
        public long UserId { get; set; }
        public Product[] Products { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
