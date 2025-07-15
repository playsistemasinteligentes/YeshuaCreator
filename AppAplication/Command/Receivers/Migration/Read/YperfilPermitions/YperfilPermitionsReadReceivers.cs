using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Outputs;
using Read.RepositoryInterfaces;

namespace Command.Receivers.Read
{
    public class YperfilPermitionsReadReceiver : ReciverBase<DataPagination<YperfilPermitionsDTO>>
    {
        private readonly IYperfilPermitionsReadRepository _repository;
        private readonly ILogger _logger;

        public YperfilPermitionsReadReceiver(IYperfilPermitionsReadRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<DataPagination<YperfilPermitionsDTO>> Action(ICommand comand)
        {
            if(comand is Command.Commands.Read.YperfilPermitionsReadCommand c) 
             {    
                var YperfilPermitionsReadRepository = _repository.getYperfilPermitions(c);
                return Success("OK", YperfilPermitionsReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration