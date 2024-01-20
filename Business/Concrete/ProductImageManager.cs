using System.Drawing;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
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
    public IResult Add(IFormFile formFile, long productId)
    {
        IResult result = BusinessRules.Run(checkFileIsEmpty(formFile));
        if (result != null)
        {
            return new ErrorResult("Something went wrong.");
        }

        string filePath;
        ProductImage productImage = new ProductImage();
        filePath = _fileHelper.CreateFile(formFile, Path).Data;
        productImage.Date = DateTime.UtcNow;
        productImage.ProductId = productId;
        productImage.ImagePath = filePath;
        productImage.Verify = false;

        _productImageDal.Add(productImage);
        return new SuccessResult(AddedMessage);
    }

    public IResult Delete(ProductImage productImage)
    {
        _fileHelper.DeleteFile(_productImageDal.Get(p => p.ImageId == productImage.ImageId).ImagePath, Path);
        _productImageDal.Delete(productImage);
        return new SuccessResult(RemovedMessage);
    }

    public IDataResult<List<ProductImage>> GetAll()
    {
        return new SuccessDataResult<List<ProductImage>>(_productImageDal.GetAll());
    }

    public IDataResult<List<string>> GetByProductId(long productId)
    {
        List<ProductImage> productImages = _productImageDal.GetAll(p => p.ProductId == productId);
        if (productImages.Count == 0)
        {
            return new SuccessDataResult<List<string>>("Resim Bulunamadı");
        }
        Console.WriteLine(productImages);
        List<string> imageList = new List<string>();
        foreach (var productImage in productImages)
        {
            productImage.ImagePath = Path + productImage.ImagePath;
            imageList.Add(_fileHelper.GetImage(productImage.ImagePath));
        }
        return new SuccessDataResult<List<string>>(imageList);
    }

    public IDataResult<List<ImageWithProductIdDto>> GetImagesWithProductId(long productId)
    {
        List<ProductImage> productImages = _productImageDal.GetAll(p => p.ProductId == productId);
        List<ImageWithProductIdDto> images = new List<ImageWithProductIdDto>();
        if (productImages.Count == 0)
        {
            ImageWithProductIdDto image = new ImageWithProductIdDto()
            {
                ProductId = productId,
                Image = "null"
            };
            images.Add(image);
        }
        else
        {
            foreach (var productImage in productImages)
            {
                ImageWithProductIdDto image = new ImageWithProductIdDto()
                {
                    ProductId = productId,
                    Image = _fileHelper.GetImage(Path + productImage.ImagePath)
                };
                images.Add(image);
            }
        }


        return new SuccessDataResult<List<ImageWithProductIdDto>>(images);
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