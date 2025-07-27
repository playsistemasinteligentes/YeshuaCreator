using System;
using System.Net;
using System.Net.Mail;
using Aplication.Interfaces.Services;
using Dominio.Interfaces.Strategy;
using IRepository.Read;

namespace Shered.Patterns.Strategy
{
    public partial class EmailNotification : INotification
    {
        private readonly IYconfigNotificationReadRepository _repReadYConfig;
        private readonly IYuserReadRepository _repUserReadRepository;

        public EmailNotification(IYconfigNotificationReadRepository repReadYConfig, IYuserReadRepository repUserReadRepository)
        {
            _repReadYConfig = repReadYConfig;
            _repUserReadRepository = repUserReadRepository;
        }

        public partial void SendNotification(IMessage message)
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));

            if (string.IsNullOrWhiteSpace(message.Destination))
                throw new InvalidOperationException("Destino da mensagem não pode ser vazio.");

            var user = _repUserReadRepository.FirstByEmail(message.Destination);
            var config = _repReadYConfig.FirstByTenantID(user.tenantid);

            SmtpClient smtpClient = new SmtpClient(config.emailsmtpclient, config.emailport)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(config.emailusername, config.emailpassword),
                DeliveryMethod = SmtpDeliveryMethod.Network
            };

            var fromAddress = config.emailusername;

            using var mail = new MailMessage
            {
                From = new MailAddress(fromAddress),
                Subject = message.Subject ?? string.Empty,
                Body = message.Body ?? string.Empty,
                IsBodyHtml = true
            };

            mail.To.Add(message.Destination);

            if (message.Attachment != null && message.Attachment.Length > 0)
            {
                var stream = new System.IO.MemoryStream(message.Attachment);
                var attachment = new Attachment(stream, "attachment");
                mail.Attachments.Add(attachment);
            }

            smtpClient.Send(mail);
        }
    }
}
