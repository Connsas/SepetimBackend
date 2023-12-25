using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract;

public interface IProductImageService
{
    IResult Add(ProductImage productImage);
    IResult Delete(ProductImage productImage);
    IDataResult<List<ProductImage>> GetAll();
}