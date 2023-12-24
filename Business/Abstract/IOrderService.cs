using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract;

public interface IOrderService
{
    IResult Add(Order order);
    IResult Delete(Order order);
    IResult Update(Order order);
    IDataResult<List<Order>> GetAll();
}