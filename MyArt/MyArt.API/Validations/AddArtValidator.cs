using FluentValidation;
using MyArt.API.ViewModels;

namespace MyArt.API.Validations
{
    public class AddArtValidator : AbstractValidator<CreateArtViewModel>
    {
        public AddArtValidator()
        {
            RuleFor(x => x.Name)
              .Must(x => x.Length >= 2)
              .WithMessage("Поле 'Название' должно быть от 2 до 30 символов на кириллице, либо на латинице");

            RuleFor(x => x.Price)
              .Must(x => x > 0 && x < 10001)
              .WithMessage("Поле 'Цена' должно быть от 1 до 10000 долларов");

            RuleFor(x => x.Month)
              .Must(x => x != 0)
              .WithMessage("Поле 'Месяц' не должно быть пустым");

            RuleFor(x => x.Year)
               .Must(x => x != null || (x >= 1600 && x <= 2022))
               .WithMessage("Поле 'Год' не должно быть пустым, допустимый год от 1600 до 2022");

            RuleFor(x => x.Type)
               .Must(x => x != 0)
               .WithMessage("Поле 'Тип' не должно быть пустым");

            RuleFor(x => x.Image)
               .Must(x => x != null)
               .WithMessage("Поле 'Изображение' не должно быть пустым");
        }
    }
}
