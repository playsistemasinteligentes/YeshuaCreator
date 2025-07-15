using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Outputs;
using Read.RepositoryInterfaces;

namespace Command.Receivers.Read
{
    public class Ytenant_ConfigurationReadReceiver : ReciverBase<DataPagination<Ytenant_ConfigurationDTO>>
    {
        private readonly IYtenant_ConfigurationReadRepository _repository;
        private readonly ILogger _logger;

        public Ytenant_ConfigurationReadReceiver(IYtenant_ConfigurationReadRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<DataPagination<Ytenant_ConfigurationDTO>> Action(ICommand comand)
        {
            if(comand is Command.Commands.Read.Ytenant_ConfigurationReadCommand c) 
             {    
                var Ytenant_ConfigurationReadRepository = _repository.getYtenant_Configuration(c);
                return Success("OK", Ytenant_ConfigurationReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration