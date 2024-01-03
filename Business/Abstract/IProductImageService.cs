using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract;

public interface IProductImageService
{
    IResult Add(IFormFile formFile,ProductImage productImage, long productId);
    IResult Delete(ProductImage productImage);
    IDataResult<List<ProductImage>> GetAll();
}