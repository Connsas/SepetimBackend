using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class Address : IEntity
    {
        [Key]
        public long AddressId { get; set; }
        public long UserId { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Neighboorhood { get; set; }
        public string Street { get; set; }
        public string Apartment { get; set; }
    }
}
