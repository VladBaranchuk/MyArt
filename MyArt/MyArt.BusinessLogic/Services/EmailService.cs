using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MyArt.API.ViewModels;
using MyArt.BusinessLogic.Contracts;
using MyArt.DataAccess.Contracts.Providers;

namespace MyArt.BusinessLogic.Services
{
    public class EmailService : IEmailService
    {
        private readonly IUserProvider _userProvider;
        private readonly ICurrentUserService _currentUserService;

        public EmailService(IUserProvider userProvider,
             ICurrentUserService currentUserService)
        {
            _userProvider = userProvider;
            _currentUserService = currentUserService;
        }

        public async Task SendEmailAsync(MailViewModel mailVM, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserIdByHttpContext(cancellationToken);

            var user = await _userProvider.GetItemByIdAsync(userId, cancellationToken);

            var recipient = await _userProvider.GetItemByIdAsync(mailVM.RecipientId, cancellationToken);

            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress(mailVM.LastName + " " + mailVM.FirstName, user.Email));
            emailMessage.To.Add(new MailboxAddress("", recipient.Email));
            emailMessage.Subject = mailVM.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = mailVM.Message
            };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 465, true);
            smtp.Authenticate("baranchuk050420@gmail.com", "rlpflyzwbofexuux");
            smtp.Send(emailMessage);
            smtp.Disconnect(true);
        }

        public async Task SendEmailAboutCommentAsync(CreateCommentViewModel commentVM, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserIdByHttpContext(cancellationToken);

            var user = await _userProvider.GetItemByIdAsync(userId, cancellationToken);

            var recipient = await _userProvider.GetItemByArtIdAsync(commentVM.Id, cancellationToken);

            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("", user.Email));
            emailMessage.To.Add(new MailboxAddress("", recipient.Email));
            emailMessage.Subject = "Комментарий от " + user.Alias;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = commentVM.Text +
                "<br/>Ссылка на комментарий: http://localhost:3000/arts/" + commentVM.Id
            };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 465, true);
            smtp.Authenticate("baranchuk050420@gmail.com", "rlpflyzwbofexuux");
            smtp.Send(emailMessage);
            smtp.Disconnect(true);
        }
    }
}
