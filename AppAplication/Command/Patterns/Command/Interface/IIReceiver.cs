using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comandos.Pateners.Command
{
    public interface IReceiver<C, T>
        where C : ICommand
    {
        State<T> Execute(C command);
    }

}
