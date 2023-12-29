using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class CategoryManager : ICategoryService
{
    private ICategoryDal _categoryDal;
    private string AddedMessage = Messages.CategoryMessages.Added;
    private string RemovedMessage = Messages.CategoryMessages.Removed;
    private string UpdatedMessage = Messages.CategoryMessages.Updated;
    public CategoryManager(ICategoryDal categoryDal)
    {
        _categoryDal = categoryDal;
    }

    [ValidationAspect(typeof(CategoryValidator))]
    public IResult Add(Category category)
    {
        _categoryDal.Add(category);
        return new SuccessResult(AddedMessage);
    }

    public IResult Delete(Category category)
    {
        _categoryDal.Delete(category);
        return new SuccessResult(RemovedMessage);
    }

    public IResult Update(Category category)
    {
        _categoryDal.Update(category);
        return new SuccessResult(UpdatedMessage);
    }

    public IDataResult<List<Category>> GetAll()
    {
        return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
    }
}