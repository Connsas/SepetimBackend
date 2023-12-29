using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class RegisteredCardManager : IRegisteredCardService
{
    private IRegisteredCardDal _registeredCardDal;
    private string AddedMessage = Messages.RegisteredCardMessages.Added;
    private string RemovedMessage = Messages.RegisteredCardMessages.Removed;
    private string UpdatedMessage = Messages.RegisteredCardMessages.Updated;

    public RegisteredCardManager(IRegisteredCardDal registeredCardDal)
    {
        _registeredCardDal = registeredCardDal;
    }

    [ValidationAspect(typeof(RegisteredCardValidator))]
    public IResult Add(RegisteredCard registeredCard)
    {
        _registeredCardDal.Add(registeredCard);
        return new SuccessResult(AddedMessage);
    }

    public IResult Delete(RegisteredCard registeredCard)
    {
        _registeredCardDal.Delete(registeredCard);
        return new SuccessResult(RemovedMessage);
    }

    public IResult Update(RegisteredCard registeredCard)
    {
        _registeredCardDal.Update(registeredCard);
        return new SuccessResult(UpdatedMessage);
    }

    public IDataResult<List<RegisteredCard>> GetAll()
    {
        return new SuccessDataResult<List<RegisteredCard>>(_registeredCardDal.GetAll());
    }
}