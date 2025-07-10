using Dominio.Interfaces;
using Dominio.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterfaces.Strategy
{
    public interface INotificationFactory
    {
        INotification GetType(TypeNotification type);
    }
}
