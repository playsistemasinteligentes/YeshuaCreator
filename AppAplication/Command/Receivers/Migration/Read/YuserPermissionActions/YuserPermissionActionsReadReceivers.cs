using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Outputs;
using IRepository.Read;

namespace Command.Receivers.Read
{
    public class YuserPermissionActionsReadReceiver : ReciverBase<DataPagination<YuserPermissionActionsDTO>>
    {
        private readonly IYuserPermissionActionsReadRepository _repository;
        private readonly ILogger _logger;

        public YuserPermissionActionsReadReceiver(IYuserPermissionActionsReadRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<DataPagination<YuserPermissionActionsDTO>> Action(ICommand comand)
        {
            if(comand is Command.Read.YuserPermissionActionsReadCommand c) 
             {    
                var YuserPermissionActionsReadRepository = _repository.getYuserPermissionActions(c);
                return Success("OK", YuserPermissionActionsReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration