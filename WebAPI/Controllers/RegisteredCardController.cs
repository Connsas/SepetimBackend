using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisteredCardController : ControllerBase
    {
        IRegisteredCardService _registeredCardService;

        public RegisteredCardController(IRegisteredCardService registeredCardService)
        {
            _registeredCardService = registeredCardService;
        }

        [HttpPost("add")]
        public ActionResult Add(RegisteredCard registeredCard)
        {
            var result = _registeredCardService.Add(registeredCard);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public ActionResult Update(RegisteredCard registeredCard)
        {
            var result = _registeredCardService.Update(registeredCard);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public ActionResult Delete(RegisteredCard registeredCard)
        {
            var result = _registeredCardService.Delete(registeredCard);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getall")]
        public ActionResult GetAll()
        {
            var result = _registeredCardService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }
    }
}
