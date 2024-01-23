using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class CommentForShowDto
    {
        public long CommentId { get; set; }
        public long UserId { get; set; }
        public string UserFullName { get; set; }

        public long ProductId { get; set; }
        public string CommentText { get; set; }
        public DateTime SendDate { get; set; }
    }
}
