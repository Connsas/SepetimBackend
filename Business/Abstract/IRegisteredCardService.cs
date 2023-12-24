using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract;

public interface IRegisteredCardService
{
    IResult Add(RegisteredCard registeredCard);
    IResult Delete(RegisteredCard registeredCard);
    IResult Update(RegisteredCard registeredCard);
    IDataResult<List<RegisteredCard>> GetAll();
}