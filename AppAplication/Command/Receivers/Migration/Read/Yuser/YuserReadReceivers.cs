using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Outputs;
using Read.RepositoryInterfaces;

namespace Command.Receivers.Read
{
    public class YuserReadReceiver : ReciverBase<DataPagination<YuserDTO>>
    {
        private readonly IYuserReadRepository _repository;
        private readonly ILogger _logger;

        public YuserReadReceiver(IYuserReadRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<DataPagination<YuserDTO>> Action(ICommand comand)
        {
            if(comand is Command.Commands.Read.YuserReadCommand c) 
             {    
                var YuserReadRepository = _repository.getYuser(c);
                return Success("OK", YuserReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration