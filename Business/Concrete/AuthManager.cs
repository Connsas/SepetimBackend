using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Entities;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.Dtos;
using TCKimlikDogrulama;

namespace Business.Concrete
{
    public class AuthManager : AuthService
    {
        private IUserAccountService _userAccountService;
        private IIndividualUserAccountService _individualUserAccountService;
        private ICorporateUserAccountService _corporateUserAccountService;
        private ITokenHelper _tokenHelper;
        
        private string UserNotFound = Messages.AuthMessages.UserNotFound;
        private string IncorrectInformation = Messages.AuthMessages.IncorrectInformation;
        private string LoginSuccess = Messages.AuthMessages.LoginSuccess;
        private string UserAlreadyExist = Messages.AuthMessages.UserAlreadyExist;
        private string UserRegisterSuccess = Messages.AuthMessages.UserRegisterSuccess;
        private string AccessTokenCreated = Messages.AuthMessages.AccessTokenCreated;

        public AuthManager(IUserAccountService userAccountService, IIndividualUserAccountService individualUserAccountService, ICorporateUserAccountService corporateUserAccountService, ITokenHelper tokenHelper)
        {
            _userAccountService = userAccountService;
            _individualUserAccountService = individualUserAccountService;
            _corporateUserAccountService = corporateUserAccountService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<UserAccount> login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userAccountService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<UserAccount>(UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Data.PasswordHash,
                    userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<UserAccount>(IncorrectInformation);
            }

            return new SuccessDataResult<UserAccount>(userToCheck.Data, LoginSuccess);
        }

        public IDataResult<IndividualUserAccount> registerIndividual(IndividualUserForRegisterDto individualUserForRegisterDto)
        {
            var userExist = _userAccountService.GetByMail(individualUserForRegisterDto.Email);
            if (userExist.Success)
            {
                return new ErrorDataResult<IndividualUserAccount>(UserAlreadyExist);
            }
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(individualUserForRegisterDto.Password, out passwordHash, out passwordSalt);
            var individualUser = new IndividualUserAccount
            {
                Email = individualUserForRegisterDto.Email,
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash,
                Name = individualUserForRegisterDto.Name,
                Surname = individualUserForRegisterDto.Surname,
                PhoneNumber = individualUserForRegisterDto.PhoneNumber,
                NationalId = individualUserForRegisterDto.NationalityId,
                IsVerified = false
            };
            _individualUserAccountService.Add(individualUser);
            return new SuccessDataResult<IndividualUserAccount>(individualUser, UserRegisterSuccess);
        }

        public IDataResult<CorporateUserAccount> registerCorporate(CorporateUserForRegisterDto corporateUserForRegister)
        {
            var userExist = _userAccountService.GetByMail(corporateUserForRegister.Email);
            if (userExist.Success)
            {
                return new ErrorDataResult<CorporateUserAccount>(UserAlreadyExist);
            }
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(corporateUserForRegister.Password, out passwordHash, out passwordSalt);
            var corporateUser = new CorporateUserAccount()
            {
                Email = corporateUserForRegister.Email,
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash,
                PhoneNumber = corporateUserForRegister.PhoneNumber,
                Name = corporateUserForRegister.Name,
                Surname = corporateUserForRegister.Surname,
                CorporateName = corporateUserForRegister.CorporateName,
                TaxNumber = corporateUserForRegister.TaxNumber,
                IsVerified = false
            };
            _corporateUserAccountService.Add(corporateUser);
            return new SuccessDataResult<CorporateUserAccount>(corporateUser, UserRegisterSuccess);
        }

        public IResult VerifyTCNO(TCNOVerifyDto tcnoVerifyDto)
        {
            throw new NotImplementedException();
        }

        public IDataResult<AccessToken> CreateAccessToken(UserAccount userAccount)
        {
            var claims = _userAccountService.GetClaims(userAccount);
            var accessToken = _tokenHelper.CreateToken(userAccount, claims.Data);
            return new SuccessDataResult<AccessToken>(accessToken, AccessTokenCreated);
        }
    }
}
