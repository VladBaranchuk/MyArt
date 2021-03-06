using FluentValidation;
using MyArt.API.ViewModels;
using MyArt.BusinessLogic.Contracts;

namespace MyArt.API.Validations
{
    public class RegisterValidator : AbstractValidator<RegisterViewModel>
    {

        public RegisterValidator(IUserService userService)
        {
            RuleFor(x => x.FirstName)
                .Must(x => x.Length >= 2 && x.Length <= 20).WithMessage("Поле 'Имя' должно содержать от 2 до 20 символов");

            RuleFor(x => x.LastName)
                .Must(x => x.Length >= 2 && x.Length <= 20).WithMessage("Поле 'Фамилия' должно содержать от 2 до 20 символов");

            RuleFor(x => x.Alias)
                .Must(x => x.Length >= 2 && x.Length <= 20).WithMessage("Поле 'Псевдоним' должно содержать от 2 до 20 символов и содержать @ в начале псевдонима");

            RuleFor(x => x.Password)
                .Must(x => x.Length >= 2 && x.Length <= 20).WithMessage("Поле 'Пароль' должно содержать от 2 до 20 символов");

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Поле 'Email' не соответствует адресу электронной почты")
                .MustAsync(async (email, token) =>
                {
                    var hasAny = await userService.HasAnyByEmailAsync(email, token);
                    return !hasAny;
                }).WithMessage("Такой Email уже существует");

        }
    }
}
