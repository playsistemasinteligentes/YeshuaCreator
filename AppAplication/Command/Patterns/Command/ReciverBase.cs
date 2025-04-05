using RepositoryInterfaces.Patterns.UnitOfWork;
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
            State state = Action(command);
            return state;
        }
        protected static State Error(string message, object data = null, bool propagation = true)
        => new State(500, message, data, propagation);

        protected static State Error(Exception message, object data = null)
                => new State(500, message, data, false);

        protected static State Success(string message, object data = null)
            => new State(200, message, data);

        protected static State Created(string message, object data = null)
            => new State(201, message, data);

        protected static State ValidationError(string message, object data = null)
            => new State(400, message, data);
        protected static State ValidationError(List<string> message, object data = null)
             => new State(400, message, data);

    }
}
