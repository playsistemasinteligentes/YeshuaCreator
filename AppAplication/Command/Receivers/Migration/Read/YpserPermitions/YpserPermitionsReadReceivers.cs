using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Outputs;
using IRepository.Read;

namespace Command.Receivers.Read
{
    public class YpserPermitionsReadReceiver : ReciverBase<DataPagination<YpserPermitionsDTO>>
    {
        private readonly IYpserPermitionsReadRepository _repository;
        private readonly ILogger _logger;

        public YpserPermitionsReadReceiver(IYpserPermitionsReadRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<DataPagination<YpserPermitionsDTO>> Action(ICommand comand)
        {
            if(comand is Command.Read.YpserPermitionsReadCommand c) 
             {    
                var YpserPermitionsReadRepository = _repository.getYpserPermitions(c);
                return Success("OK", YpserPermitionsReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration