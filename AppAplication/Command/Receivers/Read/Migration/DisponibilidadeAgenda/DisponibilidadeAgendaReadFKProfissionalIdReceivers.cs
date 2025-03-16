using Comandos.Pateners.Command;
using Dominio.Entitys.DisponibilidadeAgenda;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.DisponibilidadeAgenda;
using RepositoryInterfaces.Read.Repository.DisponibilidadeAgenda;

namespace Command.Receivers.Read
{
    public class DisponibilidadeAgendaReadFKProfissionalIdReceiver : ReciverBase
    {
        private readonly IDisponibilidadeAgendaReadRepository _repository;

        public DisponibilidadeAgendaReadFKProfissionalIdReceiver(IDisponibilidadeAgendaReadRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
            if(comand is Command.Patterns.Command.SearchFKCommand c) 
             {    
                var DisponibilidadeAgendaReadRepository = _repository.getDisponibilidadeAgendaReadFKProfissionalId(c);
                return new State(200, "OK", DisponibilidadeAgendaReadRepository);
            }
            else 
            {
                 return new State(500, "ErroConversao", comand);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration