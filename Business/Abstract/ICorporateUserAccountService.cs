using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract;

public interface ICorporateUserAccountService
{
    IResult Add(CorporateUserAccount corporateUserAccount);
    IResult Delete(CorporateUserAccount corporateUserAccount);
    IResult Update(CorporateUserAccount corporateUserAccount);
    IDataResult<List<CorporateUserAccount>> GetAll();
    IDataResult<CorporateUserAccount> GetById(long id);
    IResult CheckIfTaxNumberExists(long taxNumber);
}