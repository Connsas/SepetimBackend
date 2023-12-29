using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class TicketValidator: AbstractValidator<Ticket>
    {
        public TicketValidator()
        {
            RuleFor(t => t.ProductId).NotEmpty();
            RuleFor(t => t.TicketDate).NotEmpty();
            RuleFor(t => t.UserId).NotEmpty();
            RuleFor(t => t.TicketState).NotEmpty();
            RuleFor(t => t.TicketText).NotEmpty();
        }
    }
}
