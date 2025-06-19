using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Repositorio.Inputs.Repositorio.DisponibilidadeAgenda;
using Repositorio.Outputs.DTOs.DisponibilidadeAgenda;
using RepositoryInterfaces.Read.Repository.DisponibilidadeAgenda;

namespace Command.Receivers.Read
{
    public class DisponibilidadeAgendaReadReceiver : ReciverBase<DataPagination<DisponibilidadeAgendaDTO>>
    {
        private readonly IDisponibilidadeAgendaReadRepository _repository;

        public DisponibilidadeAgendaReadReceiver(IDisponibilidadeAgendaReadRepository repository)
        {
            _repository = repository;
        }

        protected override State<DataPagination<DisponibilidadeAgendaDTO>> Action(ICommand comand)
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