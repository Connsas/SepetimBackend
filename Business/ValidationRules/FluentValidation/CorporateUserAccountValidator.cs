using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CorporateUserAccountValidator: AbstractValidator<CorporateUserAccount>
    {
        public CorporateUserAccountValidator()
        {
            RuleFor(c => c.CorporateName).NotEmpty();
            RuleFor(c => c.TaxNumber).NotEmpty();
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Surname).NotEmpty();
            RuleFor(c => c.Email).NotEmpty();
            RuleFor(c => c.PasswordHash).NotEmpty();
            RuleFor(c => c.PasswordSalt).NotEmpty();
            RuleFor(c => c.PhoneNumber).NotEmpty();
        }
    }
}
