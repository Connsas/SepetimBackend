using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Favorite: IEntity
    {
        public long FavoriteId { get; set; }
        public long ProductId { get; set; }
        public long UserId { get; set; }
        public DateTime AddDate { get; set; }
    }
}
