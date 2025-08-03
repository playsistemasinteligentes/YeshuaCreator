using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Outputs;
using IRepository.Read;

namespace Command.Receivers.Read
{
    public class YpermissionActionsReadReceiver : ReciverBase<DataPagination<YpermissionActionsDTO>>
    {
        private readonly IYpermissionActionsReadRepository _repository;
        private readonly ILogger _logger;

        public YpermissionActionsReadReceiver(IYpermissionActionsReadRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<DataPagination<YpermissionActionsDTO>> Action(ICommand comand)
        {
            if(comand is Command.Read.YpermissionActionsReadCommand c) 
             {    
                var YpermissionActionsReadRepository = _repository.getYpermissionActions(c);
                return Success("OK", YpermissionActionsReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration