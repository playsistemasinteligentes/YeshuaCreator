using Comandos.Pateners.Command;
using Dominio.Entitys.Agendamentos;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Agendamentos;
using RepositoryInterfaces.Read.Repository.Agendamentos;

namespace Command.Receivers.Read
{
    public class AgendamentosReadReceiver : ReciverBase
    {
        private readonly IAgendamentosReadRepository _repository;

        public AgendamentosReadReceiver(IAgendamentosReadRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
            var AgendamentosReadRepository = _repository.getAllAgendamentos();
            return new State(200, "OK", AgendamentosReadRepository);
        }
    }
}
