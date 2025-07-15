using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Outputs;
using Read.RepositoryInterfaces;

namespace Command.Receivers.Read
{
    public class Y_PermtionsReadReceiver : ReciverBase<DataPagination<Y_PermtionsDTO>>
    {
        private readonly IY_PermtionsReadRepository _repository;
        private readonly ILogger _logger;

        public Y_PermtionsReadReceiver(IY_PermtionsReadRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<DataPagination<Y_PermtionsDTO>> Action(ICommand comand)
        {
            if(comand is Command.Commands.Read.Y_PermtionsReadCommand c) 
             {    
                var Y_PermtionsReadRepository = _repository.getY_Permtions(c);
                return Success("OK", Y_PermtionsReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration