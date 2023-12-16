using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Category
    {
        public long CategoryId { get; set; }
        public long ProductId { get; set; }
        public long CategoryName { get; set; }
    }
}
