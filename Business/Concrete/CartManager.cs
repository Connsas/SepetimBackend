using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Concrete;

public class CartManager : ICartService
{
    private ICartDal _cartDal;
    private string AddedMessage = Messages.CartMessages.Added;
    private string RemovedMessage = Messages.CartMessages.Removed;
    private string UpdatedMessage = Messages.CartMessages.Updated;

    public CartManager(ICartDal cartDal)
    {
        _cartDal = cartDal;
    }

    [ValidationAspect(typeof(CartValidator))]
    public IResult Add(Cart cart)
    {
        _cartDal.Add(cart);
        return new SuccessResult(AddedMessage);
    }

    public IResult Delete(Cart cart)
    {
        _cartDal.Delete(cart);
        return new SuccessResult(RemovedMessage);
    }

    public IResult DeleteAll(long userId)
    {
        var itemsToDelete = GetByUserId(userId);

        foreach (var item in itemsToDelete.Data)
        {
            _cartDal.DeleteAll(item.CartId);
        }
        
        return new SuccessResult(RemovedMessage);
    }

    public IResult Update(Cart cart)
    {
        _cartDal.Update(cart);
        return new SuccessResult(UpdatedMessage);
    }

    public IDataResult<List<Cart>> GetAll()
    {
        return new SuccessDataResult<List<Cart>>(_cartDal.GetAll());
    }

    public IDataResult<List<CartItemDto>> GetByUserId(long userId)
    {
        return new SuccessDataResult<List<CartItemDto>>(_cartDal.GetCartItemsByUserId(userId));
    }
}