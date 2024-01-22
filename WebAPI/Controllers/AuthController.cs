using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Business.Abstract;
using Core.Entities;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;
        private IUserAccountService _userAccountService;

        public AuthController(IAuthService authService, IUserAccountService userAccountService)
        {
            _authService = authService;
            _userAccountService = userAccountService;
        }

        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                var token = new JwtSecurityTokenHandler().ReadJwtToken(result.Data.Token);
                var identity = (ClaimsIdentity)User.Identity;
                identity.AddClaims(token.Claims);
                UserAccount user = _userAccountService.GetByMail(userForLoginDto.Email).Data;
                var userId = user.UserId;
                var userName = user.Name;
                var userSurname = user.Surname;
                LoginRegisterResult<AccessToken> loginRegisterResult = new LoginRegisterResult<AccessToken>(result, userId, userName, userSurname);
                return Ok(loginRegisterResult);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("registerindividual")]
        public ActionResult RegisterIndividual(IndividualUserForRegisterDto individualUserForRegisterDto)
        {
            var userExist = _authService.UserExists(individualUserForRegisterDto.Email);
            if (!userExist.Success)
            {
                return BadRequest(userExist.Message);
            }

            var registerResult = _authService.RegisterIndividual(individualUserForRegisterDto);
            var result = _authService.CreateAccessToken(registerResult.Data);
            var user = _userAccountService.GetByMail(individualUserForRegisterDto.Email).Data;
            var userId = user.UserId;
            var userName = user.Name;
            var userSurname = user.Surname;
            LoginRegisterResult<AccessToken> loginRegisterResult = new LoginRegisterResult<AccessToken>(result, userId, userName, userSurname);
            if (result.Success)
            {
                return Ok(loginRegisterResult);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("registercorporate")]
        public ActionResult RegisterCorporate(CorporateUserForRegisterDto corporateUserForRegisterDto)
        {
            var userExist = _authService.UserExists(corporateUserForRegisterDto.Email);
            if (!userExist.Success)
            {
                return BadRequest(userExist.Message);
            }

            var registerResult = _authService.RegisterCorporate(corporateUserForRegisterDto);
            var result = _authService.CreateAccessToken(registerResult.Data);
            var user = _userAccountService.GetByMail(corporateUserForRegisterDto.Email).Data;
            var userId = user.UserId;
            var userName = user.Name;
            var userSurname = user.Surname;
            LoginRegisterResult<AccessToken> loginRegisterResult = new LoginRegisterResult<AccessToken>(result, userId, userName, userSurname);
            if (result.Success)
            {
                return Ok(loginRegisterResult);
            }
            return BadRequest(result.Message);
        }
    }
}
