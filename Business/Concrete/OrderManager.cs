using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class OrderManager : IOrderService
{
    private IOrderDal _orderDal;
    private string AddedMessage = Messages.OrderMessages.Added;
    private string RemovedMessage = Messages.OrderMessages.Removed;
    private string UpdateMessage = Messages.OrderMessages.Updated;
    public OrderManager(IOrderDal orderDal)
    {
        _orderDal = orderDal;
    }

    public IResult Add(Order order)
    {
        _orderDal.Add(order);
        return new SuccessResult(AddedMessage);
    }

    public IResult Delete(Order order)
    {
        _orderDal.Delete(order);
        return new SuccessResult(RemovedMessage);
    }

    public IResult Update(Order order)
    {
        _orderDal.Update(order);
        return new SuccessResult(UpdateMessage);
    }

    public IDataResult<List<Order>> GetAll()
    {
        return new SuccessDataResult<List<Order>>(_orderDal.GetAll());
    }
}