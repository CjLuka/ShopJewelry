using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Auth.Commands.SignUp
{
    public class SignUpValidator : AbstractValidator<SignUpCommand>
    {
        public SignUpValidator()
        {
            RuleFor(u => u.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(u => u.Password)
                .NotEmpty();

            RuleFor(u => u.PhoneNumber)
                .NotEmpty();

            RuleFor(u => u.Username)
                .NotEmpty();

            RuleFor(u => u.ConfirmPassowrd)
                .NotEmpty()
                .Equal(u => u.Password);
                
        }
    }
}
