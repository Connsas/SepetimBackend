using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class AddressManager : IAddressService
    {
        private IAddressDal _addressDal;
        private string AddedMessages = Messages.AddressMessages.Added;
        private string UpdatedMessages = Messages.AddressMessages.Updated;
        private string RemovedMessages = Messages.AddressMessages.Removed;

        public AddressManager(IAddressDal addressDal)
        {
            _addressDal = addressDal;
        }

        public IResult Add(Address address)
        {
            _addressDal.Add(address);
            return new SuccessResult(AddedMessages);
        }

        public IResult Delete(Address address)
        {
            _addressDal.Delete(address);
            return new SuccessResult(RemovedMessages);
        }

        public IResult Update(Address address)
        {
            _addressDal.Update(address);
            return new SuccessResult(UpdatedMessages);
        }

        public IDataResult<List<Address>> GetAll()
        {
            return new SuccessDataResult<List<Address>>(_addressDal.GetAll());
        }
    }
}
