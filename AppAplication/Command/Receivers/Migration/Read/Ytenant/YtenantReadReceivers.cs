using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Outputs;
using IRepository.Read;

namespace Command.Receivers.Read
{
    public class YtenantReadReceiver : ReciverBase<DataPagination<YtenantDTO>>
    {
        private readonly IYtenantReadRepository _repository;
        private readonly ILogger _logger;

        public YtenantReadReceiver(IYtenantReadRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<DataPagination<YtenantDTO>> Action(ICommand comand)
        {
            if(comand is Command.Read.YtenantReadCommand c) 
             {    
                var YtenantReadRepository = _repository.getYtenant(c);
                return Success("OK", YtenantReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration