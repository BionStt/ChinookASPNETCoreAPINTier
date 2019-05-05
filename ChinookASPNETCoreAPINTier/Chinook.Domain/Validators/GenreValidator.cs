using Chinook.Domain.ApiModels;
using FluentValidation;

namespace Chinook.Domain.Validators
{
    public class GenreValidator : AbstractValidator<GenreApiModel>
    {
        public GenreValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is mandatory.");
        }
    }
}