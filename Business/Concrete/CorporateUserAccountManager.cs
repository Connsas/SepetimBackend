using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class CorporateUserAccountManager : ICorporateUserAccountService
{
    private ICorporateUserAccountDal _corporateUserAccountDal;
    private IUserAccountService _userAccountService;
    private IUserOperationClaimService _userOperationClaimService;

    private string AddedMessage = Messages.CorporateUserAccountMessages.Added;
    private string RemovedMessage = Messages.CorporateUserAccountMessages.Removed;
    private string UpdatedMessage = Messages.CorporateUserAccountMessages.Updated;

    public CorporateUserAccountManager(ICorporateUserAccountDal corporateUserAccountDal, IUserAccountService userAccountService)
    {
        _corporateUserAccountDal = corporateUserAccountDal;
        _userAccountService = userAccountService;
    }

    [ValidationAspect(typeof(CorporateUserAccountValidator))]
    public IResult Add(CorporateUserAccount corporateUserAccount)
    {
        _corporateUserAccountDal.Add(corporateUserAccount);
        return new SuccessResult(AddedMessage);
    }

    public IResult Delete(CorporateUserAccount corporateUserAccount)
    {
        _corporateUserAccountDal.Delete(corporateUserAccount);
        _userOperationClaimService.Delete(new UserOperationClaim { UserId = corporateUserAccount.UserId });
        _userAccountService.Remove(new UserAccount { UserId = corporateUserAccount.UserId });
        return new SuccessResult(RemovedMessage);
    }

    public IResult Update(CorporateUserAccount corporateUserAccount)
    {
        _corporateUserAccountDal.Update(corporateUserAccount);
        return new SuccessResult(UpdatedMessage);
    }

    public IDataResult<List<CorporateUserAccount>> GetAll()
    {
        return new SuccessDataResult<List<CorporateUserAccount>>(_corporateUserAccountDal.GetAll());
    }

    public IDataResult<CorporateUserAccount> GetById(long id)
    {
        return new SuccessDataResult<CorporateUserAccount>(_corporateUserAccountDal.Get(c => c.TaxNumber == id));
    }

    public IResult CheckIfTaxNumberExists(long taxNumber)
    {
        var result = _corporateUserAccountDal.Get(c => c.TaxNumber == taxNumber);
        if (result == null)
        {
            return new SuccessResult();
        }

        return new ErrorResult();
    }
}