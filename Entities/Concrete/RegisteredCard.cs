using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class RegisteredCard: IEntity
    {
        public long RegisteredCardId { get; set; }
        public long UserId { get; set; }
        public string PaymentName { get; set; }
        public byte[] CardNumber { get; set; }
        public byte[] ExpDate { get; set; }
        public byte[] CVV { get; set; }
    }
}
