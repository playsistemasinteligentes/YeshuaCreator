using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comandos.Pateners.Command
{
    public interface IReceiver<in C, out S >
        where C : ICommand
        where S : State
    {
        //S Action(C comand);
    }
}
