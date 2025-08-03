using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Outputs;
using IRepository.Read;

namespace Command.Receivers.Read
{
    public class YpermissionModulesReadReceiver : ReciverBase<DataPagination<YpermissionModulesDTO>>
    {
        private readonly IYpermissionModulesReadRepository _repository;
        private readonly ILogger _logger;

        public YpermissionModulesReadReceiver(IYpermissionModulesReadRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<DataPagination<YpermissionModulesDTO>> Action(ICommand comand)
        {
            if(comand is Command.Read.YpermissionModulesReadCommand c) 
             {    
                var YpermissionModulesReadRepository = _repository.getYpermissionModules(c);
                return Success("OK", YpermissionModulesReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration