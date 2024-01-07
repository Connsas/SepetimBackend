using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract;

public interface ICategoryService
{
    IResult Add(Category category);
    IResult Delete(Category category);
    IResult Update(Category category);
    IDataResult<Category> Get(int categoryName);
    IDataResult<List<Category>> GetAll();
}