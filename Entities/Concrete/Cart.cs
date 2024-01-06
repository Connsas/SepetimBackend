using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Cart: IEntity
    {
       public long CartId { get; set; }
        public long UserId { get; set; }
        public long ProductId { get; set; }
    }
}
