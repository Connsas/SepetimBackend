using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Abstract
{
    public interface AuthService
    {
        public IDataResult<UserAccount> login(UserForLoginDto userForLoginDto);
        public IDataResult<IndividualUserAccount> registerIndividual(IndividualUserForRegisterDto individualUserForRegisterDto);
        public IDataResult<CorporateUserAccount> registerCorporate(CorporateUserForRegisterDto corporateUserForRegister);
        public IResult VerifyTCNO(TCNOVerifyDto tcnoVerifyDto);
    }
}
