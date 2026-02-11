using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Outputs;
using IRepository.Read;

namespace Command.Receivers.Read
{
    public class yUserReadReceiver : ReciverBase<ICommand, DataPagination<yUserDTO>>
    {
        private readonly IyUserReadRepository _repository;
        private readonly ILogger _logger;

        public yUserReadReceiver(IyUserReadRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<DataPagination<yUserDTO>> Action(ICommand comand)
        {
            if(comand is Command.Read.yUserReadCommand c) 
             {    
                var yUserReadRepository = _repository.getyUser(c);
                return Success("OK", yUserReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration