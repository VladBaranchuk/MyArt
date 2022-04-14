using FluentValidation;
using MyArt.API.ViewModels;

namespace MyArt.API.Validations
{
    public class AuthenticationValidator : AbstractValidator<AuthenticationViewModel>
    {
        public AuthenticationValidator()
        {
            RuleFor(x => x.Password)
               .Must(x => x.Length >= 2 && x.Length <= 20)
               .WithMessage("Поле должно быть от 2 до 20 символов");


            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Поле не является адерсом электронной почты");
        }
    }
}
