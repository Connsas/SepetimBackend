using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private IProductImageService _productImageService;

        public ProductImageController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }


        [HttpPost("add")]
        public ActionResult Add()
        {
            Console.WriteLine(Request.Form);
            long productId;
            IFormFile productImage = Request.Form.Files[0];
            Request.Form.TryGetValue("productId", out var value);
            productId = Convert.ToInt64(value);
            var result = _productImageService.Add(productImage, productId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public ActionResult Delete(long imageId)
        {
            var productImage = new ProductImage()
            {
             ImageId   = imageId
            };
            var result = _productImageService.Delete(productImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyproductid")]
        public ActionResult GetByProductId(long productId)
        {
            var result = _productImageService.GetByProductId(productId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyproductidwithproductid")]
        public ActionResult GetImagesWithProductId(long productId)
        {
            var result = _productImageService.GetImagesWithProductId(productId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public ActionResult GetAll()
        {
            var result = _productImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
