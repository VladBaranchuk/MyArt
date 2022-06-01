using FluentValidation;
using MyArt.API.ViewModels;
using System.Text.RegularExpressions;

namespace MyArt.API.Validations
{
    public class ArtFilterValidator : AbstractValidator<ArtFilterViewModel>
    {
        public ArtFilterValidator()
        {

            RuleFor(x => x.Year)
               .Must(x => x == null || (x >= 1600 && x <= 2022))
               .WithMessage("Допустимый год от 1600 до 2022");
        }
    }
}
