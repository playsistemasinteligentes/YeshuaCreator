using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Outputs;
using Read.RepositoryInterfaces;

namespace Command.Receivers.Read
{
    public class YpermtionsReadReceiver : ReciverBase<DataPagination<YpermtionsDTO>>
    {
        private readonly IYpermtionsReadRepository _repository;
        private readonly ILogger _logger;

        public YpermtionsReadReceiver(IYpermtionsReadRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<DataPagination<YpermtionsDTO>> Action(ICommand comand)
        {
            if(comand is Command.Commands.Read.YpermtionsReadCommand c) 
             {    
                var YpermtionsReadRepository = _repository.getYpermtions(c);
                return Success("OK", YpermtionsReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration