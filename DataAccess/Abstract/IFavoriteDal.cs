using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Abstract;

public interface IFavoriteDal : IEntityRepository<Favorite>
{
    public List<FavoriteItemDto> GetByUserId(long userId);
}