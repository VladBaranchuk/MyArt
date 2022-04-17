using FluentValidation;
using MyArt.API.ViewModels;
using MyArt.BusinessLogic.Contracts;

namespace MyArt.API.Validations
{
    public class AuthenticationValidator : AbstractValidator<AuthenticationViewModel>
    {
        public AuthenticationValidator(IUserService userService)
        {
            RuleFor(x => x.Password)
               .Must(x => x.Length >= 2 && x.Length <= 20)
               .WithMessage("Поле должно быть от 2 до 20 символов");

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Поле не является адерсом электронной почты")
                .MustAsync(async (email, token) =>
                {
                    var hasAny = await userService.HasAnyByEmailAsync(email, token);
                    return hasAny;
                }).WithMessage("Такой Email не существует");
        }
    }
}
