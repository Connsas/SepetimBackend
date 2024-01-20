using Core.DataAccess.EntityFramework;
using Core.Entities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Concrete.EntityFramework;

public class EfCartDal : EfEntityRepositoryBase<Cart, SepetimContext>, ICartDal
{
    public List<CartItemDto> GetCartItemsByUserId(long userId)
    {
        using (SepetimContext context = new SepetimContext())
        {
            var result = from c in context.Carts join p in context.Products on c.ProductId equals p.ProductId where c.UserId == userId select new CartItemDto()
            {
                UserId = c.UserId,
                Product = p,
                CartId = c.CartId,
                Quantity = c.Quantity 
            };
            var resultList = result.ToList();
            return resultList;
        }
    }

    public void DeleteAll(long cartId)
    {
        using (SepetimContext context = new SepetimContext())
        {
            var deletedEntity = new Cart(){CartId = cartId};
            context.Carts.Remove(deletedEntity);
            context.SaveChanges();
        }
    }
}


//public void Delete(TEntity entity)
//{
//    using (TContext context = new TContext())
//    {
//        var deletedEntity = context.Entry(entity);
//        deletedEntity.State = EntityState.Deleted;
//        context.SaveChanges();
//    }
//}