using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class IndividualUserAccountManager : IIndividualUserAccountService
{
    private IIndividualUserAccountDal _individualUserAccountDal;
    private IUserAccountService _userAccountService;
    private IUserOperationClaimService _userOperationClaimService;

    private string AddedMessage = Messages.IndividualUserAccountMessages.Added;
    private string RemovedMessage = Messages.IndividualUserAccountMessages.Removed;
    private string UpdatedMessage = Messages.IndividualUserAccountMessages.Updated;
    public IndividualUserAccountManager(IIndividualUserAccountDal individualUserAccountDal, IUserAccountService userAccountService, IUserOperationClaimService userOperationClaimService)
    {
        _individualUserAccountDal = individualUserAccountDal;
        _userAccountService = userAccountService;
        _userOperationClaimService = userOperationClaimService;
    }

    [ValidationAspect(typeof(IndividualAccountUserValidator))]
    public IResult Add(IndividualUserAccount individualUserAccount)
    {
        _individualUserAccountDal.Add(individualUserAccount);
        return new SuccessResult(AddedMessage);
    }

    public IResult Delete(IndividualUserAccount individualUserAccount)
    {
        var userClaimsForRemove = _userOperationClaimService.GetAll();
        foreach (var userClaim in userClaimsForRemove.Data)
        {
            _userOperationClaimService.Delete(userClaim);
        }
        _individualUserAccountDal.Delete(individualUserAccount);
        return new SuccessResult(RemovedMessage);
    }

    public IResult Update(IndividualUserAccount individualUserAccount)
    {
        _individualUserAccountDal.Update(individualUserAccount);
        return new SuccessResult(UpdatedMessage);
    }

    public IDataResult<List<IndividualUserAccount>> GetAll()
    {
        return new SuccessDataResult<List<IndividualUserAccount>>(_individualUserAccountDal.GetAll());
    }

    public IDataResult<IndividualUserAccount> GetById(long id)
    {
        return new SuccessDataResult<IndividualUserAccount>(_individualUserAccountDal.Get(i => i.NationalId == id));
    }

    public IResult CheckIfNationalityNumberExists(long nationalityNumber)
    {
        var result = _individualUserAccountDal.Get(i => i.NationalId == nationalityNumber);
        if (result == null)
        {
            return new SuccessResult();
        }

        return new ErrorResult();
    }
}