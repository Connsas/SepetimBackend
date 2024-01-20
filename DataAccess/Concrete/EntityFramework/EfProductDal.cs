using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Dtos;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal: EfEntityRepositoryBase<Product,SepetimContext>, IProductDal
    {
        public List<ProductsWithImagesDto> GetProductsWithImages(Expression<Func<ProductsWithImagesDto, bool>> filter = null)
        {
            using (SepetimContext context = new SepetimContext())
            {
                var result = from product in context.Products
                    join productImage in context.ProductImages on product.ProductId equals productImage.ProductId
                    select new ProductsWithImagesDto()
                    {
                        CategoryId = product.CategoryId,
                        Description = product.Description,
                        Image = productImage.ImagePath,
                        Price = product.Price,
                        ProductId = product.ProductId,
                        ProductName = product.ProductName,
                        StockAmount = product.StockAmount,
                        SupplierId = product.SupplierId
                    };
                var resultList = result.ToList();
                return resultList;
            }
        }
    }
}
