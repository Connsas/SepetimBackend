using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Entities;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.Dtos;
using TCKimlikDogrulama;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserAccountService _userAccountService;
        private IIndividualUserAccountService _individualUserAccountService;
        private ICorporateUserAccountService _corporateUserAccountService;
        private IUserOperationClaimService _userOperationClaimService;
        private ITokenHelper _tokenHelper;
        
        private string UserNotFound = Messages.AuthMessages.UserNotFound;
        private string IncorrectInformation = Messages.AuthMessages.IncorrectInformation;
        private string LoginSuccess = Messages.AuthMessages.LoginSuccess;
        private string UserAlreadyExist = Messages.AuthMessages.UserAlreadyExist;
        private string UserRegisterSuccess = Messages.AuthMessages.UserRegisterSuccess;
        private string AccessTokenCreated = Messages.AuthMessages.AccessTokenCreated;

        public AuthManager(IUserAccountService userAccountService, IIndividualUserAccountService individualUserAccountService, ICorporateUserAccountService corporateUserAccountService, ITokenHelper tokenHelper, IUserOperationClaimService userOperationClaimService)
        {
            _userAccountService = userAccountService;
            _individualUserAccountService = individualUserAccountService;
            _corporateUserAccountService = corporateUserAccountService;
            _tokenHelper = tokenHelper;
            _userOperationClaimService = userOperationClaimService;
        }

        public IDataResult<UserAccount> Login(UserForLoginDto userForLoginDto)
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

        public IDataResult<IndividualUserAccount> RegisterIndividual(IndividualUserForRegisterDto individualUserForRegisterDto)
        {
            var result = BusinessRules.Run(UserExists(individualUserForRegisterDto.Email), _individualUserAccountService.CheckIfNationalityNumberExists(individualUserForRegisterDto.NationalityId));
            if (result != null)
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
            var userForClaimAdd = _individualUserAccountService.GetById(individualUserForRegisterDto.NationalityId);
            var userOperationClaim = new UserOperationClaim
            {
                OperationClaimId = 1,
                UserId = userForClaimAdd.Data.UserId
            };
            _userOperationClaimService.Add(userOperationClaim);
            return new SuccessDataResult<IndividualUserAccount>(individualUser, UserRegisterSuccess);
        }

        public IDataResult<CorporateUserAccount> RegisterCorporate(CorporateUserForRegisterDto corporateUserForRegister)
        {
            var result = BusinessRules.Run(UserExists(corporateUserForRegister.Email), _corporateUserAccountService.CheckIfTaxNumberExists(corporateUserForRegister.TaxNumber));
            if (result != null)
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
            var userForClaimAdd = _corporateUserAccountService.GetById(corporateUserForRegister.TaxNumber);
            var userOperationClaim = new UserOperationClaim
            {
                OperationClaimId = 2,
                UserId = userForClaimAdd.Data.UserId
            };
            _userOperationClaimService.Add(userOperationClaim);
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

        public IDataResult<UserAccount> UserExists(string email)
        {
            var userExists = _userAccountService.GetByMail(email);
            if (userExists.Success)
            {
                return new ErrorDataResult<UserAccount>(userExists.Message);
            }

            return new SuccessDataResult<UserAccount>(userExists.Message);
        }

    }
}
