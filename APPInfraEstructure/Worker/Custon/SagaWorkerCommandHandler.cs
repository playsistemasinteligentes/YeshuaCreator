using Command.Patterns.Command;
using Command.Saga;
using Microsoft.Win32;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Saga;

namespace Worker.Custon
{

    public class SagaWorkerCommandHandler : ReciverBase<InputCommand, OutputCommand>
    {
        protected override State<OutputCommand> Action(InputCommand comand)
        {
            try
            {
                State<OutputCommand> retorno = Success("OK", null);

                //var sagas = _repository.GetRunnableSagas();
                //
                //foreach (var saga in sagas)
                //{
                //    var resolver = _registry.Resolve(saga);
                //
                //    _executor.Execute(saga, resolver);
                //
                //    _repository.Save(saga);
                //}

                //CustomActionHook(ref retorno, comand);
                return retorno;
            }
            catch (ReceiverException<OutputCommand> e)
            {
                return e.State;
            }
            catch (Exception e)
            {
                return Error(e, default);
            }
        }
        //partial void CustomActionHook(ref State<OutputCommand> state, InputCommand comand);
    }

    public partial record InputCommand : ICommand
    {
        public List<int> lst { get; set; }
    }

    public partial record OutputCommand : ICommand
    {
        public List<int> lst { get; set; }
    }
}
