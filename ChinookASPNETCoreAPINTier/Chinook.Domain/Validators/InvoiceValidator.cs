using Chinook.Domain.ApiModels;
using FluentValidation;

namespace Chinook.Domain.Validators
{
    public class InvoiceValidator : AbstractValidator<InvoiceApiModel>
    {
        public InvoiceValidator()
        {
            RuleFor(x => x.InvoiceDate)
                .NotNull()
                .WithMessage("Invoice Date is mandatory.");
        }
    }
}