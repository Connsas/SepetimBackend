using Core.DataAccess.EntityFramework;
using Core.Entities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Concrete.EntityFramework;

public class EfFavoriteDal : EfEntityRepositoryBase<Favorite, SepetimContext>, IFavoriteDal
{
    public List<FavoriteItemDto> GetByUserId(long userId)
    {
        using (SepetimContext context = new SepetimContext())
        {
            var result = from f in context.Favorites
                join p
                    in context.Products on f.ProductId equals p.ProductId
                where f.UserId == userId
                select new FavoriteItemDto()
                {
                    AddDate = f.AddDate,
                    UserId = f.UserId,
                    Product = p,
                    FavoriteId = f.FavoriteId
                };
            var resultList = result.ToList();
            return resultList;
        }
    }
}