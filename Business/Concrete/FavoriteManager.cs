using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

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
}