using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Features.Authentication.Commands.Login
{
    public class LoginCommanValidator: AbstractValidator<LoginCommand>
    {
        public LoginCommanValidator()
        {
            RuleFor(l => l.Username)
                .NotEmpty()
                .NotNull()
                .EmailAddress();             
        }
    }
}
