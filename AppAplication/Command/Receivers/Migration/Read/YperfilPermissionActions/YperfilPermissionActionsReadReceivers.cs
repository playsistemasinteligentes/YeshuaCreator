using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Outputs;
using IRepository.Read;

namespace Command.Receivers.Read
{
    public class YperfilPermissionActionsReadReceiver : ReciverBase<DataPagination<YperfilPermissionActionsDTO>>
    {
        private readonly IYperfilPermissionActionsReadRepository _repository;
        private readonly ILogger _logger;

        public YperfilPermissionActionsReadReceiver(IYperfilPermissionActionsReadRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<DataPagination<YperfilPermissionActionsDTO>> Action(ICommand comand)
        {
            if(comand is Command.Read.YperfilPermissionActionsReadCommand c) 
             {    
                var YperfilPermissionActionsReadRepository = _repository.getYperfilPermissionActions(c);
                return Success("OK", YperfilPermissionActionsReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration