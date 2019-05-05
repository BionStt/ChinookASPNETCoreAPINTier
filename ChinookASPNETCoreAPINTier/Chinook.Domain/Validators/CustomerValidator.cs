using Chinook.Domain.ApiModels;
using FluentValidation;

namespace Chinook.Domain.Validators
{
    public class CustomerValidator : AbstractValidator<CustomerApiModel>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("First Name is mandatory.");
        }
    }
}