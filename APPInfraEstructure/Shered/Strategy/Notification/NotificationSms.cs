using Dominio.Interfaces;
using Dominio.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shered.Strategy.Notification
{
    public class NotificationSms : INotification
    {
        public TypeNotification Type { get; } = TypeNotification.SMS;

        public void SendNotification(IMessage menssege)
        {
            throw new NotImplementedException();
        }
    }
}
