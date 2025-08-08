using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Outputs;
using IRepository.Read;

namespace Command.Receivers.Read
{
    public class yTenantModuleReadReceiver : ReciverBase<DataPagination<yTenantModuleDTO>>
    {
        private readonly IyTenantModuleReadRepository _repository;
        private readonly ILogger _logger;

        public yTenantModuleReadReceiver(IyTenantModuleReadRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<DataPagination<yTenantModuleDTO>> Action(ICommand comand)
        {
            if(comand is Command.Read.yTenantModuleReadCommand c) 
             {    
                var yTenantModuleReadRepository = _repository.getyTenantModule(c);
                return Success("OK", yTenantModuleReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration