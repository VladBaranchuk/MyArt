using MyArt.API.ViewModels;

namespace MyArt.BusinessLogic.Contracts
{
    public interface IEmailService
    {
        Task SendEmailAsync(MailViewModel mailVM, CancellationToken cancellationToken);
        Task SendEmailAboutCommentAsync(CreateCommentViewModel commentVM, CancellationToken cancellationToken);
    }
}
