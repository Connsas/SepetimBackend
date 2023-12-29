using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndividualUserAccountController : ControllerBase
    {
        private IIndividualUserAccountService _individualUserAccountService;

        public IndividualUserAccountController(IIndividualUserAccountService individualUserAccountService)
        {
            _individualUserAccountService = individualUserAccountService;
        }

        [HttpPost("add")]
        public ActionResult Add(IndividualUserAccount individualUserAccount)
        {
            var result = _individualUserAccountService.Add(individualUserAccount);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public ActionResult Update(IndividualUserAccount individualUserAccount)
        {
            var result = _individualUserAccountService.Update(individualUserAccount);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public ActionResult Delete(IndividualUserAccount individualUserAccount)
        {
            var result = _individualUserAccountService.Delete(individualUserAccount);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getall")]
        public ActionResult GetAll()
        {
            var result = _individualUserAccountService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }
}
