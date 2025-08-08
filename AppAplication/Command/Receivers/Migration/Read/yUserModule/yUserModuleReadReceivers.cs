using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Outputs;
using IRepository.Read;

namespace Command.Receivers.Read
{
    public class yUserModuleReadReceiver : ReciverBase<DataPagination<yUserModuleDTO>>
    {
        private readonly IyUserModuleReadRepository _repository;
        private readonly ILogger _logger;

        public yUserModuleReadReceiver(IyUserModuleReadRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<DataPagination<yUserModuleDTO>> Action(ICommand comand)
        {
            if(comand is Command.Read.yUserModuleReadCommand c) 
             {    
                var yUserModuleReadRepository = _repository.getyUserModule(c);
                return Success("OK", yUserModuleReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration