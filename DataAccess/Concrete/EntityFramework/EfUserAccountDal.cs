using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Core.Entities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Dtos;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserAccountDal: EfEntityRepositoryBase<UserAccount, SepetimContext>, IUserAccountDal
    {
        public List<OperationClaim> GetClaims(UserAccount userAccount)
        {
            using (var context = new SepetimContext())
            {
                var result = from operationClaim in context.OperationClaims
                    join userOperationClaims in context.UserOperationClaims
                        on operationClaim.OperationClaimId equals userOperationClaims.OperationClaimId
                    where userOperationClaims.UserId == userAccount.UserId
                    select new OperationClaim
                    {
                        OperationClaimId = operationClaim.OperationClaimId,
                        OpertaionClaimName = operationClaim.OpertaionClaimName
                    };
                var resultList = result.ToList();
                return resultList;
            }
        }
    }
}
