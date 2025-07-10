using Dominio.Interfaces;
using Dominio.Strategy;
using Microsoft.Data.SqlClient;
using RepositoryInterfaces.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shered.Strategy.Notification
{



    public interface INotificationFactory
    {
        INotification GetType(TypeNotification type);
    }


    public class NotificationFactory : INotificationFactory
    {
        private readonly NotificationEmail _email;
        private readonly NotificationSms _sms;
        private readonly NotificationWhatsapp _whatsapp;

        public NotificationFactory(
            NotificationEmail emailSender,
            NotificationSms smsSender,
            NotificationWhatsapp whatsappSender)
        {
            _email = emailSender;
            _sms = smsSender;
            _whatsapp = whatsappSender;
        }

        public INotification GetType(TypeNotification type)
        {
            return type switch
            {
                TypeNotification.Email => _email,
                TypeNotification.SMS => _sms,
                TypeNotification.Whatsapp => _whatsapp,
                _ => throw new ArgumentException("Invalid Notification Type")
            };
        }

    }

}
