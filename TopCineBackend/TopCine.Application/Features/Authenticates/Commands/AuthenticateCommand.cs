using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace TopCine.Application.Features.Authenticates.Commands
{
    public class AuthenticateCommand
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }

    public class AuthenticateCommandValidator : AbstractValidator<AuthenticateCommand>
    {
        public AuthenticateCommandValidator()
        {
            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("Insira um email valido!");

            RuleFor(x => x.Password)
                .NotNull()
                .NotEmpty()
                .WithMessage("A senha não pode ser nula ou vazia!");
        }
    }
}
