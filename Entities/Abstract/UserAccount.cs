using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Abstract;

namespace Entities.Abstract
{
    public abstract class UserAccount : IEntity
    {
        public long UserId { get; set; }
        public long CartId { get; set; }
        public long OrderId { get; set; }
        public long FavoriteId { get; set; }
        public long TicketId { get; set; }
        public long AddressId { get; set; }
        public long RegisteredCardId { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
    }
}
