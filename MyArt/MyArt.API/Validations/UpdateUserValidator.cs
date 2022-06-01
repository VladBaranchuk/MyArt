using FluentValidation;
using MyArt.API.ViewModels;

namespace MyArt.API.Validations
{
    public class UpdateUserValidator : AbstractValidator<UpdatePublicUserInfoViewModel>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.FirstName)
              .Must(x => x.Length >= 2)
              .WithMessage("Поле 'Имя' должно быть от 2 до 19 символов на кириллице, либо на латинице");

            RuleFor(x => x.LastName)
              .Must(x => x.Length >= 2)
              .WithMessage("Поле 'Фамилия' должно быть от 2 до 19 символов на кириллице, либо на латинице");

            RuleFor(x => x.Description)
              .Must(x => x.Length < 701)
              .WithMessage("Поле 'Описание' должно быть не более 500 символов");
        }
    }
}
