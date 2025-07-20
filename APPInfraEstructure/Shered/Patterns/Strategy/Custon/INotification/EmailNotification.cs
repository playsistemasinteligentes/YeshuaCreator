using System;
using System.Net.Mail;
using Dominio.Interfaces.Strategy;
using Dominio.Enum.Strategy;
using Read.RepositoryInterfaces;
using IRepository.Read;

namespace Shered.Patterns.Strategy
{
    public partial class EmailNotification : INotification
    {

        private readonly IYconfigNotificationReadRepository _repReadYConfig;

        public EmailNotification(IYconfigNotificationReadRepository repReadYConfig)
        {
            _repReadYConfig = repReadYConfig;
        }

        public partial void SendNotification(IMessage message)
        {
            //Read.Repository.YuserReadRepository.

            string _fromAddress = "angeo@gmail.com";

            if (message == null) throw new ArgumentNullException(nameof(message));
            if (string.IsNullOrWhiteSpace(message.Destination))
                throw new InvalidOperationException("Destino da mensagem não pode ser vazio.");

            var mail = new MailMessage();
            mail.From = new MailAddress(_fromAddress);
            mail.To.Add(message.Destination);
            mail.Subject = message.Subject ?? string.Empty;
            mail.Body = message.Body ?? string.Empty;
            mail.IsBodyHtml = false;

            if (message.Attachment != null && message.Attachment.Length > 0)
            {
                using var stream = new System.IO.MemoryStream(message.Attachment);
                var attachment = new Attachment(stream, "attachment");
                mail.Attachments.Add(attachment);
            }

            //_smtpClient.Send(mail);


        }
    }
}

//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversUseCase