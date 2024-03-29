﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CartValidator: AbstractValidator<Cart>
    {
        public CartValidator()
        {
            RuleFor(c => c.ProductId).NotEmpty();
            RuleFor(c => c.UserId).NotEmpty();
        }
    }
}
