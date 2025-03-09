using Comandos.Pateners.Command;
using Dominio.Entitys.DisponibilidadeAgenda;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.DisponibilidadeAgenda;
using RepositoryInterfaces.Read.Repository.DisponibilidadeAgenda;

namespace Command.Receivers.Read
{
    public class DisponibilidadeAgendaReadReceiver : ReciverBase
    {
        private readonly IDisponibilidadeAgendaReadRepository _repository;

        public DisponibilidadeAgendaReadReceiver(IDisponibilidadeAgendaReadRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
            var DisponibilidadeAgendaReadRepository = _repository.getAllDisponibilidadeAgenda();
            return new State(200, "OK", DisponibilidadeAgendaReadRepository);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration