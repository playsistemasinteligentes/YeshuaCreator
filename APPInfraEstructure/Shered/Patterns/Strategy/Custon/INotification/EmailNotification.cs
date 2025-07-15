using System;
using System.Net.Mail;
using Dominio.Interfaces.Strategy;
using Dominio.Enum.Strategy;

namespace Shered.Patterns.Strategy
{
    public partial class EmailNotification : INotification
    {
        //private readonly SmtpClient _smtpClient;
        //private readonly string _fromAddress;

        //public EmailNotification(SmtpClient smtpClient, string fromAddress)
        //{
        //    _smtpClient = smtpClient ?? throw new ArgumentNullException(nameof(smtpClient));
        //    _fromAddress = !string.IsNullOrWhiteSpace(fromAddress)
        //        ? fromAddress
        //        : throw new ArgumentException("Endereço de remetente inválido.", nameof(fromAddress));
        //}

        public partial void SendNotification(IMessage message)
        {
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