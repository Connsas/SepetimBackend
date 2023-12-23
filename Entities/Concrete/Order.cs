using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Order: IEntity
    {
        public long OrderId { get; set; }
        public long UserId { get; set; }
        public long Product { get; set; }
        public decimal ProductCost { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
