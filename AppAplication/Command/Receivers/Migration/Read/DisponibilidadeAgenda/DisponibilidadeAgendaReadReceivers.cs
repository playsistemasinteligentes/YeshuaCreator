using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Outputs;
using IRepository.Read;

namespace Command.Receivers.Read
{
    public class DisponibilidadeAgendaReadReceiver : ReciverBase<ICommand, DataPagination<DisponibilidadeAgendaDTO>>
    {
        private readonly IDisponibilidadeAgendaReadRepository _repository;
        private readonly ILogger _logger;

        public DisponibilidadeAgendaReadReceiver(
            IDisponibilidadeAgendaReadRepository repository,
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<DataPagination<DisponibilidadeAgendaDTO>> Action(ICommand comand)
        {
            if(comand is Command.Read.DisponibilidadeAgendaReadCommand c) 
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