using System.Drawing;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract;

public interface IProductImageService
{
    IResult Add(IFormFile formFile, long productId);
    IResult Delete(ProductImage productImage);
    IDataResult<List<ProductImage>> GetAll();
    public IDataResult<List<ImageWithProductIdDto>> GetImagesWithProductId(long productId);
    IDataResult<List<string>> GetByProductId(long productId);
}