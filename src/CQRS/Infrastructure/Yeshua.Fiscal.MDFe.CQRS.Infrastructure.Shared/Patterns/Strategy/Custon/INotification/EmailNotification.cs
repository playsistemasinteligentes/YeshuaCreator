using System.Net;
using System.Net.Mail;
using Dominio.Interfaces.Strategy;
using IRepository.Read;

namespace Shered.Patterns.Strategy
{
    public partial class EmailNotification : INotification
    {
        private readonly IyConfigNotificationReadRepository _repReadYConfig;
        private readonly IyUserReadRepository _repUserReadRepository;

        public EmailNotification(
            IyConfigNotificationReadRepository repReadYConfig,
            IyUserReadRepository repUserReadRepository)
        {
            _repReadYConfig = repReadYConfig;
            _repUserReadRepository = repUserReadRepository;
        }

        public partial void SendNotification(IMessage message)
        {
            ArgumentNullException.ThrowIfNull(message);

            if (string.IsNullOrWhiteSpace(message.Destination))
                throw new InvalidOperationException("Destino da mensagem nao pode ser vazio.");

            var user = _repUserReadRepository.FirstByEmail(message.Destination);
            var config = _repReadYConfig.FirstByTenantID(user.tenantid);

            using var smtpClient = new SmtpClient(config.emailsmtpclient, config.emailport)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(config.emailusername, config.emailpassword),
                DeliveryMethod = SmtpDeliveryMethod.Network
            };

            using var mail = new MailMessage
            {
                From = new MailAddress(config.emailusername),
                Subject = message.Subject ?? string.Empty,
                Body = message.Body ?? string.Empty,
                IsBodyHtml = true
            };

            mail.To.Add(message.Destination);

            if (message.Attachment is { Length: > 0 })
            {
                var stream = new MemoryStream(message.Attachment);
                mail.Attachments.Add(new Attachment(stream, "attachment"));
            }

            smtpClient.Send(mail);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
