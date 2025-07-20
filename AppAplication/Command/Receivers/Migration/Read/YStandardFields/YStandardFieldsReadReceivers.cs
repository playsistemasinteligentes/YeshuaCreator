using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Outputs;
using IRepository.Read;

namespace Command.Receivers.Read
{
    public class YStandardFieldsReadReceiver : ReciverBase<DataPagination<YStandardFieldsDTO>>
    {
        private readonly IYStandardFieldsReadRepository _repository;
        private readonly ILogger _logger;

        public YStandardFieldsReadReceiver(IYStandardFieldsReadRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<DataPagination<YStandardFieldsDTO>> Action(ICommand comand)
        {
            if(comand is Command.Read.YStandardFieldsReadCommand c) 
             {    
                var YStandardFieldsReadRepository = _repository.getYStandardFields(c);
                return Success("OK", YStandardFieldsReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration