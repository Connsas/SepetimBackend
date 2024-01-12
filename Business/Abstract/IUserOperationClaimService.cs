using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IUserOperationClaimService
    {
        public IResult Add(UserOperationClaim userOperationClaim);
        public IResult Delete(UserOperationClaim userOperationClaim);
        public IDataResult<List<UserOperationClaim>> GetAll();
    }
}
