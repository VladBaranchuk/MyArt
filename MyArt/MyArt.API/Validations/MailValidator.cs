using FluentValidation;
using MyArt.API.ViewModels;

namespace MyArt.API.Validations
{
    public class MailVlidator : AbstractValidator<MailViewModel>
    {
        public MailVlidator()
        {
            RuleFor(x => x.FirstName)
                 .Must(x => x.Length >= 2 && x.Length <= 20).WithMessage("Поле 'Имя' должно содержать от 2 до 20 символов");

            RuleFor(x => x.LastName)
                .Must(x => x.Length >= 2 && x.Length <= 20).WithMessage("Поле 'Фамилия' должно содержать от 2 до 20 символов");

            RuleFor(x => x.Subject)
                .Must(x => x.Length >= 2 && x.Length <= 20).WithMessage("Поле 'Тема' должно содержать от 2 до 20 символов");

            RuleFor(x => x.Subject)
               .Must(x => x.Length >= 2 && x.Length <= 500).WithMessage("Поле 'Собщение' должно содержать от 2 до 500 символов");
        }
    }
}
