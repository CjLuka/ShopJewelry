using Domain.Entites;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Product.Commands.AddProduct
{
    public class AddProductCommandValidator : AbstractValidator<AddProductCommand>
    {
        public AddProductCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(p => p.Price)
                .NotEmpty();
        }
    }
}
