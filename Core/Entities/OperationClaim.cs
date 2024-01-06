using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class OperationClaim: IEntity
    {
        public short OperationClaimId { get; set; }
        public string OpertaionClaimName { get; set; }
    }
}
