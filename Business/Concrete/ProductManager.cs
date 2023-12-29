using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class ProductManager : IProductService
{
    private IProductDal _productDal;
    private string AddedMessage = Messages.ProductMessages.Added;
    private string RemovedMessage = Messages.ProductMessages.Removed;
    private string UpdatedMessage = Messages.ProductMessages.Updated;

    public ProductManager(IProductDal productDal)
    {
        _productDal = productDal;
    }

    [ValidationAspect(typeof(ProductValidator))]
    public IResult Add(Product product)
    {
        _productDal.Add(product);
        return new SuccessResult(AddedMessage);
    }

    public IResult Delete(Product product)
    {
        _productDal.Delete(product);
        return new SuccessResult(RemovedMessage);
    }

    public IResult Update(Product product)
    {
        _productDal.Update(product);
        return new SuccessResult(UpdatedMessage);
    }

    public IDataResult<List<Product>> GetAll()
    {
        return new SuccessDataResult<List<Product>>(_productDal.GetAll());
    }
}