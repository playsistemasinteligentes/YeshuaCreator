using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Outputs;
using IRepository.Read;

namespace Command.Receivers.Read
{
    public class yGrantReadReceiver : ReciverBase<DataPagination<yGrantDTO>>
    {
        private readonly IyGrantReadRepository _repository;
        private readonly ILogger _logger;

        public yGrantReadReceiver(IyGrantReadRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<DataPagination<yGrantDTO>> Action(ICommand comand)
        {
            if(comand is Command.Read.yGrantReadCommand c) 
             {    
                var yGrantReadRepository = _repository.getyGrant(c);
                return Success("OK", yGrantReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration