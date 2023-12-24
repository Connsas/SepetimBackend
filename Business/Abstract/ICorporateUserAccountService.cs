using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract;

public interface ICorporateUserAccountService
{
    IResult Add(CorporateUserAccount corporateUserAccount);
    IResult Delete(CorporateUserAccount corporateUserAccount);
    IResult Update(CorporateUserAccount corporateUserAccount);
    IDataResult<List<CorporateUserAccount>> GetAll();
}