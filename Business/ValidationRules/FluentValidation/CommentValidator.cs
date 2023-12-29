using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Entities.Concrete;

namespace Business.ValidationRules.FluentValidation
{
    public class CommentValidator: AbstractValidator<Entities.Concrete.Comment>
    {
        public CommentValidator()
        {
            RuleFor(c => c.CommentText).NotEmpty();
            RuleFor(c => c.ProductId).NotEmpty();
            RuleFor(c => c.UserId).NotEmpty();
            RuleFor(c => c.SendDate).NotEmpty();
        }
    }
}
