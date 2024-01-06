using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class OrderValidator:AbstractValidator<Entities.Concrete.Order>
    {
        public OrderValidator()
        {
            RuleFor(o => o.ProductId).NotEmpty();
            RuleFor(o => o.OrderDate).NotEmpty();
            RuleFor(o => o.ProductPrice).NotEmpty();
            RuleFor(o => o.UserId).NotEmpty();
        }
    }
}
