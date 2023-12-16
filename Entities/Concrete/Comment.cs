using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Comment
    {
        public long CommentId { get; set; }
        public long UserId { get; set; }
        public long ProductId { get; set; }
        public DateTime SendDate { get; set; }
        public string CommentText { get; set; }
    }
}
