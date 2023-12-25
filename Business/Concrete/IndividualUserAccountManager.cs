using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class IndividualUserAccountManager : IIndividualUserAccountService
{
    private IIndividualUserAccountDal _individualUserAccountDal;
    private string AddedMessage = Messages.IndividualUserAccountMessages.Added;
    private string RemovedMessage = Messages.IndividualUserAccountMessages.Removed;
    private string UpdatedMessage = Messages.IndividualUserAccountMessages.Updated;
    public IndividualUserAccountManager(IIndividualUserAccountDal individualUserAccountDal)
    {
        _individualUserAccountDal = individualUserAccountDal;
    }

    public IResult Add(IndividualUserAccount individualUserAccount)
    {
        _individualUserAccountDal.Add(individualUserAccount);
        return new SuccessResult(AddedMessage);
    }

    public IResult Delete(IndividualUserAccount individualUserAccount)
    {
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
}