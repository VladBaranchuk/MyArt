using FluentValidation;
using MyArt.API.ViewModels;

namespace MyArt.API.Validations
{
    public class AddBoardValidator : AbstractValidator<CreateBoardViewModel>
    {
        public AddBoardValidator()
        {
            RuleFor(x => x.Name)
             .Must(x => x.Length >= 2)
             .WithMessage("Поле 'Название' должно быть от 2 до 30 символов на кириллице, либо на латинице");
        }
    }
}
