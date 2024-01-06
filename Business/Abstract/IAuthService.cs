using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Abstract
{
    public interface IAuthService
    {
        public IDataResult<UserAccount> Login(UserForLoginDto userForLoginDto);
        public IDataResult<IndividualUserAccount> RegisterIndividual(IndividualUserForRegisterDto individualUserForRegisterDto);
        public IDataResult<CorporateUserAccount> RegisterCorporate(CorporateUserForRegisterDto corporateUserForRegister);
        public IResult VerifyTCNO(TCNOVerifyDto tcnoVerifyDto);
        public IDataResult<AccessToken> CreateAccessToken(UserAccount userAccount);
        public IDataResult<UserAccount> UserExists(string email);
    }
}
