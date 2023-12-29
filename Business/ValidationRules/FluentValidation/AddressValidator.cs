using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class AddressValidator: AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(a => a.Apartment).NotEmpty();
            RuleFor(a => a.City).NotEmpty();
            RuleFor(a => a.District).NotEmpty();
            RuleFor(a => a.Neighboorhood).NotEmpty();
            RuleFor(a => a.Street).NotEmpty();
            RuleFor(a => a.UserId).NotEmpty();
        }
    }
}
