using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Product
    {
        public long ProductId { get; set; }
        public long CategoryId { get; set; }
        public long ImageId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int StockAmount { get; set; }
        public int Price { get; set; }

    }
}
