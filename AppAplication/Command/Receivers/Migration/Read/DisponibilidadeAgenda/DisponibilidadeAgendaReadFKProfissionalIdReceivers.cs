using Comandos.Pateners.Command;
using Dominio.Entitys;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.DisponibilidadeAgenda;
using RepositoryInterfaces.Read.Repository.DisponibilidadeAgenda;
using Repositorio.Outputs.DTOs.DisponibilidadeAgenda;

namespace Command.Receivers.Read
{
    public class DisponibilidadeAgendaReadFKProfissionalIdReceiver : ReciverBase<IEnumerable<DisponibilidadeAgendaProfissionalIdDTO>>
    {
        private readonly IDisponibilidadeAgendaReadRepository _repository;

        public DisponibilidadeAgendaReadFKProfissionalIdReceiver(IDisponibilidadeAgendaReadRepository repository)
        {
            _repository = repository;
        }

        protected override State <IEnumerable<DisponibilidadeAgendaProfissionalIdDTO>> Action(ICommand comand)
        {
            if(comand is Command.Patterns.Command.SearchFKCommand c) 
             {    
                var DisponibilidadeAgendaReadRepository = _repository.getDisponibilidadeAgendaReadFKProfissionalId(c);
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