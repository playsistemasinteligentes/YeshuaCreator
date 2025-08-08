using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;

namespace Command.Receivers.Read
{
    public class DisponibilidadeAgendaReadFKTenantIDReceiver : ReciverBase<IEnumerable<DisponibilidadeAgendaTenantIDDTO>>
    {
        private readonly IDisponibilidadeAgendaReadRepository _repository;

        public DisponibilidadeAgendaReadFKTenantIDReceiver(IDisponibilidadeAgendaReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<DisponibilidadeAgendaTenantIDDTO>> Action(ICommand comand)
        {
            if(comand is SearchFKCommand c) 
             {    
                var DisponibilidadeAgendaReadRepository = _repository.getDisponibilidadeAgendaReadFKTenantID(c);
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