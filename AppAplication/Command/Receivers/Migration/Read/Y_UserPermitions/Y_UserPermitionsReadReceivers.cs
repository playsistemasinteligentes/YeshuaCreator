using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Outputs;
using Read.RepositoryInterfaces;

namespace Command.Receivers.Read
{
    public class Y_UserPermitionsReadReceiver : ReciverBase<DataPagination<Y_UserPermitionsDTO>>
    {
        private readonly IY_UserPermitionsReadRepository _repository;
        private readonly ILogger _logger;

        public Y_UserPermitionsReadReceiver(IY_UserPermitionsReadRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<DataPagination<Y_UserPermitionsDTO>> Action(ICommand comand)
        {
            if(comand is Command.Commands.Read.Y_UserPermitionsReadCommand c) 
             {    
                var Y_UserPermitionsReadRepository = _repository.getY_UserPermitions(c);
                return Success("OK", Y_UserPermitionsReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration