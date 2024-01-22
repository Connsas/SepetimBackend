using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Concrete;

public class ProductManager : IProductService
{
    private IProductDal _productDal;
    private IFavoriteService _favoriteService;
    private FileHelper _fileHelper;

    private string AddedMessage = Messages.ProductMessages.Added;
    private string RemovedMessage = Messages.ProductMessages.Removed;
    private string UpdatedMessage = Messages.ProductMessages.Updated;
    private string imagePath = FilePaths.imagePath;

    public ProductManager(IProductDal productDal, FileHelper fileHelper)
    {
        _productDal = productDal;
        _fileHelper = fileHelper;
    }

    [ValidationAspect(typeof(ProductValidator))]
    //[CacheRemoveAspect("Get")]
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
    //[CacheAspect]
    public IDataResult<List<Product>> GetAll()
    {
        return new SuccessDataResult<List<Product>>(_productDal.GetAll());
    }

    public IDataResult<List<ProductsWithImagesDto>> GetAllWithImages()
    {
        var resultList = _productDal.GetProductsWithImages();
        foreach (var result in resultList)
        {
            result.Image = _fileHelper.GetImage(imagePath + result.Image);
        }
        return new SuccessDataResult<List<ProductsWithImagesDto>>(resultList);
    }

    public IDataResult<List<Product>> GetByCategory(int categoryId)
    {
        return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == categoryId));
    }

    public IDataResult<Product> GetByProductId(long productId)
    {
        return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
    }

    public long GetProductForAddImage(string productName, long supplierId)
    {
        var result = _productDal.Get(p => p.SupplierId == supplierId && p.ProductName == productName);
        return result.ProductId;
    }
}