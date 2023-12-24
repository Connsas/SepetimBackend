using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract;

public interface IFavoriteService
{
    IResult Add(Favorite favorite);
    IResult Delete(Favorite favorite);
    IResult Update(Favorite favorite);
    IDataResult<List<Favorite>> GetAll();
}