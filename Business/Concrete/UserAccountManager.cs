using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Entities;
using Core.Utilities.Results;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class UserAccountManager : IUserAccountService
    {
        private IUserAccountDal _userAccountDal;

        public UserAccountManager(IUserAccountDal userAccountDal)
        {
            _userAccountDal = userAccountDal;
        }

        public IDataResult<UserAccount> GetByMail(string email)
        {
            return new SuccessDataResult<UserAccount>(_userAccountDal.Get(c => c.Email == email));
        }

        public IDataResult<List<OperationClaim>> GetClaims(UserAccount userAccount)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userAccountDal.GetClaims(userAccount));
        }
    }
}
