using Dominio.Interfaces;
using Dominio.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shered.Strategy.Notification
{
    public class NotificationEmail : INotification
    {
        public TypeNotification Type { get; } = TypeNotification.Email;

        public void SendNotification(IMessage message)
        {
            Console.WriteLine($"[Email] Enviando para {message.Destination}");
            if (message.Attachment != null)
            {
                Console.WriteLine($"[Email] Anexo com {message.Attachment.Length} bytes.");
            }
        }
    }
}
