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

        public IResult Add(UserAccount userAccount)
        {
            _userAccountDal.Add(userAccount);
            return new SuccessResult();
        }

        public IResult Remove(UserAccount userAccount)
        {
            _userAccountDal.Delete(userAccount);
            return new SuccessResult();
        }

        public IResult Update(UserAccount userAccount)
        {
            _userAccountDal.Update(userAccount);
            return new SuccessResult();
        }

        public IDataResult<List<UserAccount>> GetAll()
        {
            return new SuccessDataResult<List<UserAccount>>(_userAccountDal.GetAll());
        }


        public IDataResult<UserAccount> GetByMail(string email)
        {
            var user = _userAccountDal.Get(c => c.Email == email);
            if (user != null)
            {
                return new SuccessDataResult<UserAccount>(user);
            }
            return new ErrorDataResult<UserAccount>();
        }

        public IDataResult<List<OperationClaim>> GetClaims(UserAccount userAccount)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userAccountDal.GetClaims(userAccount));
        }
    }
}
