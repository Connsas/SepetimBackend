using Core.DataAccess;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;

namespace DataAccess.Abstract
{
    public interface IUserAccountDal : IEntityRepository<UserAccount>
    {
        public List<OperationClaim> GetClaims(UserAccount userAccount);
    }
}
