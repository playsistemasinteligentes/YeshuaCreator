using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Outputs;
using IRepository.Read;

namespace Command.Receivers.Read
{
    public class SesoesReadQueryD30Receiver : ReciverBase<ICommand, DataPagination<SesoesStandardDTO>>
    {
        private readonly ISesoesReadRepository _repository;
        private readonly ILogger _logger;

        public SesoesReadQueryD30Receiver(
            ISesoesReadRepository repository,
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<DataPagination<SesoesStandardDTO>> Action(ICommand comand)
        {
            if(comand is Command.Read.SesoesD30Command c) 
             {    
                var SesoesReadRepository = _repository.GetSesoesD30(c);
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