using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Outputs;
using IRepository.Read;

namespace Command.Receivers.Read
{
    public class SesoesReadQueryGeralReceiver : ReciverBase<ICommand, DataPagination<SesoesStandardDTO>>
    {
        private readonly ISesoesReadRepository _repository;
        private readonly ILogger _logger;

        public SesoesReadQueryGeralReceiver(ISesoesReadRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<DataPagination<SesoesStandardDTO>> Action(ICommand comand)
        {
            if(comand is Command.Read.SesoesGeralCommand c) 
             {    
                var SesoesReadRepository = _repository.GetSesoesGeral(c);
                return Success("OK", SesoesReadRepository);
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration