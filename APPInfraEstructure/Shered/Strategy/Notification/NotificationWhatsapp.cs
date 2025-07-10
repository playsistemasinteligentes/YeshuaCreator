using Dominio.Interfaces;
using Dominio.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shered.Strategy.Notification
{
    public class NotificationWhatsapp : INotification
    {
        public TypeNotification Type { get; } = TypeNotification.Whatsapp;
        public void SendNotification(IMessage menssege)
        {
            throw new NotImplementedException();
        }
    }
}
