using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class IndividualAccountUserValidator: AbstractValidator<IndividualUserAccount>
    {
        public IndividualAccountUserValidator()
        {
            RuleFor(i => i.NationalId).NotNull();
            RuleFor(i => i.Name).NotNull();
            RuleFor(i => i.Email).NotNull();
            RuleFor(i => i.PasswordHash).NotNull();
            RuleFor(i => i.PasswordSalt).NotNull();
            RuleFor(i => i.Surname).NotNull();
            RuleFor(i => i.PhoneNumber).NotNull();
        }
    }
}
