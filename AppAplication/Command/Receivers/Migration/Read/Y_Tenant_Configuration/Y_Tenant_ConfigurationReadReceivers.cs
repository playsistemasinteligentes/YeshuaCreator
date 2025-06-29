using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Inputs.Repositorio.Y_Tenant_Configuration;
using Repositorio.Outputs.DTOs.Y_Tenant_Configuration;
using RepositoryInterfaces.Read.Repository.Y_Tenant_Configuration;

namespace Command.Receivers.Read
{
    public class Y_Tenant_ConfigurationReadReceiver : ReciverBase<DataPagination<Y_Tenant_ConfigurationDTO>>
    {
        private readonly IY_Tenant_ConfigurationReadRepository _repository;
        private readonly ILogger _logger;

        public Y_Tenant_ConfigurationReadReceiver(IY_Tenant_ConfigurationReadRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<DataPagination<Y_Tenant_ConfigurationDTO>> Action(ICommand comand)
        {
            if(comand is Command.Commands.Read.Y_Tenant_ConfigurationReadCommand c) 
             {    
                var Y_Tenant_ConfigurationReadRepository = _repository.getY_Tenant_Configuration(c);
                return Success("OK", Y_Tenant_ConfigurationReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration