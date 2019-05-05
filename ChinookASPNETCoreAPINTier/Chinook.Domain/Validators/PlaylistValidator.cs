using Chinook.Domain.ApiModels;
using FluentValidation;

namespace Chinook.Domain.Validators
{
    public class PlaylistValidator : AbstractValidator<PlaylistApiModel>
    {
        public PlaylistValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is mandatory.");
        }
    }
}