using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class FavoriteValidator: AbstractValidator<Entities.Concrete.Favorite>
    {
        public FavoriteValidator()
        {
            RuleFor(f => f.UserId);
            RuleFor(f => f.AddDate);
            RuleFor(f => f.ProductId);
        }
    }
}
