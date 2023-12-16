using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class Ticket: IEntity
    {
        public long TicketId { get; set; }
        public long ProductId { get; set; }
        public long UserId { get; set; }
        public string TicketText { get; set; }
        public DateTime TicketDate { get; set; }
        public bool TicketState { get; set; }
    }
}
