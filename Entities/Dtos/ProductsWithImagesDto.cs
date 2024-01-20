using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class ProductsWithImagesDto
    {
        public long ProductId { get; set; }
        public long CategoryId { get; set; }
        public long SupplierId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int StockAmount { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
    }
}
