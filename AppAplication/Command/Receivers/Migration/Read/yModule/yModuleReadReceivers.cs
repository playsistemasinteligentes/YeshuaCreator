using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Outputs;
using IRepository.Read;

namespace Command.Receivers.Read
{
    public class yModuleReadReceiver : ReciverBase<DataPagination<yModuleDTO>>
    {
        private readonly IyModuleReadRepository _repository;
        private readonly ILogger _logger;

        public yModuleReadReceiver(IyModuleReadRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<DataPagination<yModuleDTO>> Action(ICommand comand)
        {
            if(comand is Command.Read.yModuleReadCommand c) 
             {    
                var yModuleReadRepository = _repository.getyModule(c);
                return Success("OK", yModuleReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration