using Chinook.Domain.ApiModels;
using FluentValidation;

namespace Chinook.Domain.Validators
{
    public class TrackValidator : AbstractValidator<TrackApiModel>
    {
        public TrackValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is mandatory.");
        }
    }
}