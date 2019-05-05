using Chinook.Domain.ApiModels;
using FluentValidation;

namespace Chinook.Domain.Validators
{
    public class AlbumValidator : AbstractValidator<AlbumApiModel>
    {
        public AlbumValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Title is mandatory.");
            
            
        }
    }
}