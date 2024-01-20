using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Abstract;

public interface IProductService
{
    IResult Add(Product product);
    IResult Delete(Product product);
    IResult Update(Product product);
    IDataResult<List<Product>> GetAll();
    IDataResult<List<ProductsWithImagesDto>> GetAllWithImages();
    IDataResult<List<ProductsWithImagesDto>> GetByCategory(int id);
    IDataResult<Product> GetByProductId(long productId);
    long GetProductForAddImage(string productName, long supplierId);
}