using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Outputs;
using IRepository.Read;

namespace Command.Receivers.Read
{
    public class yUserGrantReadReceiver : ReciverBase<ICommand, DataPagination<yUserGrantDTO>>
    {
        private readonly IyUserGrantReadRepository _repository;
        private readonly ILogger _logger;

        public yUserGrantReadReceiver(IyUserGrantReadRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<DataPagination<yUserGrantDTO>> Action(ICommand comand)
        {
            if(comand is Command.Read.yUserGrantReadCommand c) 
             {    
                var yUserGrantReadRepository = _repository.getyUserGrant(c);
                return Success("OK", yUserGrantReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration