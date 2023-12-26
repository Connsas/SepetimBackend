using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class Category: IEntity
    {
        public long CategoryId { get; set; }
        public long CategoryName { get; set; }
    }
}
