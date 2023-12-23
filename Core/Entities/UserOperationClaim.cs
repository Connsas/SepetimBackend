using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class UserOperationClaim: IEntity
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public short OperationClaimId { get; set; }
    }
}
