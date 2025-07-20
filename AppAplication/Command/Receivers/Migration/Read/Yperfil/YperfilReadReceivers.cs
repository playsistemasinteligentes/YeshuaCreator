using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Outputs;
using IRepository.Read;

namespace Command.Receivers.Read
{
    public class YperfilReadReceiver : ReciverBase<DataPagination<YperfilDTO>>
    {
        private readonly IYperfilReadRepository _repository;
        private readonly ILogger _logger;

        public YperfilReadReceiver(IYperfilReadRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<DataPagination<YperfilDTO>> Action(ICommand comand)
        {
            if(comand is Command.Read.YperfilReadCommand c) 
             {    
                var YperfilReadRepository = _repository.getYperfil(c);
                return Success("OK", YperfilReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration