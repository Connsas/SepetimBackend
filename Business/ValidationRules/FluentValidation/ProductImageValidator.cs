using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductImageValidator: AbstractValidator<Entities.Concrete.ProductImage>
    {
        public ProductImageValidator()
        {
            RuleFor(p => p.ProductId).NotEmpty();
            RuleFor(p => p.Date).NotEmpty();
            RuleFor(p => p.ImagePath).NotEmpty();
            RuleFor(p => p.Verify).NotEmpty();
        }
    }
}
