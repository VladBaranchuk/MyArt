using MyArt.API.ViewModels;

namespace MyArt.BusinessLogic.Contracts
{
    public interface IEmailService
    {
        Task SendEmailAsync(MailViewModel mailVM, CancellationToken cancellationToken);
        Task SendEmailAboutCommentAsync(CreateCommentViewModel commentVM, CancellationToken cancellationToken);
        Task SendEmailAboutBouhtAsync(int artId, CancellationToken cancellationToken);
        Task SendEmailAboutBouhtToArtistAsync(int artId, CancellationToken cancellationToken);
    }
}
