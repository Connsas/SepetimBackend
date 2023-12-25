using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class CorporateUserAccountManager : ICorporateUserAccountService
{
    private ICorporateUserAccountDal _corporateUserAccountDal;
    private string AddedMessage = Messages.CorporateUserAccountMessages.Added;
    private string RemovedMessage = Messages.CorporateUserAccountMessages.Removed;
    private string UpdatedMessage = Messages.CorporateUserAccountMessages.Updated;

    public CorporateUserAccountManager(ICorporateUserAccountDal corporateUserAccountDal)
    {
        _corporateUserAccountDal = corporateUserAccountDal;
    }

    public IResult Add(CorporateUserAccount corporateUserAccount)
    {
        _corporateUserAccountDal.Add(corporateUserAccount);
        return new SuccessResult(AddedMessage);
    }

    public IResult Delete(CorporateUserAccount corporateUserAccount)
    {
        _corporateUserAccountDal.Delete(corporateUserAccount);
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
}