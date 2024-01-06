using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
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
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("registerindividual")]
        public ActionResult RegisterIndividual(IndividualUserForRegisterDto individualUserForRegisterDto)
        {
            var userExist = _authService.UserExists(individualUserForRegisterDto.Email);
            if (userExist.Success)
            {
                return BadRequest(userExist.Message);
            }

            var registerResult = _authService.RegisterIndividual(individualUserForRegisterDto);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("registercorporate")]
        public ActionResult RegisterCorporate(CorporateUserForRegisterDto corporateUserForRegisterDto)
        {
            var userExist = _authService.UserExists(corporateUserForRegisterDto.Email);
            if (userExist.Success)
            {
                return BadRequest(userExist.Message);
            }

            var registerResult = _authService.RegisterCorporate(corporateUserForRegisterDto);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }
}
