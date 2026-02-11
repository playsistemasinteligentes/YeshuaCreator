using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Outputs;
using IRepository.Read;

namespace Command.Receivers.Read
{
    public class yInboxReadReceiver : ReciverBase<ICommand, DataPagination<yInboxDTO>>
    {
        private readonly IyInboxReadRepository _repository;
        private readonly ILogger _logger;

        public yInboxReadReceiver(IyInboxReadRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<DataPagination<yInboxDTO>> Action(ICommand comand)
        {
            if(comand is Command.Read.yInboxReadCommand c) 
             {    
                var yInboxReadRepository = _repository.getyInbox(c);
                return Success("OK", yInboxReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration