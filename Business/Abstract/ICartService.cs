using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Abstract;

public interface ICartService
{
    IResult Add(Cart Cart);
    IResult Delete(Cart Cart);
    public IResult DeleteAll(long userId);
    IResult Update(Cart Cart);
    IDataResult<List<Cart>> GetAll();
    public IDataResult<List<CartItemDto>> GetByUserId(long userId);
}