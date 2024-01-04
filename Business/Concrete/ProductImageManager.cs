using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete;

public class ProductImageManager : IProductImageService
{
    private IProductImageDal _productImageDal;
    private FileHelper _fileHelper;
    private string AddedMessage = Messages.ProductImageMessages.Added;
    private string RemovedMessage = Messages.ProductImageMessages.Removed;
    private string Path = FilePaths.imagePath;
    public ProductImageManager(IProductImageDal productImageDal, FileHelper fileHelper)
    {
        _productImageDal = productImageDal;
        _fileHelper = fileHelper;
    }

    [ValidationAspect(typeof(ProductImageValidator))]
    public IResult Add(IFormFile formFile,ProductImage productImage, long productId)
    {
        IResult result = BusinessRules.Run(checkFileIsEmpty(formFile));
        if (!result.Success)
        {
            return new ErrorResult("Something went wrong.");
        }

        string filePath;
        filePath = _fileHelper.CreateFile(formFile, Path).Data;
        productImage.Date = DateTime.Now;
        productImage.ProductId = productId;
        productImage.ImagePath = filePath;
        productImage.Verify = false;

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

    public IResult checkFileIsEmpty(IFormFile file)
    {
        if (file == null)
        {
            return new ErrorResult("Image can not be empty");
        }

        return new SuccessResult();
    }
}