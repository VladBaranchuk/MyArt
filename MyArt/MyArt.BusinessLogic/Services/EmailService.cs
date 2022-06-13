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

        public async Task SendEmailAboutBouhtAsync(int artId, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserIdByHttpContext(cancellationToken);

            var user = await _userProvider.GetItemByIdAsync(userId, cancellationToken);

            var recipient = await _userProvider.GetItemByArtIdAsync(artId, cancellationToken);

            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("", "MyArt@gmail.com"));
            emailMessage.To.Add(new MailboxAddress("", user.Email));
            emailMessage.Subject = "Покупка MyArt";
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = "Поздравляем с покупкой. Вы успешно приобрели работу на нашем сайте" +
                "<br/>Ссылка на картинку: http://localhost:3000/arts/" + artId
            };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 465, true);
            smtp.Authenticate("baranchuk050420@gmail.com", "rlpflyzwbofexuux");
            smtp.Send(emailMessage);
            smtp.Disconnect(true);
        }

        public async Task SendEmailAboutBouhtToArtistAsync(int artId, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserIdByHttpContext(cancellationToken);

            var user = await _userProvider.GetItemByIdAsync(userId, cancellationToken);

            var recipient = await _userProvider.GetItemByArtIdAsync(artId, cancellationToken);

            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("", "MyArt@gmail.com"));
            emailMessage.To.Add(new MailboxAddress("", recipient.Email));
            emailMessage.Subject = "Покупка MyArt";
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = "Поздравляем с продажей. Вашу работу успешно приобрели на нашем сайте" +
                "<br/>Ссылка на картинку: http://localhost:3000/arts/" + artId
            };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 465, true);
            smtp.Authenticate("baranchuk050420@gmail.com", "rlpflyzwbofexuux");
            smtp.Send(emailMessage);
            smtp.Disconnect(true);
        }
    }
}
