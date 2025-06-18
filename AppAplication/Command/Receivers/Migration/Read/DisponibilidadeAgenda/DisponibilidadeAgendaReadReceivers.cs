using Comandos.Pateners.Command;
using Dominio.Entitys;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.DisponibilidadeAgenda;
using Repositorio.Outputs.DTOs.DisponibilidadeAgenda;
using RepositoryInterfaces.Read.Repository.DisponibilidadeAgenda;

namespace Command.Receivers.Read
{
    public class DisponibilidadeAgendaReadReceiver : ReciverBase<IEnumerable<DisponibilidadeAgendaDTO>>
    {
        private readonly IDisponibilidadeAgendaReadRepository _repository;

        public DisponibilidadeAgendaReadReceiver(IDisponibilidadeAgendaReadRepository repository)
        {
            _repository = repository;
        }

        protected override State<IEnumerable<DisponibilidadeAgendaDTO>> Action(ICommand comand)
        {
            if(comand is Command.Commands.Read.DisponibilidadeAgendaReadCommand c) 
             {    
                var DisponibilidadeAgendaReadRepository = _repository.getDisponibilidadeAgenda(c);
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