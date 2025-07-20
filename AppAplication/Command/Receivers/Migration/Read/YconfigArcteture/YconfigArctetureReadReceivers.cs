using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Outputs;
using IRepository.Read;

namespace Command.Receivers.Read
{
    public class YconfigArctetureReadReceiver : ReciverBase<DataPagination<YconfigArctetureDTO>>
    {
        private readonly IYconfigArctetureReadRepository _repository;
        private readonly ILogger _logger;

        public YconfigArctetureReadReceiver(IYconfigArctetureReadRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<DataPagination<YconfigArctetureDTO>> Action(ICommand comand)
        {
            if(comand is Command.Read.YconfigArctetureReadCommand c) 
             {    
                var YconfigArctetureReadRepository = _repository.getYconfigArcteture(c);
                return Success("OK", YconfigArctetureReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration