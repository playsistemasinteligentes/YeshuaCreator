using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class DisponibilidadeAgendaReadFKUserIdReceiver : ReciverBase<ICommand, IEnumerable<DisponibilidadeAgendaUserIdDTO>>
    {
        private readonly IDisponibilidadeAgendaReadRepository _repository;

        public DisponibilidadeAgendaReadFKUserIdReceiver(IDisponibilidadeAgendaReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<DisponibilidadeAgendaUserIdDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var DisponibilidadeAgendaReadRepository = _repository.getDisponibilidadeAgendaReadFKUserId(c);
                return Success("OK", DisponibilidadeAgendaReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration