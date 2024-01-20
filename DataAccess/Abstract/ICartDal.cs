using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Abstract;

public interface ICartDal : IEntityRepository<Cart>
{
    public List<CartItemDto> GetCartItemsByUserId(long  userId);
    public void DeleteAll(long cartId);
}