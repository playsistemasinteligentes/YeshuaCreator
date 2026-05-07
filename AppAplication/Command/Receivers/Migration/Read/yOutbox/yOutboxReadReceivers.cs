using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Outputs;
using IRepository.Read;

namespace Command.Receivers.Read
{
    public class yOutboxReadReceiver : ReciverBase<ICommand, DataPagination<yOutboxDTO>>
    {
        private readonly IyOutboxReadRepository _repository;
        private readonly ILogger _logger;

        public yOutboxReadReceiver(
            IyOutboxReadRepository repository,
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<DataPagination<yOutboxDTO>> Action(ICommand comand)
        {
            if(comand is Command.Read.yOutboxReadCommand c) 
             {    
                var yOutboxReadRepository = _repository.getyOutbox(c);
                return Success("OK", yOutboxReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration