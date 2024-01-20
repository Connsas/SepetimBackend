using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Concrete;

public class FavoriteManager : IFavoriteService
{
    private IFavoriteDal _favoriteDal;
    private string AddedMessage = Messages.FavoriteMessages.Added;
    private string RemoveMessage = Messages.FavoriteMessages.Removed;
    public FavoriteManager(IFavoriteDal favoriteDal)
    {
        _favoriteDal = favoriteDal;
    }

    [ValidationAspect(typeof(FavoriteValidator))]
    public IResult Add(Favorite favorite)
    {
        _favoriteDal.Add(favorite);
        return new SuccessResult(AddedMessage);
    }

    public IResult Delete(Favorite favorite)
    {
        _favoriteDal.Delete(favorite);
        return new SuccessResult(RemoveMessage);
    }

    public IDataResult<List<Favorite>> GetAll()
    {
        return new SuccessDataResult<List<Favorite>>(_favoriteDal.GetAll());
    }

    public IDataResult<List<FavoriteItemDto>> GetByUserId(long userId)
    {
        return new SuccessDataResult<List<FavoriteItemDto>>(_favoriteDal.GetByUserId(userId));
    }

    public IResult CheckIfInFavorite(long userId, long productId)
    {
        var result = _favoriteDal.Get(f => f.UserId == userId && f.ProductId == productId);
        if (result == null)
        {
            return new ErrorResult();
        }
        return new SuccessResult();
    }
}