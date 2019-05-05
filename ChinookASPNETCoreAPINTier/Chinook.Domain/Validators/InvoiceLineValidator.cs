using Chinook.Domain.ApiModels;
using FluentValidation;

namespace Chinook.Domain.Validators
{
    public class InvoiceLineValidator : AbstractValidator<InvoiceLineApiModel>
    {
        public InvoiceLineValidator()
        {
            RuleFor(x => x.Quantity)
                .NotNull()
                .WithMessage("Quantity is mandatory.");
        }
    }
}