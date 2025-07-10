using Dominio.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface INotification
    {
        TypeNotification Type { get; }
        void SendNotification(IMessage menssege);
    }
}
