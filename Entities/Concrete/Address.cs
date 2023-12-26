using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class Address : IEntity
    {
        public long AdressId { get; set; }
        public long UserId { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Neighboorhood { get; set; }
        public string Street { get; set; }
        public string Apartment { get; set; }
    }
}
