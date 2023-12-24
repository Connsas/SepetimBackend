using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract;

public interface ICartService
{
    IResult Add(Cart Cart);
    IResult Delete(Cart Cart);
    IResult Update(Cart Cart);
    IDataResult<List<Cart>> GetAll();
}