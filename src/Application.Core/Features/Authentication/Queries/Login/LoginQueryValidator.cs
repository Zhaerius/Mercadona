using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Features.Authentication.Queries.Login
{
    public class LoginQueryValidator: AbstractValidator<LoginQuery>
    {
        public LoginQueryValidator()
        {
            RuleFor(l => l.Username)
                .NotEmpty()
                .NotNull()
                .EmailAddress();             
        }
    }
}
