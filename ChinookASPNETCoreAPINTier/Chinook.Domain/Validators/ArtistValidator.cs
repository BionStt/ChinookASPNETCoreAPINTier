using Chinook.Domain.ApiModels;
using FluentValidation;

namespace Chinook.Domain.Validators
{
    public class ArtistValidator : AbstractValidator<ArtistApiModel>
    {
        public ArtistValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is mandatory.");
        }
    }
}