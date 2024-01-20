using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Entities.Dtos
{
    public class FavoriteItemDto
    {
        public long FavoriteId { get; set; }
        public long UserId { get; set; }
        public Product Product { get; set; }
        public DateTime AddDate { get; set; }
    }
}
