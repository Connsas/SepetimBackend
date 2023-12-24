using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract;

public interface ICategoryService
{
    IResult Add(Category category);
    IResult Delete(Category category);
    IResult Update(Category category);
    IDataResult<List<Category>> GetAll();
}