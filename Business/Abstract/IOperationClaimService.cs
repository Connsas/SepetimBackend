using Core.Entities;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOperationClaimService
    {
        public IResult Add(OperationClaim operationClaim);
        public IResult Delete(OperationClaim operationClaim);
        public IDataResult<List<OperationClaim>> GetAll();
    }
}
