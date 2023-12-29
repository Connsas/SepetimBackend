using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorporateUserAccountController : ControllerBase
    {
        private ICorporateUserAccountService _corporateUserAccountService;

        public CorporateUserAccountController(ICorporateUserAccountService corporateUserAccountService)
        {
            _corporateUserAccountService = corporateUserAccountService;
        }

        [HttpPost("add")]
        public ActionResult Add(CorporateUserAccount corporateUserAccount)
        {
            var result = _corporateUserAccountService.Add(corporateUserAccount);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public ActionResult Update(CorporateUserAccount corporateUserAccount)
        {
            var result = _corporateUserAccountService.Update(corporateUserAccount);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public ActionResult Delete(CorporateUserAccount corporateUserAccount)
        {
            var result = _corporateUserAccountService.Delete(corporateUserAccount);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getall")]
        public ActionResult GetAll()
        {
            var result = _corporateUserAccountService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }
}
