using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class ProductImageManager : IProductImageService
{
    private IProductImageDal _productImageDal;
    private string AddedMessage = Messages.ProductImageMessages.Added;
    private string RemovedMessage = Messages.ProductImageMessages.Removed;
    public ProductImageManager(IProductImageDal productImageDal)
    {
        _productImageDal = productImageDal;
    }

    public IResult Add(ProductImage productImage)
    {
        _productImageDal.Add(productImage);
        return new SuccessResult(AddedMessage);
    }

    public IResult Delete(ProductImage productImage)
    {
        _productImageDal.Delete(productImage);
        return new SuccessResult(RemovedMessage);
    }

    public IDataResult<List<ProductImage>> GetAll()
    {
        return new SuccessDataResult<List<ProductImage>>(_productImageDal.GetAll());
    }
}