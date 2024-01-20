using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;
using System.Linq.Expressions;

namespace DataAccess.Abstract;

public interface IProductDal : IEntityRepository<Product>
{
    List<ProductsWithImagesDto> GetProductsWithImages(Expression<Func<ProductsWithImagesDto, bool>> filter = null);
}