using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;


        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("add")]
        public ActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                var newResult = _productService.GetProductForAddImage(product.ProductName, product.SupplierId);
                return Ok(newResult);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public ActionResult Update(Product product)
        {
            var result = _productService.Update(product);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public ActionResult Delete(Product product)
        {
            var result = _productService.Delete(product);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getall")]
        public ActionResult GetAll()
        {
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getallwithimages")]
        public ActionResult GetAllWithImages()
        {
            var result = _productService.GetAllWithImages();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbycategory")]
        public ActionResult GetByCategory(int categoryId)
        {
            var result = _productService.GetByCategory(categoryId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyproductid")]
        public ActionResult GetByProductId(long productId)
        {
            var result = _productService.GetByProductId(productId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
