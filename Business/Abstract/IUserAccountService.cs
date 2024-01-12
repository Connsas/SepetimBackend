using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IUserAccountService
    {
        public IResult Add(UserAccount userAccount);
        public IResult Remove(UserAccount userAccount);
        public IResult Update(UserAccount userAccount);
        public IDataResult<List<UserAccount>> GetAll();
        public IDataResult<UserAccount> GetByMail(string email);
        public IDataResult<List<OperationClaim>> GetClaims(UserAccount userAccount);
    }
}
