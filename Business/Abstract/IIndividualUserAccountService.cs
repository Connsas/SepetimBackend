﻿using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract;

public interface IIndividualUserAccountService
{
    IResult Add(IndividualUserAccount individualUserAccount);
    IResult Delete(IndividualUserAccount individualUserAccount);
    IResult Update(IndividualUserAccount individualUserAccount);
    IDataResult<List<IndividualUserAccount>> GetAll();
    IDataResult<IndividualUserAccount> GetById(long id);
    public IResult GetByUserId(long id);
    IResult CheckIfNationalityNumberExists (long nationalityNumber);
}