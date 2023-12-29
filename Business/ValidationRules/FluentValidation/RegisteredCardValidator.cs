using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class RegisteredCardValidator: AbstractValidator<RegisteredCard>
    {
        public RegisteredCardValidator()
        {
            RuleFor(r => r.UserId).NotEmpty();
            RuleFor(r => r.CVV).NotEmpty();
            RuleFor(r => r.CardNumber).NotEmpty();
            RuleFor(r => r.ExpDate).NotEmpty();
            RuleFor(r => r.PaymentName).NotEmpty();
        }
    }
}
