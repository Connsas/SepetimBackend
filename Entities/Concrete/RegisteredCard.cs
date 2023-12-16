using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class RegisteredCard: IEntity
    {
        public long RegisteredCardId { get; set; }
        public long UserId { get; set; }
        public string PaymentName { get; set; }
        public long CardNumber { get; set; }
        public string ExpDate { get; set; }
        public short CVV { get; set; }
    }
}
