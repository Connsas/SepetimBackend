using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class ProductImage: IEntity
    {
        public long ImageId { get; set; }
        public long ProductId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
        public bool Verify { get; set; }
    }
}
