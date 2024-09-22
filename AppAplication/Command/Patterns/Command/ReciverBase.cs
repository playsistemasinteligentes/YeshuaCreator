using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comandos.Pateners.Command
{
    public abstract class ReciverBase : IReceiver<ICommand, State>
    {
        protected abstract State Action(ICommand comand);

        public State Execute(ICommand command)
        {
            BeforeAction();
            State state = Action(command);
            AfterAction();
            return state;
        }
        protected void BeforeAction() { }
        protected void AfterAction() { }
    }
}
