using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Outputs;
using IRepository.Read;

namespace Command.Receivers.Read
{
    public class YuserPermitionsReadReceiver : ReciverBase<DataPagination<YuserPermitionsDTO>>
    {
        private readonly IYuserPermitionsReadRepository _repository;
        private readonly ILogger _logger;

        public YuserPermitionsReadReceiver(IYuserPermitionsReadRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<DataPagination<YuserPermitionsDTO>> Action(ICommand comand)
        {
            if(comand is Command.Read.YuserPermitionsReadCommand c) 
             {    
                var YuserPermitionsReadRepository = _repository.getYuserPermitions(c);
                return Success("OK", YuserPermitionsReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration