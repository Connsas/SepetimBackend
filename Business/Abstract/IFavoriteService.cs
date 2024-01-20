using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Abstract;

public interface IFavoriteService
{
    IResult Add(Favorite favorite);
    IResult Delete(Favorite favorite);
    public IDataResult<List<FavoriteItemDto>> GetByUserId(long userId);
    IDataResult<List<Favorite>> GetAll();
    public IResult CheckIfInFavorite(long userId, long productId);
}