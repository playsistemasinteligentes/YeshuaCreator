using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Outputs;
using IRepository.Read;

namespace Command.Receivers.Read
{
    public class yTenantReadReceiver : ReciverBase<ICommand, DataPagination<yTenantDTO>>
    {
        private readonly IyTenantReadRepository _repository;
        private readonly ILogger _logger;

        public yTenantReadReceiver(
            IyTenantReadRepository repository,
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<DataPagination<yTenantDTO>> Action(ICommand comand)
        {
            if(comand is Command.Read.yTenantReadCommand c) 
             {    
                var yTenantReadRepository = _repository.getyTenant(c);
                return Success("OK", yTenantReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration