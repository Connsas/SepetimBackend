using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Product: IEntity
    {
        public long ProductId { get; set; }
        public long CategoryId { get; set; }
        public long ImageId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int StockAmount { get; set; }
        public decimal Price { get; set; }

    }
}
