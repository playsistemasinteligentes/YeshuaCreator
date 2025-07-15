using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Outputs;
using Read.RepositoryInterfaces;

namespace Command.Receivers.Read
{
    public class Y_TenantReadReceiver : ReciverBase<DataPagination<Y_TenantDTO>>
    {
        private readonly IY_TenantReadRepository _repository;
        private readonly ILogger _logger;

        public Y_TenantReadReceiver(IY_TenantReadRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<DataPagination<Y_TenantDTO>> Action(ICommand comand)
        {
            if(comand is Command.Commands.Read.Y_TenantReadCommand c) 
             {    
                var Y_TenantReadRepository = _repository.getY_Tenant(c);
                return Success("OK", Y_TenantReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration